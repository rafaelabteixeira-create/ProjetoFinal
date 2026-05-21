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
    public partial class FocoGER : Form
    {

        public int focoF = 3;
        public int local = 0;
        ClassDatabase db = new ClassDatabase();
        MapaGER mapa = new MapaGER();
        int numFoco1 = 0;
        int numFoco2 = 0;



        public FocoGER()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            pictureBox3.Image = Properties.Resources.LinhaF1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
