using Bitva_Polcovodcev.Classi.Dannie;
using Bitva_Polcovodcev.Classi.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public partial class Igra : Form
    {
        public Igra()
        {
            InitializeComponent();
            panelDeistvie.MouseMove += new MouseEventHandler(PanelDeistvie_Dvijenie);
        }

        Form viborKarti;
        bool vivodSvazei = false, panelPeremeshaut = false;

        private void FormIgra_Load(object sender, EventArgs e)
        {
            Data.bitKartaIgri = Zagruzka.ZagruzkaBitmapKarti("Карта Политій");
            Data.bitKartaTerritorii = Zagruzka.ZagruzkaBitmapKarti("Карта Территорій");

            Zagruzka.ZagruzkaElementovFormiIgra(pictureKarta, panelInterfeis, this);
            Zagruzka.ZagruzkaElementovFormiDlaIgroka(pictureFlag, pictureBrosok, labelNazvanie, labelOD, buttonBrosok, buttonHod, panelInterfeis);

            Zagruzka.Deserelizacia_TerritoriiData(ref Data.territorii, Baza.scenarii[Data.indexScenaria, 5]);

            Zagruzka.ZagruzkaElementovFormiDlaData(this, panelDeistvie, panelMenu);

            Raschet.SmenaIgroka(ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, true, ref panelMenu, ref panelDeistvie);
        }

        private void ButtonBrosok_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int Znachenie = rnd.Next(1, 7);

            switch (Znachenie)
            {
                case 1:
                    pictureBrosok.Image = Properties.Resources.Odin;
                    break;

                case 2:
                    pictureBrosok.Image = Properties.Resources.Dwa;
                    break;

                case 3:
                    pictureBrosok.Image = Properties.Resources.Tri;
                    break;

                case 4:
                    pictureBrosok.Image = Properties.Resources.Chetire;
                    break;

                case 5:
                    pictureBrosok.Image = Properties.Resources.Piat;
                    break;

                case 6:
                    pictureBrosok.Image = Properties.Resources.Chest;
                    break;

            }

            Data.igroki[Data.indexIgroka].KolicestvoOD += Znachenie;

            labelOD.Text = "ОД " + Data.igroki[Data.indexIgroka].KolicestvoOD;

            buttonBrosok.Enabled = false;

            buttonHod.Enabled = true;
        }

        private void ButtonVixod_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ButtonGlavnoeMenu_Click(object sender, EventArgs e)
        {
            viborKarti = new ViborKarti
            {
                Location = new Point(this.Location.X, this.Location.Y)
            };
            this.Visible = false;
            viborKarti.ShowDialog();
            this.Dispose();
        }

        private void PanelDeistvie_Dvijenie(object sender, MouseEventArgs e)
        {
            int dvijenieX = e.X + panelDeistvie.Location.X;
            int dvijenieY = e.Y + panelDeistvie.Location.Y;

            Proverka.ProverkaKoordinatDlaPohodnikov(ref dvijenieX, this.Width);
            Proverka.ProverkaKoordinatDlaPohodnikov(ref dvijenieY, this.Height);

            if (panelPeremeshaut)
            {
                bool vVerh = dvijenieY < panelDeistvie.Location.Y && dvijenieX > panelDeistvie.Location.X && dvijenieX < panelDeistvie.Location.X + panelDeistvie.Width;
                bool vNiz = dvijenieY > panelDeistvie.Location.Y && dvijenieX > panelDeistvie.Location.X && dvijenieX < panelDeistvie.Location.X + panelDeistvie.Width;
                bool vLevo = dvijenieX < panelDeistvie.Location.X && dvijenieY > panelDeistvie.Location.Y && dvijenieY < panelDeistvie.Location.Y + panelDeistvie.Height;
                bool vPravo = dvijenieX > panelDeistvie.Location.X && dvijenieY > panelDeistvie.Location.Y && dvijenieY < panelDeistvie.Location.Y + panelDeistvie.Height;
                bool vCentre = dvijenieY > panelDeistvie.Location.Y && dvijenieY < panelDeistvie.Location.Y + panelDeistvie.Height && dvijenieX > panelDeistvie.Location.X && dvijenieX < panelDeistvie.Location.X + panelDeistvie.Width;
                bool vVerhVlevo = dvijenieY < panelDeistvie.Location.Y && dvijenieX < panelDeistvie.Location.X;
                bool vVerhVpravo = dvijenieY < panelDeistvie.Location.Y && dvijenieX > panelDeistvie.Location.X + panelDeistvie.Width;
                bool vNizVlevo = dvijenieY > panelDeistvie.Location.Y + panelDeistvie.Height && dvijenieX < panelDeistvie.Location.X;
                bool vNizVpravo = dvijenieY > panelDeistvie.Location.Y + panelDeistvie.Height && dvijenieX > panelDeistvie.Location.X + panelDeistvie.Width;

                if (!vCentre)
                {
                    if (vVerh || vVerhVlevo || vVerhVpravo)
                    {
                        panelDeistvie.Location = new Point(panelDeistvie.Location.X, panelDeistvie.Location.Y - 1);
                    }
                    if (vNiz || vNizVlevo || vNizVpravo)
                    {
                        panelDeistvie.Location = new Point(panelDeistvie.Location.X, panelDeistvie.Location.Y + 1);
                    }
                    if (vLevo || vVerhVlevo || vNizVlevo)
                    {
                        panelDeistvie.Location = new Point(panelDeistvie.Location.X - 1, panelDeistvie.Location.Y);
                    }
                    if (vPravo || vVerhVpravo || vNizVpravo)
                    {
                        panelDeistvie.Location = new Point(panelDeistvie.Location.X + 1, panelDeistvie.Location.Y);
                    }
                }

            }
        }

        private void PictureKarta_MouseDown(object sender, MouseEventArgs e)
        {
            Color cvetIgrovoiKarti = Data.bitKartaIgri.GetPixel(e.X, e.Y);

            if (cvetIgrovoiKarti != Baza.granica && cvetIgrovoiKarti != Baza.gori && cvetIgrovoiKarti != Baza.more)
            {
                if (cvetIgrovoiKarti == Data.igroki[Data.indexIgroka].Cvet || (cvetIgrovoiKarti.R == Data.igroki[Data.indexIgroka].Cvet.R && cvetIgrovoiKarti.G == Data.igroki[Data.indexIgroka].Cvet.G && cvetIgrovoiKarti.B == Data.igroki[Data.indexIgroka].Cvet.B)) MessageBox.Show(Data.igroki[Data.indexIgroka].UpravlenieTerritorii);
                else
                {
                    //Въ будущем можно будетъ прописать if для разныхъ типовъ территорій

                    bool boolODdlaTerritorii = Data.igroki[Data.indexIgroka].KolicestvoOD >= Baza.cenaZahvataTerritorii;
                    bool boolSvaziEst = false;
                    int nomerTerritoriiDlaProverki = 0;

                    Color cvetKartiTerritorii = Data.bitKartaTerritorii.GetPixel(e.X, e.Y);

                    for (int ter = 0; ter < Data.territorii.Count; ter++)
                    {
                        if (cvetKartiTerritorii == Data.territorii[ter].Cvet || (cvetKartiTerritorii.R == Data.territorii[ter].Cvet.R && cvetKartiTerritorii.G == Data.territorii[ter].Cvet.G && cvetKartiTerritorii.B == Data.territorii[ter].Cvet.B))
                        {
                            nomerTerritoriiDlaProverki = Data.territorii[ter].Nomer;

                            for (int terSosed = 0; terSosed < Data.territorii[ter].Sosedi.Length; terSosed++)
                            {
                                if (Data.igroki[Data.indexIgroka].PodkontrolnieTerritorii.Contains(Data.territorii[ter].Sosedi[terSosed]))
                                {

                                    if (boolODdlaTerritorii)//Переписать хватаетъ ли ОД для нужного типа
                                    {
                                        boolSvaziEst = true;

                                        Raschet.Pocrass(nomerTerritoriiDlaProverki);

                                    }
                                    else if (!boolODdlaTerritorii) MessageBox.Show(Baza.MaloOD);

                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (boolSvaziEst) 
                    {
                        Grafika.Otrisovka(nomerTerritoriiDlaProverki, pictureKarta, labelOD, panelInterfeis);
                        
                    }
                }

            }

            for (int i = 0; i < Data.igroki.Count; i++)
            {
                if (Data.igroki[i].CenaZahvata == 0 && Data.igroki[i].JivLi)
                {
                    Data.igroki[i].JivLi = false;

                    if (Data.igroki[i].Tip != Baza.tip[0]) MessageBox.Show("Страна подъ названіемъ: " + Data.igroki[i].Ima + " перестала существовать");
                }
            }

            if (vivodSvazei) MessageBox.Show(VivodSvazei(Data.igroki));

        }

        private void PanelDeistvie_MouseDown(object sender, MouseEventArgs e)
        {
            if (Data.vozmojnostPeremesheniaPaneliDeistvia)
            {
                panelPeremeshaut = true;
                timerProverkaNazatia.Start();
            }
        }

        private void TimerProverkaNazatia_Tick(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Left) panelPeremeshaut = false;
        }

        private void Igra_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Data.konecIgri)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (!panelDeistvie.Visible)
                        {

                            Grafika.RabotaSIgrovimMenu(ref panelDeistvie, ref panelMenu, ref buttonMenuNabludatel, ref buttonMenuVGlavnoeMenu, ref buttonMenuVihod, this);

                            panelDeistvie.Visible = true;
                        }
                        else panelDeistvie.Visible = false;
                        break;
                }
            }
        }

        private void ButtonHod_Click(object sender, EventArgs e)
        {
            if (Data.igroki[Data.indexIgroka].CenaZahvata == int.Parse(Baza.scenarii[Data.indexScenaria, 1]))
            {
                buttonHod.Enabled = false;
                Grafika.VivodPobedi(ref panelDeistvie, ref panelPobeda, ref labelTextPobedi, ref buttonPobedaGlavnoeMenu, ref buttonPobedaVihod, Data.igroki[Data.indexIgroka].TekstPobedi, Data.igroki[Data.indexIgroka].Ima, this);
            }
            else Raschet.SmenaIgroka(ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, false, ref panelMenu, ref panelDeistvie);
        }

        private String VivodSvazei(List<Igrok> igroki)
        {
            StringBuilder informacia = new StringBuilder();

            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].JivLi)
                {
                    informacia.Append(igroki[i].Ima + "\nТерритории: " + igroki[i].PodkontrolnieTerritorii.Count + "\nСоседи: ");
                    for (int s = 0; s < igroki[i].SosediIgroki.Count; s++)
                    {
                        informacia.Append(igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[i].SosediIgroki[s]))].Ima);
                        if (s < igroki[i].SosediIgroki.Count - 1) informacia.Append(", ");
                        else informacia.Append(".");
                    }
                    informacia.Append("\n");
                }
            }

            return informacia.ToString();
        }
    }
}
