

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bitva_Polcovodcev.Classi.Dannie
{
    internal class Data
    {
        public static int indexIgroka, indexScenaria, hod,
            kolichestvoJI, kolichestvoIP, kolichestvoNI;

        public static bool prisutstvuiutLiJI, 
            vozmojnostPeremesheniaPaneliDeistvia = false, 
            konecIgri = false;

        public static List<Igrok> igroki = new List<Igrok>(), igrokiVneIgri = new List<Igrok>();
        public static List<Territoria> territorii = new List<Territoria>();

        public static Bitmap bitKartaIgri, bitKartaTerritorii;

        public static Form Igra;
        public static Panel panelMenu, panelDeistvie;
    }
}
