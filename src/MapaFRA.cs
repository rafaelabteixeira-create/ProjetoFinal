using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Windows.Forms;

namespace idea
{
    public partial class MapaFRA : Form
    {
        PontosProv pontosprov = new PontosProv();

        private Dictionary<string, ProvinceData> provinces = new Dictionary<string, ProvinceData>();
        private List<ProvinceData> vizinhosAtivos = new List<ProvinceData>();
        private MapPanel mapPanel;

        public static string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Projeto2Ano; Trusted_Connection = True";

        private ProvinceData provinciasSelecionada = null;

        int turnos = 0;
        int limite = 0;
        int estabilidade = 40;
        int conta = 5;
        bool estabilidadeBotao = true;
        bool DivBotao = false;
        bool warW = false;
        bool warEventMostrado = false;
        bool winEventMostrado = false;
        bool lim1 = false;
        bool lim2 = false;

        ClassDatabase db = new ClassDatabase();

        public MapaFRA()
        {

            InitializeComponent();

            this.Text = "Mapa de Províncias";
            this.ClientSize = new Size(1200, 1200);
            this.MaximizeBox = false;

            CriarProvincias();
            DefinirVizinhos();
            CriarMapaPanel();


            Stability.Text = estabilidade + "%";


            if (db.Conf(0, 1) == 1)
            {
                pictureBox2.Image = Properties.Resources.FlagEUON;
            }


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
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });


