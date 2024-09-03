﻿using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class IP
    {
        Random rnd = new Random();
        List<int> territoriiDlaZahvata = new List<int>();

        public void Hod(ref List<Igrok> igroki, List<Igrok> igrokiVneIgri, List<Territorii> territorii, ref int indexIgroka, int indexScenaria, Bitmap bitKartaTerritorii, ref Bitmap bitKartaIgri, PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {
            Baza baza = new Baza();

            BrosokKubika(igroki, indexIgroka);

            while (igroki[indexIgroka].KolicestvoOD > 1)
            {
                //ИП забираетъ территоріи у самого большого сосѣда
                Logika(igroki, indexIgroka);

                if (territoriiDlaZahvata.Count > 0)
                {
                    ViborTerritorii(igroki, igrokiVneIgri, territorii, ref indexIgroka, bitKartaTerritorii, ref bitKartaIgri, pictureKarta, labelOD, panelInterfeis);

                }

                if (igroki[indexIgroka].CenaZahvata == int.Parse(baza.scenarii[indexScenaria, 1]))
                {
                    break;
                }
            }

        }

        public void ViborTerritorii(List<Igrok> igroki, List<Igrok> igrokiVneIgri, List<Territorii> territorii, ref int indexIgrok, Bitmap bitKartaTerritorii, ref Bitmap bitKartaIgri, PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {
            Raschet raschet = new Raschet();
            Grafika grafika = new Grafika();

            int nomerTerritoriiPoteri;

            if (territoriiDlaZahvata.Count > 1)
            {
                nomerTerritoriiPoteri = territoriiDlaZahvata[rnd.Next(0, territoriiDlaZahvata.Count)];
            }
            else
            {
                nomerTerritoriiPoteri = territoriiDlaZahvata[0];
            }

            raschet.Pocrass(igroki, igrokiVneIgri, territorii, ref indexIgrok, nomerTerritoriiPoteri);

            grafika.Otrisovka(igroki, territorii, bitKartaTerritorii, ref bitKartaIgri, nomerTerritoriiPoteri, indexIgrok, pictureKarta, labelOD, panelInterfeis);

            territoriiDlaZahvata = new List<int>();
        }

        public void Logika(List<Igrok> igroki, int indexIgrok)
        {
            Proverka proverka = new Proverka();

            List<int> sosedi = new List<int>();
            int naibolsaiaCenaZahvata = 0;

            for (int i = 0; i < igroki[indexIgrok].SosediIgroki.Count; i++)
            {
                if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[indexIgrok].SosediIgroki[i]))].CenaZahvata >= naibolsaiaCenaZahvata)
                {
                    if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[indexIgrok].SosediIgroki[i]))].CenaZahvata > naibolsaiaCenaZahvata)
                    {
                        naibolsaiaCenaZahvata = igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[indexIgrok].SosediIgroki[i]))].CenaZahvata;
                        sosedi.Clear();
                    }

                    sosedi.Add(igroki[indexIgrok].SosediIgroki[i]);

                }
            }

            for (int ter = 0; ter < igroki[indexIgrok].SosediTerritorii.Count; ter++)
            {
                proverka.FormirovanieSpiskaZahvataTerritorii(igroki, sosedi, territoriiDlaZahvata, indexIgrok, ter);
            }
        }

        public void BrosokKubika(List<Igrok> igroki, int indexIgrok)
        {

            int Znachenie = rnd.Next(1, 7);

            igroki[indexIgrok].KolicestvoOD += Znachenie;

        }
    }
}
