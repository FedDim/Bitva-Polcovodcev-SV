using Bitva_Polcovodcev.Classi.Dannie;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Proverka
    {
        public static void ProverkaKorrektnostiElementovDatiIFormi(ref Panel panelMenu, ref Panel panelDeistvie)
        {
            if (!panelDeistvie.Equals(Data.panelDeistvie))
            {
                panelDeistvie = Data.panelDeistvie;
                panelMenu = Data.panelMenu;
            }
                
        }

        public static void FormirovanieSpiskaZahvataTerritorii(List<int> spisokSosedei, List<int> kandidatiDlaZahvata, int indexTerritorii)
        {
            for (int i = 0; i < spisokSosedei.Count; i++)
            {
                if (Data.igroki[Data.igroki.FindIndex(igrok => int.Equals(igrok.Nomer, spisokSosedei[i]))].PodkontrolnieTerritorii.Contains(Data.igroki[Data.indexIgroka].SosediTerritorii[indexTerritorii]))
                {
                    kandidatiDlaZahvata.Add(Data.igroki[Data.indexIgroka].SosediTerritorii[indexTerritorii]);
                }
            }

        }

        public static void ProverkaPolojeniaIndexaIgroka(int nomerIgroka)
        {
            for (int i = 0; i < Data.igroki.Count; i++)
            {
                if (Data.igroki[i].Nomer == nomerIgroka)
                {
                    Data.indexIgroka = i;
                    break;
                }
            }
        }

        public static void ProverkaTipovIgrokov(ref int kolichestvoJI, ref int kolichestvoIP, ref int kolichestvoNI)
        {
            for (int i = 0; i < Data.igroki.Count; i++)
            {
                if (Data.igroki[i].Tip == Baza.tip[0]) kolichestvoNI++;
                else if (Data.igroki[i].Tip == Baza.tip[1]) kolichestvoJI++;
                else if (Data.igroki[i].Tip == Baza.tip[2]) kolichestvoIP++;
            }
        }

        public static void ProverkaKoordinatDlaPohodnikov(ref int Koordinata, int ZnachenieFormi)
        {
            if (Koordinata > ZnachenieFormi) Koordinata = ZnachenieFormi;

            if (Koordinata < 0) Koordinata = 0;
        }
    }
}
