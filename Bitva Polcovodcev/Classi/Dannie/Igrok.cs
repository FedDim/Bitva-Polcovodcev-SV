using System.Collections.Generic;
using System.Drawing;

namespace Bitva_Polcovodcev
{
    public class Igrok
    {
        public int Nomer { get; set; }
        public int KolicestvoOD { get; set; }
        public int CenaZahvata { get; set; }
        public bool JivLi { get; set; }
        public string Ima { get; set; }
        public string Tip { get; set; }
        public string UpravlenieTerritorii { get; set; }
        public string TekstPobedi { get; set; }
        public Color Cvet { get; set; }
        public List<int> PodkontrolnieTerritorii { get; set; }
        public List<int> SosediIgroki { get; set; }
        public List<int> SosediTerritorii { get; set; }
    }
}
