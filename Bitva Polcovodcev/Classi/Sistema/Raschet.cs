using Bitva_Polcovodcev.Classi.Dannie;
using Bitva_Polcovodcev.Classi.Sistema;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public class Raschet
    {

        public static void SmenaIgroka(
            ref Label labelNazvanie, ref Label labelOD,
            ref PictureBox pictureFlag, ref PictureBox pictureBrosok, PictureBox pictureKarta,
            Button buttonBrosok, Button buttonHod,
            Panel panelInterfeis,
            bool zagruzka,
            ref Panel panelMenu, ref Panel panelDeistvia)
        {

            if(!zagruzka || (zagruzka && Data.igroki[Data.indexIgroka].Tip ==  Baza.tip[0]))
            {
                while (true)
                {
                    if (Data.indexIgroka < Data.igroki.Count - 1) Data.indexIgroka++;
                    else Data.indexIgroka = 0;

                    if (Data.igroki[Data.indexIgroka].JivLi && Data.igroki[Data.indexIgroka].Tip != Baza.tip[0]) break;
                }
            }

            if (Data.igroki[Data.indexIgroka].Tip == Baza.tip[2])
            {
                IP ip = new IP();
                ip.Hod(pictureKarta, labelOD, panelInterfeis);
                if (Data.igroki.Count > 1) 
                { 
                    if(Data.prisutstvuiutLiJI) SmenaIgroka(ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, false, ref panelMenu, ref panelDeistvia);
                }
            }

            Proverka.ProverkaKorrektnostiElementovDatiIFormi(ref panelMenu, ref panelDeistvia);

            if (Data.igroki[Data.indexIgroka].Tip == Baza.tip[1] || !Data.prisutstvuiutLiJI)
            {
                pictureFlag.BackColor = Data.igroki[Data.indexIgroka].Cvet;//Пока такъ, дальше догружать флагъ
                labelNazvanie.Text = Data.igroki[Data.indexIgroka].Ima;
                labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);
                labelOD.Text = "ОД " + Data.igroki[Data.indexIgroka].KolicestvoOD;
                labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);
                pictureBrosok.Image = Properties.Resources.Niet;
                buttonBrosok.Enabled = true;
                buttonHod.Enabled = false;
            }
        }

        public static void Rabota_S_Soseduami_U_Igroka_Poluchivshego(int nomerTerritorii)
        {
            Data.igroki[Data.indexIgroka].PodkontrolnieTerritorii.Add(nomerTerritorii);
            Data.igroki[Data.indexIgroka].SosediTerritorii.Remove(nomerTerritorii);

            //Работа съ Соседями Территоріями
            for (int sosediZahvachennoiTerritorii = 0; sosediZahvachennoiTerritorii < Data.territorii[nomerTerritorii].Sosedi.Length; sosediZahvachennoiTerritorii++)
            {
                bool boolVSostaveLiStrani = Data.igroki[Data.indexIgroka].PodkontrolnieTerritorii.Contains(Data.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                bool boolZapisanLiUzeVSosedi = Data.igroki[Data.indexIgroka].SosediTerritorii.Contains(Data.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                if (!boolVSostaveLiStrani && !boolZapisanLiUzeVSosedi) Data.igroki[Data.indexIgroka].SosediTerritorii.Add(Data.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);
            }

            //Работа съ Соседями Игроками
            for (int territoriiSosedi = 0; territoriiSosedi < Data.igroki[Data.indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
            {
                int indexVladelcaTerritorii = Data.igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(Data.igroki[Data.indexIgroka].SosediTerritorii[territoriiSosedi]));

                if (!Data.igroki[Data.indexIgroka].SosediIgroki.Contains(Data.igroki[indexVladelcaTerritorii].Nomer)) Data.igroki[Data.indexIgroka].SosediIgroki.Add(Data.igroki[indexVladelcaTerritorii].Nomer);
                if (!Data.igroki[indexVladelcaTerritorii].SosediIgroki.Contains(Data.igroki[Data.indexIgroka].Nomer)) Data.igroki[indexVladelcaTerritorii].SosediIgroki.Add(Data.igroki[Data.indexIgroka].Nomer);
            }
        }

        public static void Rabota_S_Soseduami_U_Igroka_Poteriavsego(int indexIgrokaPoteravshego, int nomerTerritorii)
        {
            Data.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Remove(nomerTerritorii);

            if (Data.igroki[indexIgrokaPoteravshego].CenaZahvata > 0)
            {
                //Работа съ Соседями Территоріями
                for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < Data.territorii[nomerTerritorii].Sosedi.Length; sosediPoterannoiTerritorii++)
                {
                    bool uavlaetsaLiTerritoriaChastiuPolitii = Data.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Contains(Data.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                    if (uavlaetsaLiTerritoriaChastiuPolitii && !Data.igroki[indexIgrokaPoteravshego].SosediTerritorii.Contains(nomerTerritorii))
                    {
                        Data.igroki[indexIgrokaPoteravshego].SosediTerritorii.Add(nomerTerritorii);
                    }
                    else if (!uavlaetsaLiTerritoriaChastiuPolitii)
                    {
                        bool immetGranicuSTerritorieuPolitii = true;

                        for (int territoriaFrakcii = 0; territoriaFrakcii < Data.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                        {
                            immetGranicuSTerritorieuPolitii = Data.territorii[Data.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(Data.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                            if (immetGranicuSTerritorieuPolitii) break;
                        }

                        if (!immetGranicuSTerritorieuPolitii) Data.igroki[indexIgrokaPoteravshego].SosediTerritorii.Remove(Data.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);
                    }

                }

                //Работа съ Соседями Игроками

                List<int> spisokBivsihSosedeiIgrokov = new List<int>();

                for (int ninesnieSosedi = 0; ninesnieSosedi < Data.igroki[indexIgrokaPoteravshego].SosediIgroki.Count; ninesnieSosedi++)
                {
                    int indexSoseda = Data.igroki.FindIndex(list => int.Equals(list.Nomer, Data.igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]));

                    bool estLiTerritoriaVSostave = false;

                    for (int territoriiSosedi = 0; territoriiSosedi < Data.igroki[indexIgrokaPoteravshego].SosediTerritorii.Count; territoriiSosedi++)
                    {
                        int indexTerritorii = Data.territorii.FindIndex(list => int.Equals(list.Nomer, Data.igroki[indexIgrokaPoteravshego].SosediTerritorii[territoriiSosedi]));

                        estLiTerritoriaVSostave = Data.igroki[indexSoseda].PodkontrolnieTerritorii.Contains(Data.territorii[indexTerritorii].Nomer);

                        if (estLiTerritoriaVSostave) break;
                    }

                    if (!estLiTerritoriaVSostave)
                    {
                        spisokBivsihSosedeiIgrokov.Add(Data.igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]);
                    }

                }

                for (int bivshiSosedIgrok = 0; bivshiSosedIgrok < spisokBivsihSosedeiIgrokov.Count; bivshiSosedIgrok++)
                {
                    Data.igroki[indexIgrokaPoteravshego].SosediIgroki.Remove(spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]);
                    Data.igroki[Data.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]))].SosediIgroki.Remove(Data.igroki[indexIgrokaPoteravshego].Nomer);
                }

            }
            else
            {
                Data.igroki[indexIgrokaPoteravshego].SosediTerritorii.Clear();

                for (int i = 0; i < Data.igroki[indexIgrokaPoteravshego].SosediIgroki.Count; i++)
                {
                    int indexSoseda = Data.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, Data.igroki[indexIgrokaPoteravshego].SosediIgroki[i]));

                    if (Data.igroki[indexSoseda].SosediIgroki.Contains(Data.igroki[indexIgrokaPoteravshego].Nomer)) Data.igroki[indexSoseda].SosediIgroki.Remove(Data.igroki[indexIgrokaPoteravshego].Nomer);
                }

                Data.igroki[indexIgrokaPoteravshego].SosediIgroki.Clear();
                Data.igroki[indexIgrokaPoteravshego].JivLi = false;

                int nomerIgroka = Data.igroki[Data.indexIgroka].Nomer;

                if (Data.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[0]) Data.kolichestvoNI--;
                else if (Data.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[1]) Data.kolichestvoJI--;
                else if (Data.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[2]) Data.kolichestvoIP--;

                if (Data.kolichestvoJI == 0) Data.prisutstvuiutLiJI = false;

                Data.igrokiVneIgri.Add(Data.igroki[indexIgrokaPoteravshego]);
                Data.igroki.Remove(Data.igroki[indexIgrokaPoteravshego]);

                Proverka.ProverkaPolojeniaIndexaIgroka(nomerIgroka);

            }
        }

        public static void Pocrass(int nomerTerritoriiPoteri)
        {
            int indexIgrokaDlaLambdi = Data.indexIgroka;

            int indexIgrokaPoteravshego = Data.igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(nomerTerritoriiPoteri) && list.Nomer != Data.igroki[indexIgrokaDlaLambdi].Nomer);

            Data.igroki[Data.indexIgroka].KolicestvoOD -= Baza.cenaZahvataTerritorii;
            Data.igroki[Data.indexIgroka].CenaZahvata += Baza.cenaZahvataTerritorii;
            Data.igroki[indexIgrokaPoteravshego].CenaZahvata -= Baza.cenaZahvataTerritorii;

            Data.igroki[Data.indexIgroka].SosediIgroki.Remove(Data.igroki[indexIgrokaPoteravshego].Nomer);

            Rabota_S_Soseduami_U_Igroka_Poluchivshego(nomerTerritoriiPoteri);

            Rabota_S_Soseduami_U_Igroka_Poteriavsego(indexIgrokaPoteravshego, nomerTerritoriiPoteri);

        }
    }
}
