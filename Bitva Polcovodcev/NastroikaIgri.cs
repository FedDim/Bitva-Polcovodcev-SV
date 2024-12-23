using Bitva_Polcovodcev.Classi.Dannie;
using Bitva_Polcovodcev.Classi.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public partial class NastroikaIgri : Form
    {
        public NastroikaIgri()
        {
            InitializeComponent();
        }

        List<Igrok> igrokiDlaRedactirovania;
        Panel[] panelniElement;
        Button[] buttonskiVerch, buttonskiNiz;
        bool dannieShozi = true, dannieSohraneni = false;
        Igra igra;

        private void NastroikaIgri_Load(object sender, EventArgs e)
        {
            Zagruzka.Deserelizacia_IgrokData(ref Data.igroki, Baza.scenarii[Data.indexScenaria, 4]);

            Zagruzka.Deserelizacia_IgrokData(ref igrokiDlaRedactirovania, Baza.scenarii[Data.indexScenaria, 4]);

            Proverka.ProverkaTipovIgrokov(ref Data.kolichestvoJI, ref Data.kolichestvoIP, ref Data.kolichestvoNI);

            ZagruzkaElementovFormiNastroikiIgri();
        }

        private void Vverch_Click(object sender, EventArgs e)
        {
            timerProverka.Start();

            Button btn = (Button)sender;
            for (int i = 0; i < panelniElement.Length; i++)
            {
                if (panelniElement[i].Tag.ToString() == btn.Tag.ToString())
                {
                    int NomerVerhnegoVSpiske = i - 1;
                    int NomerNiznegoVSpiske = i;
                    Point pointVerhnego = panelniElement[NomerVerhnegoVSpiske].Location;
                    Point pointNiznego = panelniElement[NomerNiznegoVSpiske].Location;
                    panelniElement[NomerVerhnegoVSpiske].Location = pointNiznego;
                    panelniElement[NomerNiznegoVSpiske].Location = pointVerhnego;

                    RedactirovanieDannihIgrokov(igrokiDlaRedactirovania, NomerNiznegoVSpiske, NomerVerhnegoVSpiske);

                    if (panelniElement[NomerNiznegoVSpiske].Location.Y <= 5) buttonskiVerch[NomerNiznegoVSpiske].Visible = false;
                    if (panelniElement[NomerVerhnegoVSpiske].Location.Y > 5) buttonskiVerch[NomerVerhnegoVSpiske].Visible = true;
                    if (panelniElement[NomerNiznegoVSpiske].Location.Y < panelSpisok.Height - 5 - panelniElement[NomerNiznegoVSpiske].Height) buttonskiNiz[NomerNiznegoVSpiske].Visible = true;
                    if (panelniElement[NomerVerhnegoVSpiske].Location.Y == panelSpisok.Height - 5 - panelniElement[NomerVerhnegoVSpiske].Height) buttonskiNiz[NomerVerhnegoVSpiske].Visible = false;

                    RedactirovaniePanelnogo(ref panelniElement, NomerNiznegoVSpiske, NomerVerhnegoVSpiske);
                    RedactirovanieButonskago(ref buttonskiVerch, NomerNiznegoVSpiske, NomerVerhnegoVSpiske);
                    RedactirovanieButonskago(ref buttonskiNiz, NomerNiznegoVSpiske, NomerVerhnegoVSpiske);
                    break;
                }
            }
        }

        private void Vniz_Click(object sender, EventArgs e)
        {
            timerProverka.Start();

            Button btn = (Button)sender;
            for (int i = 0; i < panelniElement.Length; i++)
            {
                if (panelniElement[i].Tag.ToString() == btn.Tag.ToString())
                {
                    int NomerVerhnegoVSpiske = i;
                    int NomerNiznegoVSpiske = i + 1;
                    Point pointVerhnego = panelniElement[NomerVerhnegoVSpiske].Location;
                    Point pointNiznego = panelniElement[NomerNiznegoVSpiske].Location;
                    panelniElement[NomerVerhnegoVSpiske].Location = pointNiznego;
                    panelniElement[NomerNiznegoVSpiske].Location = pointVerhnego;

                    if (panelniElement[NomerNiznegoVSpiske].Location.Y <= 5) buttonskiVerch[NomerNiznegoVSpiske].Visible = false;
                    if (panelniElement[NomerVerhnegoVSpiske].Location.Y > 5) buttonskiVerch[NomerVerhnegoVSpiske].Visible = true;
                    if (panelniElement[NomerNiznegoVSpiske].Location.Y < panelSpisok.Height - 5 - panelniElement[NomerNiznegoVSpiske].Height) buttonskiNiz[NomerNiznegoVSpiske].Visible = true;
                    if (panelniElement[NomerVerhnegoVSpiske].Location.Y == panelSpisok.Height - 5 - panelniElement[NomerVerhnegoVSpiske].Height) buttonskiNiz[NomerVerhnegoVSpiske].Visible = false;

                    RedactirovanieDannihIgrokov(igrokiDlaRedactirovania, NomerVerhnegoVSpiske, NomerNiznegoVSpiske);

                    RedactirovaniePanelnogo(ref panelniElement, NomerVerhnegoVSpiske, NomerNiznegoVSpiske);
                    RedactirovanieButonskago(ref buttonskiVerch, NomerVerhnegoVSpiske, NomerNiznegoVSpiske);
                    RedactirovanieButonskago(ref buttonskiNiz, NomerVerhnegoVSpiske, NomerNiznegoVSpiske);
                    break;
                }
            }
        }

        private void Status_Click(object sender, EventArgs e)
        {
            timerProverka.Start();
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Нулевой Игрокъ":
                    btn.Text = "Живой Игрокъ";
                    Data.kolichestvoNI--;
                    Data.kolichestvoJI++;
                    break;
                case "Живой Игрокъ":
                    btn.Text = "Искусственный Противникъ";
                    Data.kolichestvoJI--;
                    Data.kolichestvoIP++;
                    break;
                case "Искусственный Противникъ":
                    btn.Text = "Нулевой Игрокъ";
                    Data.kolichestvoIP--;
                    Data.kolichestvoNI++;
                    break;
            }

            btn.Width = btn.Text.Length;
            igrokiDlaRedactirovania[int.Parse(btn.Tag.ToString())].Tip = btn.Text;

        }

        private void TimerProverka_Tick(object sender, EventArgs e)
        {
            dannieShozi = true;

            for (int i = 0; i < igrokiDlaRedactirovania.Count; i++)
            {
                if (igrokiDlaRedactirovania[i].Nomer != Data.igroki[i].Nomer 
                    || igrokiDlaRedactirovania[i].Tip != Data.igroki[i].Tip) dannieShozi = false;
            }

            if (dannieShozi)
            {
                if (!dannieSohraneni) sohranitIzmenenia.Enabled = false;
                primenitIzmenenia.Enabled = false;

            }
            else
            {
                dannieSohraneni = false;
                if (!dannieSohraneni) sohranitIzmenenia.Enabled = true;
                primenitIzmenenia.Enabled = true;
                timerProverka.Stop();
            }
        }

        private void ZagruzkaElementovFormiNastroikiIgri()
        {
            ima.Text = igrokiDlaRedactirovania[0].Ima;
            cvet.Location = new Point(ima.Location.X + ima.Width + 5, cvet.Location.Y);
            cvet.BackColor = igrokiDlaRedactirovania[0].Cvet;
            status.Text = igrokiDlaRedactirovania[0].Tip;
            status.Location = new Point(cvet.Location.X + cvet.Width + 5, status.Location.Y);

            int intPanelY = panelElement.Location.Y;

            panelniElement = new Panel[igrokiDlaRedactirovania.Count];
            panelniElement[0] = panelElement;
            buttonskiVerch = new Button[igrokiDlaRedactirovania.Count];
            buttonskiVerch[0] = vverch;
            buttonskiNiz = new Button[igrokiDlaRedactirovania.Count];
            buttonskiNiz[0] = vniz;

            for (int i = 1; i < igrokiDlaRedactirovania.Count; i++)
            {
                intPanelY += 5 + panelElement.Height;

                panelniElement[i] = new Panel
                {
                    Name = "panelElement",
                    BackColor = panelElement.BackColor,
                    Height = panelElement.Height,
                    Width = panelElement.Width,
                    Location = new Point(panelElement.Location.X, intPanelY),
                    Tag = i
                };
                panelniElement[i].BringToFront();
                panelSpisok.Controls.Add(panelniElement[i]);

                Label label = new Label
                {
                    Name = "ima",
                    Location = ima.Location,
                    BackColor = ima.BackColor,
                    Font = ima.Font,
                    Text = igrokiDlaRedactirovania[i].Ima,
                    AutoSize = true
                };
                label.BringToFront();
                panelniElement[i].Controls.Add(label);

                buttonskiVerch[i] = new Button
                {
                    Name = "buttonVverch",
                    Location = vverch.Location,
                    Height = vverch.Height,
                    Width = vverch.Width,
                    Text = vverch.Text,
                    BackColor = vverch.BackColor,
                    Tag = i
                };
                buttonskiVerch[i].Click += Vverch_Click;
                buttonskiVerch[i].BringToFront();
                panelniElement[i].Controls.Add(buttonskiVerch[i]);

                buttonskiNiz[i] = new Button
                {
                    Name = "buttonVniz" + i,
                    Location = vniz.Location,
                    Height = vniz.Height,
                    Width = vniz.Width,
                    Text = vniz.Text,
                    BackColor = vniz.BackColor,
                    Tag = i
                };
                buttonskiNiz[i].Click += Vniz_Click;
                buttonskiNiz[i].BringToFront();
                panelniElement[i].Controls.Add(buttonskiNiz[i]);

                PictureBox picture = new PictureBox
                {
                    Name = "cvet",
                    Location = new Point(label.Location.X + label.Width + 5, cvet.Location.Y),
                    Height = cvet.Height,
                    Width = cvet.Width,
                    BackColor = igrokiDlaRedactirovania[i].Cvet,
                };
                picture.BringToFront();
                panelniElement[i].Controls.Add(picture);

                Button button = new Button
                {
                    Name = "buttonStatus",
                    Location = new Point(picture.Location.X + picture.Width + 5, status.Location.Y),
                    Height = status.Height,
                    Width = status.Width,
                    Text = igrokiDlaRedactirovania[i].Tip,
                    BackColor = status.BackColor,
                    AutoSize = true,
                    Tag = i
                };
                button.Click += Status_Click;
                button.BringToFront();
                panelniElement[i].Controls.Add(button);

                panelSpisok.Height = panelniElement[i].Location.Y + panelniElement[i].Height + 5;

                if (panelniElement[i].Location.Y <= 5) buttonskiVerch[i].Visible = false;
                if (i == igrokiDlaRedactirovania.Count - 1 && (panelniElement[i].Location.Y == panelSpisok.Height - 5 - panelniElement[i].Height)) buttonskiNiz[i].Visible = false;

            }

            vverch.Visible = false;
        }

        private void RedactirovanieButonskago(ref Button[] Butonskii, int NomerPervogo, int NomerVtorogo)
        {
            Button[] ButttonDlaSmeni = new Button[3];
            ButttonDlaSmeni[1] = Butonskii[NomerPervogo];
            ButttonDlaSmeni[2] = Butonskii[NomerVtorogo];

            Butonskii[NomerPervogo] = ButttonDlaSmeni[2];
            Butonskii[NomerVtorogo] = ButttonDlaSmeni[1];
        }

        private void RedactirovaniePanelnogo(ref Panel[] Panelni, int NomerPervogo, int NomerVtorogo)
        {
            Panel[] PanelDlaSmeni = new Panel[3];
            PanelDlaSmeni[1] = Panelni[NomerPervogo];
            PanelDlaSmeni[2] = Panelni[NomerVtorogo];

            Panelni[NomerPervogo] = PanelDlaSmeni[2];
            Panelni[NomerVtorogo] = PanelDlaSmeni[1];
        }

        private void RedactirovanieDannihIgrokov(List<Igrok> igroki, int indexPervogo, int indexVtorogo)
        {
            var igrokPervi = igroki[indexPervogo];
            var igrokVtoroi = igroki[indexVtorogo];

            igroki[indexPervogo] = igrokVtoroi;
            igroki[indexVtorogo] = igrokPervi;
        }

        private void PrimenitIzmenenia_Click(object sender, EventArgs e)
        {
            Data.igroki = new List<Igrok> (igrokiDlaRedactirovania);
            primenitIzmenenia.Enabled = false;
        }

        private void Igrat_Click(object sender, EventArgs e)
        {
            if (primenitIzmenenia.Enabled)
            {
                DialogResult otvet = MessageBox.Show("Не желаете ли передъ началомъ игры примѣнить измѣненія?", "Работа съ Данными", MessageBoxButtons.YesNo);

                if(otvet == DialogResult.Yes) Data.igroki = new List<Igrok>(igrokiDlaRedactirovania);
            }

            if (Data.kolichestvoNI + Data.kolichestvoJI + Data.kolichestvoIP != Data.igroki.Count) Proverka.ProverkaTipovIgrokov(ref Data.kolichestvoJI, ref Data.kolichestvoIP, ref Data.kolichestvoNI);

            if (Data.kolichestvoJI > 0) Data.prisutstvuiutLiJI = true;

            igra = new Igra
            {
                Location = new Point(this.Location.X, this.Location.Y),
            };
            this.Visible = false;
            igra.ShowDialog();
            this.Dispose();

        }

        private void SohranitIzmenenia_Click(object sender, EventArgs e)
        {
            Zagruzka.Sohranenie_IgrokData(igrokiDlaRedactirovania, Baza.scenarii[Data.indexScenaria, 4]);
            sohranitIzmenenia.Enabled = false;
        }
    }
}
