using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_11._06
{
    public partial class Form1 : Form
    {
        private Point center;
        private int radius;
        private bool isFirstClick = true;
        private bool shouldDraw = false;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isFirstClick)
            {
                center = e.Location;
                isFirstClick = false;
                shouldDraw = false;
            }
            else
            {
                radius = (int)Math.Sqrt(Math.Pow(e.X - center.X, 2) + Math.Pow(e.Y - center.Y, 2));
                shouldDraw = true;
                isFirstClick = true;
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (shouldDraw)
            {
                using (Graphics g = e.Graphics)
                {
                    g.Clear(this.BackColor);
                    g.DrawEllipse(Pens.Black, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                }
            }
        }
    }
}
