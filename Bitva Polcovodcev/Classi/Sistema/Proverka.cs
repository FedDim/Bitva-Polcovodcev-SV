using Bitva_Polcovodcev.Classi.Dannie;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Proverka
    {
        public static void ProverkaKorrektnostiElementovDatiIFormi(ref Panel panelMenu, ref Panel panelDeistvie)
        {
            if(!panelMenu.Equals(Data.panelMenu)) panelMenu = Data.panelMenu;
            if(!panelDeistvie.Equals(Data.panelDeistvie)) panelDeistvie = Data.panelDeistvie;
        }

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

        public static void ProverkaPolojeniaIndexaIgroka(List<Igrok> igroki, ref int indexIgroka, int nomerIgroka)
        {
            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].Nomer == nomerIgroka)
                {
                    indexIgroka = i;
                    break;
                }
            }
        }

        public static void ProverkaTipovIgrokov(ref int kolichestvoJI, ref int kolichestvoIP, ref int kolichestvoNI, List<Igrok> igroki)
        {
            for (int i = 0; i < igroki.Count; i++)
            {
                if (igroki[i].Tip == Baza.tip[0]) kolichestvoNI++;
                else if (igroki[i].Tip == Baza.tip[1]) kolichestvoJI++;
                else if (igroki[i].Tip == Baza.tip[2]) kolichestvoIP++;
            }
        }

        public static void ProverkaKoordinatDlaPohodnikov(ref int Koordinata, int ZnachenieFormi)
        {
            if (Koordinata > ZnachenieFormi) Koordinata = ZnachenieFormi;

            if (Koordinata < 0) Koordinata = 0;
        }
    }
}
