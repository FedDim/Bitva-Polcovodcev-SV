using System.Collections.Generic;


namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Proverka
    {
        public void FormirovanieSpiskaZahvataTerritorii(List<Igrok> igroki, List<int> spisokSosedei, List<int> kandidatiDlaZahvata, int igrokIndex, int indexTerritorii)
        {
            for (int i = 0; i < spisokSosedei.Count; i++)
            {
                if (igroki[igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokSosedei[i]))].PodkontrolnieTerritorii.Contains(igroki[igrokIndex].SosediTerritorii[indexTerritorii]))
                {
                    kandidatiDlaZahvata.Add(igroki[igrokIndex].SosediTerritorii[indexTerritorii]);
                }
            }

        }

        public void ProverkaNaSushestvovaniePolitii(List<Igrok> igroki, List<Igrok> igrokiVneIgri)
        {
            Baza baza = new Baza();

            List<int> politiiVneIgri = new List<int>();

            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].CenaZahvata == 0 && igroki[i].JivLi)
                {
                    igroki[i].JivLi = false;
                    politiiVneIgri.Add(igroki[i].Nomer);

                }
            }

            for (int i = 0; i < politiiVneIgri.Count; i++)
            {
                int indexIgrokaVneIgri = igroki.FindIndex(igrok => int.Equals(igrok.Nomer, politiiVneIgri[i]));

                igrokiVneIgri.Add(igroki[indexIgrokaVneIgri]);
                igroki.Remove(igroki[indexIgrokaVneIgri]);
            }

        }
    }
}
