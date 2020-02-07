using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dragonborn
{
    public partial class Form1 : Form
    {
        public Form1()
         {
            InitializeComponent();
         }

        void dragon_func(double x1, double y1, double x2, double y2, int n)
         {
            int[] mas = new int[] { 1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,0,1,1,0,1,1,0,0,0,1,1,0,0,1,0,0 };
            double xn,yn;
            /*double angle45 = Math.PI * 45 / 180;
            double angle135 = Math.PI * 135/180;*/
             Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
             var drawingPen = new Pen(Brushes.Navy, 1);

            if(n > 0)
             {
                /*foreach (int element in mas)
                {
                    if(element == 1)
                    {
                        xn = (x1 * Math.Cos(angle45) - y2 * Math.Sin(angle45)) / Math.Sqrt(2);
                        yn = (x1 * Math.Sin(angle45) + y2 * Math.Cos(angle45)) / Math.Sqrt(2);
                    }
                    else
                    {
                        xn = (x1 * Math.Cos(angle135) - y2 * Math.Sin(angle135)) / Math.Sqrt(2) + 1;
                        yn = (x1 * Math.Sin(angle135) + y2 * Math.Cos(angle135)) / Math.Sqrt(2);
                    }*/


                //}

                //xn = x1 + (x2 - x1) * Math.Cos(n * Math.PI / 180) - (y2 - y1) * Math.Sin(n * Math.PI / 180);
                //yn = y1 + (x2 - x1) * Math.Sin(n * Math.PI / 180) + (y2 - y1) * Math.Cos(n * Math.PI / 180);

                xn = (x1 + x2) / 2 + (y2 - y1) / 2;
                yn = (y1 + y2) / 2 - (x2 - x1) / 2 ;
                dragon_func(x2, y2, xn, yn, n - 1);
                dragon_func(x1, y1, xn, yn, n - 1);

                var point1 = new Point((int)x1, (int)y1);
                var point2 = new Point((int)x2, (int)y2);
                g.DrawLine(drawingPen, point1, point2);


                //xn = x1 + (x2 - x1) * Math.Cos(n * Math.PI / 180) - (y2 - y1) * Math.Sin(n * Math.PI / 180);
                //yn = y1 + (x2 - x1) * Math.Sin(n * Math.PI / 180) + (y2 - y1) * Math.Cos(n * Math.PI / 180);

                /*dragon_func(x2, y2, xn, yn, n - 1);
                dragon_func(x1, y1, xn, yn, n - 1);*/
             }
         
           /* var point1 = new Point((int)x1, (int)y1);
            var point2 = new Point((int)x2, (int)y2);
            g.DrawLine(drawingPen, point1, point2);*/

        }


       /* this.pointRotation= function(x1, y1, x2, y2, a)
        {
            var resx = x1 + (x2 - x1) * Math.cos(a * Math.PI / 180) - (y2 - y1) * Math.sin(a * Math.PI / 180);   
            var resy = y1 + (x2 - x1) * Math.sin(a * Math.PI / 180) + (y2 - y1) * Math.cos(a * Math.PI / 180);
            return 
           {
                x:resx, y:resy
           };
        }*/

/*void DragonCurve(float dragon_x1, float dragon_y1, float dragon_x2, float dragon_y2, int dragon_number)
{
    Pen pen(Color(0, 255, 0), 2);
    Pen* dragon_pen = pen.Clone();
    Point* dragon_Point;
    dragon_Point = new Point[2];
    int dragon_x, dragon_y;
    if (dragon_number > 0)
    {
        dragon_x = (dragon_x1 + dragon_x2) / 2 + (dragon_y2 + dragon_y1) / 2;
        dragon_y = (dragon_y1 + dragon_y2) / 2 + (dragon_x2 + dragon_x1) / 2;
        DragonCurve(dragon_x2, dragon_y2, dragon_x, dragon_y, dragon_number - 1);
        DragonCurve(dragon_x1, dragon_y1, dragon_x, dragon_y, dragon_number - 1);
    }
    dragon_Point[0] = Point(dragon_x1, dragon_y1);
    dragon_Point[1] = Point(dragon_x2, dragon_y2);
    draw_temp->DrawLine(dragon_pen, dragon_Point[0], dragon_Point[1]);
    delete[] dragon_Point;
}*/

private void Draw_dragon_curve(object sender, EventArgs e)
        {
            int x1,y1,x2,y2, k;
            
             x1 = 200;
             y1 = 200;
             x2 = 400;
             y2 = 400;
             k  = 8;
            dragon_func(x1,y1,x2, y2, k);
        }

        private void Clear_curve(object sender, EventArgs e)
        {
            /*Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            var bgcolor = new SolidBrush(Color.White);
            g.FillRectangle(bgcolor, 0, 0, 660, 516);*/

            pictureBox1.Image = null;
        }

        private void Picturebox(object sender, EventArgs e)
        {
            
        }
    }
}
