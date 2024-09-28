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

        public void SmenaIgroka(List<Igrok> igroki, List<Igrok> igrokiVneIgri,
            List<Territorii> territorii,
            ref int indexIgroka,
            ref Label labelNazvanie, ref Label labelOD,
            ref PictureBox pictureFlag, ref PictureBox pictureBrosok, PictureBox pictureKarta,
            Button buttonBrosok, Button buttonHod,
            Panel panelInterfeis,
            ref Color cvetIgroka,
            bool zagruzka, int indexScenaria,
            Bitmap bitKartaTerritorii, ref Bitmap bitKartaIgri,
            ref Panel panelMenu, ref Panel panelDeistvia)
        {

            if(!zagruzka || (zagruzka && igroki[indexIgroka].Tip ==  Baza.tip[0]))
            {
                while (true)
                {
                    if (indexIgroka < igroki.Count - 1) indexIgroka++;
                    else indexIgroka = 0;

                    if (igroki[indexIgroka].JivLi && igroki[indexIgroka].Tip != Baza.tip[0]) break;
                }
            }

            if (igroki[indexIgroka].Tip == Baza.tip[2])
            {
                IP ip = new IP();
                ip.Hod(ref igroki, igrokiVneIgri, territorii, ref indexIgroka, indexScenaria, bitKartaTerritorii, ref bitKartaIgri, pictureKarta, labelOD, panelInterfeis);
                if (igroki.Count > 1) 
                { 
                    if(Data.prisutstvuiutLiJI) SmenaIgroka(igroki, igrokiVneIgri, territorii, ref indexIgroka, ref labelNazvanie, ref labelOD, ref pictureFlag, ref pictureBrosok, pictureKarta, buttonBrosok, buttonHod, panelInterfeis, ref cvetIgroka, false, indexScenaria, bitKartaTerritorii, ref bitKartaIgri, ref panelMenu, ref panelDeistvia);
                }
            }

            Proverka.ProverkaKorrektnostiElementovDatiIFormi(ref panelMenu, ref panelDeistvia);

            if (igroki[indexIgroka].Tip == Baza.tip[1] || !Data.prisutstvuiutLiJI)
            {
                pictureFlag.BackColor = igroki[indexIgroka].Cvet;//Пока такъ, дальше догружать флагъ
                labelNazvanie.Text = igroki[indexIgroka].Ima;
                labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);
                labelOD.Text = "ОД " + igroki[indexIgroka].KolicestvoOD;
                labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);
                pictureBrosok.Image = Properties.Resources.Niet;
                buttonBrosok.Enabled = true;
                buttonHod.Enabled = false;
            }

            cvetIgroka = igroki[indexIgroka].Cvet;
        }

        public void Rabota_S_Soseduami_U_Igroka_Poluchivshego(List<Igrok> igroki, List<Territorii> territorii, int indexIgroka, int nomerTerritorii)
        {
            igroki[indexIgroka].PodkontrolnieTerritorii.Add(nomerTerritorii);
            igroki[indexIgroka].SosediTerritorii.Remove(nomerTerritorii);

            //Работа съ Соседями Территоріями
            for (int sosediZahvachennoiTerritorii = 0; sosediZahvachennoiTerritorii < territorii[nomerTerritorii].Sosedi.Length; sosediZahvachennoiTerritorii++)
            {
                bool boolVSostaveLiStrani = igroki[indexIgroka].PodkontrolnieTerritorii.Contains(territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                bool boolZapisanLiUzeVSosedi = igroki[indexIgroka].SosediTerritorii.Contains(territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                if (!boolVSostaveLiStrani && !boolZapisanLiUzeVSosedi) igroki[indexIgroka].SosediTerritorii.Add(territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);
            }

            //Работа съ Соседями Игроками
            for (int territoriiSosedi = 0; territoriiSosedi < igroki[indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
            {
                int indexVladelcaTerritorii = igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(igroki[indexIgroka].SosediTerritorii[territoriiSosedi]));

                if (!igroki[indexIgroka].SosediIgroki.Contains(igroki[indexVladelcaTerritorii].Nomer)) igroki[indexIgroka].SosediIgroki.Add(igroki[indexVladelcaTerritorii].Nomer);
                if (!igroki[indexVladelcaTerritorii].SosediIgroki.Contains(igroki[indexIgroka].Nomer)) igroki[indexVladelcaTerritorii].SosediIgroki.Add(igroki[indexIgroka].Nomer);
            }
        }

        public void Rabota_S_Soseduami_U_Igroka_Poteriavsego(List<Igrok> igroki, List<Igrok> igrokiVneIgri, List<Territorii> territorii, ref int indexIgroka, int indexIgrokaPoteravshego, int nomerTerritorii)
        {
            igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Remove(nomerTerritorii);

            if (igroki[indexIgrokaPoteravshego].CenaZahvata > 0)
            {
                //Работа съ Соседями Территоріями
                for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < territorii[nomerTerritorii].Sosedi.Length; sosediPoterannoiTerritorii++)
                {
                    bool uavlaetsaLiTerritoriaChastiuPolitii = igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Contains(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                    if (uavlaetsaLiTerritoriaChastiuPolitii && !igroki[indexIgrokaPoteravshego].SosediTerritorii.Contains(nomerTerritorii))
                    {
                        igroki[indexIgrokaPoteravshego].SosediTerritorii.Add(nomerTerritorii);
                    }
                    else if (!uavlaetsaLiTerritoriaChastiuPolitii)
                    {
                        bool immetGranicuSTerritorieuPolitii = true;

                        for (int territoriaFrakcii = 0; territoriaFrakcii < igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                        {
                            immetGranicuSTerritorieuPolitii = territorii[igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                            if (immetGranicuSTerritorieuPolitii) break;
                        }

                        if (!immetGranicuSTerritorieuPolitii) igroki[indexIgrokaPoteravshego].SosediTerritorii.Remove(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);
                    }

                }

                //Работа съ Соседями Игроками

                List<int> spisokBivsihSosedeiIgrokov = new List<int>();

                for (int ninesnieSosedi = 0; ninesnieSosedi < igroki[indexIgrokaPoteravshego].SosediIgroki.Count; ninesnieSosedi++)
                {
                    int indexSoseda = igroki.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]));

                    bool estLiTerritoriaVSostave = false;

                    for (int territoriiSosedi = 0; territoriiSosedi < igroki[indexIgrokaPoteravshego].SosediTerritorii.Count; territoriiSosedi++)
                    {
                        int indexTerritorii = territorii.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgrokaPoteravshego].SosediTerritorii[territoriiSosedi]));

                        estLiTerritoriaVSostave = igroki[indexSoseda].PodkontrolnieTerritorii.Contains(territorii[indexTerritorii].Nomer);

                        if (estLiTerritoriaVSostave) break;
                    }

                    if (!estLiTerritoriaVSostave)
                    {
                        spisokBivsihSosedeiIgrokov.Add(igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]);
                    }

                }

                for (int bivshiSosedIgrok = 0; bivshiSosedIgrok < spisokBivsihSosedeiIgrokov.Count; bivshiSosedIgrok++)
                {
                    igroki[indexIgrokaPoteravshego].SosediIgroki.Remove(spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]);
                    igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]))].SosediIgroki.Remove(igroki[indexIgrokaPoteravshego].Nomer);
                }

            }
            else
            {
                igroki[indexIgrokaPoteravshego].SosediTerritorii.Clear();

                for (int i = 0; i < igroki[indexIgrokaPoteravshego].SosediIgroki.Count; i++)
                {
                    int indexSoseda = igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[indexIgrokaPoteravshego].SosediIgroki[i]));

                    if (igroki[indexSoseda].SosediIgroki.Contains(igroki[indexIgrokaPoteravshego].Nomer)) igroki[indexSoseda].SosediIgroki.Remove(igroki[indexIgrokaPoteravshego].Nomer);
                }

                igroki[indexIgrokaPoteravshego].SosediIgroki.Clear();
                igroki[indexIgrokaPoteravshego].JivLi = false;

                int nomerIgroka = igroki[indexIgroka].Nomer;

                if (igroki[indexIgrokaPoteravshego].Tip == Baza.tip[0]) Data.kolichestvoNI--;
                else if (igroki[indexIgrokaPoteravshego].Tip == Baza.tip[1]) Data.kolichestvoJI--;
                else if (igroki[indexIgrokaPoteravshego].Tip == Baza.tip[2]) Data.kolichestvoIP--;

                if (Data.kolichestvoJI == 0) Data.prisutstvuiutLiJI = false;

                igrokiVneIgri.Add(igroki[indexIgrokaPoteravshego]);
                igroki.Remove(igroki[indexIgrokaPoteravshego]);

                Proverka.ProverkaPolojeniaIndexaIgroka(igroki, ref indexIgroka, nomerIgroka);

            }
        }

        public void Pocrass(List<Igrok> igroki, List<Igrok> igrokiVneIgri, List<Territorii> territorii, ref int indexIgrok, int nomerTerritoriiPoteri)
        {
            int indexIgrokaDlaLambdi = indexIgrok;

            int indexIgrokaPoteravshego = igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(nomerTerritoriiPoteri) && list.Nomer != igroki[indexIgrokaDlaLambdi].Nomer);

            igroki[indexIgrok].KolicestvoOD -= Baza.cenaZahvataTerritorii;
            igroki[indexIgrok].CenaZahvata += Baza.cenaZahvataTerritorii;
            igroki[indexIgrokaPoteravshego].CenaZahvata -= Baza.cenaZahvataTerritorii;

            igroki[indexIgrok].SosediIgroki.Remove(igroki[indexIgrokaPoteravshego].Nomer);

            Rabota_S_Soseduami_U_Igroka_Poluchivshego(igroki, territorii, indexIgrok, nomerTerritoriiPoteri);

            Rabota_S_Soseduami_U_Igroka_Poteriavsego(igroki, igrokiVneIgri, territorii, ref indexIgrok, indexIgrokaPoteravshego, nomerTerritoriiPoteri);

        }
    }
}
