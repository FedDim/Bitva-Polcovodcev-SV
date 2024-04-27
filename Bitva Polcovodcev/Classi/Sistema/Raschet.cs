using Bitva_Polcovodcev.Classi.Dannie;
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

        public void Raspredelenie_Rolei(List<Roli> listClassRoli, List<Igrok> listClassIgrok)
        {
            for (int i = 0; i < listClassIgrok.Count; i++)
            {
                //if (listClassRoli[0].Igroki.Contains(listClassIgrok[i].Nomer) && listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[4].Igroki.Remove(listClassIgrok[i].Nomer);

                if (listClassIgrok[i].Tip != dannie.tip[0])
                {
                    //Работа съ Гегемономъ
                    if (listClassRoli[1].Igroki.Count == 0)
                    {
                        listClassIgrok[i].Rol = listClassRoli[1].Ima;
                        listClassRoli[1].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if (listClassIgrok[i].CenaZahvata > listClassIgrok[listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]))].CenaZahvata)
                    {
                        int nomerProslogoGegemona = listClassRoli[1].Igroki[0];
                        listClassRoli[1].Igroki[0] = listClassIgrok[i].Nomer;
                        listClassRoli[2].Igroki.Remove(listClassIgrok[i].Nomer);
                        listClassIgrok[i].Rol = listClassRoli[1].Ima;

                        i = listClassIgrok.FindIndex(list => int.Equals(list.Nomer, nomerProslogoGegemona));
                        listClassIgrok[i].Rol = listClassRoli[2].Ima;
                    }

                    if (listClassIgrok[i].Rol == listClassRoli[1].Ima) continue;

                    int indexGegemona = listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]));

                    //Работа съ Соперникомъ
                    if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata && listClassIgrok[i].CenaZahvata >= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && !listClassRoli[2].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[2].Ima;
                        listClassRoli[2].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassRoli[2].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[2].Igroki.Remove(listClassIgrok[i].Nomer);

                    //Работа съ Середнякомъ
                    if (listClassIgrok[i].CenaZahvata < listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassIgrok[i].CenaZahvata > listClassIgrok[indexGegemona].CenaZahvata / 10 && !listClassRoli[3].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[3].Ima;
                        listClassRoli[3].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if ((listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata / 10 || listClassIgrok[i].CenaZahvata >= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10) && listClassRoli[3].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[3].Igroki.Remove(listClassIgrok[i].Nomer);

                    //Работа съ Изгоемъ
                    if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassIgrok[i].CenaZahvata > 0 && !listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[4].Ima;
                        listClassRoli[4].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if ((listClassIgrok[i].CenaZahvata > listClassIgrok[indexGegemona].CenaZahvata / 10 || listClassIgrok[i].CenaZahvata < 0) && listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[4].Igroki.Remove(listClassIgrok[i].Nomer);
                }
                else if (!listClassRoli[0].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[0].Igroki.Add(listClassIgrok[i].Nomer);
            }

            Sortirovka_Spiskov_Rolei(listClassRoli, listClassIgrok);
        }

        public void Sortirovka_Spiskov_Rolei(List<Roli> listClassRoli, List<Igrok> listClassIgrok)
        {
            int nomerElementa = 0;
            if (listClassRoli[2].Igroki.Count > 1)
            {
                var sortirovkaKonkurenta = listClassRoli[2].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaKonkurenta)
                {
                    listClassRoli[2].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

            nomerElementa = 0;
            if (listClassRoli[3].Igroki.Count > 1)
            {
                var sortirovkaSerednauk = listClassRoli[3].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaSerednauk)
                {
                    listClassRoli[3].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

            nomerElementa = 0;
            if (listClassRoli[4].Igroki.Count > 1)
            {
                var sortirovkaIzgoi = listClassRoli[4].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaIzgoi)
                {
                    listClassRoli[4].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

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
                        igroki[indexIgroka].SosediIgroki.Remove(igroki[indexSoseda].Nomer);
                        igroki[indexSoseda].SosediIgroki.Remove(igroki[indexIgroka].Nomer);
                    }

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
