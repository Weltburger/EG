using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media;

namespace BrickOut
{
    public partial class Form1 : Form
    {
       
        //Declaration of Rectangles and Rectangle Shapes
        // 
        private Microsoft.VisualBasic.PowerPacks.RectangleShape[] vectRectShape = new Microsoft.VisualBasic.PowerPacks.RectangleShape[100];
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //

        private int j = 0;
        private double speed_left = 4;
        private double speed_top = 4;
        private int point = 0;
        private Rectangle rectPlayer;
        private Rectangle[] vectRectangles = new Rectangle[100];

        public Form1()
        {
            InitializeComponent();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();

            

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playground.Bottom - (playground.Bottom / 10);

            game_over_lbl.Left = (playground.Width / 2) - (game_over_lbl.Width / 2);
            game_over_lbl.Top = (playground.Height / 2) - (game_over_lbl.Height / 2);
            game_over_lbl.Visible = false;

            //This is the code of the bricks

            //This algorithm is the model of create Rectangle Shapes to instance bricks and Rectangles for test collisions (go to line 229 )

            rectPlayer = new Rectangle(ball.Location.X,ball.Location.Y,ball.Width,ball.Height); // modelling rectangles for player to test collision


                for (int row = playground.Height / 30; row < playground.Height / 3; row += playground.Height / 20) //For each "row" of bricks
                {

                    for (double platform = (playground.Width / 100); platform < playground.Width; platform += playground.Width / 9) //For each "platform/collumns" of bricks
                    {

                        int widthRect = Convert.ToInt32(playground.Width / 10); //width of each brick
                        int predictable = Convert.ToInt32(platform) + (playground.Width / 10); // the next platform

                        if (predictable < playground.Width) //test to no instance a brick out of your monitor :p
                        {
                            //Configure the possition of the bricks, and the collor.
                            vectRectShape[j] = new Microsoft.VisualBasic.PowerPacks.RectangleShape(Convert.ToInt32(platform), 70 + row, widthRect, 30);
                            vectRectShape[j].FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
                            //vectRectShape[j].FillColor = Color.Red;

                            if(j > -1 && j < 9)
                            {
                                vectRectShape[j].FillColor = Color.Red;
                            }
                            if (j > 8 && j < 18)
                            {
                                vectRectShape[j].FillColor = Color.Purple;
                            }
                            if (j > 17 && j < 27)
                            {
                                vectRectShape[j].FillColor = Color.DarkCyan;
                            }
                            if (j > 26 && j < 36)
                            {
                                vectRectShape[j].FillColor = Color.DarkGray;
                            }
                            if (j > 35 && j < 45)
                            {
                                vectRectShape[j].FillColor = Color.White;
                            }
                            if (j > 44 && j < 54)
                            {
                                vectRectShape[j].FillColor = Color.Green;
                            }
                    }

                        j++;
                    }
                }

            




            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer2";

             for(int k = j; k > 0; k--)
            {
                this.shapeContainer1.Shapes.Add(vectRectShape[k - 1]);   //Instance of the bricks
            }

            this.shapeContainer1.Size = new System.Drawing.Size(663, 329);
            this.shapeContainer1.TabIndex = 13;
            this.shapeContainer1.TabStop = false;

            this.playground.Controls.Add(this.shapeContainer1);

        }


        



        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            rectPlayer.Location = ball.Location;

            ball.Left += Convert.ToInt32(speed_left);
            ball.Top += Convert.ToInt32(speed_top);

            label1.Text = ball.Bottom.ToString();
            label2.Text = ball.Top.ToString();
            label3.Text = ball.Left.ToString();
            label4.Text = ball.Right.ToString();

            label5.Text = racket.Bottom.ToString();
            label6.Text = racket.Top.ToString();
            label7.Text = racket.Left.ToString();
            label8.Text = racket.Right.ToString();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;


            if (ball.Bottom >= racket.Top &&
                ball.Bottom <= racket.Bottom &&
                ball.Left >= racket.Left &&
                ball.Right <= racket.Right)
            {
                speed_top += 0.5;
                speed_left += 0.5;
                speed_top = -speed_top;
                /*point += 1;
                points_lbl.Text = point.ToString();*/
                Random r = new Random();
                //playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));

                /*for(int h = j; h > 0; h--)
                {
                    vectRectShape[h-1].FillColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }*/
                 
                
                 
            }

