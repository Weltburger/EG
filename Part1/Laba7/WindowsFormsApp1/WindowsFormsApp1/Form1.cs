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

        // Битовая картинка pictureBox
        Bitmap pictureBoxBitMap;
        // Битовая картинка динамического изображения
        Bitmap spriteBitMap;
        // Битовая картинка для временного хранения области экрана
        Bitmap cloneBitMap;
        // Графический контекст picturebox
        Graphics g_pictureBox;
        // Графический контекст спрайта
        Graphics g_sprite;
        int x, y; // Координаты автобуса
        int width = 480, height = 120; // Ширина и высота автобуса
        Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаём Bitmap для pictureBox1 и графический контекст
            pictureBox1.Image = Image.FromFile(@"fon.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            // Создаём Bitmap для спрайта и графический контекст
            spriteBitMap = new Bitmap(width, height);
            g_sprite = Graphics.FromImage(spriteBitMap);
            // Рисуем линию движения автобуса
            g_pictureBox.DrawLine(new Pen(Color.Black, 2), 0, 410, pictureBox1.Width - 1, 410);
            // Рисуем автобус на графическом контексте g_sprite
            DrawSprite();
            // Создаём Bitmap для временного хранения части изображения
            cloneBitMap = new Bitmap(width, height);
            // Задаем начальные координаты вывода движущегося объекта
            x = 0; y = 280;
            // Сохраняем область экрана перед первым выводом объекта
            SavePart(x, y);
            // Выводим автобус на графический контекст g_pictureBox
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
            // Создаём таймер с интервалом 100 миллисекунд
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer1_Tick);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Восстанавливаем затёртую область статического изображения
            g_pictureBox.DrawImage(cloneBitMap, x, y);
            // Изменяем координаты для следующего вывода автобуса
            x += 8;
            if (x > 120)
            {
                y -= 2;
            }
            // Проверяем на выход изображения автобуса за правую границу
            if (x > pictureBox1.Width - 1) x = pictureBox1.Location.X;
            if (y < 10) y = pictureBox1.Location.Y;
            // Сохраняем область экрана перед первым выводом автобуса
            SavePart(x, y);
            // Выводим автобус
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                timer.Enabled = true;
        }

        // Функция рисования спрайта (автобуса)
        void DrawSprite()
        {
            // Рисуем колеса
            /*g_sprite.DrawEllipse(new Pen(Color.Black, 2), 70, 150, 60, 60);
            g_sprite.FillEllipse(new SolidBrush(Color.Black), 70, 150, 60, 60);
            g_sprite.DrawEllipse(new Pen(Color.Black, 2), 350, 150, 60, 60);
            g_sprite.FillEllipse(new SolidBrush(Color.Black), 350, 150, 60, 60);*/
            // Рисуем корпус автобуса
            Point[] points = new Point[16] 
            {
                new Point(1,1), new Point(20,1), new Point(80, 60), new Point(400, 60), new Point(410, 65), new Point(420, 70), new Point(430,75), new Point(440,80),
                new Point(450,110), new Point(440,120), new Point(60,120), new Point(50,110), new Point(40,100),
                new Point(30,90), new Point(20,80), new Point(1,1)
            };
            g_sprite.FillPolygon(Brushes.DarkOrange, points);
            g_sprite.DrawPolygon(new Pen(Color.Black, 2), points);
            // Рисуем четыре пассажирских окна
            for (int i = 0; i < 5; i++)
            {
                g_sprite.FillEllipse(Brushes.LightGray, 100 + i * 50 + i * 10, 65, 20, 30);
                g_sprite.DrawEllipse(new Pen(Color.Black, 2), 100 + i * 50 + i * 10, 65, 20, 30);
            }

            Point[] points1 = new Point[8]
            {
                new Point(380,65), new Point(410, 65), new Point(420, 70), new Point(430,75), new Point(440,80),
                new Point(446,100), new Point(436,100), new Point(380,100)
            };

            g_sprite.FillPolygon(Brushes.SkyBlue, points1);
            g_sprite.DrawPolygon(new Pen(Color.Black, 2), points1);

            Point[] points2 = new Point[5]
            {
                new Point(150,100), new Point(280, 100), new Point(285, 120), new Point(150,120), new Point(150,100)
            };

            g_sprite.FillPolygon(Brushes.White, points2);
            g_sprite.DrawPolygon(new Pen(Color.Black, 2), points2);

            // Рисуем контур двери
            /*g_sprite.DrawRectangle(new Pen(Color.Black, 2), 290, 10, 60, 160);
            // Рисуем окно двери и контур окна
            g_sprite.FillRectangle(Brushes.LightGray, 295, 15, 50, 90);
            g_sprite.DrawRectangle(new Pen(Color.Black, 2), 295, 15, 50, 90);
            // Рисуем окно кабины и его контур
            Point[] point = new Point[5]
            {
                new Point(360,10), new Point(420,10), new Point(438,90), new Point(360,90), new Point(360,10)
            };
            g_sprite.FillPolygon(Brushes.LightGray, point);
            g_sprite.DrawPolygon(new Pen(Color.Black, 2), point);*/
        }
        // Функция сохранения части изображения шириной
        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            System.Drawing.Imaging.PixelFormat format =  pictureBoxBitMap.PixelFormat;
            // Клонируем изображение, заданное прямоугольной областью
            cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }

    }
}
