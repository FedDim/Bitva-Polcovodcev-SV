using System.Drawing;


namespace Bitva_Polcovodcev
{
    public class Territorii
    {
        public int Nomer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Cvet { get; set; }
        public int[] Sosedi { get; set; }
    }
}