            if(ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }

            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }

            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                game_over_lbl.Visible = true;
            }

            bool play = false;

            for(int l = j; l > 0; l--)
            {
                if(vectRectShape[l-1].Visible == true && vectRectangles[l - 1].IntersectsWith(rectPlayer))
                {
                    vectRectShape[l - 1].Visible = false;

                    if (vectRectShape[l - 1] == vectRectShape[0] || vectRectShape[l - 1] == vectRectShape[1] || vectRectShape[l - 1] == vectRectShape[2] || vectRectShape[l - 1] == vectRectShape[3] ||
                        vectRectShape[l - 1] == vectRectShape[4] || vectRectShape[l - 1] == vectRectShape[5] || vectRectShape[l - 1] == vectRectShape[6] || vectRectShape[l - 1] == vectRectShape[7] ||
                        vectRectShape[l - 1] == vectRectShape[8])
                    {
                        point += 6;
                    }

                    if (vectRectShape[l - 1] == vectRectShape[9] || vectRectShape[l - 1] == vectRectShape[10] || vectRectShape[l - 1] == vectRectShape[11] || vectRectShape[l - 1] == vectRectShape[12] ||
                        vectRectShape[l - 1] == vectRectShape[13] || vectRectShape[l - 1] == vectRectShape[14] || vectRectShape[l - 1] == vectRectShape[15] || vectRectShape[l - 1] == vectRectShape[16] ||
                        vectRectShape[l - 1] == vectRectShape[17])
                    {
                        point += 5;
                    }

                    if (vectRectShape[l - 1] == vectRectShape[18] || vectRectShape[l - 1] == vectRectShape[19] || vectRectShape[l - 1] == vectRectShape[20] || vectRectShape[l - 1] == vectRectShape[21] ||
                        vectRectShape[l - 1] == vectRectShape[22] || vectRectShape[l - 1] == vectRectShape[23] || vectRectShape[l - 1] == vectRectShape[24] || vectRectShape[l - 1] == vectRectShape[25] ||
                        vectRectShape[l - 1] == vectRectShape[26])
                    {
                        point += 4;
                    }

                    if (vectRectShape[l - 1] == vectRectShape[27] || vectRectShape[l - 1] == vectRectShape[28] || vectRectShape[l - 1] == vectRectShape[29] || vectRectShape[l - 1] == vectRectShape[30] ||
                        vectRectShape[l - 1] == vectRectShape[31] || vectRectShape[l - 1] == vectRectShape[32] || vectRectShape[l - 1] == vectRectShape[33] || vectRectShape[l - 1] == vectRectShape[34] ||
                        vectRectShape[l - 1] == vectRectShape[35])
                    {
                        point += 3;
                    }

                    if (vectRectShape[l - 1] == vectRectShape[36] || vectRectShape[l - 1] == vectRectShape[37] || vectRectShape[l - 1] == vectRectShape[38] || vectRectShape[l - 1] == vectRectShape[39] ||
                        vectRectShape[l - 1] == vectRectShape[40] || vectRectShape[l - 1] == vectRectShape[41] || vectRectShape[l - 1] == vectRectShape[42] || vectRectShape[l - 1] == vectRectShape[43] ||
                        vectRectShape[l - 1] == vectRectShape[44])
                    {
                        point += 2;
                    }

                    if (vectRectShape[l - 1] == vectRectShape[45] || vectRectShape[l - 1] == vectRectShape[46] || vectRectShape[l - 1] == vectRectShape[47] || vectRectShape[l - 1] == vectRectShape[48] ||
                        vectRectShape[l - 1] == vectRectShape[49] || vectRectShape[l - 1] == vectRectShape[50] || vectRectShape[l - 1] == vectRectShape[51] || vectRectShape[l - 1] == vectRectShape[52] ||
                        vectRectShape[l - 1] == vectRectShape[53])
                    {
                        point += 1;
                    }

                    speed_top = -speed_top;
                    points_lbl.Text = point.ToString();
                   
 
                }
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.F1)
            {
                ball.Top = 400;
                ball.Left = 400;
                speed_left = 4;
                speed_top = 4;
                point = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                game_over_lbl.Visible = false;
                for (int k = j; k > 0; k--)
                {
                    this.shapeContainer1.Shapes.Add(vectRectShape[k - 1]);
                    this.vectRectShape[k - 1].Visible = true;
                }
                this.playground.Controls.Add(shapeContainer1);



            }


        }

        private void playground_Paint(object sender, PaintEventArgs e)  //that method draw rectangles for each brick to test collisions and help to "bounce" the "ball"
        {

            //Rectangles is structures, not objects like bricks to disappear, so I create a vector of RectangleShapes in line 17 and instance them with the same algorith and structure of this vector of Rectangles in line 49 (more informations above)

            int i = 0;

            for(int fila = playground.Height/30; fila < playground.Height/3; fila += playground.Height / 20) //fila is row in Portuguese Brazilian :p
            {

                for (double plataforma = (playground.Width / 100); plataforma < playground.Width; plataforma += playground.Width/9) //plataforma = platform
                {

                    int widthRect = Convert.ToInt32(playground.Width / 10);
                    int predict = Convert.ToInt32(plataforma) + (playground.Width/10);

                    if (predict < playground.Width)
                    {
                        vectRectangles[i] = new Rectangle(Convert.ToInt32(plataforma), 70 + fila, widthRect, 30);
                    }

                    i++;
                }

            }

            
            
            Graphics objGraph = e.Graphics;


            Pen p = new Pen(Brushes.Green);
             //objGraph.FillRectangles(Brushes.GreenYellow, vectRectangles);   // this active collor green in rectangles
         
        }

    }
}
