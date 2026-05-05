using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idea
{
    public partial class Entrar : Form
    {
        ClassDatabase database = new ClassDatabase();

        private static SqlConnection db = new SqlConnection(ClassDatabase.connectionString);
        public Entrar()
        {
            InitializeComponent();
            this.MaximizeBox = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 MapaF = new Form3();
            try
            {
                string UserSQL = textBoxUser.Text;
                string PassSQL = textBoxPass.Text;

                using (SqlConnection db = new SqlConnection(ClassDatabase.connectionString))
                {
                    db.Open();

                    string query = "SELECT COUNT(*) FROM Contas WHERE Nome = @nome AND Pass = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = UserSQL;
                        cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = PassSQL;

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Login bem-sucedido!");

                            
                            MapaF.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nome ou palavra-passe incorretos!");
                        }
                        MapaF.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\nErro: {ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                Criar criar = new Criar();


                criar.Show();
                this.Hide();
            }
            catch { }
        }

        private void Entrar_Load(object sender, EventArgs e)
        {

        }
    }
}
