using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace idea
{
    public partial class MapaGER : Form
    {
        PontosProv pontosprov = new PontosProv();
        
        
        private Dictionary<string, ProvinceData> provinces = new Dictionary<string, ProvinceData>();

        private MapPanel mapPanel;


        int turnos = 0;
        ClassDatabase db = new ClassDatabase();

        public MapaGER()
        {
            InitializeComponent();

            this.Text = "Mapa de Províncias";
            this.MaximizeBox = false;
            this.ClientSize = new Size(1200, 1200);

            CriarProvincias();
            CriarMapaPanel();
        }

        private void CriarMapaPanel()
        {
            mapPanel = new MapPanel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 1200),
                BackColor = Color.FromArgb(0, 80, 160)
            };

            mapPanel.Paint += MapPanel_Paint;
            mapPanel.MouseClick += MapPanel_MouseClick;

            this.Controls.Add(mapPanel);
        }

        private void CriarProvincias()
        {
            provinces.Add("Corsica", new ProvinceData
            {
                Name = "Córsega",
                Points = pontosprov.ProvinciaCOR,
                Color = Color.LightBlue
            });

            provinces.Add("Paris", new ProvinceData
            {
                Name = "Paris",
                Points = pontosprov.ProvinciaParis,
                Color = Color.LightBlue
            });

            provinces.Add("Calais", new ProvinceData
            {
                Name = "Calais",
                Points = pontosprov.ProvinciaCalais,
                Color = Color.LightBlue
            });
            provinces.Add("Normandy", new ProvinceData
            {
                Name = "Normandy",
                Points = pontosprov.ProvinciaNormandy,
                Color = Color.LightBlue
            }
                );
            provinces.Add("Orleans", new ProvinceData
            {
                Name = "Orleans",
                Points = pontosprov.ProvinciaOrleans,
                Color = Color.LightBlue
            });
            provinces.Add("Brittany", new ProvinceData
            {
                Name = "Brittany",
                Points = pontosprov.ProvinciaBrittany,
                Color = Color.LightBlue
            });
            provinces.Add("Metz", new ProvinceData
            {
                Name = "Metz",
                Points = pontosprov.ProvinciaMetz,
                Color = Color.LightBlue
            });
            provinces.Add("Strasbourg", new ProvinceData
            {
                Name = "Strasbourg",
                Points = pontosprov.ProvinciaStrasbourg,
                Color = Color.LightBlue
            });
            provinces.Add("Nantes", new ProvinceData
            {
                Name = "Nantes",
                Points = pontosprov.ProvinciaNantes,
                Color = Color.LightBlue
            });
            provinces.Add("Bordeux", new ProvinceData
            {
                Name = "Bordeux",
                Points = pontosprov.ProvinciaBordeux,
                Color = Color.LightBlue
            });
            provinces.Add("Massif-Central", new ProvinceData
            {
                Name = "Massif-Central",
                Points = pontosprov.ProvinciaMassifCentral,
                Color = Color.LightBlue
            });
            provinces.Add("Toulouse", new ProvinceData
            {
                Name = "Toulouse",
                Points = pontosprov.ProvinciaToulouse,
                Color = Color.LightBlue
            });
            provinces.Add("Marseille", new ProvinceData
            {
                Name = "Marseille",
                Points = pontosprov.ProvinciaMarseille,
                Color = Color.LightBlue
            });
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
                            prov.Value.Color = (prov.Value.Color == Color.LightBlue)
                                                ? Color.Orange : Color.LightBlue;

                            mapPanel.Invalidate();
                            MessageBox.Show($"Clicaste em {prov.Value.Name}!");
                            return;
                        }
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Quer mesmo passar o turno ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                turnos = db.contadorT(turnos);
                button1.Text = "Turno:" +  turnos;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}