            provinces.Add("Paris", new ProvinceData
            {
                Name = "Paris",
                Points = pontosprov.ProvinciaParis,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 7,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Calais", new ProvinceData
            {
                Name = "Calais",
                Points = pontosprov.ProvinciaCalais,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 3,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Normandy", new ProvinceData
            {
                Name = "Normandy",
                Points = pontosprov.ProvinciaNormandy,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 1,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Orleans", new ProvinceData
            {
                Name = "Orleans",
                Points = pontosprov.ProvinciaOrleans,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 4,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Brittany", new ProvinceData
            {
                Name = "Brittany",
                Points = pontosprov.ProvinciaBrittany,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Metz", new ProvinceData
            {
                Name = "Metz",
                Points = pontosprov.ProvinciaMetz,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 5,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Strasbourg", new ProvinceData
            {
                Name = "Strasbourg",
                Points = pontosprov.ProvinciaStrasbourg,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Nantes", new ProvinceData
            {
                Name = "Nantes",
                Points = pontosprov.ProvinciaNantes,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 5,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Bordeux", new ProvinceData
            {
                Name = "Bordeux",
                Points = pontosprov.ProvinciaBordeux,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Massif", new ProvinceData
            {
                Name = "Massif",
                Points = pontosprov.ProvinciaMassifCentral,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Toulouse", new ProvinceData
            {
                Name = "Toulouse",
                Points = pontosprov.ProvinciaToulouse,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Marseille", new ProvinceData
            {
                Name = "Marseille",
                Points = pontosprov.ProvinciaMarseille,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Nice", new ProvinceData
            {
                Name = "Nice",
                Points = pontosprov.ProvinciaNice,
                CorP = Color.LightBlue,
                CorOriginal = Color.LightBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Wallonia", new ProvinceData
            {
                Name = "Wallonia",
                Points = pontosprov.ProvinciaWallonia,
                CorP = Color.LightYellow,
                CorOriginal = Color.LightYellow,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Brussels", new ProvinceData
            {
                Name = "Brussels",
                Points = pontosprov.ProvinciaBruxelas,
                CorP = Color.LightYellow,
                CorOriginal = Color.LightYellow,
                Value = 3,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Flanders", new ProvinceData
            {
                Name = "Flanders",
                Points = pontosprov.ProvinciaFlanders,
                CorP = Color.LightYellow,
                CorOriginal = Color.LightYellow,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Liege", new ProvinceData
            {
                Name = "Liege",
                Points = pontosprov.ProvinciaLiege,
                CorP = Color.LightYellow,
                CorOriginal = Color.LightYellow,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Luxembourg", new ProvinceData
            {
                Name = "Luxembourg",
                Points = pontosprov.ProvinciaLuxembourg,
                CorP = Color.CornflowerBlue,
                CorOriginal = Color.CornflowerBlue,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Amsterdam", new ProvinceData
            {
                Name = "Amsterdam",
                Points = pontosprov.ProvinciaAmsterdam,
                CorP = Color.DarkOrange,
                CorOriginal = Color.DarkOrange,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Rotterdam", new ProvinceData
            {
                Name = "Rotterdam",
                Points = pontosprov.ProvinciaRoterdam,
                CorP = Color.DarkOrange,
                CorOriginal = Color.DarkOrange,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Eindhoven", new ProvinceData
            {
                Name = "Eindhoven",
                Points = pontosprov.ProvinciaEindhoven,
                CorP = Color.DarkOrange,
                CorOriginal = Color.DarkOrange,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Saarland", new ProvinceData
            {
                Name = "Saarland",
                Points = pontosprov.ProvinciaSaarland,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Rhine do Sul", new ProvinceData
            {
                Name = "Rhine do Sul",
                Points = pontosprov.ProvinciaSulRhine,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 6,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Rhine do Norte", new ProvinceData
            {
                Name = "Rhine do Norte",
                Points = pontosprov.ProvinciaNorteRhine,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Frankfurt", new ProvinceData
            {
                Name = "Frakfurt",
                Points = pontosprov.ProvinciaFrankfurt,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Bavaria", new ProvinceData
            {
                Name = "Baviéra",
                Points = pontosprov.ProvinciaBavaria,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Baden-Wurttenberg", new ProvinceData
            {
                Name = "Baden-Wurttenberg",
                Points = pontosprov.ProvinciaBaden,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 2,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Dresden", new ProvinceData
            {
                Name = "Dresden",
                Points = pontosprov.ProvinciaDresden,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 4,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Bradenbourg", new ProvinceData
            {
                Name = "Bradenbourgo",
                Points = pontosprov.ProvinciaBrandenburg,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Schwern", new ProvinceData
            {
                Name = "Schwern",
                Points = pontosprov.ProvinciaSchwern,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Kiel", new ProvinceData
            {
                Name = "Kiel",
                Points = pontosprov.ProvinciaKiel,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 1,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Hambourg", new ProvinceData
            {
                Name = "Hambourg",
                Points = pontosprov.ProvinciaHamburg,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 2,
                War = false,    
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Berlin", new ProvinceData
            {
                Name = "Berlin",
                Points = pontosprov.ProvinciaBerlin,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 1,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Magdebourg", new ProvinceData
            {
                Name = "Magdebourgo",
                Points = pontosprov.ProvinciaMagdeburg,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Bremen", new ProvinceData
            {
                Name = "Bremen",
                Points = pontosprov.ProvinciaBremen,
                CorP = Color.LightGray,
                CorOriginal = Color.LightGray,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Austria", new ProvinceData
            {
                Name = "Austria",
                Points = pontosprov.ProvinciaAustria,
                CorP = Color.GhostWhite,
                CorOriginal = Color.GhostWhite,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Geneva", new ProvinceData
            {
                Name = "Geneva",
                Points = pontosprov.ProvinciaGeneva,
                CorP = Color.IndianRed,
                CorOriginal = Color.IndianRed,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Berne", new ProvinceData
            {
                Name = "Berne",
                Points = pontosprov.ProvinciaBerne,
                CorP = Color.IndianRed,
                CorOriginal = Color.IndianRed,
                Value = 0,
                War = false,
                Vizinhos = new List<ProvinceData>()
            });

            provinces.Add("Mark", new ProvinceData
            {
                Name = "Dinamarca",
                Points = pontosprov.ProvinciaMark,
                CorP = Color.OrangeRed,
                CorOriginal = Color.OrangeRed,
                Value = 0,
                War = false,
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
            provinces["Calais"].Vizinhos.Add(provinces["Orleans"]);

            provinces["Normandy"].Vizinhos.Add(provinces["Calais"]);
            provinces["Normandy"].Vizinhos.Add(provinces["Brittany"]);
            provinces["Normandy"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Normandy"].Vizinhos.Add(provinces["Nantes"]);

            provinces["Brittany"].Vizinhos.Add(provinces["Nantes"]);
            provinces["Brittany"].Vizinhos.Add(provinces["Normandy"]);

            provinces["Nantes"].Vizinhos.Add(provinces["Massif"]);
            provinces["Nantes"].Vizinhos.Add(provinces["Brittany"]);
            provinces["Nantes"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Nantes"].Vizinhos.Add(provinces["Normandy"]);
            provinces["Nantes"].Vizinhos.Add(provinces["Bordeux"]);

            provinces["Orleans"].Vizinhos.Add(provinces["Paris"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Calais"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Massif"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Metz"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Strasbourg"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Normandy"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Geneva"]);
            provinces["Orleans"].Vizinhos.Add(provinces["Nantes"]);

            provinces["Massif"].Vizinhos.Add(provinces["Toulouse"]);
            provinces["Massif"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Massif"].Vizinhos.Add(provinces["Nantes"]);
            provinces["Massif"].Vizinhos.Add(provinces["Nice"]);
            provinces["Massif"].Vizinhos.Add(provinces["Marseille"]);
            provinces["Massif"].Vizinhos.Add(provinces["Geneva"]);

            provinces["Bordeux"].Vizinhos.Add(provinces["Toulouse"]);
            provinces["Bordeux"].Vizinhos.Add(provinces["Nantes"]);

            provinces["Toulouse"].Vizinhos.Add(provinces["Bordeux"]);
            provinces["Toulouse"].Vizinhos.Add(provinces["Marseille"]);
            provinces["Toulouse"].Vizinhos.Add(provinces["Massif"]);

            provinces["Nice"].Vizinhos.Add(provinces["Marseille"]);
            provinces["Nice"].Vizinhos.Add(provinces["Massif"]);
            provinces["Nice"].Vizinhos.Add(provinces["Geneva"]);

            provinces["Marseille"].Vizinhos.Add(provinces["Nice"]);
            provinces["Marseille"].Vizinhos.Add(provinces["Massif"]);
            provinces["Marseille"].Vizinhos.Add(provinces["Toulouse"]);

            provinces["Strasbourg"].Vizinhos.Add(provinces["Metz"]);
            provinces["Strasbourg"].Vizinhos.Add(provinces["Geneva"]);
            provinces["Strasbourg"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Strasbourg"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);

            provinces["Metz"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Metz"].Vizinhos.Add(provinces["Calais"]);
            provinces["Metz"].Vizinhos.Add(provinces["Strasbourg"]);
            provinces["Metz"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);
            provinces["Metz"].Vizinhos.Add(provinces["Rhine do Sul"]);
            provinces["Metz"].Vizinhos.Add(provinces["Saarland"]);
            provinces["Metz"].Vizinhos.Add(provinces["Luxembourg"]);

            provinces["Geneva"].Vizinhos.Add(provinces["Orleans"]);
            provinces["Geneva"].Vizinhos.Add(provinces["Massif"]);
            provinces["Geneva"].Vizinhos.Add(provinces["Strasbourg"]);
            provinces["Geneva"].Vizinhos.Add(provinces["Nice"]);
            provinces["Geneva"].Vizinhos.Add(provinces["Berne"]);

            provinces["Berne"].Vizinhos.Add(provinces["Geneva"]);
            provinces["Berne"].Vizinhos.Add(provinces["Austria"]);
            provinces["Berne"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);

            provinces["Luxembourg"].Vizinhos.Add(provinces["Liege"]);
            provinces["Luxembourg"].Vizinhos.Add(provinces["Wallonia"]);
            provinces["Luxembourg"].Vizinhos.Add(provinces["Calais"]);
            provinces["Luxembourg"].Vizinhos.Add(provinces["Metz"]);
            provinces["Luxembourg"].Vizinhos.Add(provinces["Saarland"]);
            provinces["Luxembourg"].Vizinhos.Add(provinces["Rhine do Sul"]);

            provinces["Austria"].Vizinhos.Add(provinces["Berne"]);
            provinces["Austria"].Vizinhos.Add(provinces["Bavaria"]);
            provinces["Austria"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);

            provinces["Mark"].Vizinhos.Add(provinces["Kiel"]);

            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Rhine do Sul"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Frankfurt"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Strasbourg"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Metz"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Austria"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Bavaria"]);
            provinces["Baden-Wurttenberg"].Vizinhos.Add(provinces["Berne"]);

            provinces["Bavaria"].Vizinhos.Add(provinces["Austria"]);
            provinces["Bavaria"].Vizinhos.Add(provinces["Frankfurt"]);
            provinces["Bavaria"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);

            provinces["Frankfurt"].Vizinhos.Add(provinces["Bavaria"]);
            provinces["Frankfurt"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);
            provinces["Frankfurt"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Frankfurt"].Vizinhos.Add(provinces["Rhine do Sul"]);
            provinces["Frankfurt"].Vizinhos.Add(provinces["Rhine do Norte"]);
            provinces["Frankfurt"].Vizinhos.Add(provinces["Bremen"]);

            provinces["Dresden"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Dresden"].Vizinhos.Add(provinces["Bradenbourg"]);

            provinces["Berlin"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Berlin"].Vizinhos.Add(provinces["Bradenbourg"]);

            provinces["Bradenbourg"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Bradenbourg"].Vizinhos.Add(provinces["Schwern"]);
            provinces["Bradenbourg"].Vizinhos.Add(provinces["Dresden"]);
            provinces["Bradenbourg"].Vizinhos.Add(provinces["Berlin"]);

            provinces["Magdebourg"].Vizinhos.Add(provinces["Bradenbourg"]);
            provinces["Magdebourg"].Vizinhos.Add(provinces["Frankfurt"]);
            provinces["Magdebourg"].Vizinhos.Add(provinces["Dresden"]);
            provinces["Magdebourg"].Vizinhos.Add(provinces["Berlin"]);
            provinces["Magdebourg"].Vizinhos.Add(provinces["Schwern"]);
            provinces["Magdebourg"].Vizinhos.Add(provinces["Bremen"]);

            provinces["Schwern"].Vizinhos.Add(provinces["Kiel"]);
            provinces["Schwern"].Vizinhos.Add(provinces["Hambourg"]);
            provinces["Schwern"].Vizinhos.Add(provinces["Bremen"]);
            provinces["Schwern"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Schwern"].Vizinhos.Add(provinces["Bradenbourg"]);

            provinces["Kiel"].Vizinhos.Add(provinces["Hambourg"]);
            provinces["Kiel"].Vizinhos.Add(provinces["Mark"]);
            provinces["Kiel"].Vizinhos.Add(provinces["Schwern"]);

            provinces["Hambourg"].Vizinhos.Add(provinces["Bremen"]);
            provinces["Hambourg"].Vizinhos.Add(provinces["Kiel"]);
            provinces["Hambourg"].Vizinhos.Add(provinces["Schwern"]);

            provinces["Bremen"].Vizinhos.Add(provinces["Hambourg"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Kiel"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Magdebourg"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Schwern"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Rhine do Norte"]);
            provinces["Bremen"].Vizinhos.Add(provinces["Frankfurt"]);

            provinces["Rhine do Norte"].Vizinhos.Add(provinces["Bremen"]);
            provinces["Rhine do Norte"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Rhine do Norte"].Vizinhos.Add(provinces["Rhine do Sul"]);
            provinces["Rhine do Norte"].Vizinhos.Add(provinces["Frankfurt"]);

            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Saarland"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Liege"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Rhine do Norte"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Frankfurt"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Metz"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Baden-Wurttenberg"]);
            provinces["Rhine do Sul"].Vizinhos.Add(provinces["Luxembourg"]);

            provinces["Saarland"].Vizinhos.Add(provinces["Luxembourg"]);
            provinces["Saarland"].Vizinhos.Add(provinces["Metz"]);
            provinces["Saarland"].Vizinhos.Add(provinces["Rhine do Sul"]);

            provinces["Brussels"].Vizinhos.Add(provinces["Flanders"]);
            provinces["Brussels"].Vizinhos.Add(provinces["Wallonia"]);

            provinces["Liege"].Vizinhos.Add(provinces["Wallonia"]);
            provinces["Liege"].Vizinhos.Add(provinces["Luxembourg"]);
            provinces["Liege"].Vizinhos.Add(provinces["Rhine do Sul"]);

            provinces["Wallonia"].Vizinhos.Add(provinces["Brussels"]);
            provinces["Wallonia"].Vizinhos.Add(provinces["Liege"]);
            provinces["Wallonia"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Wallonia"].Vizinhos.Add(provinces["Flanders"]);
            provinces["Wallonia"].Vizinhos.Add(provinces["Calais"]);
            provinces["Wallonia"].Vizinhos.Add(provinces["Luxembourg"]);

            provinces["Flanders"].Vizinhos.Add(provinces["Brussels"]);
            provinces["Flanders"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Flanders"].Vizinhos.Add(provinces["Wallonia"]);
            provinces["Flanders"].Vizinhos.Add(provinces["Calais"]);
            provinces["Flanders"].Vizinhos.Add(provinces["Amsterdam"]);

            provinces["Amsterdam"].Vizinhos.Add(provinces["Flanders"]);
            provinces["Amsterdam"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Amsterdam"].Vizinhos.Add(provinces["Rotterdam"]);

            provinces["Rotterdam"].Vizinhos.Add(provinces["Eindhoven"]);
            provinces["Rotterdam"].Vizinhos.Add(provinces["Amsterdam"]);

            provinces["Eindhoven"].Vizinhos.Add(provinces["Flanders"]);
            provinces["Eindhoven"].Vizinhos.Add(provinces["Wallonia"]);
            provinces["Eindhoven"].Vizinhos.Add(provinces["Amsterdam"]);
            provinces["Eindhoven"].Vizinhos.Add(provinces["Rotterdam"]);
            provinces["Eindhoven"].Vizinhos.Add(provinces["Bremen"]);
            provinces["Eindhoven"].Vizinhos.Add(provinces["Rhine do Norte"]);
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
                Color cor = prov.CorP;


                if (prov == provinciasSelecionada)
                {
                    cor = Color.Yellow;
                }

                else if (vizinhosAtivos != null && vizinhosAtivos.Contains(prov))
                {
                    cor = Color.DarkSalmon;
                }

                using (SolidBrush brush = new SolidBrush(cor))
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

                using (Font font = new Font("Arial", 10, FontStyle.Bold))
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
            foreach (var prov in provinces.Values)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddPolygon(prov.Points.ToArray());

                    using (Region region = new Region(path))
                    {
                        if (!region.IsVisible(e.Location))
                            continue;
                        if (prov.CorP == Color.LightBlue)
                        {
                            prov.War = true;
                        }
                        if (db.Conf(2, 0) == 1)
                        {

                        }
                        if (prov.War == true)
                        {

                            if (provinciasSelecionada != null && provinciasSelecionada.Vizinhos.Contains(prov))
                            {
                                if (limite >= 3)
                                {
                                    MessageBox.Show("Só pode mover 3 casas");
                                    provinciasSelecionada = null;
                                    mapPanel.Invalidate();
                                }
                                else
                                {
                                    if (prov.CorP == Color.LightBlue && provinciasSelecionada.CorP == Color.LightBlue)
                                    {
                                        prov.Value = provinciasSelecionada.Value + prov.Value;
                                        provinciasSelecionada.Value = 0;
                                        mapPanel.Invalidate();
                                        limite++;
                                    }
                                    else
                                    {
                                        db.Batalha(provinciasSelecionada, prov);

                                        provinciasSelecionada = null;
                                        vizinhosAtivos.Clear();

                                        mapPanel.Invalidate();
                                        limite++;
                                    }



                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("País Neutro");
                        }


                        if (prov.CorP == Color.LightBlue)
                        {
                            provinciasSelecionada = prov;

                            vizinhosAtivos = prov.Vizinhos.ToList();


                        }
                        else
                        {
                            provinciasSelecionada = null;
                            vizinhosAtivos.Clear();
                        }

                        mapPanel.Invalidate();
                        return;
                    }
                }
            }

            provinciasSelecionada = null;
            vizinhosAtivos.Clear();
            mapPanel.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Quer mesmo passar o turno ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            SoundPlayer Hino = new SoundPlayer(Properties.Resources.FranceWin);
            SoundPlayer WarM = new SoundPlayer(Properties.Resources.FranceWar);




            FranceWar franceWar = new FranceWar();
            Europe_War E_War_Screen = new Europe_War();

            if (x == DialogResult.Yes)
            {
                turnos = db.contadorT(turnos);
                button1.Text = "Turno:" + turnos;
                estabilidade = db.Destabilizador(estabilidade);

                limite = 0;
                if (db.Conf(0, 0) == 1)
                {
                    if (lim1 == false) { estabilidade -= 20; lim1 = true; }

                    Lider.Image = Properties.Resources.Captura_de_ecrã_2026_06_29_095922;


                }
                if (db.Conf(1, 0) == 1)
                {
                    if (lim2 == false) { estabilidade += 40; lim2 = true; }
                    Lider.Image = Properties.Resources.Captura_de_ecrã_2026_06_29_095922;


                }

                foreach (var prov in provinces.Values)
                {

                    Stability.Text = estabilidade + "%";
                    if (prov.CorP == Color.LightGray && warW == true)
                    {
                        prov.CorP = Color.LightBlue;
                        mapPanel.Invalidate();
                    }
                    if (db.Conf(2, 0) == 1)
                    {
                        if (prov.CorP == Color.IndianRed)
                        {
                            prov.CorP = Color.LightBlue;
                        }
                        mapPanel.Invalidate();

                    }
                    if (db.Conf(3, 0) == 1)
                    {
                        if (prov.CorP == Color.LightYellow || prov.CorP == Color.DarkOrange)
                        {
                            prov.War = true;
                        }

                    }
                    mapPanel.Invalidate();
                    if (db.Conf(4, 0) == 1)
                    {
                        if (prov.CorP == Color.LightGray)
                        {
                            prov.War = true;
                        }
                        if (db.Conf(4, 0) == 1 && warEventMostrado == false)
                        {
                            franceWar.Show();
                            WarM.Play();
                            mapPanel.Invalidate();
                            warEventMostrado = true;
                        }


                    }
                    if (db.Conf(5, 0) == 1)
                    {
                        if (prov.CorP == Color.GhostWhite|| prov.CorP == Color.OrangeRed)
                        {
                            prov.CorP = Color.LightBlue;
                            prov.Value = 7;
                        }
                    }
                    if (estabilidadeBotao == false)
                    {
                        conta--;
                        if (conta < 0)
                        {
                            estabilidadeBotao = true;
                        }
                    }

                    else if (estabilidade < 0)
                    {
                        MessageBox.Show("Perdeu o jogo");
                        Application.Exit();
                    }
                    DivBotao = false;
                    if (prov.CorP == Color.LightBlue && prov.Name == "Berlin")
                    {
                        warW = true;
                        Hino.Play();
                    }

                    try
                    {
                        GuardarProvincias(provinces);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"\nErro: {ex.Message}");
                    }
                }


            }
        }



        public void CarregarProvincias(Dictionary<string, ProvinceData> provinces)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Nome, Controlador, N_Tropas, Paz_War FROM Provincias";

                    using (var cmd = new SqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nome = reader.GetString(0);
                            string controlador = reader.IsDBNull(1) ? null : reader.GetString(1);
                            int tropas = reader.GetInt32(2);
                            bool emGuerra = reader.GetBoolean(3);

                            if (provinces.TryGetValue(nome, out ProvinceData p))
                            {
                                p.Value = tropas;
                                p.War = emGuerra;
                                p.Controlador = controlador;

                                if (controlador != null)
                                {
                                    Color cor = db.TagParaCor(controlador);
                                    p.CorP = cor;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\nErro: {ex.Message}");
            }

        }
        public void GuardarProvincias(Dictionary<string, ProvinceData> provinces)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    string sql = @"UPDATE Provincias 
                            SET Controlador = @Controlador, 
                                N_Tropas = @N_Tropas, 
                                Paz_War = @Paz_War 
                            WHERE Nome = @Nome";

                    foreach (var kvp in provinces)
                    {
                        string nomeChave = kvp.Key;
                        ProvinceData p = kvp.Value;
                        string tag = db.CorParaTag(p.CorP);

                        using (var cmd = new SqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Nome", nomeChave);
                            cmd.Parameters.AddWithValue("@Controlador", (object)tag ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@N_Tropas", p.Value);
                            cmd.Parameters.AddWithValue("@Paz_War", p.War);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
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
            FocoFRA focoFRA = new FocoFRA();
            focoFRA.Show();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Manpower_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (estabilidadeBotao == true)
            {
                estabilidade += 15;
                estabilidadeBotao = false;
                button5.Enabled = false;
                MessageBox.Show($"Poderá construir mais Infrastrutura em {conta} turnos");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProvinceData provinceData = new ProvinceData();
            if (DivBotao == false)
            {
                foreach (var prov in provinces.Values)
                {
                    if (prov.Name == "Paris")
                    {
                        prov.Value += 2;
                    }

                    if (prov.Name == "Rhine do Sul")
                    {
                        prov.Value += 2;
                    }
                    else if (prov.Name == "Baden-Wurttenberg")
                    {
                        prov.Value += 2;
                    }
                    mapPanel.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Só pode treinar 2 divisões por turno ");
            }
            DivBotao = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CarregarProvincias(provinces);
            mapPanel.Invalidate();
        }
    }


    public class MapPanel2 : Panel
    {
        public MapPanel2()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }
    }


    public class ProvinceData2
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
        public Color CorP { get; set; }
        public Color CorOriginal { get; set; }
        public string Controlador { get; set; }
        public int Value { get; set; }
        public List<ProvinceData> Vizinhos { get; set; }
        public bool War;
    }

}
