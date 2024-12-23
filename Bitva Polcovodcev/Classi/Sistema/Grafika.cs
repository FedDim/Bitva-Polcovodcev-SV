using Bitva_Polcovodcev.Classi.Dannie;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bitva_Polcovodcev.Classi.Sistema
{
    internal class Grafika
    {
        public static void ПерерисовкаКарты(int indexTerritorii, PictureBox pictureKarta)
        {
            int RisovanieX = Дата.territorii[indexTerritorii].X;

            int RisovanieY = Дата.territorii[indexTerritorii].Y;

            int RisovanieWidth = Дата.territorii[indexTerritorii].Width;

            int RisovanieHeight = Дата.territorii[indexTerritorii].Height;

            Bitmap bitTerritoria = new Bitmap(Дата.bitKartaTerritorii.Width, Дата.bitKartaTerritorii.Height);

            for (int y = RisovanieY; y < RisovanieHeight; y++)
            {
                for (int x = RisovanieX; x < RisovanieWidth; x++)
                {
                    Color cvetPerekrass = Дата.bitKartaTerritorii.GetPixel(x, y);

                    if (cvetPerekrass == Дата.territorii[indexTerritorii].Cvet || (cvetPerekrass.R == Дата.territorii[indexTerritorii].Cvet.R && cvetPerekrass.G == Дата.territorii[indexTerritorii].Cvet.G && cvetPerekrass.B == Дата.territorii[indexTerritorii].Cvet.B))
                    {
                        bitTerritoria.SetPixel(x, y, Дата.igroki[Дата.indexIgroka].Cvet);
                    }
                    else
                    {
                        bitTerritoria.SetPixel(x, y, Baza.pustota);
                    }
                }
            }

            Bitmap bitKartaNovusIgri = new Bitmap(Дата.bitKartaIgri);
            Graphics grapNovusIgra = Graphics.FromImage(bitKartaNovusIgri);
            grapNovusIgra.CompositingMode = CompositingMode.SourceOver;

            grapNovusIgra.DrawImage(bitTerritoria, 0, 0);

            Дата.bitKartaIgri = bitKartaNovusIgri;

            pictureKarta.Image = Дата.bitKartaIgri;

            bitTerritoria.Dispose();
            grapNovusIgra.Dispose();
        }

        public static void ВыводъОД(Label labelОД, Panel panelИнтерфейсъ)
        {
            if (Дата.igroki[Дата.indexIgroka].Tip == Baza.tip[1])
            {
                labelОД.Text = "ОД " + Дата.igroki[Дата.indexIgroka].KolicestvoOD;
                labelОД.Location = new Point(panelИнтерфейсъ.Width / 2 - labelОД.Width / 2, labelОД.Location.Y);
            }
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
            Дата.vozmojnostPeremesheniaPaneliDeistvia = true;
            Дата.konecIgri = true;

            int chislo = 10;

            panelDeistvie.Size = new Size(panelPobeda.Width + chislo, panelPobeda.Height + chislo);
            panelDeistvie.Location = new Point(form.Width / 2 - panelDeistvie.Width / 2, form.Height / 2 - panelDeistvie.Height / 2);
            panelPobeda.Location = new Point(chislo / 2, chislo / 2);

            labelTekstPopedi.Text = "Политія: " + imaIgroka + " одержала побѣду\n" + tekstPopedi;
            labelTekstPopedi.Location = new Point(panelPobeda.Width / 2 - panelPobeda.Width / 2, panelPobeda.Height / 5);

            panelDeistvie.Visible = true;
            panelPobeda.Visible = true;
        }

        public static void VivodPorajenia(ref Panel panelDeistvie, ref Panel panelMenu, ref Panel panelИнтерфейсъ, Form form)
        {
            Дата.vozmojnostPeremesheniaPaneliDeistvia = Дата.konecIgri = true;

            panelИнтерфейсъ.Enabled = false;

            int chislo = 10;

            panelDeistvie.Size = new Size(panelMenu.Width + chislo, panelMenu.Height + chislo);
            panelDeistvie.Location = new Point(form.Width / 2 - panelDeistvie.Width / 2, form.Height / 2 - panelDeistvie.Height / 2);
            panelMenu.Location = new Point(chislo / 2, chislo / 2);

            panelDeistvie.Visible = panelMenu.Visible = true;
        }

    }
}
