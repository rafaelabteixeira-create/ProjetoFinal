using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idea
{
    public partial class FocoFRA : Form
    {
        public int focoF = 1;

        ClassDatabase db = new ClassDatabase();
        MapaGER mapa = new MapaGER();
        int numFoco1 = 0;
        int numFoco2 = 0;
        public FocoFRA()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (db.Conf(0, 0) > 0)
            {
                Line1.Image = Properties.Resources.LinhaF1;
                FranceFoco1.Image = Properties.Resources.AnarchoFrance;
            }
            if (db.Conf(1, 0) > 0)
            {
                FranceFoco2.Image = Properties.Resources.AnarchoFrance;
                line2.Image = Properties.Resources.LinhaF1;
                line3.Image = Properties.Resources.LinhaF1;
            }
            if (db.Conf(2, 0) > 0)
            {
                FranceFoco3.Image = Properties.Resources.AnarchoFrance;

            }
            if (db.Conf(3, 0) > 0)
            {
                FranceFoco4.Image = Properties.Resources.AnarchoFrance;
                line4.Image = Properties.Resources.LinhaF1;

            }
            if (db.Conf(4, 0) > 0)
            {
                FranceFoco5.Image = Properties.Resources.AnarchoFrance;
                line5.Image = Properties.Resources.LinhaF1;

            }
            if (db.Conf(5, 0) > 0)
            {
                FranceFoco6.Image = Properties.Resources.AnarchoFrance;
                

            }
        }

        private void FocoFRA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (db.Conf(numFoco1, numFoco2) > 0)
            {
                numFoco1 = 1;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

            }
            else
            {
                MessageBox.Show("Escolha o fóco anterior");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
                numFoco1 = 0;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

           
        }

        private void FranceFoco4_Click(object sender, EventArgs e)
        {
            if (db.Conf(numFoco1, numFoco2) > 0)
            {
                numFoco1 = 3;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

            }
            else
            {
                MessageBox.Show("Escolha o fóco anterior");
            }
        }

        private void FranceFoco3_Click(object sender, EventArgs e)
        {
            if (db.Conf(numFoco1, numFoco2) > 0)
            {
                numFoco1 = 2;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

            }
            else
            {
                MessageBox.Show("Escolha o fóco anterior");
            }
        }

        private void FranceFoco5_Click(object sender, EventArgs e)
        {
            if (db.Conf(numFoco1, numFoco2) > 0)
            {
                numFoco1 = 4;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

            }
            else
            {
                MessageBox.Show("Escolha o fóco anterior");
            }
        }

        private void FranceFoco6_Click(object sender, EventArgs e)
        {
            if (db.Conf(numFoco1, numFoco2) > 0)
            {
                numFoco1 = 5;
                numFoco2 = 0;
                db.FocoTurno(focoF, numFoco1, numFoco2);

            }
            else
            {
                MessageBox.Show("Escolha o fóco anterior");
            }
        }
    }
}
