using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Bitva_Polcovodcev.Classi.Dannie;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Grafika
    {
        public static void Otrisovka(int indexTerritorii, PictureBox pictureKarta, Label labelOD, Panel panelInterfeis)
        {

            int RisovanieX = Data.territorii[indexTerritorii].X;

            int RisovanieY = Data.territorii[indexTerritorii].Y;

            int RisovanieWidth = Data.territorii[indexTerritorii].Width;

            int RisovanieHeight = Data.territorii[indexTerritorii].Height;

            Bitmap BitTerritoria = new Bitmap(Data.bitKartaTerritorii.Width, Data.bitKartaTerritorii.Height);

            for (int y = RisovanieY; y < RisovanieHeight; y++)
            {
                for (int x = RisovanieX; x < RisovanieWidth; x++)
                {
                    Color cvetPerekrass = Data.bitKartaTerritorii.GetPixel(x, y);

                    if (cvetPerekrass == Data.territorii[indexTerritorii].Cvet || (cvetPerekrass.R == Data.territorii[indexTerritorii].Cvet.R && cvetPerekrass.G == Data.territorii[indexTerritorii].Cvet.G && cvetPerekrass.B == Data.territorii[indexTerritorii].Cvet.B))
                    {
                        BitTerritoria.SetPixel(x, y, Data.igroki[Data.indexIgroka].Cvet);
                    }
                    else
                    {
                        BitTerritoria.SetPixel(x, y, Baza.pustota);
                    }
                }
            }

            if (Data.igroki[Data.indexIgroka].Tip == Baza.tip[1])
            {
                labelOD.Text = "ОД " + Data.igroki[Data.indexIgroka].KolicestvoOD;
                labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, labelOD.Location.Y);
            }

            Bitmap bitKartaNovusIgri = new Bitmap(Data.bitKartaIgri);
            Graphics grapNovusIgra = Graphics.FromImage(bitKartaNovusIgri);
            grapNovusIgra.CompositingMode = CompositingMode.SourceOver;

            grapNovusIgra.DrawImage(BitTerritoria, 0, 0);

            Data.bitKartaIgri = bitKartaNovusIgri;

            pictureKarta.Image = Data.bitKartaIgri;

            if (!Data.prisutstvuiutLiJI) VivodPorajenia();
        }

        public static void RabotaSIgrovimMenu(ref Panel panelDeistvie, ref Panel panelMenu, ref Button buttonNabludatel, ref Button buttonVGlavnoeMenu, ref Button buttonVihod, Form form)
        {
            panelDeistvie.Size = form.Size;

            panelDeistvie.Location = new Point(0, 0);

            panelDeistvie.BackColor = Color.FromArgb(255, 63, 63, 63);

            panelMenu.Visible = true;

            panelMenu.Location = new Point(panelDeistvie.Width / 2 - panelMenu.Width / 2, panelDeistvie.Height / 3);
        }

        public static void VivodPobedi(ref Panel panelDeistvie, ref Panel panelPobeda, ref Label labelTekstPopedi, ref Button buttonVMenu, ref Button buttonVihod, string tekstPopedi, string imaIgroka, Form form)
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

        public static void VivodPorajenia()
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
