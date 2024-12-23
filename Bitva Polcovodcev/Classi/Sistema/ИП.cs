using Bitva_Polcovodcev.Classi.Dannie;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    public class ИП
    {
        Random rnd = new Random();
        List<int> territoriiDlaZahvata = new List<int>();

        public void Ходъ(PictureBox pictureKarta)
        {
            BrosokKubika();

            while (Дата.igroki[Дата.indexIgroka].KolicestvoOD > 1)
            {
                //ИП забираетъ территоріи у самого большого сосѣда
                Logika(Дата.igroki);

                if (territoriiDlaZahvata.Count > 0)
                {
                    ViborTerritorii(pictureKarta);

                }

                if (Дата.igroki[Дата.indexIgroka].CenaZahvata == int.Parse(Baza.scenarii[Дата.indexScenaria, 1]))
                {
                    break;
                }
            }

        }

        private void ViborTerritorii(PictureBox pictureKarta)
        {
            int nomerTerritoriiPoteri;

            if (territoriiDlaZahvata.Count > 1)
            {
                nomerTerritoriiPoteri = territoriiDlaZahvata[rnd.Next(0, territoriiDlaZahvata.Count)];
            }
            else
            {
                nomerTerritoriiPoteri = territoriiDlaZahvata[0];
            }

            Raschet.Pocrass(nomerTerritoriiPoteri);

            Grafika.ПерерисовкаКарты(nomerTerritoriiPoteri, pictureKarta);

            territoriiDlaZahvata = new List<int>();
        }

        private void Logika(List<Igrok> igroki)
        {
            Proverka proverka = new Proverka();

            List<int> sosedi = new List<int>();
            int naibolsaiaCenaZahvata = 0;

            for (int i = 0; i < igroki[Дата.indexIgroka].SosediIgroki.Count; i++)
            {
                if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Дата.indexIgroka].SosediIgroki[i]))].CenaZahvata >= naibolsaiaCenaZahvata)
                {
                    if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Дата.indexIgroka].SosediIgroki[i]))].CenaZahvata > naibolsaiaCenaZahvata)
                    {
                        naibolsaiaCenaZahvata = igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Дата.indexIgroka].SosediIgroki[i]))].CenaZahvata;
                        sosedi.Clear();
                    }

                    sosedi.Add(igroki[Дата.indexIgroka].SosediIgroki[i]);

                }
            }

            for (int ter = 0; ter < igroki[Дата.indexIgroka].SosediTerritorii.Count; ter++)
            {

                Proverka.FormirovanieSpiskaZahvataTerritorii(sosedi, territoriiDlaZahvata, ter);
            }
        }

        public void BrosokKubika()
        {
            int Znachenie = rnd.Next(1, 7);

            Дата.igroki[Дата.indexIgroka].KolicestvoOD += Znachenie;
        }
    }
}
