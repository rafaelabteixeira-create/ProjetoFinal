using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Data.SqlClient;
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

        public static int[,] PosFoco = new int[7, 2];

        public static int NF1;
        public static int NF2;

        

        public string CorParaTag(Color cor)
        {
            if (cor == Color.LightGray) return "GER";
            if (cor == Color.LightBlue) return "FRA";
            if (cor == Color.LightYellow) return "BEL";
            if (cor == Color.CornflowerBlue) return "LUX";
            if (cor == Color.DarkOrange) return "NED";
            if (cor == Color.GhostWhite) return "AUS";
            if (cor == Color.IndianRed) return "SWI";
            if (cor == Color.OrangeRed) return "MRK";
            return null;
        }
        
        public Color TagParaCor(string tag)
        {
            switch (tag)
            {
                case "GER": return Color.LightGray;
                case "FRA": return Color.LightBlue;
                case "BEL": return Color.LightYellow;
                case "LUX": return Color.CornflowerBlue;
                case "NED": return Color.DarkOrange;
                case "AUS": return Color.GhostWhite;
                case "SWI": return Color.IndianRed;
                case "MRK": return Color.OrangeRed;
                default: return Color.White;
            }
        }







        SoundPlayer HinoEU = new SoundPlayer(Properties.Resources.EU_Anthem);
        EU_Victory_Screen E_W_Screen = new EU_Victory_Screen();


        public int contadorT(int contador)
        {
            contador++;

            Turnos2++;

            if (Turnos2 == Dif)
            {
                MessageBox.Show($"Terminou o foco");
                Dif = 0;
                PosFoco[NF1, NF2] = 1;




            }
            return contador;
        }
        public int Destabilizador(int contador)
        {
            contador -= 2;
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
                    NF1 = numF1;
                    NF2 = numF2;
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
            if (1 == PosFoco[num1, num2])
            {
                res = 1;
            }
            return res;
        }
        public bool Batalha(ProvinceData atacante, ProvinceData defensor)
        {
            int diferenca = atacante.Value - defensor.Value;
            Random num = new Random();
            double chanceVitoria = 0.5 + (diferenca * 0.015);
            double chanceSub = 0.3;
            bool atacanteVenceu = false;
            atacanteVenceu = num.NextDouble() < chanceVitoria;
            if (atacante.Value == 0)
            {
                atacanteVenceu = false;
            }
            else
            {
                if (defensor.Value == 0)
                {
                    atacanteVenceu = true;
                }
                else
                {
                    for (int i = 0; i < atacante.Value; i++)
                    {
                        chanceVitoria = Math.Max(0.04, Math.Min(0.96, chanceVitoria));
                        if (num.NextDouble() < chanceSub)
                        {
                            atacante.Value--;
                        }
                    }
                }
            }
            if (atacanteVenceu == true)
            {
                defensor.CorP = atacante.CorP;
                defensor.Value = atacante.Value;
                atacante.Value = 0;
            }
            else
            {
            }

            return atacanteVenceu;
        }


    }

}
