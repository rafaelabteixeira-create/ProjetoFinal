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
    public partial class EscolhaLider : Form
    {
        public int escolha = 0;
        public EscolhaLider()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void EscolhaLider_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             escolha = 1;
            this.Close();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
             escolha = 2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             escolha = 3;
            this.Close();
        }
    }
}
