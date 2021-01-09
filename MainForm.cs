using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalSerpinsky
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int Z = 6; // Глубина фрактала

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "Ковёр Серпинского";
            ClientSize = new Size(500, 500);
            CenterToScreen();
            Invalidate();
        }

        private void Serp(Graphics gr, float x1, float y1, float x2, float y2, int n)
        {
            float x1n, y1n, x2n, y2n;
            if (n > 0)
            {
                x1n = 2 * x1 / 3 + x2 / 3;
                x2n = x1 / 3 + 2 * x2 / 3;
                y1n = 2 * y1 / 3 + y2 / 3;
                y2n = y1 / 3 + 2 * y2 / 3;
                gr.DrawRectangle(Pens.Black, x1n, y1n, x2n - x1n, y2n - y1n);
                Serp(gr, x1, y1, x1n, y1n, n - 1);
                Serp(gr, x1n, y1, x2n, y1n, n - 1);
                Serp(gr, x2n, y1, x2, y1n, n - 1);
                Serp(gr, x1, y1n, x1n, y2n, n - 1);
                Serp(gr, x2n, y1n, x2, y2n, n - 1);
                Serp(gr, x1, y2n, x1n, y2, n - 1);
                Serp(gr, x1n, y2n, x2n, y2, n - 1);
                Serp(gr, x2n, y2n, x2, y2, n - 1);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gr.FillRectangle(Brushes.White, ClientRectangle);
            gr.DrawRectangle(Pens.Black, 20, 20, 460, 460);
            Serp(gr, 20, 20, 460, 460, Z);
        }
    }
}
