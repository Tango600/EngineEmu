using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Drawing;

namespace EngineEmu
{
    public partial class Engine : Form
    {
        private bool changed;
        private string lastTableName = "";

        private ulong ticks = 0;
        private int ticksByRottation = 100;
        private int lastIgnitionDegree = -1;
        private int tack = 0;
        private Graphics graphics;
        private bool monitorInit = false;
        private int ledTicks = 0;
        private bool paused = false;
        private bool roundNotation360 = false;

        private int[] tableRPMPoints;
        private int[] tableIgnDelays;

        public Engine()
        {
            InitializeComponent();
        }

        private void initParametrs(bool RoundNatation)
        {
            var rpmPoints = new List<int>();
            var ignDelays = new List<int>();
            for (int i = 0; i < dgIgnitionMoments.RowCount; i++)
            {
                if (dgIgnitionMoments[0, i]?.Value != null && dgIgnitionMoments[0, i].Value.ToString() != "" && dgIgnitionMoments[1, i].Value.ToString() != "")
                {
                    decimal rpm = Convert.ToDecimal(dgIgnitionMoments[0, i].Value);
                    decimal rt = (1000000M / (rpm / 60M));

                    rpmPoints.Add((int)rt);

                    int deg = Convert.ToInt32(dgIgnitionMoments[1, i].Value);
                    if (!RoundNatation)
                    {
                        if (deg > 0M)
                        {
                            deg = 360 - deg;
                        }
                        else
                        {
                            deg = deg * -1;
                        }
                    }
                    ignDelays.Add(deg);
                }
            }

            tableRPMPoints = rpmPoints.ToArray();
            tableIgnDelays = ignDelays.ToArray();
        }

        private void LoadParametrsFromFile(string FileName)
        {
            var lines = File.ReadAllLines(FileName);
            dgIgnitionMoments.RowCount = lines.Count(l => !l.Contains("#")) + 1;
            roundNotation360 = lines.Any(l => l.Contains("#RN/360"));
            chRoundNotation360.Checked = roundNotation360;

            int ln = 0;
            for (int i = 0; i < lines.Count(l => !l.Contains("#")); i++)
            {
                var element = lines[i].Split(';');
                if (element.Length > 1)
                {
                    dgIgnitionMoments[0, ln].Value = element[0];
                    dgIgnitionMoments[1, ln].Value = element[1];
                    ln++;
                }
            }

            initParametrs(chRoundNotation360.Checked);
            changed = false;
        }

        private void SaveParametrsToFile(string FileName)
        {
            var list = new List<string>();
            list.Add(chRoundNotation360.Checked ? "#RN/360" : "#RN/plus-minus");
            for (int i = 0; i < dgIgnitionMoments.RowCount; i++)
            {
                if (dgIgnitionMoments[0, i].Value != null && dgIgnitionMoments[1, i].Value != null)
                {
                    string s = Convert.ToString(dgIgnitionMoments[0, i].Value) + ";" + Convert.ToString(dgIgnitionMoments[1, i].Value);
                    if (s.Length > 3)
                        list.Add(s);
                }
            }

            File.WriteAllLines(FileName, list.ToArray());
            changed = false;
        }

