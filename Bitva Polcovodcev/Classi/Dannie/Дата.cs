

using System.Collections.Generic;
using System.Drawing;

namespace Bitva_Polcovodcev.Classi.Dannie
{
    public static class Дата
    {
        public static int indexIgroka, indexScenaria,
            kolichestvoJI, kolichestvoIP, kolichestvoNI;

        public static bool prisutstvuiutLiJI,
            vozmojnostPeremesheniaPaneliDeistvia = false,
            konecIgri = false;

        public static List<Igrok> igroki = new List<Igrok>(), igrokiVneIgri = new List<Igrok>();
        public static List<Territoria> territorii = new List<Territoria>();

        public static Bitmap bitKartaIgri, bitKartaTerritorii;
    }
}
