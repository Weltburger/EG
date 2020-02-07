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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 10);
            Pen myPen2 = new Pen(Color.DarkKhaki, 25);

            SolidBrush wheels = new SolidBrush(Color.Gray);
            SolidBrush dot = new SolidBrush(Color.Black);
            SolidBrush plat = new SolidBrush(Color.Blue);
            SolidBrush corp = new SolidBrush(Color.Red);
            SolidBrush window = new SolidBrush(Color.White);
            SolidBrush smoke = new SolidBrush(Color.LightSlateGray);

            Graphics g = pictureBox1.CreateGraphics();

            g.DrawLine(myPen, 0, pictureBox1.Height - 100, pictureBox1.Width, pictureBox1.Height - 100);
            for (int i = 25; i < pictureBox1.Width; i++)
            {
                g.DrawLine(myPen2, i, pictureBox1.Height - 100, i, pictureBox1.Height - 90);
                i += 50;
            }


            Point[] point1 = new Point[16]
            {
                new Point(420, 20),
                new Point(480, 10),
                new Point(540, 20),
                new Point(600, 10),
                new Point(660, 20),
                new Point(680, 5),
                new Point(820, 20),
                new Point(850, 50),
                new Point(830, 80),
                new Point(790, 85),
                new Point(660, 70),
                new Point(600, 80),
                new Point(540, 60),
                new Point(500, 60),
                new Point(450, 100),
                new Point(395, 55)
            };

            g.FillPolygon(smoke, point1);


            Point[] point2 = new Point[3]
            {
                new Point(150, pictureBox1.Height - 273),
                new Point(230, pictureBox1.Height - 349),
                new Point(230, pictureBox1.Height - 200)
            };

            g.FillPolygon(plat, point2);

            g.FillEllipse(wheels, 250, pictureBox1.Height - 180, 80, 80);
            g.FillEllipse(dot, 285, pictureBox1.Height - 142, 10, 10);

            g.FillEllipse(wheels, 370, pictureBox1.Height - 180, 80, 80);
            g.FillEllipse(dot, 405, pictureBox1.Height - 142, 10, 10);

            g.FillRectangle(plat, 400, pictureBox1.Height - 535, 100, 250);
            g.FillRectangle(wheels, 265, pictureBox1.Height - 455, 20, 40);
            g.FillRectangle(plat, 250, pictureBox1.Height - 435, 50, 100);
            g.FillEllipse(window, 255, pictureBox1.Height - 415, 20, 40);
            g.FillEllipse(plat, 550, pictureBox1.Height - 400, 100, 100);
            g.FillRectangle(wheels, 230, pictureBox1.Height - 200, 500, 30);
            g.FillRectangle(corp, 230, pictureBox1.Height - 350, 500, 150);
            g.FillRectangle(plat, 690, pictureBox1.Height - 515, 200, 350);
            g.FillRectangle(window, 740, pictureBox1.Height - 450, 90, 70);
            g.FillRectangle(wheels, 640, pictureBox1.Height - 515, 250, 30);

            g.FillEllipse(wheels, 600, pictureBox1.Height - 340, 240, 240);
            g.FillEllipse(dot, 705, pictureBox1.Height - 230, 30, 30);

            

        }
    }
}
