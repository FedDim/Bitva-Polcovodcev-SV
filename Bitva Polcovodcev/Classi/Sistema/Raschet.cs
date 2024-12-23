using Bitva_Polcovodcev.Classi.Dannie;
using Bitva_Polcovodcev.Classi.Sistema;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public class Raschet
    {

        public static void SmenaIgroka(
            ref PictureBox pictureFlag, ref PictureBox pictureBrosok, PictureBox pictureKarta,
            bool zagruzka)
        {

            if (!zagruzka || (zagruzka && Дата.igroki[Дата.indexIgroka].Tip == Baza.tip[0]))
            {
                while (true)
                {
                    if (Дата.indexIgroka < Дата.igroki.Count - 1) Дата.indexIgroka++;
                    else Дата.indexIgroka = 0;

                    if (Дата.igroki[Дата.indexIgroka].JivLi && Дата.igroki[Дата.indexIgroka].Tip != Baza.tip[0]) break;
                }
            }

            if (Дата.igroki[Дата.indexIgroka].Tip == Baza.tip[2])
            {
                ИП ип = new ИП();
                ип.Ходъ(pictureKarta);
                if (Дата.igroki.Count > 1)
                {
                    if (Дата.prisutstvuiutLiJI) SmenaIgroka(ref pictureFlag, ref pictureBrosok, pictureKarta, false);
                }
            }
        }

        public static void Rabota_S_Soseduami_U_Igroka_Poluchivshego(int nomerTerritorii)
        {
            Дата.igroki[Дата.indexIgroka].PodkontrolnieTerritorii.Add(nomerTerritorii);
            Дата.igroki[Дата.indexIgroka].SosediTerritorii.Remove(nomerTerritorii);

            //Работа съ Соседями Территоріями
            for (int sosediZahvachennoiTerritorii = 0; sosediZahvachennoiTerritorii < Дата.territorii[nomerTerritorii].Sosedi.Length; sosediZahvachennoiTerritorii++)
            {
                bool boolVSostaveLiStrani = Дата.igroki[Дата.indexIgroka].PodkontrolnieTerritorii.Contains(Дата.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                bool boolZapisanLiUzeVSosedi = Дата.igroki[Дата.indexIgroka].SosediTerritorii.Contains(Дата.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);

                if (!boolVSostaveLiStrani && !boolZapisanLiUzeVSosedi) Дата.igroki[Дата.indexIgroka].SosediTerritorii.Add(Дата.territorii[nomerTerritorii].Sosedi[sosediZahvachennoiTerritorii]);
            }

            //Работа съ Соседями Игроками
            for (int territoriiSosedi = 0; territoriiSosedi < Дата.igroki[Дата.indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
            {
                int indexVladelcaTerritorii = Дата.igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(Дата.igroki[Дата.indexIgroka].SosediTerritorii[territoriiSosedi]));

                if (!Дата.igroki[Дата.indexIgroka].SosediIgroki.Contains(Дата.igroki[indexVladelcaTerritorii].Nomer)) Дата.igroki[Дата.indexIgroka].SosediIgroki.Add(Дата.igroki[indexVladelcaTerritorii].Nomer);
                if (!Дата.igroki[indexVladelcaTerritorii].SosediIgroki.Contains(Дата.igroki[Дата.indexIgroka].Nomer)) Дата.igroki[indexVladelcaTerritorii].SosediIgroki.Add(Дата.igroki[Дата.indexIgroka].Nomer);
            }
        }

        public static void Rabota_S_Soseduami_U_Igroka_Poteriavsego(int indexIgrokaPoteravshego, int nomerTerritorii)
        {
            Дата.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Remove(nomerTerritorii);

            if (Дата.igroki[indexIgrokaPoteravshego].CenaZahvata > 0)
            {
                //Работа съ Соседями Территоріями
                for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < Дата.territorii[nomerTerritorii].Sosedi.Length; sosediPoterannoiTerritorii++)
                {
                    bool uavlaetsaLiTerritoriaChastiuPolitii = Дата.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Contains(Дата.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                    if (uavlaetsaLiTerritoriaChastiuPolitii && !Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii.Contains(nomerTerritorii))
                    {
                        Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii.Add(nomerTerritorii);
                    }
                    else if (!uavlaetsaLiTerritoriaChastiuPolitii)
                    {
                        bool immetGranicuSTerritorieuPolitii = true;

                        for (int territoriaFrakcii = 0; territoriaFrakcii < Дата.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                        {
                            immetGranicuSTerritorieuPolitii = Дата.territorii[Дата.igroki[indexIgrokaPoteravshego].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(Дата.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                            if (immetGranicuSTerritorieuPolitii) break;
                        }

                        if (!immetGranicuSTerritorieuPolitii) Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii.Remove(Дата.territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);
                    }

                }

                //Работа съ Соседями Игроками

                List<int> spisokBivsihSosedeiIgrokov = new List<int>();

                for (int ninesnieSosedi = 0; ninesnieSosedi < Дата.igroki[indexIgrokaPoteravshego].SosediIgroki.Count; ninesnieSosedi++)
                {
                    int indexSoseda = Дата.igroki.FindIndex(list => int.Equals(list.Nomer, Дата.igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]));

                    bool estLiTerritoriaVSostave = false;

                    for (int territoriiSosedi = 0; territoriiSosedi < Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii.Count; territoriiSosedi++)
                    {
                        int indexTerritorii = Дата.territorii.FindIndex(list => int.Equals(list.Nomer, Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii[territoriiSosedi]));

                        estLiTerritoriaVSostave = Дата.igroki[indexSoseda].PodkontrolnieTerritorii.Contains(Дата.territorii[indexTerritorii].Nomer);

                        if (estLiTerritoriaVSostave) break;
                    }

                    if (!estLiTerritoriaVSostave)
                    {
                        spisokBivsihSosedeiIgrokov.Add(Дата.igroki[indexIgrokaPoteravshego].SosediIgroki[ninesnieSosedi]);
                    }

                }

                for (int bivshiSosedIgrok = 0; bivshiSosedIgrok < spisokBivsihSosedeiIgrokov.Count; bivshiSosedIgrok++)
                {
                    Дата.igroki[indexIgrokaPoteravshego].SosediIgroki.Remove(spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]);
                    Дата.igroki[Дата.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]))].SosediIgroki.Remove(Дата.igroki[indexIgrokaPoteravshego].Nomer);
                }

            }
            else
            {
                Дата.igroki[indexIgrokaPoteravshego].SosediTerritorii.Clear();

                for (int i = 0; i < Дата.igroki[indexIgrokaPoteravshego].SosediIgroki.Count; i++)
                {
                    int indexSoseda = Дата.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, Дата.igroki[indexIgrokaPoteravshego].SosediIgroki[i]));

                    if (Дата.igroki[indexSoseda].SosediIgroki.Contains(Дата.igroki[indexIgrokaPoteravshego].Nomer)) Дата.igroki[indexSoseda].SosediIgroki.Remove(Дата.igroki[indexIgrokaPoteravshego].Nomer);
                }

                Дата.igroki[indexIgrokaPoteravshego].SosediIgroki.Clear();
                Дата.igroki[indexIgrokaPoteravshego].JivLi = false;

                int nomerIgroka = Дата.igroki[Дата.indexIgroka].Nomer;

                if (Дата.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[0]) Дата.kolichestvoNI--;
                else if (Дата.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[1]) Дата.kolichestvoJI--;
                else if (Дата.igroki[indexIgrokaPoteravshego].Tip == Baza.tip[2]) Дата.kolichestvoIP--;

                if (Дата.kolichestvoJI == 0) Дата.prisutstvuiutLiJI = false;

                Дата.igrokiVneIgri.Add(Дата.igroki[indexIgrokaPoteravshego]);
                Дата.igroki.Remove(Дата.igroki[indexIgrokaPoteravshego]);

                Proverka.ProverkaPolojeniaIndexaIgroka(nomerIgroka);

            }
        }

        public static void Pocrass(int nomerTerritoriiPoteri)
        {
            int indexIgrokaDlaLambdi = Дата.indexIgroka;

            int indexIgrokaPoteravshego = Дата.igroki.FindIndex(list => list.PodkontrolnieTerritorii.Contains(nomerTerritoriiPoteri) && list.Nomer != Дата.igroki[indexIgrokaDlaLambdi].Nomer);

            Дата.igroki[Дата.indexIgroka].KolicestvoOD -= Baza.cenaZahvataTerritorii;
            Дата.igroki[Дата.indexIgroka].CenaZahvata += Baza.cenaZahvataTerritorii;
            Дата.igroki[indexIgrokaPoteravshego].CenaZahvata -= Baza.cenaZahvataTerritorii;

            Дата.igroki[Дата.indexIgroka].SosediIgroki.Remove(Дата.igroki[indexIgrokaPoteravshego].Nomer);

            Rabota_S_Soseduami_U_Igroka_Poluchivshego(nomerTerritoriiPoteri);

            Rabota_S_Soseduami_U_Igroka_Poteriavsego(indexIgrokaPoteravshego, nomerTerritoriiPoteri);

        }
    }
}
