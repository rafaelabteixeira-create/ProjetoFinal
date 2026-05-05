using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idea
{
    public partial class Form2 : Form
    {


        List<Point> pontosProvincia;
        Region areaProvincia;
        bool selecionada = false;

        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            CriarProvinciaCorsi();

            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
        }

        void CriarProvinciaCorsi()
        {
            pontosProvincia = new List<Point>()
            {
                new Point(12,45),
                new Point(12,71),
                new Point(22,81),
                new Point(34,78),
                new Point(40,57),
                new Point(40,39),
                new Point(41,18),
                new Point(37,15),
                new Point(34,38),
                new Point(20,38)
            };

            GraphicsPath Corsica = new GraphicsPath();
            Corsica.AddPolygon(pontosProvincia.ToArray());
            areaProvincia = new Region(Corsica);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Color corRhine = Color.Yellow;

            g.FillPolygon(new SolidBrush(corRhine), pontosProvincia.ToArray());
            g.DrawPolygon(Pens.Black, pontosProvincia.ToArray());
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (areaProvincia.IsVisible(e.Location))
            {
                selecionada = !selecionada;

                MessageBox.Show("Clicaste na província!");
            }

            pictureBox1.Invalidate();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
