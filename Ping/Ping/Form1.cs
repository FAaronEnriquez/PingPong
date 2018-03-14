using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping
{
    public partial class Form1 : Form
    {
        public 
        int speedball = 4; //speed of ball
        int speed_top = 4;
        int pts = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None; // removes any border
            this.TopMost = true; //brings the form to the front


            racket.Top = background.Bottom - (background.Bottom/10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width/2);
            pong.Left += speedball; //move the pong
            pong.Top += speed_top;

            if(pong.Bottom >= racket.Top && 
                pong.Bottom <= racket.Bottom && 
                pong.Left >= racket.Left && 
                pong.Right <= racket.Right )
            {
                speed_top += 2;
                speedball += 2;
                speed_top = -speed_top;
                pts += 1;
                points_lbl.Text = pts.ToString();

                Random r = new Random();
                background.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
                
            }
            if (pong.Left <= background.Left) speedball = -speedball;
            if (pong.Right >= background.Right) speedball = -speedball;
            if (pong.Top <= background.Top) speed_top = -speed_top;
            if (pong.Bottom >= background.Bottom) timer1.Enabled = false; //ends the game
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close(); //closes the program
            if (e.KeyCode == Keys.F1)
            {
                pong.Left = 50;
                pong.Top = 50;
                speedball = 4;
                speed_top = 4;
                points_lbl.Text = "0";
                pts = 0;
                timer1.Enabled = true;

            }
        }

      
    }
}
