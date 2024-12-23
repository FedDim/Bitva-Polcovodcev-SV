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
        public static void ZagruzkaElementovFormiIgra(PictureBox pictureKarta, Panel panelInterfeis, Form form)
        {
            pictureKarta.Height = Дата.bitKartaIgri.Height;
            pictureKarta.Width = Дата.bitKartaIgri.Width;

            pictureKarta.Image = Дата.bitKartaIgri;

            panelInterfeis.Location = new Point(pictureKarta.Width, 0);
            panelInterfeis.Height = Дата.bitKartaIgri.Height;

            form.Height = pictureKarta.Height + 38;
            form.Width = pictureKarta.Width + panelInterfeis.Width + 16;

            form.Text = Baza.scenarii[Дата.indexScenaria, 0];
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

        public static void Deserelizacia_TerritoriiData(ref List<Territoria> territorii, string nazvanie)
        {
            try
            {
                territorii = JsonConvert.DeserializeObject<List<Territoria>>(File.ReadAllText(nazvanie));
            }
            catch
            {
                MessageBox.Show("Файлъ: " + nazvanie + " не обнаруженъ");
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

        public static void Sohranenie_IgrokTerritorii(List<Territoria> territorii, string nazvanie)
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

        public static Bitmap ZagruzkaBitmapKarti(string kartaTip)
        {
            //Улучшить проверку
            switch (kartaTip)
            {
                case "Карта Политій":
                    return Дата.indexScenaria == 1 ? Properties.Resources.BitvaZaOstrov_Igroki : Properties.Resources.Proba_Igroki;
                case "Карта Территорій":
                    return Дата.indexScenaria == 1 ? Properties.Resources.BitvaZaOstrov_Territorii : Properties.Resources.Proba_Territorii;
            }

            return null;
        }
    }
}
