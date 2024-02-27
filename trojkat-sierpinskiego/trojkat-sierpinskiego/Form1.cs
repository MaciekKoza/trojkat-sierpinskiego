using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trojkat_sierpinskiego
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Paint += TriangleGeneration;
        }

        int maxDepth = 5;
        private void TriangleGeneration(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            int depth = 0;

            Point p1 = new Point(500, 100);
            Point p2 = new Point(900, 700);
            Point p3 = new Point(100, 700);

            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p1, p3);


            DivideTriangle(sender, e, p1, p2, p3, depth);
        }
        private void DivideTriangle(object sender, PaintEventArgs e, Point p1, Point p2, Point p3, int depth)
        {
            if (depth >= maxDepth) { return; }
            depth++;

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 2);

            Point pmid1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            Point pmid2 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
            Point pmid3 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);

            g.DrawLine(pen, pmid1, pmid2);
            g.DrawLine(pen, pmid2, pmid3);
            g.DrawLine(pen, pmid3, pmid1);

            DivideTriangle(sender, e, p1, pmid1, pmid3, depth);
            DivideTriangle(sender, e, pmid1, p2, pmid2, depth);
            DivideTriangle(sender, e, pmid3, pmid2, p3, depth);
        }
    }
}
