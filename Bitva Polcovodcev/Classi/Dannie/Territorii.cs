using System.Drawing;


namespace Bitva_Polcovodcev
{
    public class Territorii
    {
        public int IntNomer { get; set; }
        public int IntX { get; set; }
        public int IntY { get; set; }
        public int IntWidth { get; set; }
        public int IntHeight { get; set; }
        public Color CvetTerritorii { get; set; }
        public int[] Sosedi { get; set; }
    }
}
