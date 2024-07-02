using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    public partial class Form1 : Form
    {
        Point start, end;
        int value = 0;
        public Form1()
        {
            InitializeComponent();
            start = new Point(0, Height / 2);
            end = start;
        }

        private void Start_Click(object sender, EventArgs e)
        {

            CreateGraphics().Clear(Color.White);
            CreateGraphics().DrawLine(new Pen(Color.Black), new Point(Width / 2, 0), new Point(Width / 2, Height));
            CreateGraphics().DrawLine(new Pen(Color.Black), new Point(0, Height / 2), new Point(Width, Height / 2));

            timer1.Start();

        }

        private void Stop_Click(object sender, EventArgs e)
        {

            start = new Point(0, Height / 2);
            end = start;
            timer1.Stop();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            end.X += 2;
            end.Y -= Convert.ToInt32(Math.Sin(value) * 10);
            value++;
            CreateGraphics().DrawLine(new Pen(Color.Black), start, end);
            start = end;

            if (end.X > Width)
            {
                timer1.Stop();
            }

        }
    }
}
