﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public partial class ViborKarti : Form
    {
        public ViborKarti()
        {
            InitializeComponent();
        }

        Button[] vibori;
        Baza baza = new Baza();
        public int indexScenaria;
        NastroikaIgri nastroikaIgri;

        private void ViborKarti_Load(object sender, EventArgs e)
        {
            ZagruzkaElementovFormiViborKarti(this, vibor, ref vibori, karti, kartiFon, karta);

        }

        public void Vibor_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            indexScenaria = Convert.ToInt32(btn.Tag);

            switch (indexScenaria)
            {
                case 0:
                    kartina.Image = Properties.Resources.Proba_Igroki;
                    break;
                case 1:
                    kartina.Image = Properties.Resources.BitvaZaOstrov_Igroki;
                    break;
            }

            nazvanie.Text = "Названіе: " + baza.scenarii[indexScenaria, 0];
            cenaZahvata.Text = "Цѣна Захвата: " + baza.scenarii[indexScenaria, 1];
            kolichestvoTerritorii.Text = "Количество Территорій: " + baza.scenarii[indexScenaria, 2];
            kolichestvoIgrokov.Text = "Количество Возможных Игроковъ: " + baza.scenarii[indexScenaria, 3];

            if (karta.Visible == false) karta.Visible = true;
        }

        public void ZagruzkaElementovFormiViborKarti(Form form, Button vibor, ref Button[] vibori, Panel karti, Panel kartiFon, Panel karta)
        {

            vibor.Height = 75;
            vibor.Width = 120;

            vibori = new Button[baza.scenarii.GetLength(0)];
            vibori[0] = vibor;

            vibor.Text = baza.scenarii[0, 0];

            karti.Width = 126;

            kartiFon.Width = karti.Width + 17;

            for (int i = 1; i < baza.scenarii.GetLength(0); i++)
            {
                vibori[i] = new Button
                {
                    Name = vibori[i - 1].Name,
                    BackColor = vibori[i - 1].BackColor,
                    Height = vibori[i - 1].Height,
                    Width = vibori[i - 1].Width,
                    Text = baza.scenarii[i, 0],
                    Font = vibori[i - 1].Font,
                    FlatStyle = vibori[i - 1].FlatStyle,
                    ForeColor = vibori[i - 1].ForeColor,
                    Location = new Point(vibori[i - 1].Location.X, 5 + vibori[i - 1].Height),
                    Tag = i
                };
                vibori[i].Click += new System.EventHandler(Vibor_Click);
                vibori[i].BringToFront();
                karti.Controls.Add(vibori[i]);
            }

            karta.Location = new Point(kartiFon.Width, 0);

            karti.Height = karta.Height;
            kartiFon.Size = new Size(karti.Width, karta.Height);

            karta.Visible = false;

            form.Size = new Size(karta.Location.X + karta.Width + 16, karta.Height + 40);
        }

        private void KNastroikeIgrokov_Click(object sender, EventArgs e)
        {
            nastroikaIgri = new NastroikaIgri
            {
                Location = new Point(this.Location.X, this.Location.Y),
                indexScenaria = this.indexScenaria
            };
            this.Visible = false;
            nastroikaIgri.ShowDialog();
            this.Dispose();
        }
    }
}