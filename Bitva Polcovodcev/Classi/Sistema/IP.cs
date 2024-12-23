using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using Bitva_Polcovodcev.Classi.Dannie;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class IP
    {
        Random rnd = new Random();
        List<int> territoriiDlaZahvata = new List<int>();

        public void Hod(PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {
            BrosokKubika();

            while (Data.igroki[Data.indexIgroka].KolicestvoOD > 1)
            {
                //ИП забираетъ территоріи у самого большого сосѣда
                Logika(Data.igroki);

                if (territoriiDlaZahvata.Count > 0)
                {
                    ViborTerritorii(pictureKarta, labelOD, panelInterfeis);

                }

                if (Data.igroki[Data.indexIgroka].CenaZahvata == int.Parse(Baza.scenarii[Data.indexScenaria, 1]))
                {
                    break;
                }
            }

        }

        public void ViborTerritorii(PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
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

            Grafika.Otrisovka(nomerTerritoriiPoteri, pictureKarta, labelOD, panelInterfeis);

            territoriiDlaZahvata = new List<int>();
        }

        public void Logika(List<Igrok> igroki)
        {
            Proverka proverka = new Proverka();

            List<int> sosedi = new List<int>();
            int naibolsaiaCenaZahvata = 0;

            for (int i = 0; i < igroki[Data.indexIgroka].SosediIgroki.Count; i++)
            {
                if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Data.indexIgroka].SosediIgroki[i]))].CenaZahvata >= naibolsaiaCenaZahvata)
                {
                    if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Data.indexIgroka].SosediIgroki[i]))].CenaZahvata > naibolsaiaCenaZahvata)
                    {
                        naibolsaiaCenaZahvata = igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, igroki[Data.indexIgroka].SosediIgroki[i]))].CenaZahvata;
                        sosedi.Clear();
                    }

                    sosedi.Add(igroki[Data.indexIgroka].SosediIgroki[i]);

                }
            }

            for (int ter = 0; ter < igroki[Data.indexIgroka].SosediTerritorii.Count; ter++)
            {

                Proverka.FormirovanieSpiskaZahvataTerritorii(sosedi, territoriiDlaZahvata, ter);
            }
        }

        public void BrosokKubika()
        {

            int Znachenie = rnd.Next(1, 7);

            Data.igroki[Data.indexIgroka].KolicestvoOD += Znachenie;

        }
    }
}
