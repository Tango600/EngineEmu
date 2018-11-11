namespace EngineEmu
{
    partial class Engine
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Engine));
            this.btStart = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.lbTicks = new System.Windows.Forms.Label();
            this.speSpeed = new System.Windows.Forms.NumericUpDown();
            this.tmLoop = new System.Windows.Forms.Timer(this.components);
            this.speTicksByRotation = new System.Windows.Forms.NumericUpDown();
            this.speRPM = new System.Windows.Forms.NumericUpDown();
            this.pnLed = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnMonitor = new System.Windows.Forms.Panel();
            this.lbWarring = new System.Windows.Forms.Label();
            this.monAngle = new System.Windows.Forms.Label();
            this.monRPM = new System.Windows.Forms.Label();
            this.chMonitor = new System.Windows.Forms.CheckBox();
            this.dgIgnitionMoments = new System.Windows.Forms.DataGridView();
            this.colRPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuGetTimings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.plusToolStripItemPlusMunis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItemConvert360 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuCalcOptimal = new System.Windows.Forms.ToolStripMenuItem();
            this.btApply = new System.Windows.Forms.Button();
            this.openFileSettings = new System.Windows.Forms.OpenFileDialog();
            this.saveFileSettings = new System.Windows.Forms.SaveFileDialog();
            this.saveFileTimings = new System.Windows.Forms.SaveFileDialog();
            this.chRoundNotation = new System.Windows.Forms.CheckBox();
            this.tmLed = new System.Windows.Forms.Timer(this.components);
            this.btPause = new System.Windows.Forms.Button();
            this.btTickStep = new System.Windows.Forms.Button();
            this.btRedraw = new System.Windows.Forms.Button();
            this.speFlashDuration = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btOverfollow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.speSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTicksByRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRPM)).BeginInit();
            this.pnMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIgnitionMoments)).BeginInit();
            this.contextMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speFlashDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Image = ((System.Drawing.Image)(resources.GetObject("btStart.Image")));
            this.btStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btStart.Location = new System.Drawing.Point(10, 161);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(85, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start / Stop";
            this.btStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btTest
            // 
            this.btTest.Image = ((System.Drawing.Image)(resources.GetObject("btTest.Image")));
            this.btTest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTest.Location = new System.Drawing.Point(10, 190);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(60, 23);
            this.btTest.TabIndex = 2;
            this.btTest.Text = "Test";
            this.btTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // lbTicks
            // 
            this.lbTicks.AutoSize = true;
            this.lbTicks.Location = new System.Drawing.Point(111, 30);
            this.lbTicks.Name = "lbTicks";
            this.lbTicks.Size = new System.Drawing.Size(25, 13);
            this.lbTicks.TabIndex = 3;
            this.lbTicks.Text = "000";
            // 
            // speSpeed
            // 
            this.speSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speSpeed.Location = new System.Drawing.Point(10, 28);
            this.speSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speSpeed.Name = "speSpeed";
            this.speSpeed.Size = new System.Drawing.Size(60, 20);
            this.speSpeed.TabIndex = 6;
            this.speSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.speSpeed.ValueChanged += new System.EventHandler(this.speSpeed_ValueChanged);
            // 
            // tmLoop
            // 
            this.tmLoop.Tick += new System.EventHandler(this.tmLoop_Tick);
            // 
            // speTicksByRotation
            // 
            this.speTicksByRotation.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speTicksByRotation.Location = new System.Drawing.Point(10, 80);
            this.speTicksByRotation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speTicksByRotation.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speTicksByRotation.Name = "speTicksByRotation";
            this.speTicksByRotation.Size = new System.Drawing.Size(60, 20);
            this.speTicksByRotation.TabIndex = 7;
            this.speTicksByRotation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.speTicksByRotation.ValueChanged += new System.EventHandler(this.speTicksByRotation_ValueChanged);
            // 
            // speRPM
            // 
            this.speRPM.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.speRPM.Location = new System.Drawing.Point(108, 80);
            this.speRPM.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.speRPM.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.speRPM.Name = "speRPM";
            this.speRPM.Size = new System.Drawing.Size(57, 20);
            this.speRPM.TabIndex = 8;
            this.speRPM.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // pnLed
            // 
            this.pnLed.BackColor = System.Drawing.Color.Black;
            this.pnLed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnLed.Location = new System.Drawing.Point(206, 80);
            this.pnLed.Name = "pnLed";
            this.pnLed.Size = new System.Drawing.Size(25, 23);
            this.pnLed.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ticks per round";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "RPM";
            // 
            // pnMonitor
            // 
            this.pnMonitor.BackColor = System.Drawing.Color.Silver;
            this.pnMonitor.Controls.Add(this.lbWarring);
            this.pnMonitor.Controls.Add(this.monAngle);
            this.pnMonitor.Controls.Add(this.monRPM);
            this.pnMonitor.Location = new System.Drawing.Point(253, 12);
            this.pnMonitor.Name = "pnMonitor";
            this.pnMonitor.Size = new System.Drawing.Size(231, 199);
            this.pnMonitor.TabIndex = 15;
            // 
            // lbWarring
            // 
            this.lbWarring.AutoSize = true;
            this.lbWarring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWarring.ForeColor = System.Drawing.Color.White;
            this.lbWarring.Location = new System.Drawing.Point(10, 171);
            this.lbWarring.Name = "lbWarring";
            this.lbWarring.Size = new System.Drawing.Size(12, 17);
            this.lbWarring.TabIndex = 3;
            this.lbWarring.Text = "!";
            this.lbWarring.Visible = false;
            // 
            // monAngle
            // 
            this.monAngle.AutoSize = true;
            this.monAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monAngle.ForeColor = System.Drawing.Color.White;
            this.monAngle.Location = new System.Drawing.Point(157, 5);
            this.monAngle.Name = "monAngle";
            this.monAngle.Size = new System.Drawing.Size(54, 17);
            this.monAngle.TabIndex = 2;
            this.monAngle.Text = "0 deg.";
            // 
            // monRPM
            // 
            this.monRPM.AutoSize = true;
            this.monRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monRPM.ForeColor = System.Drawing.Color.White;
            this.monRPM.Location = new System.Drawing.Point(10, 5);
            this.monRPM.Name = "monRPM";
            this.monRPM.Size = new System.Drawing.Size(49, 17);
            this.monRPM.TabIndex = 0;
            this.monRPM.Text = "0 rpm";
            // 
            // chMonitor
            // 
            this.chMonitor.AutoSize = true;
            this.chMonitor.Checked = true;
            this.chMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chMonitor.Location = new System.Drawing.Point(253, 217);
            this.chMonitor.Name = "chMonitor";
            this.chMonitor.Size = new System.Drawing.Size(61, 17);
            this.chMonitor.TabIndex = 16;
            this.chMonitor.Text = "Monitor";
            this.chMonitor.UseVisualStyleBackColor = true;
            // 
            // dgIgnitionMoments
            // 
            this.dgIgnitionMoments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIgnitionMoments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRPM,
            this.colDegree});
            this.dgIgnitionMoments.ContextMenuStrip = this.contextMenuGrid;
            this.dgIgnitionMoments.Location = new System.Drawing.Point(506, 12);
            this.dgIgnitionMoments.Name = "dgIgnitionMoments";
            this.dgIgnitionMoments.Size = new System.Drawing.Size(210, 199);
            this.dgIgnitionMoments.TabIndex = 17;
            this.dgIgnitionMoments.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgIgnitionMoments_CellEndEdit);
            this.dgIgnitionMoments.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgIgnitionMoments_RowPrePaint);
            // 
            // colRPM
            // 
            this.colRPM.Frozen = true;
            this.colRPM.HeaderText = "RPM";
            this.colRPM.Name = "colRPM";
            this.colRPM.Width = 60;
            // 
            // colDegree
            // 
            this.colDegree.Frozen = true;
            this.colDegree.HeaderText = "Degree";
            this.colDegree.Name = "colDegree";
            this.colDegree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDegree.Width = 70;
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuRemove,
            this.toolStripMenuInsert,
            this.toolStripSeparator1,
            this.toolStripMenuSave,
            this.toolStripMenuLoad,
            this.toolStripSeparator2,
            this.toolStripMenuGetTimings,
            this.toolStripMenuConvert,
            this.toolStripSeparator3,
            this.toolStripMenuCalcOptimal});
            this.contextMenuGrid.Name = "contextMenuGrid";
            this.contextMenuGrid.Size = new System.Drawing.Size(200, 176);
            // 
            // toolStripMenuRemove
            // 
            this.toolStripMenuRemove.Name = "toolStripMenuRemove";
            this.toolStripMenuRemove.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuRemove.Text = "Remove";
            this.toolStripMenuRemove.Click += new System.EventHandler(this.toolStripMenuRemove_Click);
            // 
            // toolStripMenuInsert
            // 
            this.toolStripMenuInsert.Name = "toolStripMenuInsert";
            this.toolStripMenuInsert.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuInsert.Text = "Insert";
            this.toolStripMenuInsert.Click += new System.EventHandler(this.toolStripMenuInsert_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuSave.Text = "Save...";
            this.toolStripMenuSave.Click += new System.EventHandler(this.toolStripMenuSave_Click);
            // 
            // toolStripMenuLoad
            // 
            this.toolStripMenuLoad.Name = "toolStripMenuLoad";
            this.toolStripMenuLoad.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuLoad.Text = "Load...";
            this.toolStripMenuLoad.Click += new System.EventHandler(this.toolStripMenuLoad_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuGetTimings
            // 
            this.toolStripMenuGetTimings.Name = "toolStripMenuGetTimings";
            this.toolStripMenuGetTimings.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuGetTimings.Text = "Get timings";
            this.toolStripMenuGetTimings.Click += new System.EventHandler(this.toolStripMenuGetTimings_Click);
            // 
            // toolStripMenuConvert
            // 
            this.toolStripMenuConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plusToolStripItemPlusMunis,
            this.toolStripItemConvert360});
            this.toolStripMenuConvert.Name = "toolStripMenuConvert";
            this.toolStripMenuConvert.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuConvert.Text = "Convert round notation";
            // 
            // plusToolStripItemPlusMunis
            // 
            this.plusToolStripItemPlusMunis.Name = "plusToolStripItemPlusMunis";
            this.plusToolStripItemPlusMunis.Size = new System.Drawing.Size(152, 22);
            this.plusToolStripItemPlusMunis.Text = "+/-";
            this.plusToolStripItemPlusMunis.Click += new System.EventHandler(this.plusToolStripMenuItem_Click);
            // 
            // toolStripItemConvert360
            // 
            this.toolStripItemConvert360.Name = "toolStripItemConvert360";
            this.toolStripItemConvert360.Size = new System.Drawing.Size(152, 22);
            this.toolStripItemConvert360.Text = "360";
            this.toolStripItemConvert360.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuCalcOptimal
            // 
            this.toolStripMenuCalcOptimal.Name = "toolStripMenuCalcOptimal";
            this.toolStripMenuCalcOptimal.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuCalcOptimal.Text = "Calc optimal degree";
            this.toolStripMenuCalcOptimal.Click += new System.EventHandler(this.toolStripMenuCalcOptimal_Click);
            // 
            // btApply
            // 
            this.btApply.Image = ((System.Drawing.Image)(resources.GetObject("btApply.Image")));
            this.btApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btApply.Location = new System.Drawing.Point(506, 217);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(59, 23);
            this.btApply.TabIndex = 18;
            this.btApply.Text = "Apply";
            this.btApply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApplay_Click);
            // 
            // openFileSettings
            // 
            this.openFileSettings.DefaultExt = "ees";
            this.openFileSettings.Filter = "Engine Emu Setting|*.ees";
            // 
            // saveFileSettings
            // 
            this.saveFileSettings.DefaultExt = "ees";
            this.saveFileSettings.Filter = "Engine Emu Setting|*.ees";
            // 
            // saveFileTimings
            // 
            this.saveFileTimings.DefaultExt = "inc";
            this.saveFileTimings.Filter = "Scetch include|*.inc";
            // 
            // chRoundNotation
            // 
            this.chRoundNotation.AutoSize = true;
            this.chRoundNotation.Location = new System.Drawing.Point(581, 223);
            this.chRoundNotation.Name = "chRoundNotation";
            this.chRoundNotation.Size = new System.Drawing.Size(126, 17);
            this.chRoundNotation.TabIndex = 19;
            this.chRoundNotation.Text = "Round notation - 360";
            this.chRoundNotation.UseVisualStyleBackColor = true;
            // 
            // tmLed
            // 
            this.tmLed.Tick += new System.EventHandler(this.tmLed_Tick);
            // 
            // btPause
            // 
            this.btPause.Image = ((System.Drawing.Image)(resources.GetObject("btPause.Image")));
            this.btPause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPause.Location = new System.Drawing.Point(101, 161);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(60, 23);
            this.btPause.TabIndex = 20;
            this.btPause.Text = "Pause";
            this.btPause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btTickStep
            // 
            this.btTickStep.Image = ((System.Drawing.Image)(resources.GetObject("btTickStep.Image")));
            this.btTickStep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTickStep.Location = new System.Drawing.Point(167, 161);
            this.btTickStep.Name = "btTickStep";
            this.btTickStep.Size = new System.Drawing.Size(54, 23);
            this.btTickStep.TabIndex = 21;
            this.btTickStep.Text = "Step";
            this.btTickStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTickStep.UseVisualStyleBackColor = true;
            this.btTickStep.Click += new System.EventHandler(this.btTickStep_Click);
            // 
            // btRedraw
            // 
            this.btRedraw.Image = ((System.Drawing.Image)(resources.GetObject("btRedraw.Image")));
            this.btRedraw.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRedraw.Location = new System.Drawing.Point(409, 217);
            this.btRedraw.Name = "btRedraw";
            this.btRedraw.Size = new System.Drawing.Size(75, 23);
            this.btRedraw.TabIndex = 22;
            this.btRedraw.Text = "Redraw";
            this.btRedraw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRedraw.UseVisualStyleBackColor = true;
            this.btRedraw.Click += new System.EventHandler(this.btRedraw_Click);
            // 
            // speFlashDuration
            // 
            this.speFlashDuration.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.speFlashDuration.Location = new System.Drawing.Point(10, 125);
            this.speFlashDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speFlashDuration.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.speFlashDuration.Name = "speFlashDuration";
            this.speFlashDuration.Size = new System.Drawing.Size(60, 20);
            this.speFlashDuration.TabIndex = 23;
            this.speFlashDuration.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Flash duration (mcs.)";
            // 
            // btOverfollow
            // 
            this.btOverfollow.Location = new System.Drawing.Point(76, 190);
            this.btOverfollow.Name = "btOverfollow";
            this.btOverfollow.Size = new System.Drawing.Size(75, 23);
            this.btOverfollow.TabIndex = 25;
            this.btOverfollow.Text = "Overfollow";
            this.btOverfollow.UseVisualStyleBackColor = true;
            this.btOverfollow.Click += new System.EventHandler(this.btOverfollow_Click);
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 246);
            this.Controls.Add(this.btOverfollow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.speFlashDuration);
            this.Controls.Add(this.btRedraw);
            this.Controls.Add(this.btTickStep);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.chRoundNotation);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.dgIgnitionMoments);
            this.Controls.Add(this.chMonitor);
            this.Controls.Add(this.pnMonitor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnLed);
            this.Controls.Add(this.speRPM);
            this.Controls.Add(this.speTicksByRotation);
            this.Controls.Add(this.speSpeed);
            this.Controls.Add(this.lbTicks);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Engine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engine Emu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Engine_FormClosing);
            this.Load += new System.EventHandler(this.Engine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTicksByRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRPM)).EndInit();
            this.pnMonitor.ResumeLayout(false);
            this.pnMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIgnitionMoments)).EndInit();
            this.contextMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speFlashDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Label lbTicks;
        private System.Windows.Forms.NumericUpDown speSpeed;
        private System.Windows.Forms.Timer tmLoop;
        private System.Windows.Forms.NumericUpDown speTicksByRotation;
        private System.Windows.Forms.NumericUpDown speRPM;
        private System.Windows.Forms.Panel pnLed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnMonitor;
        private System.Windows.Forms.CheckBox chMonitor;
        private System.Windows.Forms.Label monRPM;
        private System.Windows.Forms.Label monAngle;
        private System.Windows.Forms.DataGridView dgIgnitionMoments;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuLoad;
        private System.Windows.Forms.OpenFileDialog openFileSettings;
        private System.Windows.Forms.SaveFileDialog saveFileSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGetTimings;
        private System.Windows.Forms.SaveFileDialog saveFileTimings;
        private System.Windows.Forms.CheckBox chRoundNotation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuConvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripItemConvert360;
        private System.Windows.Forms.ToolStripMenuItem plusToolStripItemPlusMunis;
        private System.Windows.Forms.Label lbWarring;
        private System.Windows.Forms.Timer tmLed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDegree;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btTickStep;
        private System.Windows.Forms.Button btRedraw;
        private System.Windows.Forms.NumericUpDown speFlashDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCalcOptimal;
        private System.Windows.Forms.Button btOverfollow;
    }
}

