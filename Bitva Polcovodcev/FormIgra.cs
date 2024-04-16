using Bitva_Polcovodcev.Classi.Dannie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        bool vivodRolei = false;
        Color cvetIgrok;

        public List<Igrok> listClassIgrok = new List<Igrok>();
        public List<Territorii> listClassTeritorii = new List<Territorii>();

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

            zagruzka.Deserelizacia_IgrokData(ref listClassIgrok);
            zagruzka.Deserelizacia_TerritoriiData(ref listClassTeritorii);

            raschet.Raspredelenie_Rolei(listClassRoli, listClassIgrok);
            raschet.SmenaIgroka(listClassIgrok, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgrok, true);
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

            listClassIgrok[indexIgroka].KolicestvoOD += Znachenie;

            labelOD.Text = "ОД " + listClassIgrok[indexIgroka].KolicestvoOD;

            buttonBrosok.Enabled = false;

            buttonHod.Enabled = true;
        }

        private void PictureKarta_MouseDown(object sender, MouseEventArgs e)
        {
            Color cvetIgrovoiKarti = bitKartaIgri.GetPixel(e.X, e.Y);

            if (cvetIgrovoiKarti != dannie.granica && cvetIgrovoiKarti != dannie.gori && cvetIgrovoiKarti != dannie.more)
            {
                if (cvetIgrovoiKarti == cvetIgrok || (cvetIgrovoiKarti.R == cvetIgrok.R && cvetIgrovoiKarti.G == cvetIgrok.G && cvetIgrovoiKarti.B == cvetIgrok.B)) MessageBox.Show(listClassIgrok[indexIgroka].UpravlenieTerritorii);
                else
                {
                    //Въ будущем можно будетъ прописать if для разныхъ типовъ территорій

                    bool boolODdlaTerritorii = listClassIgrok[indexIgroka].KolicestvoOD >= dannie.cenaZahvataTerritorii;
                    bool boolSvaziEst = false;
                    int intNomerTerritoriiDlaProverki = 0;

                    Color cvetKartiTerritorii = bitKartaTerritorii.GetPixel(e.X, e.Y);

                    for (int ter = 0; ter < listClassTeritorii.Count; ter++)
                    {
                        if (cvetKartiTerritorii == listClassTeritorii[ter].Cvet || (cvetKartiTerritorii.R == listClassTeritorii[ter].Cvet.R && cvetKartiTerritorii.G == listClassTeritorii[ter].Cvet.G && cvetKartiTerritorii.B == listClassTeritorii[ter].Cvet.B))
                        {
                            intNomerTerritoriiDlaProverki = listClassTeritorii[ter].Nomer;

                            for (int terSosed = 0; terSosed < listClassTeritorii[ter].Sosedi.Length; terSosed++)
                            {
                                if (listClassIgrok[indexIgroka].PodkontrolnieTerritorii.Contains(listClassTeritorii[ter].Sosedi[terSosed]))
                                {

                                    if (boolODdlaTerritorii)//Переписать хватаетъ ли ОД для нужного типа
                                    {
                                        boolSvaziEst = true;

                                        if (boolODdlaTerritorii) listClassIgrok[indexIgroka].KolicestvoOD -= dannie.cenaZahvataTerritorii;

                                        listClassIgrok[indexIgroka].PodkontrolnieTerritorii.Add(intNomerTerritoriiDlaProverki);
                                        if (boolODdlaTerritorii) listClassIgrok[indexIgroka].CenaZahvata += dannie.cenaZahvataTerritorii;

                                        //Работа съ Соседями Территоріями у Игрока
                                        listClassIgrok[indexIgroka].SosediTerritorii.Remove(intNomerTerritoriiDlaProverki);

                                        for (int sosediZahvachennoiTerritorii = 0; sosediZahvachennoiTerritorii < listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi.Length; sosediZahvachennoiTerritorii++)
                                        {
                                            bool boolVSostaveLiStrani = listClassIgrok[indexIgroka].PodkontrolnieTerritorii.Contains(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);

                                            bool boolZapisanLiUzeVSosedi = listClassIgrok[indexIgroka].SosediTerritorii.Contains(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);

                                            if (!boolVSostaveLiStrani && !boolZapisanLiUzeVSosedi) listClassIgrok[indexIgroka].SosediTerritorii.Add(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediZahvachennoiTerritorii]);
                                        }

                                        //Работа съ Соседями у Игрока
                                        for (int territoriiSosedi = 0; territoriiSosedi < listClassIgrok[indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
                                        {
                                            int indexVladelcaTerritorii = listClassIgrok.FindIndex(list => list.PodkontrolnieTerritorii.Contains(listClassIgrok[indexIgroka].SosediTerritorii[territoriiSosedi]));

                                            if (!listClassIgrok[indexIgroka].SosediIgroki.Contains(listClassIgrok[indexVladelcaTerritorii].Nomer)) listClassIgrok[indexIgroka].SosediIgroki.Add(listClassIgrok[indexVladelcaTerritorii].Nomer);
                                            if (!listClassIgrok[indexVladelcaTerritorii].SosediIgroki.Contains(listClassIgrok[indexIgroka].Nomer)) listClassIgrok[indexVladelcaTerritorii].SosediIgroki.Add(listClassIgrok[indexIgroka].Nomer);
                                        }

                                        //Работа съ данными Соседа
                                        int indexIgrokaPoteravshego = listClassIgrok.FindIndex(list => list.PodkontrolnieTerritorii.Contains(intNomerTerritoriiDlaProverki) && list.Nomer != listClassIgrok[indexIgroka].Nomer);

                                        //MessageBox.Show(listClassIgrok[indexIgrokaPoteravshego].Ima);

                                        listClassIgrok[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Remove(intNomerTerritoriiDlaProverki);
                                        if (boolODdlaTerritorii) listClassIgrok[indexIgrokaPoteravshego].CenaZahvata -= dannie.cenaZahvataTerritorii;

                                        if (listClassIgrok[indexIgrokaPoteravshego].CenaZahvata > 0)
                                        {
                                            //Работа съ Соседями Территоріями у Соседа
                                            for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi.Length; sosediPoterannoiTerritorii++)
                                            {
                                                bool boolUavlaetsaLiTerritoriaChastiuFrakcii = listClassIgrok[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Contains(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);

                                                if (boolUavlaetsaLiTerritoriaChastiuFrakcii && !listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii.Contains(intNomerTerritoriiDlaProverki))
                                                {
                                                    listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii.Add(intNomerTerritoriiDlaProverki);
                                                }
                                                else if (!boolUavlaetsaLiTerritoriaChastiuFrakcii)
                                                {
                                                    bool boolImmetGranicuSTerritorieuFrakcii = true;

                                                    for (int territoriaFrakcii = 0; territoriaFrakcii < listClassIgrok[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                                                    {
                                                        boolImmetGranicuSTerritorieuFrakcii = listClassTeritorii[listClassIgrok[indexIgrokaPoteravshego].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);

                                                        if (boolImmetGranicuSTerritorieuFrakcii) break;
                                                    }

                                                    if (!boolImmetGranicuSTerritorieuFrakcii) listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii.Remove(listClassTeritorii[intNomerTerritoriiDlaProverki].Sosedi[sosediPoterannoiTerritorii]);
                                                }

                                            }

                                            //Работа съ Соседями Игроками у Соседа
                                            for (int ninesnieSosedi = 0; ninesnieSosedi < listClassIgrok[indexIgrokaPoteravshego].SosediIgroki.Count; ninesnieSosedi++)
                                            {
                                                int indexSoseda = listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassIgrok[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]));

                                                bool EstLiTerritoriaVSostave = false;

                                                for (int territoriiSosedi = 0; territoriiSosedi < listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii.Count; territoriiSosedi++)
                                                {
                                                    int indexTerritorii = listClassTeritorii.FindIndex(list => int.Equals(list.Nomer, listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii[territoriiSosedi]));

                                                    EstLiTerritoriaVSostave = listClassIgrok[indexSoseda].PodkontrolnieTerritorii.Contains(listClassTeritorii[indexTerritorii].Nomer);

                                                    if (EstLiTerritoriaVSostave) break;
                                                }

                                                if (!EstLiTerritoriaVSostave) listClassIgrok[indexIgrokaPoteravshego].SosediIgroki.Remove(listClassIgrok[indexSoseda].Nomer);

                                            }
                                        }
                                        else
                                        {
                                            listClassIgrok[indexIgrokaPoteravshego].SosediTerritorii.Clear();
                                            listClassIgrok[indexIgrokaPoteravshego].SosediIgroki.Clear();
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

                        raschet.Raspredelenie_Rolei(listClassRoli, listClassIgrok);

                        //Отрисовка

                        int RisovanieX = listClassTeritorii[intNomerTerritoriiDlaProverki].X;

                        int RisovanieY = listClassTeritorii[intNomerTerritoriiDlaProverki].Y;

                        int RisovaniWidth = listClassTeritorii[intNomerTerritoriiDlaProverki].Width;

                        int RisovanieHeight = listClassTeritorii[intNomerTerritoriiDlaProverki].Height;

                        Bitmap BitTerritoria = new Bitmap(bitKartaTerritorii.Width, bitKartaTerritorii.Height);

                        for (int y = RisovanieY; y < RisovanieHeight; y++)
                        {
                            for (int x = RisovanieX; x < RisovaniWidth; x++)
                            {
                                Color cvetPerekrass = bitKartaTerritorii.GetPixel(x, y);

                                if (cvetPerekrass == listClassTeritorii[intNomerTerritoriiDlaProverki].Cvet || (cvetPerekrass.R == listClassTeritorii[intNomerTerritoriiDlaProverki].Cvet.R && cvetPerekrass.G == listClassTeritorii[intNomerTerritoriiDlaProverki].Cvet.G && cvetPerekrass.B == listClassTeritorii[intNomerTerritoriiDlaProverki].Cvet.B))
                                {
                                    BitTerritoria.SetPixel(x, y, cvetIgrok);
                                }
                                else
                                {
                                    BitTerritoria.SetPixel(x, y, dannie.pustota);
                                }
                            }
                        }

                        labelOD.Text = "ОД " + listClassIgrok[indexIgroka].KolicestvoOD;
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

            for (int i = 0; i < listClassIgrok.Count; i++)
            {
                if (listClassIgrok[i].CenaZahvata == 0 && listClassIgrok[i].JivLi)
                {
                    listClassIgrok[i].JivLi = false;
                    listClassIgrok[i].Rol = listClassRoli[0].Ima;
                    if (!listClassRoli[0].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[0].Igroki.Add(listClassIgrok[i].Nomer);

                    if (listClassIgrok[i].Tip != dannie.tip[0]) MessageBox.Show("Страна подъ названіемъ: " + listClassIgrok[i].Ima + " перестала существовать");
                }
            }

            if (vivodRolei)
            {
                string roli = "Нулевой Игрокъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[0].Igroki);
                roli += "\nГегемонъ: ";
                if (listClassRoli[1].Igroki.Count != 0) roli += listClassIgrok[listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]))].Ima;
                else roli += "Отсутствуетъ";
                roli += "\nПротивникъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[2].Igroki);
                roli += "\nСереднякъ: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[3].Igroki);
                roli += "\nИзгой: ";
                FormirovanieOtvetaRoliDlaNegegemona(ref roli, listClassRoli[4].Igroki);
                MessageBox.Show(roli, "Роли");
            }

        }

        private void ButtonHod_Click(object sender, EventArgs e)
        {
            if (listClassIgrok[indexIgroka].CenaZahvata == dannie.cenaZahvataKarti) MessageBox.Show("Политія: " + listClassIgrok[indexIgroka].Ima + " одержала побѣду. " + listClassIgrok[indexIgroka].TekstPobedi);
            else raschet.SmenaIgroka(listClassIgrok, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgrok, false);
        }

        private void FormirovanieOtvetaRoliDlaNegegemona(ref string roli, List<int> spisok)
        {
            if (spisok.Count > 0)
            {
                for (int i = 0; i < spisok.Count; i++)
                {
                    roli += listClassIgrok[listClassIgrok.FindIndex(list => int.Equals(list.Nomer, spisok[i]))].Ima;
                    if (i < spisok.Count - 1) roli += ", ";
                }

            }
            else roli += "Отсутствуетъ";
        }
    }
}
