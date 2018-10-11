using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace Drawing
{
    public enum FigureType
    {
        Figure,
        Mask
    }

    public static class DrawingObjects
    {
        public static int figureX = 20;
        public static int figureY = 20;
        public static Color BackgroundColor = Color.Gray;

        private static Color baseColor = Color.Black;
        private const int penNum = 3;
        public const int circleRadius = 75;

        private static int ConvertDegree(int degree)
        {
            return degree + (270 - 360);
        }

        public static void DrawRotation(Graphics g, int degree)
        {
            var pen = new SolidBrush(Color.AntiqueWhite);
            g.FillPie(pen, figureX + (circleRadius / 2), figureY + (circleRadius / 2), circleRadius, circleRadius, ConvertDegree(0), degree);

            var blackPen = new SolidBrush(Color.Black);
            g.FillPie(blackPen, figureX + (circleRadius / 2), figureY + (circleRadius / 2), circleRadius, circleRadius, ConvertDegree(degree), 360 - degree);
        }

        public static void DrawBase(Graphics g)
        {
            Pen blackPen = new Pen(baseColor, penNum);
            g.DrawEllipse(blackPen, figureX, figureY, circleRadius * 2, circleRadius * 2);
        }

        public static int DrawIgnitFlashSector(Graphics g, int startAngle, ulong deltaTime, int flasDuration, FigureType figureType)
        {
            int sweepAngle = 0;
            int r = circleRadius * 2;

            var pen = new Pen(figureType == FigureType.Figure ? Color.Orange : BackgroundColor, penNum);
            if (figureType == FigureType.Figure)
            {
                sweepAngle = Convert.ToInt32(360M / ((decimal)deltaTime / flasDuration));
                g.DrawArc(pen, figureX + 25, figureY + 25, r - 50, r - 50, ConvertDegree(Math.Abs(startAngle)), sweepAngle);
            }
            else
            {
                g.DrawArc(pen, figureX + 25, figureY + 25, r - 50, r - 50, ConvertDegree(0), 360);
            }
            return sweepAngle;
        }

        public static void DrawSensor(Graphics g)
        {
            DrawStroke(g, 0, Color.Green, penNum + 1, 14, 8, FigureType.Figure);
        }

        public static void DrawOnSensor(Graphics g)
        {
            DrawStroke(g, 0, Color.Violet, penNum + 1, 14, 8, FigureType.Figure);
        }

        private static double DegToRad(int Degree)
        {
            return Degree * Math.PI / 180;
        }

        private static void DrawStroke(Graphics g, int degree, Color color, int penWidth, int longStroke, int offset, FigureType figureType)
        {
            Pen pen = new Pen(figureType == FigureType.Figure ? color : BackgroundColor, penWidth);
            int d = ConvertDegree(degree);
            double rad = DegToRad(d);

            var cos = Math.Cos(rad);
            var sin = Math.Sin(rad);
            var x = (figureX + circleRadius + (circleRadius - (longStroke / 2)) * cos);
            var y = (figureY + circleRadius + (circleRadius - (longStroke / 2)) * sin) - offset;
            var x2 = (figureX + circleRadius + (circleRadius + (longStroke / 2)) * cos);
            var y2 = (figureY + circleRadius + (circleRadius + (longStroke / 2)) * sin) - offset;

            g.DrawLine(pen, (float)x, (float)y, (float)x2, (float)y2);

            if (figureType == FigureType.Mask)
            {
                x = figureX + circleRadius + (circleRadius - 1) * cos;
                y = figureY + circleRadius + (circleRadius - 1) * sin;
                x2 = figureX + circleRadius + (circleRadius + 1) * cos;
                y2 = figureY + circleRadius + (circleRadius + 1) * sin;

                pen = new Pen(baseColor, penWidth);
                g.DrawLine(pen, (float)x, (float)y, (float)x2, (float)y2);
            }
        }

        public static void DrawIgnitionMoment(Graphics g, int degree, ulong deltaTime, int ignitionGap, FigureType figureType)
        {
            DrawStroke(g, Math.Abs(degree), Color.BlueViolet, 6, 15, 0, figureType);

            int r = circleRadius * 2;
            var pen = new Pen(figureType == FigureType.Figure ? Color.BlueViolet : BackgroundColor, figureType == FigureType.Figure ? penNum : penNum + 1);
            if (figureType == FigureType.Figure)
            {
                int sweepAngle = Convert.ToInt32(360M / ((decimal)deltaTime / ignitionGap));
                g.DrawArc(pen, figureX + 20, figureY + 20, r - 40, r - 40, ConvertDegree(Math.Abs(degree)), sweepAngle);
            }
            else
            {
                g.DrawArc(pen, figureX + 20, figureY + 20, r - 40, r - 40, ConvertDegree(0), 360);
            }
        }
    }
}
