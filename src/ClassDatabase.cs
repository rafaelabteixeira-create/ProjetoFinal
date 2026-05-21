using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idea
{
    public class ClassDatabase
    {


        public static string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Projeto2Ano; Trusted_Connection = True";

        public static int Turnos2 = 0;

        public static int Dif = 0;

        public static int[,] PosFoco = new int[5, 1];




        public int contadorT(int contador)
        {
            contador++;

            Turnos2++;

            if (Turnos2 == Dif)
            {
                MessageBox.Show($"Terminou o foco");
                Dif = 0;
            }

            return contador;
        }

        public void FocoTurno(int num, int numF1, int numF2)
        {
            if (PosFoco[numF1, numF2] == 0)
            {
                Turnos2 = 0;
                DialogResult x = MessageBox.Show("Quer mesmo Escolher este fóco ?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {
                    num += Turnos2;
                    MessageBox.Show($"O seu foco vai demorar {num} turnos");
                    Dif = num;
                    PosFoco[numF1, numF2] = 1;
                }
            }
            else
            {
                MessageBox.Show($"Já fez este fóco ou está a decorrer");
            }
        }
        public int Conf(int num1, int num2)
        {
            int res = 0;
            if( 1 == PosFoco[num1,num2])
            {
                res = 1;
            }
            return res;
        }
    }

}
