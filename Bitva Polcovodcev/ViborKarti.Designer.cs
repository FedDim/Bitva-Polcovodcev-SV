namespace Bitva_Polcovodcev
{
    partial class ViborKarti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViborKarti));
            this.karti = new System.Windows.Forms.Panel();
            this.panelKarta = new System.Windows.Forms.Panel();
            this.vibor = new System.Windows.Forms.Button();
            this.igrat = new System.Windows.Forms.Button();
            this.kartinaKarta = new System.Windows.Forms.PictureBox();
            this.nazvanie = new System.Windows.Forms.Label();
            this.cenaZahvata = new System.Windows.Forms.Label();
            this.kolichestvoTerritoriu = new System.Windows.Forms.Label();
            this.kolichestvoIgrokov = new System.Windows.Forms.Label();
            this.kartiFon = new System.Windows.Forms.Panel();
            this.karti.SuspendLayout();
            this.panelKarta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kartinaKarta)).BeginInit();
            this.kartiFon.SuspendLayout();
            this.SuspendLayout();
            // 
            // karti
            // 
            this.karti.BackColor = System.Drawing.Color.Gainsboro;
            this.karti.Controls.Add(this.vibor);
            this.karti.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.karti.Location = new System.Drawing.Point(0, 0);
            this.karti.Name = "karti";
            this.karti.Size = new System.Drawing.Size(221, 549);
            this.karti.TabIndex = 0;
            // 
            // panelKarta
            // 
            this.panelKarta.BackColor = System.Drawing.Color.Silver;
            this.panelKarta.Controls.Add(this.kolichestvoIgrokov);
            this.panelKarta.Controls.Add(this.kolichestvoTerritoriu);
            this.panelKarta.Controls.Add(this.cenaZahvata);
            this.panelKarta.Controls.Add(this.nazvanie);
            this.panelKarta.Controls.Add(this.kartinaKarta);
            this.panelKarta.Controls.Add(this.igrat);
            this.panelKarta.Location = new System.Drawing.Point(395, 0);
            this.panelKarta.Name = "panelKarta";
            this.panelKarta.Size = new System.Drawing.Size(520, 439);
            this.panelKarta.TabIndex = 1;
            // 
            // vibor
            // 
            this.vibor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.vibor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vibor.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vibor.ForeColor = System.Drawing.Color.Yellow;
            this.vibor.Location = new System.Drawing.Point(3, 3);
            this.vibor.Name = "vibor";
            this.vibor.Size = new System.Drawing.Size(165, 91);
            this.vibor.TabIndex = 0;
            this.vibor.Tag = "0";
            this.vibor.Text = "button1";
            this.vibor.UseVisualStyleBackColor = false;
            // 
            // igrat
            // 
            this.igrat.BackColor = System.Drawing.Color.DimGray;
            this.igrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.igrat.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.igrat.ForeColor = System.Drawing.Color.Yellow;
            this.igrat.Location = new System.Drawing.Point(372, 350);
            this.igrat.Name = "igrat";
            this.igrat.Size = new System.Drawing.Size(145, 86);
            this.igrat.TabIndex = 0;
            this.igrat.Text = "button1";
            this.igrat.UseVisualStyleBackColor = false;
            // 
            // kartinaKarta
            // 
            this.kartinaKarta.Image = global::Bitva_Polcovodcev.Properties.Resources.BitvaZaOstrov_Provincii;
            this.kartinaKarta.Location = new System.Drawing.Point(3, 4);
            this.kartinaKarta.Name = "kartinaKarta";
            this.kartinaKarta.Size = new System.Drawing.Size(514, 329);
            this.kartinaKarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kartinaKarta.TabIndex = 1;
            this.kartinaKarta.TabStop = false;
            // 
            // nazvanie
            // 
            this.nazvanie.AutoSize = true;
            this.nazvanie.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nazvanie.ForeColor = System.Drawing.Color.Yellow;
            this.nazvanie.Location = new System.Drawing.Point(3, 336);
            this.nazvanie.Name = "nazvanie";
            this.nazvanie.Size = new System.Drawing.Size(81, 24);
            this.nazvanie.TabIndex = 2;
            this.nazvanie.Text = "Наваніе";
            // 
            // cenaZahvata
            // 
            this.cenaZahvata.AutoSize = true;
            this.cenaZahvata.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cenaZahvata.ForeColor = System.Drawing.Color.Yellow;
            this.cenaZahvata.Location = new System.Drawing.Point(3, 360);
            this.cenaZahvata.Name = "cenaZahvata";
            this.cenaZahvata.Size = new System.Drawing.Size(139, 24);
            this.cenaZahvata.TabIndex = 3;
            this.cenaZahvata.Text = "Цѣна Захвата";
            // 
            // kolichestvoTerritoriu
            // 
            this.kolichestvoTerritoriu.AutoSize = true;
            this.kolichestvoTerritoriu.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolichestvoTerritoriu.ForeColor = System.Drawing.Color.Yellow;
            this.kolichestvoTerritoriu.Location = new System.Drawing.Point(3, 384);
            this.kolichestvoTerritoriu.Name = "kolichestvoTerritoriu";
            this.kolichestvoTerritoriu.Size = new System.Drawing.Size(230, 24);
            this.kolichestvoTerritoriu.TabIndex = 4;
            this.kolichestvoTerritoriu.Text = "Количество Территорій";
            // 
            // kolichestvoIgrokov
            // 
            this.kolichestvoIgrokov.AutoSize = true;
            this.kolichestvoIgrokov.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolichestvoIgrokov.ForeColor = System.Drawing.Color.Yellow;
            this.kolichestvoIgrokov.Location = new System.Drawing.Point(3, 408);
            this.kolichestvoIgrokov.Name = "kolichestvoIgrokov";
            this.kolichestvoIgrokov.Size = new System.Drawing.Size(321, 24);
            this.kolichestvoIgrokov.TabIndex = 5;
            this.kolichestvoIgrokov.Text = "Количество Возможных Игроковъ";
            // 
            // kartiFon
            // 
            this.kartiFon.AutoScroll = true;
            this.kartiFon.BackColor = System.Drawing.Color.DimGray;
            this.kartiFon.Controls.Add(this.karti);
            this.kartiFon.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.kartiFon.Location = new System.Drawing.Point(0, 0);
            this.kartiFon.Name = "kartiFon";
            this.kartiFon.Size = new System.Drawing.Size(264, 439);
            this.kartiFon.TabIndex = 1;
            // 
            // ViborKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.kartiFon);
            this.Controls.Add(this.panelKarta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViborKarti";
            this.Text = "Битва Полководцевъ";
            this.Load += new System.EventHandler(this.ViborKarti_Load);
            this.karti.ResumeLayout(false);
            this.panelKarta.ResumeLayout(false);
            this.panelKarta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kartinaKarta)).EndInit();
            this.kartiFon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel karti;
        private System.Windows.Forms.Panel panelKarta;
        private System.Windows.Forms.Button vibor;
        private System.Windows.Forms.PictureBox kartinaKarta;
        private System.Windows.Forms.Button igrat;
        private System.Windows.Forms.Label nazvanie;
        private System.Windows.Forms.Label kolichestvoTerritoriu;
        private System.Windows.Forms.Label cenaZahvata;
        private System.Windows.Forms.Label kolichestvoIgrokov;
        private System.Windows.Forms.Panel kartiFon;
    }
}