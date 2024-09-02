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

        public void ProverkaPolojeniaIndexaIgroka(List<Igrok> igroki, ref int indexIgroka, int nomerIgroka)
        {
            for(int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].Nomer == nomerIgroka)
                {
                    indexIgroka = i;
                    break;
                }
            }
        }
    }
}
