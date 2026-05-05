using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idea
{
    public partial class Criar : Form
    {

        public Criar()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entrar mainF = new Entrar();
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 MapaF = new Form3();

            if (textBoxUser.Text == "")
            {
                MessageBox.Show("Intruduza o nome da Conta");
            }
            else if (textBoxPass.Text == "")
            {
                MessageBox.Show("Intruduza a sua palavra-passe");
            }
            else
            {
                try
                {
                    string UserSQL = textBoxUser.Text;
                    string PassSQL = textBoxPass.Text;
                    int total1 = textBoxUser.Text.Length;
                    int total2 = textBoxPass.Text.Length;

                    using (SqlConnection db = new SqlConnection(ClassDatabase.connectionString))
                    {
                        db.Open();

                        if (total1 <= 0)
                        {
                            MessageBox.Show("Escreva o Username");
                        }
                        else if (total2 <= 0)
                        {
                            MessageBox.Show("Escreva o Username");
                        }
                        else if (total1 >= 20)
                        {
                            MessageBox.Show("Escreva o Username");
                        }
                        else if (total2 >= 20)
                        {
                            MessageBox.Show("Escreva o Username");
                        }
                        else
                        {

                            SqlCommand cmdInsert = new SqlCommand();
                            cmdInsert.Connection = db;
                            cmdInsert.CommandText = "insert into Contas (Nome,Pass) values (@nome, @pass)";

                            cmdInsert.Parameters.Add("@nome", SqlDbType.VarChar).Value = UserSQL;
                            cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = PassSQL;


                            int recAfectados = cmdInsert.ExecuteNonQuery();

                            MessageBox.Show($"\n Foram Inseridos {recAfectados} registros !");
                        }
                    }
                    MapaF.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"\nErro: {ex.Message}");
                }
            }
        }
    }
}
