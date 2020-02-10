using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics dc; Pen p;
        /* Коэффициенты матрицы видового преобразования */
        double v11, v12, v13, v21, v22, v23, v32, v33, v43;
        /* Сферические координаты точки наблюдения */
        double rho = 150.0, theta = 120.0, phi = 55.0;
        /* Расстояние от точки наблюдения до экрана */
        double screen_dist = 100.0;
        /* Cмещение относительно левого нижнего угла экрана */
        double c1 = 5.0, c2 = 3.5;
        /* Половина длины ребра куба */
        double h = 2;

        public Form1()
        {
            InitializeComponent();
            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Black, 1);
        }

        /* Функция преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Функция преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y *

            (pictureBox1.Size.Height / 7.0) + 0.5;

            return (int)yy;
        }
        /* Вычисление коэффициентов, не зависящих от вершин куба */
        private void coeff(double rho, double theta, double phi)
        {
            double th, ph, costh, sinth, cosph, sinph, factor;
            factor = Math.PI / 180.0; // из градусов в радианы
            th = theta * factor;
            ph = phi * factor;
            costh = Math.Cos(th);
            sinth = Math.Sin(th);
            cosph = Math.Cos(ph);
            sinph = Math.Sin(ph);
            /* Элементы матрицы V видового преобразования
            | -sin(th) -cos(phi) * cos(th) -sin(phi) * cos(th) 0 |
            V= | cos(th) -cos(phi) * sin(th) -sin(phi) * sin(th) 0 |
            | 0 sin(phi) -cos(phi) 0 |
            | 0 0 rho 1 |
            */
            v11 = -sinth; v12 = -cosph * costh; v13 = -sinph * costh;
            v21 = costh; v22 = -cosph * sinth; v23 = -sinph * sinth;
            v32 = sinph; v33 = -cosph; v43 = rho;
        }
        /* Функция видового и перспективного преобразования координат */
        private void perspective(double x, double y, double z, ref double pX, ref double pY)
        {
            double xe, ye, ze;
            /*координаты точки наблюдения, вычисляемые по уравнению
            [Xe Ye Ze 1]= [Xw Yw Zw 1]*V
            */
            xe = v11 * x + v21 * y;
            ye = v12 * x + v22 * y + v32 * z;
            ze = v13 * x + v23 * y + v33 * z + v43;
            /* Экранные координаты,вычисляемые по формулам
            X= d* (x/z)+c1, Y= d*(y/z)+c2,
            где - расстояние от точки наблюдения до экрана
            */
            pX = screen_dist * xe / ze + c1;
            pY = screen_dist * ye / ze + c2;
        }
        /* Функция вычерчивания линии (экран 10х7 условн. единиц) */
        private void dw(double x1, double y1, double z1, double x2, double y2, double z2)

        {
            double X1 = 0, Y1 = 0, X2 = 0, Y2 = 0;
            /* Преобразование мировых координат в экранные */
            perspective(x1, y1, z1, ref X1, ref Y1);
            perspective(x2, y2, z2, ref X2, ref Y2);
            /* Вычерчивание линии */
            Point point1 = new Point(IX(X1), IY(Y1));
            Point point2 = new Point(IX(X2), IY(Y2));
            dc.DrawLine(p, point1, point2);
        }
        /* Функция рисования проволочной модели куба */
        private void drawCube(double h)
        {
            dw(h, -h, -h, h, h, -h); // Отрезок AB
            dw(h, h, -h, -h, h, -h); // Отрезок BC
            dw(-h, h, -h, -h/2, h/2, h/2); // Отрезок CG
            dw(-h/2, h/2, h/2, -h/2, -h/2, h/2); // Отрезок GH
            dw(-h/2, -h/2, h/2, h/2, -h/2, h/2); // Отрезок HE
            dw(h/2, -h/2, h/2, h, -h, -h); // Отрезок EA
            dw(h, h, -h, h/2, h/2, h/2); // Отрезок BF
            dw(h/2, h/2, h/2, -h/2, h/2, h/2); // Отрезок FG
            dw(h/2, h/2, h/2, h/2, -h/2, h/2); // Отрезок FE
            dw(h, -h, -h, -h, -h, -h); // Отрезок AD
            dw(-h, -h, -h, -h, h, -h); // Отрезок DC
            dw(-h, -h, -h, -h/2, -h/2, h/2); // Отрезок DH
        }
        /* Вызов главной функции рисования проволочной модели куба */

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            coeff(rho, theta, phi);
            drawCube(h);
        }
    }
}
