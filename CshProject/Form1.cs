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

        int xHeight, yWeight, sum = 0;

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

        int Area(int xHeight, int yWeight)
        {
            return xHeight * yWeight;
        }
    }
}
