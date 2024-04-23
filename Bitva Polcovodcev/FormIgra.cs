using Bitva_Polcovodcev.Classi.Dannie;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public partial class FormIgra : Form
    {
        public FormIgra()
        {
            InitializeComponent();
        }

        Bitmap bitKartaIgri = Properties.Resources.Proba_Igroki;
        Bitmap bitKartaTerritorii = Properties.Resources.Proba_Territorii;
        int indexIgroka = 0;
        bool vivodRolei = false, vivodSvazei = true;
        Color cvetIgrok;

        public List<Igrok> igroki = new List<Igrok>();
        public List<Territorii> territorii = new List<Territorii>();

        Raschet raschet = new Raschet();
        Dannie dannie = new Dannie();

        public List<Roli> listClassRoli = new List<Roli>()
        {
            new Roli() { Ima = "Нулевой Игрокъ", Igroki = new List<int>() },
            new Roli() { Ima = "Гегемонъ", Igroki = new List<int>() },
            new Roli() { Ima = "Соперникъ", Igroki = new List<int>() },
            new Roli() { Ima = "Середнякъ", Igroki = new List<int>() },
            new Roli() { Ima = "Изгой", Igroki = new List<int>() }
        };

        private void FormIgra_Load(object sender, EventArgs e)
        {
            Zagruzka zagruzka = new Zagruzka();

            zagruzka.ZagruzkaElementovFormi(pictureKarta, bitKartaIgri, panelInterfeis, this);
            zagruzka.ZagruzkaElementovFormiDlaIgroka(pictureFlag, pictureBrosok, labelNazvanie, labelOD, buttonBrosok, buttonHod, panelInterfeis);

            zagruzka.Deserelizacia_IgrokData(ref igroki);
            zagruzka.Deserelizacia_TerritoriiData(ref territorii);

            raschet.Raspredelenie_Rolei(listClassRoli, igroki);
            raschet.SmenaIgroka(igroki, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgrok, true);
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

            if (cvetIgrovoiKarti != dannie.granica && cvetIgrovoiKarti != dannie.gori && cvetIgrovoiKarti != dannie.more)
            {
                if (cvetIgrovoiKarti == cvetIgrok || (cvetIgrovoiKarti.R == cvetIgrok.R && cvetIgrovoiKarti.G == cvetIgrok.G && cvetIgrovoiKarti.B == cvetIgrok.B)) MessageBox.Show(igroki[indexIgroka].UpravlenieTerritorii);
                else
                {
                    //Въ будущем можно будетъ прописать if для разныхъ типовъ территорій

                    bool boolODdlaTerritorii = igroki[indexIgroka].KolicestvoOD >= dannie.cenaZahvataTerritorii;
                    bool boolSvaziEst = false;
                    int intNomerTerritoriiDlaProverki = 0;

                    Color cvetKartiTerritorii = bitKartaTerritorii.GetPixel(e.X, e.Y);

                    for (int ter = 0; ter < territorii.Count; ter++)
                    {
                        if (cvetKartiTerritorii == territorii[ter].Cvet || (cvetKartiTerritorii.R == territorii[ter].Cvet.R && cvetKartiTerritorii.G == territorii[ter].Cvet.G && cvetKartiTerritorii.B == territorii[ter].Cvet.B))
                        {
                            intNomerTerritoriiDlaProverki = territorii[ter].Nomer;

                            for (int terSosed = 0; terSosed < territorii[ter].Sosedi.Length; terSosed++)
                            {
                                if (igroki[indexIgroka].PodkontrolnieTerritorii.Contains(territorii[ter].Sosedi[terSosed]))
                                {

                                    if (boolODdlaTerritorii)//Переписать хватаетъ ли ОД для нужного типа
                                    {
                                        boolSvaziEst = true;

                                        if (boolODdlaTerritorii) igroki[indexIgroka].KolicestvoOD -= dannie.cenaZahvataTerritorii;

                                        igroki[indexIgroka].PodkontrolnieTerritorii.Add(intNomerTerritoriiDlaProverki);
                                        if (boolODdlaTerritorii) igroki[indexIgroka].CenaZahvata += dannie.cenaZahvataTerritorii;

                                        //Работа съ Соседями Территоріями у Игрока
                                        igroki[indexIgroka].SosediTerritorii.Remove(intNomerTerritoriiDlaProverki);

                                        for (int sosediZahvachennoiTerritorii = 0; sosediZahvachennoiTerritorii < territorii[intNomerTerritoriiDlaProverki].Sosedi.Length; sosediZahvachennoiTerritorii++)
                                        {
                                            bool boolVSostaveLiStrani = igroki[indexIgroka].PodkontrolnieTerritorii.Contains(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);

                                            bool boolZapisanLiUzeVSosedi = igroki[indexIgroka].SosediTerritorii.Contains(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);

                                            if (!boolVSostaveLiStrani && !boolZapisanLiUzeVSosedi) igroki[indexIgroka].SosediTerritorii.Add(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);
                                        }

                                        //Работа съ Соседями у Игрока
                                        for (int territoriiSosedi = 0; territoriiSosedi < igroki[indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
                                        {
                                            int indexVladelcaTerritorii = igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(igroki[indexIgroka].SosediTerritorii[territoriiSosedi]));

                                            if (!igroki[indexIgroka].SosediIgroki.Contains(igroki[indexVladelcaTerritorii].Nomer)) igroki[indexIgroka].SosediIgroki.Add(igroki[indexVladelcaTerritorii].Nomer);
                                            if (!igroki[indexVladelcaTerritorii].SosediIgroki.Contains(igroki[indexIgroka].Nomer)) igroki[indexVladelcaTerritorii].SosediIgroki.Add(igroki[indexIgroka].Nomer);
                                        }

                                        //Работа съ данными Соседа
                                        int indexIgrokaPoteravshego = igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(intNomerTerritoriiDlaProverki) && list.Nomer != igroki[indexIgroka].Nomer);

                                        //MessageBox.Show(listClassIgrok[indexIgrokaPoteravshego].Ima);

                                        igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Remove(intNomerTerritoriiDlaProverki);
                                        if (boolODdlaTerritorii) igroki[indexIgrokaPoteravshego].CenaZahvata -= dannie.cenaZahvataTerritorii;

                                        if (igroki[indexIgrokaPoteravshego].CenaZahvata > 0)
                                        {
                                            //Работа съ Соседями Территоріями у Соседа
                                            for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < territorii[intNomerTerritoriiDlaProverki].Sosedi.Length; sosediPoterannoiTerritorii++)
                                            {
                                                bool boolUavlaetsaLiTerritoriaChastiuFrakcii = igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Contains(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);

                                                if (boolUavlaetsaLiTerritoriaChastiuFrakcii && !igroki[indexIgrokaPoteravshego].SosediTerritorii.Contains(intNomerTerritoriiDlaProverki))
                                                {
                                                    igroki[indexIgrokaPoteravshego].SosediTerritorii.Add(intNomerTerritoriiDlaProverki);
                                                }
                                                else if (!boolUavlaetsaLiTerritoriaChastiuFrakcii)
                                                {
                                                    bool boolImmetGranicuSTerritorieuFrakcii = true;

                                                    for (int territoriaFrakcii = 0; territoriaFrakcii < igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                                                    {
                                                        boolImmetGranicuSTerritorieuFrakcii = territorii[igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);

                                                        if (boolImmetGranicuSTerritorieuFrakcii) break;
                                                    }

                                                    if (!boolImmetGranicuSTerritorieuFrakcii) igroki[indexIgrokaPoteravshego].SosediTerritorii.Remove(territorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);
                                                }

                                            }

                                            //Работа съ Соседями Игроками у Соседа
                                            for (int ninesnieSosedi = 0; ninesnieSosedi < igroki[indexIgrokaPoteravshego].SosediIgroki.Count; ninesnieSosedi++)
                                            {
                                                int indexSoseda = igroki.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]));

                                                bool EstLiTerritoriaVSostave = false;

                                                for (int territoriiSosedi = 0; territoriiSosedi < igroki[indexIgrokaPoteravshego].SosediTerritorii.Count; territoriiSosedi++)
                                                {
                                                    int indexTerritorii = territorii.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgrokaPoteravshego].SosediTerritorii[territoriiSosedi]));

                                                    EstLiTerritoriaVSostave = igroki[indexSoseda].PodkontrolnieTerritorii.Contains(territorii[indexTerritorii].Nomer);

                                                    if (EstLiTerritoriaVSostave) break;
                                                }

                                                if (!EstLiTerritoriaVSostave) igroki[indexIgrokaPoteravshego].SosediIgroki.Remove(igroki[indexSoseda].Nomer);

                                            }
                                        }
                                        else
                                        {
                                            igroki[indexIgrokaPoteravshego].SosediTerritorii.Clear();
                                            igroki[indexIgrokaPoteravshego].SosediIgroki.Clear();
                                        }

                                    }
                                    else if (!boolODdlaTerritorii) MessageBox.Show(dannie.MaloOD);

                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (boolSvaziEst) //Отрисовка и Работа съ Ролями
                    {
                        //Работа съ Ролями

                        raschet.Raspredelenie_Rolei(listClassRoli, igroki);

                        //Отрисовка

                        int RisovanieX = territorii[intNomerTerritoriiDlaProverki].X;

                        int RisovanieY = territorii[intNomerTerritoriiDlaProverki].Y;

                        int RisovaniWidth = territorii[intNomerTerritoriiDlaProverki].Width;

                        int RisovanieHeight = territorii[intNomerTerritoriiDlaProverki].Height;

                        Bitmap BitTerritoria = new Bitmap(bitKartaTerritorii.Width, bitKartaTerritorii.Height);

                        for (int y = RisovanieY; y < RisovanieHeight; y++)
                        {
                            for (int x = RisovanieX; x < RisovaniWidth; x++)
                            {
                                Color cvetPerekrass = bitKartaTerritorii.GetPixel(x, y);

                                if (cvetPerekrass == territorii[intNomerTerritoriiDlaProverki].Cvet || (cvetPerekrass.R == territorii[intNomerTerritoriiDlaProverki].Cvet.R && cvetPerekrass.G == territorii[intNomerTerritoriiDlaProverki].Cvet.G && cvetPerekrass.B == territorii[intNomerTerritoriiDlaProverki].Cvet.B))
                                {
                                    BitTerritoria.SetPixel(x, y, cvetIgrok);
                                }
                                else
                                {
                                    BitTerritoria.SetPixel(x, y, dannie.pustota);
                                }
                            }
                        }

                        labelOD.Text = "ОД " + igroki[indexIgroka].KolicestvoOD;
                        labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, labelOD.Location.Y);

                        Bitmap bitKartaNovusIgri = new Bitmap(bitKartaIgri);
                        Graphics grapNovusIgra = Graphics.FromImage(bitKartaNovusIgri);
                        grapNovusIgra.CompositingMode = CompositingMode.SourceOver;

                        grapNovusIgra.DrawImage(BitTerritoria, 0, 0);

                        bitKartaIgri = bitKartaNovusIgri;

                        Bitmap bitFinal = new Bitmap(bitKartaIgri);

                        Graphics grapFinal = Graphics.FromImage(bitFinal);
                        grapFinal.CompositingMode = CompositingMode.SourceOver;

                        grapFinal.DrawImage(bitKartaIgri, 0, 0);

                        pictureKarta.Image = bitFinal;
                    }
                }

            }

            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].CenaZahvata == 0 && igroki[i].JivLi)
                {
                    igroki[i].JivLi = false;
                    igroki[i].Rol = listClassRoli[0].Ima;
                    if (!listClassRoli[0].Igroki.Contains(igroki[i].Nomer)) listClassRoli[0].Igroki.Add(igroki[i].Nomer);

                    if (igroki[i].Tip != dannie.tip[0]) MessageBox.Show("Страна подъ названіемъ: " + igroki[i].Ima + " перестала существовать");
                }
            }

            if (vivodRolei)
            {
                string roli = "Нулевой Игрокъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[0].Igroki);
                roli += "\nГегемонъ: ";
                if (listClassRoli[1].Igroki.Count != 0) roli += igroki[igroki.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]))].Ima;
                else roli += "Отсутствуетъ";
                roli += "\nПротивникъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[2].Igroki);
                roli += "\nСереднякъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[3].Igroki);
                roli += "\nИзгой: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[4].Igroki);
                MessageBox.Show(roli, "Роли");
            }

            if (vivodSvazei) MessageBox.Show(VivodSvazei(igroki));

        }

        private void ButtonHod_Click(object sender, EventArgs e)
        {
            if (igroki[indexIgroka].CenaZahvata == dannie.cenaZahvataKarti) MessageBox.Show("Политія: " + igroki[indexIgroka].Ima + " одержала побѣду. " + igroki[indexIgroka].TekstPobedi);
            else raschet.SmenaIgroka(igroki, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgrok, false);
        }

        private void FormirovanieOtvetaRoliDlaNegegemona(ref string roli, List<int> spisok)
        {
            if (spisok.Count > 0)
            {
                for (int i = 0; i < spisok.Count; i++)
                {
                    roli += igroki[igroki.FindIndex(list => int.Equals(list.Nomer, spisok[i]))].Ima;
                    if (i < spisok.Count - 1) roli += ", ";
                }

            }
            else roli += "Отсутствуетъ";
        }

        private String VivodSvazei(List<Igrok> igroki)
        {
            StringBuilder informacia = new StringBuilder();

            for (int i = 0; i < igroki.Count; i++)
            {
                informacia.Append(igroki[i].Ima + "\nТерритории: " + igroki[i].PodkontrolnieTerritorii.Count + "\nСоседи: ");
                for(int s = 0; s < igroki[i].SosediIgroki.Count; s++)
                {
                    informacia.Append(igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[i].SosediIgroki[s]))].Ima);
                    if (s < igroki[i].SosediIgroki.Count - 1) informacia.Append(", ");
                    else informacia.Append(".\n");
                }
            }

            return informacia.ToString();
        }
    }
}
