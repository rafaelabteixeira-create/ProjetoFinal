using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace idea
{
    public partial class FocoGER : Form
    {

        public int focoF = 1;
        
        ClassDatabase db = new ClassDatabase();
        MapaGER mapa = new MapaGER();
        int numFoco1 = 0;
        int numFoco2 = 0;



        public FocoGER()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            if (db.Conf(0, 0) > 0)
            {
                pictureBox3.Image = Properties.Resources.LinhaF1;
                pictureBox2.Image = Properties.Resources.FlagEUOFF;

            }
            if (db.Conf(1, 0) > 0)
            {
                pictureBox1.Image = Properties.Resources.FlagEUOFF;
                LinhaF2.Image = Properties.Resources.LinhaF1;
            }
            if (db.Conf(2, 0) > 0) { 
                pictureBoxElectLead.Image = Properties.Resources.FlagEUOFF;
                LinhaF3.Image = Properties.Resources.LinhaF1;
                LinhaF4.Image = Properties.Resources.LinhaF1;

                
            }
            if (db.Conf(3, 0) > 0)
            {
                pictureBoxIntegrate.Image = Properties.Resources.FlagEUOFF;
                
            }
            if (db.Conf(4, 0) > 0)
            {
                pictureBoxGuerraAnarq.Image = Properties.Resources.FlagEUOFF;
                LinhaF5.Image = Properties.Resources.LinhaF1;
            }
            if (db.Conf(5, 0) > 0)
            {
                pictureBoxBlitz.Image = Properties.Resources.FlagEUOFF;
                LinhaF5.Image = Properties.Resources.LinhaF1;
            }
            if (db.Conf(6, 0) > 0)
            {
                pictureBoxBlitz.Image = Properties.Resources.FlagEUOFF;
            }
            if (db.Conf(0, 1) > 0)
            {
               pictureBoxConstructInfa.Image = Properties.Resources.FlagEUOFF;
                LinhaF6.Image = Properties.Resources.LinhaF1;
            }
            if (db.Conf(1, 1) > 0)
            {
                pictureBoxSatisfy.Image = Properties.Resources.FlagEUOFF;
            }




        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void FocoGER_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            numFoco1 = 0;
            numFoco2 = 0;
            db.FocoTurno(focoF, numFoco1, numFoco2);
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxElectLead_Click(object sender, EventArgs e)
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

        private void pictureBoxConstructInfa_Click(object sender, EventArgs e)
        {
            numFoco1 = 0;
            numFoco2 = 1;
            db.FocoTurno(focoF, numFoco1, numFoco2);
        }

        private void pictureBoxIntegrate_Click(object sender, EventArgs e)
        {
            if (db.Conf(2, 0) > 0)
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

        private void pictureBoxGuerraAnarq_Click(object sender, EventArgs e)
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

        private void pictureBoxBlitz_Click(object sender, EventArgs e)
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

        private void LinhaF5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSatisfy_Click(object sender, EventArgs e)
        {
            numFoco1 = 1;
            numFoco2 = 1;
            db.FocoTurno(focoF, numFoco1, numFoco2);
        }

        private void LinhaF6_Click(object sender, EventArgs e)
        {

        }
    }
}
