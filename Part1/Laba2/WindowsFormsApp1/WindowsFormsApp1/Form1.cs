using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromName("Info");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 2);        // Создаем перо для рисования
            Graphics g = pictureBox1.CreateGraphics();  // Создаем объект Graphics для объекта

            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.ControlLight);  // Цвет фона
            pictureBox1.Refresh();                                                  // Обновить

            g.DrawRectangle(myPen, 1, 1, pictureBox1.Size.Width - 2, pictureBox1.Size.Height - 2);                  // Рисуем прямоугольник (рамки)
            g.DrawLine(myPen, pictureBox1.Width / 2, 0, pictureBox1.Size.Height - 1, pictureBox1.Width / 2);        // Вертикальная линия
            g.DrawLine(myPen, 0, pictureBox1.Size.Height / 2, pictureBox1.Width - 1, pictureBox1.Size.Height / 2);  // Горизонтальная линия

            int cx = pictureBox1.Size.Width;
            int cy = pictureBox1.Size.Height / 2;

            var p = new PointF[pictureBox1.Size.Width];
            for (int i = 0; i < pictureBox1.Size.Width; i++)
            {
                p[i].Y = (float)(cy * (1 - Math.Pow(i, 3) / (cx - 1)));
                p[i].X = i + pictureBox1.Size.Width / 2;
            }

            Pen myPen2 = new Pen(Color.FromArgb(210, 124, 250), 2);
            
            g.DrawLines(myPen2, p);

            g.Dispose();    //Размещаем
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;   // Очистка pictureBox1
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen myPen = new Pen(Color.FromArgb(150, 254, 160), 0.6F);

            pictureBox1.BackColor = Color.FromName("InactiveCaption");

            g.PageUnit = GraphicsUnit.Millimeter;
            
            //g.DrawRectangle(myPen, 0, 0, (238 - 1), (119 - 1));

            Point x1 = new Point((238 / 2), 0);
            Point x2 = new Point((238 / 2), 119);
            Point y1 = new Point(0, (119 / 2));
            Point y2 = new Point(238, 119 / 2);

            pictureBox1.Refresh();

            int cx = 238;
            int cy = 119 / 2;

            var p = new PointF[pictureBox1.Size.Width];
            for (int i = 0; i < pictureBox1.Size.Width; i++)
            {
                p[i].Y = (float)(cy * (1 - Math.Pow(i, 3) / (cx - 1)));
                p[i].X = i + 118;
            }

            Pen myPen2 = new Pen(Color.SlateBlue, 0.6F);

            g.DrawLines(myPen, p);
            g.DrawRectangle(myPen2, (float)(0.5), (float)(0.5), (238 - 1), (119 - 1));
            g.DrawLine(myPen2, x1, x2);
            g.DrawLine(myPen2, y1, y2);
            g.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen myPen = new Pen(Color.Orange, 0.05f);

            pictureBox1.BackColor = Color.FromName("Khaki");
            pictureBox1.Refresh();

            g.PageUnit = GraphicsUnit.Inch;

            g.DrawRectangle(myPen, 0, 0, 9, 9);


            Point x1 = new Point(9 / 2, 0);
            Point x2 = new Point(9 / 2, 5);
            Point y1 = new Point(0, 5 / 2);
            Point y2 = new Point(9, 5 / 2);
            int cx = 9;
            int cy = 5 / 2;

            var p = new PointF[pictureBox1.Size.Width];

            for (int i = 0; i < pictureBox1.Size.Width; i++)
            {
                p[i].Y = (float)(cy * (1 - Math.Pow(i, 2) / (cx - 1)));
                p[i].X = i + 5;
            }

            Pen myPen2 = new Pen(Color.Green, 0.05F);

            g.DrawLines(myPen2, p);

            g.DrawLine(myPen, x1, x2);
            g.DrawLine(myPen, y1, y2);
            g.Dispose();
        }
    }
}
