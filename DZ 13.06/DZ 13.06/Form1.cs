using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_13._06
{
    public partial class Form1 : Form
    {
        class Line
        {
            public List<Point> points = new List<Point>();
            public Line(string type, Form form)
            {

                if (type == "horizontal")
                {
                    points.Add(new Point(0, form.Size.Height / 2));
                    points.Add(new Point(form.Size.Width, form.Size.Height / 2));
                }
                else if (type == "vertical")
                {
                    points.Add(new Point(form.Size.Width / 2, 0));
                    points.Add(new Point(form.Size.Width / 2, form.Size.Height));
                }
            }
            public Point returnPoint(int index)
            {
                return points[index];
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen axisPen = new Pen(Color.Black, 2);
            Pen graphPen = new Pen(Color.Blue, 2);

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            g.DrawLine(axisPen, 0, height / 2, width, height / 2);
            g.DrawLine(axisPen, width / 2, 0, width / 2, height); 

            for (int x = -width / 2; x < width / 2; x++)
            {
                int y = -x;
                g.DrawRectangle(graphPen, width / 2 + x, height / 2 - y, 1, 1);
            }
        }
    }
}
