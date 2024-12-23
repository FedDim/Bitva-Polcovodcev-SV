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
            Дата.bitKartaIgri = Zagruzka.ZagruzkaBitmapKarti("Карта Политій");
            Дата.bitKartaTerritorii = Zagruzka.ZagruzkaBitmapKarti("Карта Территорій");

            Zagruzka.ZagruzkaElementovFormiIgra(pictureKarta, panelInterfeis, this);
            Zagruzka.ZagruzkaElementovFormiDlaIgroka(pictureFlag, pictureBrosok, labelNazvanie, labelOD, buttonBrosok, buttonHod, panelInterfeis);

            Zagruzka.Deserelizacia_TerritoriiData(ref Дата.territorii, Baza.scenarii[Дата.indexScenaria, 5]);

            Raschet.SmenaIgroka(ref pictureFlag, ref pictureBrosok, pictureKarta, true);
            if (!Дата.prisutstvuiutLiJI) Grafika.VivodPorajenia(ref panelDeistvie, ref panelMenu, ref panelInterfeis, this);
            ОбновленіеЗначенійЭлементовъСвязанныхъСъИгрокомъ();
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

            Дата.igroki[Дата.indexIgroka].KolicestvoOD += Znachenie;

            labelOD.Text = "ОД " + Дата.igroki[Дата.indexIgroka].KolicestvoOD;

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
            Дата.konecIgri = false;
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
            Color cvetIgrovoiKarti = Дата.bitKartaIgri.GetPixel(e.X, e.Y);

            if (cvetIgrovoiKarti != Baza.granica && cvetIgrovoiKarti != Baza.gori && cvetIgrovoiKarti != Baza.more)
            {
                if (cvetIgrovoiKarti == Дата.igroki[Дата.indexIgroka].Cvet || (cvetIgrovoiKarti.R == Дата.igroki[Дата.indexIgroka].Cvet.R && cvetIgrovoiKarti.G == Дата.igroki[Дата.indexIgroka].Cvet.G && cvetIgrovoiKarti.B == Дата.igroki[Дата.indexIgroka].Cvet.B)) MessageBox.Show(Дата.igroki[Дата.indexIgroka].UpravlenieTerritorii);
                else
                {
                    //Въ будущем можно будетъ прописать if для разныхъ типовъ территорій

                    bool boolODdlaTerritorii = Дата.igroki[Дата.indexIgroka].KolicestvoOD >= Baza.cenaZahvataTerritorii;
                    bool boolSvaziEst = false;
                    int nomerTerritoriiDlaProverki = 0;

                    Color cvetKartiTerritorii = Дата.bitKartaTerritorii.GetPixel(e.X, e.Y);

                    for (int ter = 0; ter < Дата.territorii.Count; ter++)
                    {
                        if (cvetKartiTerritorii == Дата.territorii[ter].Cvet || (cvetKartiTerritorii.R == Дата.territorii[ter].Cvet.R && cvetKartiTerritorii.G == Дата.territorii[ter].Cvet.G && cvetKartiTerritorii.B == Дата.territorii[ter].Cvet.B))
                        {
                            nomerTerritoriiDlaProverki = Дата.territorii[ter].Nomer;

                            for (int terSosed = 0; terSosed < Дата.territorii[ter].Sosedi.Length; terSosed++)
                            {
                                if (Дата.igroki[Дата.indexIgroka].PodkontrolnieTerritorii.Contains(Дата.territorii[ter].Sosedi[terSosed]))
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
                        Grafika.ПерерисовкаКарты(nomerTerritoriiDlaProverki, pictureKarta);
                        Grafika.ВыводъОД(labelOD, panelInterfeis);
                    }
                }

            }

            for (int i = 0; i < Дата.igroki.Count; i++)
            {
                if (Дата.igroki[i].CenaZahvata == 0 && Дата.igroki[i].JivLi)
                {
                    Дата.igroki[i].JivLi = false;

                    if (Дата.igroki[i].Tip != Baza.tip[0]) MessageBox.Show("Страна подъ названіемъ: " + Дата.igroki[i].Ima + " перестала существовать");
                }
            }

            if (vivodSvazei) MessageBox.Show(VivodSvazei(Дата.igroki));

        }

        private void PanelDeistvie_MouseDown(object sender, MouseEventArgs e)
        {
            if (Дата.vozmojnostPeremesheniaPaneliDeistvia)
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
            if (!Дата.konecIgri)
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
            if (Дата.igroki[Дата.indexIgroka].CenaZahvata == int.Parse(Baza.scenarii[Дата.indexScenaria, 1]))
            {
                buttonHod.Enabled = false;
                Grafika.VivodPobedi(ref panelDeistvie, ref panelPobeda, ref labelTextPobedi, ref buttonPobedaGlavnoeMenu, ref buttonPobedaVihod, Дата.igroki[Дата.indexIgroka].TekstPobedi, Дата.igroki[Дата.indexIgroka].Ima, this);
            }
            else
            {
                Raschet.SmenaIgroka(ref pictureFlag, ref pictureBrosok, pictureKarta, false);
                if (!Дата.prisutstvuiutLiJI) Grafika.VivodPorajenia(ref panelDeistvie, ref panelMenu, ref panelInterfeis, this);
                ОбновленіеЗначенійЭлементовъСвязанныхъСъИгрокомъ();
            }
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

        public void ОбновленіеЗначенійЭлементовъСвязанныхъСъИгрокомъ()
        {
            if (Дата.igroki[Дата.indexIgroka].Tip == Baza.tip[1] || !Дата.prisutstvuiutLiJI)
            {
                pictureFlag.BackColor = Дата.igroki[Дата.indexIgroka].Cvet;
                labelNazvanie.Text = Дата.igroki[Дата.indexIgroka].Ima;
                labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);
                labelOD.Text = "ОД " + Дата.igroki[Дата.indexIgroka].KolicestvoOD;
                labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);
                pictureBrosok.Image = Properties.Resources.Niet;
                buttonBrosok.Enabled = true;
                buttonHod.Enabled = false;
            }
        }
    }
}
