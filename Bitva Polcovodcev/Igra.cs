using Bitva_Polcovodcev.Classi.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public partial class Igra : Form
    {
        public Igra()
        {
            InitializeComponent();
        }

        Bitmap bitKartaIgri, bitKartaTerritorii;
        public int indexScenaria;
        int indexIgroka = 0, hod = 0;
        bool vivodSvazei = false;
        Color cvetIgroka;

        public List<Igrok> igroki = new List<Igrok>();
        public List<Igrok> igrokiVneIgri = new List<Igrok>();
        public List<Territorii> territorii = new List<Territorii>();

        Raschet raschet = new Raschet();
        Baza baza = new Baza();

        private void FormIgra_Load(object sender, EventArgs e)
        {
            Zagruzka zagruzka = new Zagruzka();

            zagruzka.ZagruzkaBitmapKart(indexScenaria, ref bitKartaIgri, ref bitKartaTerritorii);

            zagruzka.ZagruzkaElementovFormiIgra(pictureKarta, bitKartaIgri, panelInterfeis, this, indexScenaria);
            zagruzka.ZagruzkaElementovFormiDlaIgroka(pictureFlag, pictureBrosok, labelNazvanie, labelOD, buttonBrosok, buttonHod, panelInterfeis);

            zagruzka.Deserelizacia_IgrokData(ref igroki, baza.scenarii[indexScenaria, 4]);
            zagruzka.Deserelizacia_TerritoriiData(ref territorii, baza.scenarii[indexScenaria, 5]);

            raschet.SmenaIgroka(igroki, igrokiVneIgri, territorii, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgroka, true, indexScenaria, bitKartaTerritorii, ref bitKartaIgri);
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

            igroki[indexIgroka].KolicestvoOD += Znachenie;

            labelOD.Text = "ОД " + igroki[indexIgroka].KolicestvoOD;

            buttonBrosok.Enabled = false;

            buttonHod.Enabled = true;
        }

        private void PictureKarta_MouseDown(object sender, MouseEventArgs e)
        {
            Color cvetIgrovoiKarti = bitKartaIgri.GetPixel(e.X, e.Y);

            if (cvetIgrovoiKarti != baza.granica && cvetIgrovoiKarti != baza.gori && cvetIgrovoiKarti != baza.more)
            {
                if (cvetIgrovoiKarti == cvetIgroka || (cvetIgrovoiKarti.R == cvetIgroka.R && cvetIgrovoiKarti.G == cvetIgroka.G && cvetIgrovoiKarti.B == cvetIgroka.B)) MessageBox.Show(igroki[indexIgroka].UpravlenieTerritorii);
                else
                {
                    //Въ будущем можно будетъ прописать if для разныхъ типовъ территорій

                    bool boolODdlaTerritorii = igroki[indexIgroka].KolicestvoOD >= baza.cenaZahvataTerritorii;
                    bool boolSvaziEst = false;
                    int nomerTerritoriiDlaProverki = 0;

                    Color cvetKartiTerritorii = bitKartaTerritorii.GetPixel(e.X, e.Y);

                    for (int ter = 0; ter < territorii.Count; ter++)
                    {
                        if (cvetKartiTerritorii == territorii[ter].Cvet || (cvetKartiTerritorii.R == territorii[ter].Cvet.R && cvetKartiTerritorii.G == territorii[ter].Cvet.G && cvetKartiTerritorii.B == territorii[ter].Cvet.B))
                        {
                            nomerTerritoriiDlaProverki = territorii[ter].Nomer;

                            for (int terSosed = 0; terSosed < territorii[ter].Sosedi.Length; terSosed++)
                            {
                                if (igroki[indexIgroka].PodkontrolnieTerritorii.Contains(territorii[ter].Sosedi[terSosed]))
                                {

                                    if (boolODdlaTerritorii)//Переписать хватаетъ ли ОД для нужного типа
                                    {
                                        boolSvaziEst = true;

                                        raschet.Pocrass(igroki, igrokiVneIgri, territorii, ref indexIgroka, nomerTerritoriiDlaProverki);

                                    }
                                    else if (!boolODdlaTerritorii) MessageBox.Show(baza.MaloOD);

                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (boolSvaziEst) 
                    {
                        Grafika grafika = new Grafika();

                        grafika.Otrisovka(igroki, territorii, bitKartaTerritorii, ref bitKartaIgri, nomerTerritoriiDlaProverki, indexIgroka, pictureKarta, labelOD, panelInterfeis);
                        
                    }
                }

            }

            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].CenaZahvata == 0 && igroki[i].JivLi)
                {
                    igroki[i].JivLi = false;

                    if (igroki[i].Tip != baza.tip[0]) MessageBox.Show("Страна подъ названіемъ: " + igroki[i].Ima + " перестала существовать");
                }
            }

            if (vivodSvazei) MessageBox.Show(VivodSvazei(igroki));

        }

        private void ButtonHod_Click(object sender, EventArgs e)
        {
            if (igroki[indexIgroka].CenaZahvata == int.Parse(baza.scenarii[indexScenaria, 1])) MessageBox.Show("Политія: " + igroki[indexIgroka].Ima + " одержала побѣду. " + igroki[indexIgroka].TekstPobedi);
            else raschet.SmenaIgroka(igroki, igrokiVneIgri, territorii, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgroka, false, indexScenaria, bitKartaTerritorii, ref bitKartaIgri);
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
