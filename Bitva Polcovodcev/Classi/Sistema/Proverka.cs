using Bitva_Polcovodcev.Classi.Dannie;
using System.Collections.Generic;


namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Proverka
    {
        public static void FormirovanieSpiskaZahvataTerritorii(List<int> spisokSosedei, List<int> kandidatiDlaZahvata, int indexTerritorii)
        {
            for (int i = 0; i < spisokSosedei.Count; i++)
            {
                if (Дата.igroki[Дата.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokSosedei[i]))].PodkontrolnieTerritorii.Contains(Дата.igroki[Дата.indexIgroka].SosediTerritorii[indexTerritorii]))
                {
                    kandidatiDlaZahvata.Add(Дата.igroki[Дата.indexIgroka].SosediTerritorii[indexTerritorii]);
                }
            }

        }

        public static void ProverkaPolojeniaIndexaIgroka(int nomerIgroka)
        {
            for (int i = 0; i < Дата.igroki.Count; i++)
            {
                if (Дата.igroki[i].Nomer == nomerIgroka)
                {
                    Дата.indexIgroka = i;
                    break;
                }
            }
        }

        public static void ProverkaTipovIgrokov(ref int kolichestvoJI, ref int kolichestvoIP, ref int kolichestvoNI)
        {
            for (int i = 0; i < Дата.igroki.Count; i++)
            {
                if (Дата.igroki[i].Tip == Baza.tip[0]) kolichestvoNI++;
                else if (Дата.igroki[i].Tip == Baza.tip[1]) kolichestvoJI++;
                else if (Дата.igroki[i].Tip == Baza.tip[2]) kolichestvoIP++;
            }
        }

        public static void ProverkaKoordinatDlaPohodnikov(ref int Koordinata, int ZnachenieFormi)
        {
            if (Koordinata > ZnachenieFormi) Koordinata = ZnachenieFormi;

            if (Koordinata < 0) Koordinata = 0;
        }
    }
}