        private void InitMonitor()
        {
            speTicksByRotation.Value = ticksByRottation;

            initParametrs(chRoundNotation360.Checked);

            if (!monitorInit)
            {
                monitorInit = true;
                DrawingObjects.BackgroundColor = pnMonitor.BackColor;
                DrawingObjects.figureX = pnMonitor.Width / 2 - DrawingObjects.circleRadius;
                DrawingObjects.figureY = pnMonitor.Height / 2 - DrawingObjects.circleRadius;

                graphics = pnMonitor.CreateGraphics();
                DrawingObjects.DrawBase(graphics);
                DrawingObjects.DrawSensor(graphics);
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            ticks = 0;
            tmLoop.Enabled = !tmLoop.Enabled;
            tmLed.Enabled = !tmLed.Enabled;
        }

        private int CalcDegreeMonitor(int degree)
        {
            int deg = 0;
            if (degree > 120)
            {
                deg = 360 - degree;
            }
            else
            {
                deg = -degree;
            }
            return deg;
        }

        private void ClockTickTak()
        {
            if (speRPM.Value > 0)
            {
                if (chMonitor.Checked)
                {
                    InitMonitor();

                    DrawingObjects.DrawSensor(graphics);
                    DrawingObjects.DrawRotation(graphics, (int)(((decimal)tack / ticksByRottation) * 360M));
                }
                if (tack >= ticksByRottation)
                {
                    OnSensor();
                    tack = 0;
                }
                decimal kvant = (1000000M / (speRPM.Value / 60M)) / ticksByRottation;
                ticks += (ulong)kvant;

                if (tableRPMPoints.Length > 0 && tableIgnDelays.Length > 0)
                    loop();

                lbTicks.Text = ticks.ToString("0,0");
                tack++;
            }
        }

        long cycle = 1;

        private void tmLoop_Tick(object sender, EventArgs e)
        {
            ClockTickTak();

            if (cycle % (ticksByRottation * 4) == 0)
            {
                Redraw();
            }
            cycle++;
        }

        byte flashDurationAngle = 10;

        byte sensor = 0;
        ulong ignitionDelay = 0;
        ulong lastTime = 0;
        ulong deltaTime = 100000;
        ulong stopTime = 0;
        ulong lastStopTime = 0;
        ulong startTime = 0;

        private void loop()
        {
            if (sensor == 1)
            {
                if (deltaTime > 0 && deltaTime < 200000)
                {
                    sensor = 0;
                    byte i = 0;
                    while (i < tableRPMPoints.Length && (ulong)tableRPMPoints[i] > deltaTime)
                    {
                        i++;
                    }
                    if (i >= tableRPMPoints.Length)
                        i = Convert.ToByte(tableRPMPoints.Length - 1);

                    for (int j = 0; j < dgIgnitionMoments.Rows.Count; j++)
                    {
                        dgIgnitionMoments.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    }
                    dgIgnitionMoments.Rows[i].DefaultCellStyle.BackColor = Color.DodgerBlue;

                    if (tableIgnDelays[i] == 0)
                        tableIgnDelays[i] = 1;

                    if (chOptimalCalc1024.Checked)
                    {
                        ignitionDelay = (deltaTime * (((ulong)tableIgnDelays[i] * 1024) / 360)) / 1024;
                    }
                    else
                    {
                        ignitionDelay = (deltaTime * (((ulong)tableIgnDelays[i] * 1000) / 360)) / 1000;
                    }

                    lastIgnitionDegree = Convert.ToInt32(360M / ((decimal)deltaTime / ignitionDelay));

                    startTime = lastTime + ignitionDelay;
                    lastStopTime = stopTime;
                    stopTime = startTime + (ulong)speFlashDuration.Value;
                }
            }

            if ((startTime < micros() && stopTime > micros()) || lastStopTime > micros())
            {
                pnLed.BackColor = Color.Red;

                monAngle.Text = CalcDegreeMonitor(lastIgnitionDegree).ToString() + " deg.";
                if (chMonitor.Checked)
                {
                    DrawingObjects.DrawIgnitionMoment(graphics, lastIgnitionDegree, deltaTime, (int)speFlashDuration.Value, FigureType.Figure);
                    int igntSector = DrawingObjects.DrawIgnitFlashSector(graphics, lastIgnitionDegree, deltaTime, flashDurationAngle, FigureType.Figure);
                    if (lastIgnitionDegree + igntSector < 360 && lastIgnitionDegree + igntSector > 180)
                    {
                        lbWarring.Visible = true;
                        lbWarring.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (lastIgnitionDegree + igntSector < 180 && lastIgnitionDegree + igntSector > 90)
                        {
                            lbWarring.Visible = true;
                            lbWarring.ForeColor = Color.Orange;
                        }
                        else
                        {
                            lbWarring.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if (chMonitor.Checked)
                {
                    if (lastIgnitionDegree != -1)
                    {
                        DrawingObjects.DrawIgnitionMoment(graphics, lastIgnitionDegree, 0, 0, FigureType.Mask);
                        DrawingObjects.DrawIgnitFlashSector(graphics, lastIgnitionDegree, 0, 0, FigureType.Mask);
                    }
                }

                pnLed.BackColor = Color.Gray;
            }
        }

        private ulong micros()
        {
            return ticks;
        }

        private void OnSensor()
        {
            if (chMonitor.Checked)
            {
                DrawingObjects.DrawOnSensor(graphics);
            }
            pnLed.BackColor = Color.BlueViolet;

            deltaTime = micros() - lastTime;
            lastTime = micros();
            sensor = 1;

            if (deltaTime > 0)
            {
                monRPM.Text = Convert.ToString(Convert.ToInt32(60000000M / deltaTime)) + " rpm";
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            OnSensor();
        }

        private void SetTimers(int Interval)
        {
            if (Interval > 0)
            {
                tmLoop.Interval = Interval;
            }
        }

        private void Engine_Load(object sender, EventArgs e)
        {
            SetTimers((int)speSpeed.Value);

            string lastSetting = Properties.Settings.Default.LastSetting;
            chRoundNotation360.Checked = Properties.Settings.Default.RoundNotation;
            chOptimalCalc1024.Checked = Properties.Settings.Default.CalcByShift;
            if (!string.IsNullOrEmpty(lastSetting) && File.Exists(lastSetting))
            {
                LoadParametrsFromFile(lastSetting);
                lastTableName = lastSetting;
            }
            tmLed.Start();
        }

        private void speSpeed_ValueChanged(object sender, EventArgs e)
        {
            SetTimers((int)speSpeed.Value);
        }

        private void speTicksByRotation_ValueChanged(object sender, EventArgs e)
        {
            if (speTicksByRotation.Value >= 1)
            {
                ticksByRottation = (int)speTicksByRotation.Value;
                SetTimers((int)speSpeed.Value);
            }
        }

        private void btApplay_Click(object sender, EventArgs e)
        {
            initParametrs(chRoundNotation360.Checked);
        }

        private void toolStripMenuSave_Click(object sender, EventArgs e)
        {
            if (saveFileSettings.ShowDialog() == DialogResult.OK)
            {
                SaveParametrsToFile(saveFileSettings.FileName);
                lastTableName = saveFileSettings.FileName;

                Properties.Settings.Default.LastSetting = saveFileSettings.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void toolStripMenuLoad_Click(object sender, EventArgs e)
        {
            if (openFileSettings.ShowDialog() == DialogResult.OK)
            {
                LoadParametrsFromFile(openFileSettings.FileName);
                lastTableName = openFileSettings.FileName;

                Properties.Settings.Default.LastSetting = openFileSettings.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void toolStripMenuInsert_Click(object sender, EventArgs e)
        {
            if (dgIgnitionMoments.CurrentRow.Index != -1)
            {
                dgIgnitionMoments.Rows.Insert(dgIgnitionMoments.CurrentRow.Index, "", "");

                changed = true;
                initParametrs(chRoundNotation360.Checked);
            }
        }

        private int ConvertRoundNotation(int degree, bool ToRN360)
        {
            int res = 0;
            if (ToRN360)
            {
                if (degree > 0)
                {
                    res = 360 - degree;
                }
                else
                {
                    res = -degree;
                }
            }
            else
            {
                res = degree;
            }
            return res;
        }

        private void toolStripMenuGetTimings_Click(object sender, EventArgs e)
        {
            if (saveFileTimings.ShowDialog() == DialogResult.OK)
            {
                var timings = new List<string>();
                timings.Add("const int FlashDuration = " + Convert.ToInt32(speFlashDuration.Value) + ";");
                timings.Add("const byte tablesLength = " + tableRPMPoints.Length + ";");
                timings.Add("// RPM:                  " + string.Join(", ", tableRPMPoints.Select(f => Convert.ToInt32(1000000M / (f / 60M)))));
                timings.Add("int tableRPMPoints[] = { " + string.Join(", ", tableRPMPoints) + " };");
                timings.Add("int tableIgnDelays[] = { " + string.Join(", ", tableIgnDelays.Select(f => ConvertRoundNotation(f, roundNotation360))) + " };");

                File.WriteAllLines(saveFileTimings.FileName, timings.ToArray());
            }
        }

        private void Engine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                if (MessageBox.Show("Content timings are changed. Do you save?", "Save...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(lastTableName) && saveFileSettings.ShowDialog() == DialogResult.OK)
                    {
                        lastTableName = saveFileSettings.FileName;
                    }
                    SaveParametrsToFile(lastTableName);
                }
            }
            Properties.Settings.Default.CalcByShift = chOptimalCalc1024.Checked;
            Properties.Settings.Default.RoundNotation = chRoundNotation360.Checked;
            Properties.Settings.Default.Save();
        }

        private void dgIgnitionMoments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changed = true;
            initParametrs(chRoundNotation360.Checked);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgIgnitionMoments.RowCount; i++)
            {
                if (dgIgnitionMoments[0, i].Value != null && dgIgnitionMoments[1, i].Value != null)
                {
                    string s = Convert.ToString(dgIgnitionMoments[0, i].Value) + ";" + Convert.ToString(dgIgnitionMoments[1, i].Value);
                    if (s.Length > 3)
                    {
                        int deg = Convert.ToInt32(dgIgnitionMoments[1, i].Value);
                        if (deg > 0)
                        {
                            dgIgnitionMoments[1, i].Value = 360 - deg;
                        }
                        else
                        {
                            dgIgnitionMoments[1, i].Value = -deg;
                        }
                        changed = true;
                    }
                }
            }
            chRoundNotation360.Checked = true;
        }

        private void plusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgIgnitionMoments.RowCount; i++)
            {
                if (dgIgnitionMoments[0, i].Value != null && dgIgnitionMoments[1, i].Value != null)
                {
                    string s = Convert.ToString(dgIgnitionMoments[0, i].Value) + ";" + Convert.ToString(dgIgnitionMoments[1, i].Value);
                    if (s.Length > 3)
                    {
                        int deg = Convert.ToInt32(dgIgnitionMoments[1, i].Value);
                        if (deg > 120)
                        {
                            dgIgnitionMoments[1, i].Value = 360 - deg;
                        }
                        else
                        {
                            dgIgnitionMoments[1, i].Value = -deg;
                        }
                        changed = true;
                    }
                }
            }
            chRoundNotation360.Checked = false;
        }

        private void tmLed_Tick(object sender, EventArgs e)
        {
            if (ledTicks % 10 == 0)
            {
                pnLed.BackColor = paused ? Color.GreenYellow : Color.OrangeRed;
            }
            else
            {
                pnLed.BackColor = Color.Black;
            }

            ledTicks++;
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            if (tmLoop.Enabled && !paused)
            {
                tmLoop.Enabled = !tmLoop.Enabled;
                tmLed.Enabled = true;
                paused = true;
            }
            else
            {
                if (paused)
                {
                    tmLoop.Enabled = !tmLoop.Enabled;
                    tmLed.Enabled = false;
                    paused = false;
                }
            }
        }

        private void btTickStep_Click(object sender, EventArgs e)
        {
            if (!tmLoop.Enabled && paused)
            {
                ClockTickTak();
            }
        }

        private void Redraw()
        {
            DrawingObjects.BackgroundColor = pnMonitor.BackColor;
            DrawingObjects.figureX = pnMonitor.Width / 2 - DrawingObjects.circleRadius;
            DrawingObjects.figureY = pnMonitor.Height / 2 - DrawingObjects.circleRadius;

            graphics = pnMonitor.CreateGraphics();
            graphics.Clear(DrawingObjects.BackgroundColor);
            DrawingObjects.DrawBase(graphics);
            DrawingObjects.DrawSensor(graphics);
        }

        private void btRedraw_Click(object sender, EventArgs e)
        {
            Redraw();
        }

        private void dgIgnitionMoments_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgIgnitionMoments.Rows[e.RowIndex];
            try
            {
                int rpm = Convert.ToInt32(row.Cells[0].Value);
                int degree = Convert.ToInt32(360M * (speFlashDuration.Value / (1000000M / (rpm / 60M))));
                if (degree > 120 && degree <= 180)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    if (degree > 180)
                    {
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    }
                }
            }
            catch
            {
                //
            }
        }

        private void toolStripMenuCalcOptimal_Click(object sender, EventArgs e)
        {
            var row = dgIgnitionMoments.CurrentRow;
            int rpm = Convert.ToInt32(row.Cells[0].Value);
            int degree = Convert.ToInt32(360M * (speFlashDuration.Value / (1000000M / (rpm / 60M))));
            row.Cells[1].Value = degree - 5;
        }

        private void btOverfollow_Click(object sender, EventArgs e)
        {
            ulong dlt = ticks + ulong.MaxValue - 10000;
            ticks = ulong.MaxValue - 10000;

            lastTime += dlt;
            deltaTime = micros() - lastTime;
            startTime = lastTime + ignitionDelay;
            stopTime = startTime + (ulong)speFlashDuration.Value;
            lastStopTime = stopTime;
        }

        private void toolStripMenuRemove_Click(object sender, EventArgs e)
        {
            var row = dgIgnitionMoments.CurrentRow;
            dgIgnitionMoments.Rows.Remove(row);

            changed = true;
            initParametrs(chRoundNotation360.Checked);
        }
    }
}
