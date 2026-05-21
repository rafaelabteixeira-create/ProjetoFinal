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
    public partial class EscolhaPais : Form
    {
        int escolha = 0;
        public EscolhaPais()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            escolha = 1;



            pictureBox6.Image = Properties.Resources.FRA_leader;
            label1.Text = "Franca";
                label2.Text = "A França está à beira do colapso, desde da guerra\n" +  "a população está cada vez mais farta do governo de\n" + "Macron e mudanças Ideológicas são aparente\n\n"+  "AI VEM A REVOLUÇÂO !";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EscolhaPais_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.GER_Leader;
            escolha = 2;
            label1.Text = "Alemanha";
            label2.Text = "Depois da humilhação da guerra a Alemanha \n" + "encontra-se em ruina económica e social apenas \n" + "uma associação pode salvar a Europa num todo\n\n" + "Uma união ?";



        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (escolha == 0)
            {
                MessageBox.Show("Escolha um País");
            }
            else if (escolha == 1)
            {

                

            }
            else if (escolha == 2) 
            {

                MapaGER mapa = new MapaGER();
                mapa.Show();
                this.Close();
                
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
