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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           
           Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EscolhaPais escolhaPais = new EscolhaPais();
            escolhaPais.Show();
            this.Close();
        }
    }
}
