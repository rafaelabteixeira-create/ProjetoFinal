using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace idea
{
    public partial class MapaGER : Form
    {
        PontosProv pontosprov = new PontosProv();

        private Dictionary<string, ProvinceData> provinces = new Dictionary<string, ProvinceData>();
        private MapPanel mapPanel;
        
        private ProvinceData provinciasSelecionada = null;

        int turnos = 0;

        ClassDatabase db = new ClassDatabase();

        public MapaGER()
        {
            InitializeComponent();

            this.Text = "Mapa de Províncias";
            this.ClientSize = new Size(1200, 1200);
            this.MaximizeBox = false;

            CriarProvincias();
            DefinirVizinhos();
            CriarMapaPanel();
        }

        private void CriarMapaPanel()
        {
            mapPanel = new MapPanel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 1200),
                BackColor = Color.FromArgb(9, 131, 140)
            };

            mapPanel.Paint += MapPanel_Paint;
            mapPanel.MouseClick += MapPanel_MouseClick;

            this.Controls.Add(mapPanel);
        }

        private void CriarProvincias()
        {
            provinces.Add("Corsica", new ProvinceData
            {
                Name = "Corsica",
                Points = pontosprov.ProvinciaCOR,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Paris", new ProvinceData
            {
                Name = "Paris",
                Points = pontosprov.ProvinciaParis,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Calais", new ProvinceData
            {
                Name = "Calais",
                Points = pontosprov.ProvinciaCalais,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Normandy", new ProvinceData
            {
                Name = "Normandy",
                Points = pontosprov.ProvinciaNormandy,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Orleans", new ProvinceData
            {
                Name = "Orleans",
                Points = pontosprov.ProvinciaOrleans,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Brittany", new ProvinceData
            {
                Name = "Brittany",
                Points = pontosprov.ProvinciaBrittany,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Metz", new ProvinceData
            {
                Name = "Metz",
                Points = pontosprov.ProvinciaMetz,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Strasbourg", new ProvinceData
            {
                Name = "Strasbourg",
                Points = pontosprov.ProvinciaStrasbourg,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Nantes", new ProvinceData
            {
                Name = "Nantes",
                Points = pontosprov.ProvinciaNantes,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Bordeux", new ProvinceData
            {
                Name = "Bordeux",
                Points = pontosprov.ProvinciaBordeux,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Massif", new ProvinceData
            {
                Name = "Massif",
                Points = pontosprov.ProvinciaMassifCentral,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Toulouse", new ProvinceData
            {
                Name = "Toulouse",
                Points = pontosprov.ProvinciaToulouse,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Marseille", new ProvinceData
            {
                Name = "Marseille",
                Points = pontosprov.ProvinciaMarseille,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Nice", new ProvinceData
            {
                Name = "Nice",
                Points = pontosprov.ProvinciaNice,
                Color = Color.LightBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Wallonia", new ProvinceData
            {
                Name = "Wallonia",
                Points = pontosprov.ProvinciaWallonia,
                Color = Color.LightYellow,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Brussels", new ProvinceData
            {
                Name = "Brussels",
                Points = pontosprov.ProvinciaBruxelas,
                Color = Color.LightYellow,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Flanders", new ProvinceData
            {
                Name = "Flanders",
                Points = pontosprov.ProvinciaFlanders,
                Color = Color.LightYellow,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Liege", new ProvinceData
            {
                Name = "Liege",
                Points = pontosprov.ProvinciaLiege,
                Color = Color.LightYellow,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Luxembourg", new ProvinceData
            {
                Name = "Luxembourg",
                Points = pontosprov.ProvinciaLuxembourg,
                Color = Color.CornflowerBlue,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Amsterdam", new ProvinceData
            {
                Name = "Amsterdam",
                Points = pontosprov.ProvinciaAmsterdam,
                Color = Color.DarkOrange,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Rotterdam", new ProvinceData
            {
                Name = "Rotterdam",
                Points = pontosprov.ProvinciaRoterdam,
                Color = Color.DarkOrange,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Eindhoven", new ProvinceData
            {
                Name = "Eindhoven",
                Points = pontosprov.ProvinciaEindhoven,
                Color = Color.DarkOrange,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Saarland", new ProvinceData
            {
                Name = "Saarland",
                Points = pontosprov.ProvinciaSaarland,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Rhine do Sul", new ProvinceData
            {
                Name = "Rhine do Sul",
                Points = pontosprov.ProvinciaSulRhine,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Rhine do Norte", new ProvinceData
            {
                Name = "Rhine do Norte",
                Points = pontosprov.ProvinciaNorteRhine,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Frankfurt", new ProvinceData
            {
                Name = "Frakfurt",
                Points = pontosprov.ProvinciaFrankfurt,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Baviéra", new ProvinceData
            {
                Name = "Baviéra",
                Points = pontosprov.ProvinciaBavaria,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Baden-Wurttenberg", new ProvinceData
            {
                Name = "Baden-Wurttenberg",
                Points = pontosprov.ProvinciaBaden,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Dresden", new ProvinceData
            {
                Name = "Dresden",
                Points = pontosprov.ProvinciaDresden,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Bradenbourg", new ProvinceData
            {
                Name = "Bradenbourgo",
                Points = pontosprov.ProvinciaBrandenburg,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Schwern", new ProvinceData
            {
                Name = "Schwern",
                Points = pontosprov.ProvinciaSchwern,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Kiel", new ProvinceData
            {
                Name = "Kiel",
                Points = pontosprov.ProvinciaKiel,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Hambourg", new ProvinceData
            {
                Name = "Hambourg",
                Points = pontosprov.ProvinciaHamburg,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Berlin", new ProvinceData
            {
                Name = "Berlim",
                Points = pontosprov.ProvinciaBerlin,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Magdebourg", new ProvinceData
            {
                Name = "Magdebourgo",
                Points = pontosprov.ProvinciaMagdeburg,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Bremen", new ProvinceData
            {
                Name = "Bremen",
                Points = pontosprov.ProvinciaBremen,
                Color = Color.LightGray,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Austria", new ProvinceData
            {
                Name = "Austria",
                Points = pontosprov.ProvinciaAustria,
                Color = Color.GhostWhite,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Geneva", new ProvinceData
            {
                Name = "Geneva",
                Points = pontosprov.ProvinciaGeneva,
                Color = Color.IndianRed,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Berne", new ProvinceData
            {
                Name = "Berne",
                Points = pontosprov.ProvinciaBerne,
                Color = Color.IndianRed,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
            provinces.Add("Mark", new ProvinceData
            {
                Name = "Dinamarca",
                Points = pontosprov.ProvinciaMark,
                Color = Color.OrangeRed,
                Value = 0,
                Vizinhos = new List<ProvinceData>()
            });
        }
        private void DefinirVizinhos()
        {
            provinces["Paris"].Vizinhos.Add(provinces["Calais"]);
            provinces["Paris"].Vizinhos.Add(provinces["Orleans"]);


            provinces["Calais"].Vizinhos.Add(provinces["Paris"]);
            provinces["Calais"].Vizinhos.Add(provinces["Wallonia"]);
            provinces["Calais"].Vizinhos.Add(provinces["Flanders"]);
            provinces["Calais"].Vizinhos.Add(provinces["Luxembourg"]);
            provinces["Calais"].Vizinhos.Add(provinces["Metz"]);
            provinces["Calais"].Vizinhos.Add(provinces["Normandy"]);

        }

        private Point GetCenter(List<Point> points)
        {
            int x = 0, y = 0;

            foreach (var p in points)
            {
                x += p.X;
                y += p.Y;
            }

            return new Point(x / points.Count, y / points.Count);
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(mapPanel.BackColor);

            foreach (var prov in provinces.Values)
            {
                using (SolidBrush brush = new SolidBrush(prov.Color))
                {
                    g.FillPolygon(brush, prov.Points.ToArray());
                }

                g.DrawPolygon(Pens.Black, prov.Points.ToArray());


                Point center = GetCenter(prov.Points);

                if (prov.Name == "Rotterdam")
                {
                    center.Y += 20;
                }
                else if (prov.Name == "Nice")
                {
                    center.X -= 10;
                }
                else if (prov.Name == "Austria")
                {
                    center.X += 50;
                    center.Y += 13;
                }

                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    string text = prov.Value.ToString();
                    SizeF size = g.MeasureString(text, font);

                    g.DrawString(text, font, textBrush, center.X - size.Width / 2, center.Y - size.Height / 2);
                }
            }
        }
        
        private void MapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var prov in provinces)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddPolygon(prov.Value.Points.ToArray());
                    using (Region region = new Region(path))
                    {
                        if (region.IsVisible(e.Location))
                        {
                            
                            if (provinciasSelecionada != null)
                            {
                                provinciasSelecionada.Color = Color.LightBlue;
                                foreach (var vizinho in provinciasSelecionada.Vizinhos)
                                    vizinho.Color = Color.LightBlue;
                            }

                           
                            if (provinciasSelecionada == prov.Value)
                            {
                                provinciasSelecionada = null;
                                mapPanel.Invalidate();
                                return;
                            }

                            
                            if (provinciasSelecionada != null && provinciasSelecionada.Vizinhos.Contains(prov.Value))
                            {
                                MessageBox.Show($"Atacando {prov.Value.Name} a partir de {provinciasSelecionada.Name}!");
                                provinciasSelecionada = null;
                                mapPanel.Invalidate();
                                return;
                            }

                            
                            provinciasSelecionada = prov.Value;
                            provinciasSelecionada.Color = Color.Yellow; 

                            foreach (var vizinho in provinciasSelecionada.Vizinhos)
                                vizinho.Color = Color.DarkSalmon; 

                            mapPanel.Invalidate();
                            return;
                        }
                    }
                }
            }
            if (provinciasSelecionada != null)
            {
                provinciasSelecionada.Color = Color.LightBlue;
                foreach (var vizinho in provinciasSelecionada.Vizinhos)
                    vizinho.Color = Color.LightBlue;

                provinciasSelecionada = null;
                mapPanel.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Quer mesmo passar o turno ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                turnos = db.contadorT(turnos); button1.Text = "Turno:" + turnos;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Focu_Click(object sender, EventArgs e)
        {
            FocoGER focoGER = new FocoGER();
            focoGER.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }



    }


    public class MapPanel : Panel
    {
        public MapPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
    public class ProvinceData
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
        public Color Color { get; set; }
        public int Value { get; set; }
        public List<ProvinceData> Vizinhos { get; set; }
    }
}