using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public class Raschet
    {
        Baza dannie = new Baza();

        public void SmenaIgroka(List<Igrok> listClassIgrok, ref int NomerIgroka, ref Label labelNazvanie, ref Label labelOD, ref PictureBox pictureFlag, ref PictureBox pictureBrosok, Button buttonBrosok, Button buttonHod, Panel panelInterfeis, ref Color IgrokCvet, bool boolZagruzca)
        {
            if (!boolZagruzca)
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            //Пока нѣтъ ИП его ходъ будетъ пропускатся
            while (listClassIgrok[NomerIgroka].Tip == dannie.tip[2])
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            while (!listClassIgrok[NomerIgroka].JivLi || listClassIgrok[NomerIgroka].Tip == dannie.tip[0])
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            pictureFlag.BackColor = listClassIgrok[NomerIgroka].Cvet;//Пока такъ, дальше догружать флагъ
            labelNazvanie.Text = listClassIgrok[NomerIgroka].Ima;
            labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);
            labelOD.Text = "ОД " + listClassIgrok[NomerIgroka].KolicestvoOD;
            labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);
            pictureBrosok.Image = Properties.Resources.Niet;
            buttonBrosok.Enabled = true;
            buttonHod.Enabled = false;

            IgrokCvet = listClassIgrok[NomerIgroka].Cvet;
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

        public void Rabota_S_Soseduami_U_Igroka_Poteriavsego(List<Igrok> igroki, List<Territorii> territorii, int indexIgroka, int nomerTerritorii)
        {
            igroki[indexIgroka].PodkontrolnieTerritorii.Remove(nomerTerritorii);

            if (igroki[indexIgroka].CenaZahvata > 0)
            {
                //Работа съ Соседями Территоріями
                for (int sosediPoterannoiTerritorii = 0; sosediPoterannoiTerritorii < territorii[nomerTerritorii].Sosedi.Length; sosediPoterannoiTerritorii++)
                {
                    bool uavlaetsaLiTerritoriaChastiuPolitii = igroki[indexIgroka].PodkontrolnieTerritorii.Contains(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                    if (uavlaetsaLiTerritoriaChastiuPolitii && !igroki[indexIgroka].SosediTerritorii.Contains(nomerTerritorii))
                    {
                        igroki[indexIgroka].SosediTerritorii.Add(nomerTerritorii);
                    }
                    else if (!uavlaetsaLiTerritoriaChastiuPolitii)
                    {
                        bool immetGranicuSTerritorieuPolitii = true;

                        for (int territoriaFrakcii = 0; territoriaFrakcii < igroki[indexIgroka].PodkontrolnieTerritorii.Count; territoriaFrakcii++)
                        {
                            immetGranicuSTerritorieuPolitii = territorii[igroki[indexIgroka].PodkontrolnieTerritorii[territoriaFrakcii]].Sosedi.Contains(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);

                            if (immetGranicuSTerritorieuPolitii) break;
                        }

                        if (!immetGranicuSTerritorieuPolitii) igroki[indexIgroka].SosediTerritorii.Remove(territorii[nomerTerritorii].Sosedi[sosediPoterannoiTerritorii]);
                    }

                }

                //Работа съ Соседями Игроками

                List<int> spisokBivsihSosedeiIgrokov = new List<int>();

                for (int ninesnieSosedi = 0; ninesnieSosedi < igroki[indexIgroka].SosediIgroki.Count; ninesnieSosedi++)
                {
                    int indexSoseda = igroki.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgroka].SosediIgroki[ninesnieSosedi]));

                    bool estLiTerritoriaVSostave = false;

                    for (int territoriiSosedi = 0; territoriiSosedi < igroki[indexIgroka].SosediTerritorii.Count; territoriiSosedi++)
                    {
                        int indexTerritorii = territorii.FindIndex(list => int.Equals(list.Nomer, igroki[indexIgroka].SosediTerritorii[territoriiSosedi]));

                        estLiTerritoriaVSostave = igroki[indexSoseda].PodkontrolnieTerritorii.Contains(territorii[indexTerritorii].Nomer);

                        if (estLiTerritoriaVSostave) break;
                    }

                    if (!estLiTerritoriaVSostave)
                    {
                        spisokBivsihSosedeiIgrokov.Add(igroki[indexIgroka].SosediIgroki[ninesnieSosedi]);
                    }

                }

                for (int bivshiSosedIgrok = 0; bivshiSosedIgrok < spisokBivsihSosedeiIgrokov.Count; bivshiSosedIgrok++)
                {
                    igroki[indexIgroka].SosediIgroki.Remove(spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]);
                    igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokBivsihSosedeiIgrokov[bivshiSosedIgrok]))].SosediIgroki.Remove(igroki[indexIgroka].Nomer);
                }

            }
            else
            {
                igroki[indexIgroka].SosediTerritorii.Clear();

                for (int i = 0; i < igroki[indexIgroka].SosediIgroki.Count; i++)
                {
                    int indexSoseda = igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[indexIgroka].SosediIgroki[i]));

                    if (igroki[indexSoseda].SosediIgroki.Contains(igroki[indexIgroka].Nomer)) igroki[indexSoseda].SosediIgroki.Remove(igroki[indexIgroka].Nomer);
                }

                igroki[indexIgroka].SosediIgroki.Clear();
                igroki[indexIgroka].JivLi = false;
            }
        }
    }
}
