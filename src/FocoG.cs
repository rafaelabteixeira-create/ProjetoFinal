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
    public partial class Foco : Form
    {
        ClassDatabase classdatabase = new ClassDatabase();

        public Foco()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int contador = 0;
            contador = contador + 3;
        }
    }
}
