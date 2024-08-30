using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Grafika
    {
        public void Otrisovka(List<Igrok> igroki, List<Territorii> territorii, Bitmap bitKartaTerritorii, ref Bitmap bitKartaIgri, int indexTerritorii, int indexIgroka, PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {
            Baza baza = new Baza();

            int RisovanieX = territorii[indexTerritorii].X;

            int RisovanieY = territorii[indexTerritorii].Y;

            int RisovanieWidth = territorii[indexTerritorii].Width;

            int RisovanieHeight = territorii[indexTerritorii].Height;

            Bitmap BitTerritoria = new Bitmap(bitKartaTerritorii.Width, bitKartaTerritorii.Height);

            for (int y = RisovanieY; y < RisovanieHeight; y++)
            {
                for (int x = RisovanieX; x < RisovanieWidth; x++)
                {
                    Color cvetPerekrass = bitKartaTerritorii.GetPixel(x, y);

                    if (cvetPerekrass == territorii[indexTerritorii].Cvet || (cvetPerekrass.R == territorii[indexTerritorii].Cvet.R && cvetPerekrass.G == territorii[indexTerritorii].Cvet.G && cvetPerekrass.B == territorii[indexTerritorii].Cvet.B))
                    {
                        BitTerritoria.SetPixel(x, y, igroki[indexIgroka].Cvet);
                    }
                    else
                    {
                        BitTerritoria.SetPixel(x, y, baza.pustota);
                    }
                }
            }

            labelOD.Text = "ОД " + igroki[indexIgroka].KolicestvoOD;
            labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, labelOD.Location.Y);

            Bitmap bitKartaNovusIgri = new Bitmap(bitKartaIgri);
            Graphics grapNovusIgra = Graphics.FromImage(bitKartaNovusIgri);
            grapNovusIgra.CompositingMode = CompositingMode.SourceOver;

            grapNovusIgra.DrawImage(BitTerritoria, 0, 0);

            bitKartaIgri = bitKartaNovusIgri;

            pictureKarta.Image = bitKartaIgri;
        }
    }
}
