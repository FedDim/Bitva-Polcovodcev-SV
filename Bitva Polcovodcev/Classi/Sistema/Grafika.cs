using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Bitva_Polcovodcev.Classi.Dannie;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Grafika
    {
        public void Otrisovka(List<Igrok> igroki, List<Territorii> territorii, Bitmap bitKartaTerritorii, ref Bitmap bitKartaIgri, int indexTerritorii, int indexIgroka, PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {

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
                        BitTerritoria.SetPixel(x, y, Baza.pustota);
                    }
                }
            }

            if (igroki[indexIgroka].Tip == Baza.tip[1])
            {
                labelOD.Text = "ОД " + igroki[indexIgroka].KolicestvoOD;
                labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, labelOD.Location.Y);
            }

            Bitmap bitKartaNovusIgri = new Bitmap(bitKartaIgri);
            Graphics grapNovusIgra = Graphics.FromImage(bitKartaNovusIgri);
            grapNovusIgra.CompositingMode = CompositingMode.SourceOver;

            grapNovusIgra.DrawImage(BitTerritoria, 0, 0);

            bitKartaIgri = bitKartaNovusIgri;

            pictureKarta.Image = bitKartaIgri;

            if (!Data.prisutstvuiutLiJI) VivodPorajenia();
        }

        public void RabotaSIgrovimMenu(ref Panel panelDeistvie, ref Panel panelMenu, ref Button buttonNabludatel, ref Button buttonVGlavnoeMenu, ref Button buttonVihod, Form form)
        {
            panelDeistvie.Size = form.Size;

            panelDeistvie.Location = new Point(0, 0);

            panelDeistvie.BackColor = Color.FromArgb(255, 63, 63, 63);

            panelMenu.Visible = true;

            panelMenu.Location = new Point(panelDeistvie.Width / 2 - panelMenu.Width / 2, panelDeistvie.Height / 3);
        }

        public void VivodPobedi(ref Panel panelDeistvie, ref Panel panelPobeda, ref Label labelTekstPopedi, ref Button buttonVMenu, ref Button buttonVihod, string tekstPopedi, string imaIgroka, Form form)
        {
            Data.vozmojnostPeremesheniaPaneliDeistvia = true;
            Data.konecIgri = true;

            int chislo = 10;

            panelDeistvie.Size = new Size(panelPobeda.Width + chislo, panelPobeda.Height + chislo);
            panelDeistvie.Location = new Point(form.Width / 2 - panelDeistvie.Width / 2, form.Height / 2 - panelDeistvie.Height / 2);
            panelPobeda.Location = new Point(chislo/2, chislo/2);

            labelTekstPopedi.Text = "Политія: "+ imaIgroka +" одержала побѣду\n"+tekstPopedi;
            labelTekstPopedi.Location = new Point(panelPobeda.Width/2 - panelPobeda.Width/2, panelPobeda.Height/5);

            panelDeistvie.Visible = true;
            panelPobeda.Visible = true;
        }

        public void VivodPorajenia()
        {
            Data.vozmojnostPeremesheniaPaneliDeistvia = true;
            Data.konecIgri = true;

            int chislo = 10;

            Data.panelDeistvie.Size = new Size(Data.panelMenu.Width + chislo, Data.panelMenu.Height + chislo);
            Data.panelDeistvie.Location = new Point(Data.Igra.Width / 2 - Data.panelDeistvie.Width / 2, Data.Igra.Height / 2 - Data.panelDeistvie.Height / 2);
            Data.panelMenu.Location = new Point(chislo / 2, chislo / 2);

            Data.panelDeistvie.Visible = true;
            Data.panelMenu.Visible = true;
        }
    }
}
