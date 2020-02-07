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
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //создать пустой файл
            //System.IO.File.Create("D:\\TestFile.txt");

            //создать (если нет) либо открыть если есть и записать текст (путем замены если что то      было   записано)
            //System.IO.File.WriteAllText("D:\\TestFile.txt", "текст");

            //создает новый  если такого нет , либо открывает имеющийся и пишет путем добавления 
            //System.IO.File.AppendAllText("D:\\TestFile.txt", "текст");

            //получить доступ к  существующему либо создать новый
            StreamWriter file = new StreamWriter("D:\\TestFile.txt");
            //записать в него
            for(int i = 0; i < 15; i++)
            {
                //string s = Convert.ToString(i + 1);
                file.WriteLine(Convert.ToString(i + 1) + " line");
            }
            //закрыть для сохранения данных
            file.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int a = 20;
            int b = 20;
            string path = @"D:\\TestFile.txt";
            Graphics g = pictureBox1.CreateGraphics();
            Font fn = new Font("Corbel", 24,/* FontStyle.Bold | */FontStyle.Italic);
            Font fn2 = new Font("Imprint MT Shadow", 36, FontStyle.Regular);
            Font fn3 = new Font("Arial Black", 72, FontStyle.Bold);
            //g.DrawString("Hello World!", fn, Brushes.Black, 200, 100);

            StringFormat sf = /*(StringFormat)*/ new StringFormat()/*.GenericTypographic.Clone()*/;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            //sf.Trimming = StringTrimming.EllipsisWord;
            //e.Graphics.DrawString(str, fn, Brushes.Black, new RectangleF(10, 10, this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20), sf);

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;

                for(int i = 0; i < 9; i++)
                {
                    line = sr.ReadLine();
                    //g.DrawString(line, fn, Brushes.Black, 100, a);
                    g.DrawString(line, fn, Brushes.Orange, new RectangleF(10, a, this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20), sf);
                    a += 30;
                }

                for (int i = 9; i < 14; i++)
                {
                    line = sr.ReadLine();
                    //g.DrawString(line, fn, Brushes.Black, 100, a);
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    g.DrawString(line, fn2, Brushes.Red, new RectangleF(b, 0, this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20), sf);
                    b += 40;
                }

                for (int i = 14; i < 15; i++)
                {
                    line = sr.ReadLine();
                    //g.DrawString(line, fn, Brushes.Black, 100, a);
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(line, fn3, Brushes.Green, new RectangleF(400, pictureBox1.Height - 180, 800, 0), sf);
                    //b += 40;
                }
            }
            fn.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            System.IO.File.Delete(@"D:\\TestFile.txt");
        }
    }
}
