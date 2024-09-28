using Bitva_Polcovodcev.Classi.Dannie;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public class Zagruzka
    {
        public static void ZagruzkaElementovFormiDlaData(Form form, Panel panelDeistvie, Panel panelMenu)
        {
            Data.Igra = form;
            Data.panelDeistvie = panelDeistvie;
            Data.panelMenu = panelMenu;
        }

        public static void ZagruzkaElementovFormiIgra(PictureBox pictureKarta, Bitmap BitKartaIgri, Panel panelInterfeis, Form form, int indexScenaria)
        {
            pictureKarta.Height = BitKartaIgri.Height;
            pictureKarta.Width = BitKartaIgri.Width;

            pictureKarta.Image = BitKartaIgri;

            panelInterfeis.Location = new Point(pictureKarta.Width, 0);
            panelInterfeis.Height = BitKartaIgri.Height;

            form.Height = pictureKarta.Height + 38;
            form.Width = pictureKarta.Width + panelInterfeis.Width + 16;

            form.Text = Baza.scenarii[indexScenaria, 0];
        }

        public static void ZagruzkaElementovFormiDlaIgroka(PictureBox pictureFlag, PictureBox pictureBrosok, Label labelNazvanie, Label labelOD, Button buttonBrosok, Button buttonHod, Panel panelInterfeis)
        {
            pictureFlag.Width = panelInterfeis.Width;
            pictureFlag.Height = panelInterfeis.Height / 4;

            labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);

            pictureBrosok.Width = Properties.Resources.Niet.Width;
            pictureBrosok.Height = Properties.Resources.Niet.Height;
            pictureBrosok.Location = new Point(panelInterfeis.Width / 2 - pictureBrosok.Width / 2, labelNazvanie.Location.Y + labelNazvanie.Height + 5);

            buttonBrosok.Width = pictureBrosok.Width;
            buttonBrosok.Location = new Point(pictureBrosok.Location.X, pictureBrosok.Location.Y + pictureBrosok.Height + 5);

            labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);

            buttonHod.Width = panelInterfeis.Width;
            buttonHod.Height = panelInterfeis.Height - labelOD.Location.Y - labelOD.Height - 5;
            buttonHod.Location = new Point(0, labelOD.Location.Y + labelOD.Height + 5);
        }

        public static void Deserelizacia_IgrokData(ref List<Igrok> igroki, string nazvanie)
        {
            try
            {
                igroki = JsonConvert.DeserializeObject<List<Igrok>>(File.ReadAllText(nazvanie));
            }
            catch
            {
                MessageBox.Show("Файлъ: " + nazvanie + " не обнаруженъ");
            }
        }

        public static void Deserelizacia_TerritoriiData(ref List<Territorii> territorii, string nazvanie)
        {
            try
            {
                territorii = JsonConvert.DeserializeObject<List<Territorii>>(File.ReadAllText(nazvanie));
            }
            catch
            {
                MessageBox.Show("Файлъ: "+ nazvanie + " не обнаруженъ" );
            }
        }

        public static void Sohranenie_IgrokData(List<Igrok> igroki, string nazvanie)
        {
            try
            {
                File.WriteAllText(nazvanie, JsonConvert.SerializeObject(igroki));
                MessageBox.Show("Данные сохранены");
            }
            catch
            {
                MessageBox.Show("Ошибка: " + nazvanie);
            }
        }

        public static void Sohranenie_IgrokTerritorii(List<Territorii> territorii, string nazvanie)
        {
            try
            {
                File.WriteAllText(nazvanie, JsonConvert.SerializeObject(territorii));
            }
            catch
            {
                MessageBox.Show("Ошибка: " + nazvanie);
            }
        }

        public static void ZagruzkaBitmapKart(int indexScenaria, ref Bitmap kartaIgrokov, ref Bitmap kartaTerritorii)
        {
            switch (indexScenaria)
            {
                case 0:
                    kartaIgrokov = Properties.Resources.Proba_Igroki;
                    kartaTerritorii = Properties.Resources.Proba_Territorii;
                    break;
                case 1:
                    kartaIgrokov = Properties.Resources.BitvaZaOstrov_Igroki;
                    kartaTerritorii = Properties.Resources.BitvaZaOstrov_Territorii;
                    break;
                default:

                    break;
            }
        }
    }
}
