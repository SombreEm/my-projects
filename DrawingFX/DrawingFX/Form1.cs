using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingFX
{
    public partial class Form1 : Form
    {
        class Line
        {
            public List<Point> points = new List<Point>();
            public Line(string type, Form form) {
                
                if (type == "horizontal") {
                    points.Add(new Point(0, form.Size.Height / 2));
                    points.Add(new Point(form.Size.Width,form.Size.Height / 2));
                }
                else if (type == "vertical") {
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
            this.BackColor = Color.White;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            Line horizontal = new Line("horizontal",this),
                 vertical = new Line("vertical",this);
            graphics.DrawLine(pen, horizontal.returnPoint(0),
                                   horizontal.returnPoint(1));
            graphics.DrawLine(pen, vertical.returnPoint(0),
                                   vertical.returnPoint(1));

            Point Center = new Point(this.Size.Width/2, this.Size.Height/2);

            double x = Convert.ToDouble(inputValue.Text);
            double y = Convert.ToDouble(Math.Pow(x,2));
            Point Stream = Center;
            Point superCenter = new Point(this.Size.Width / 2, this.Size.Height / 2);
            int step = 2;
            for (int i = 0; i < 400; i++)
            {
                graphics.DrawLine(pen, Stream, new Point((Stream.X + Convert.ToInt32(x)* 5), (Stream.Y - Convert.ToInt32(y) * 5)));
                Stream = new Point((Stream.X + Convert.ToInt32(x) * 5), (Stream.Y - Convert.ToInt32(y) * 5));
                x++;
                y = x * x;
            }
            x = Convert.ToDouble(inputValue.Text);
            y = Convert.ToDouble(Math.Pow(x, 2));
            Stream = Center;
            
            for (int i = 0; i < 400; i++)
            {
                graphics.DrawLine(pen, Stream, new Point((Stream.X - Convert.ToInt32(x) * 5), (Stream.Y - Convert.ToInt32(y) * 5)));
                Stream = new Point((Stream.X - Convert.ToInt32(x) * 5), (Stream.Y - Convert.ToInt32(y) * 5));
                x++;
                y = x * x;
            }
            graphics.Dispose();
            pen.Dispose();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.White);
        }
    }
}
