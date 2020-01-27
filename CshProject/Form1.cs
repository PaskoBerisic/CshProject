using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CshProject
{
    public partial class Form1 : Form
    {
        Rectangle rectangle;

        Point StartPoint;
        Point EndPoint;

        int xWidth, yHeight, sum = 0;

        bool IsMouseDown = false;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            StartPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndPoint = e.Location;

                Refresh();
            }
        }
            
        
        
        
        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bitm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = bitm;
                }
                using (Graphics grap = Graphics.FromImage(pictureBox1.Image))
                {
                    grap.DrawRectangle(Pens.Black, GetCoordinates());
                }

                pictureBox1.Invalidate();
                EndPoint = e.Location;
                IsMouseDown = false;
            }
            sum += Area(xWidth, yHeight);
            textBoxArea.Text = string.Format("{0}", sum);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                
                textBoxArea.Text = "0";

                sum = 0;

                Invalidate();
            }
        }

        public Rectangle GetCoordinates() {

            rectangle = new Rectangle();

            rectangle.X = Math.Min(StartPoint.X, EndPoint.X);

            rectangle.Y = Math.Min(StartPoint.Y, EndPoint.Y);

            rectangle.Width = Math.Abs(StartPoint.X - EndPoint.X);

            rectangle.Height = Math.Abs(StartPoint.Y - EndPoint.Y);

            xWidth = rectangle.Width;
            yHeight = rectangle.Height;

            return rectangle;
        }


        int Area(int xWidth, int yHeight)
        {
            return xWidth * yHeight;
        }
    }
}
