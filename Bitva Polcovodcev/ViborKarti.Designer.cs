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
            this.vibor = new System.Windows.Forms.Button();
            this.karta = new System.Windows.Forms.Panel();
            this.kolichestvoIgrokov = new System.Windows.Forms.Label();
            this.kolichestvoTerritorii = new System.Windows.Forms.Label();
            this.cenaZahvata = new System.Windows.Forms.Label();
            this.nazvanie = new System.Windows.Forms.Label();
            this.kartina = new System.Windows.Forms.PictureBox();
            this.kNastroikeIgrokov = new System.Windows.Forms.Button();
            this.kartiFon = new System.Windows.Forms.Panel();
            this.karti.SuspendLayout();
            this.karta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kartina)).BeginInit();
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
            this.vibor.Click += new System.EventHandler(this.vibor_Click);
            // 
            // karta
            // 
            this.karta.BackColor = System.Drawing.Color.Gray;
            this.karta.Controls.Add(this.kolichestvoIgrokov);
            this.karta.Controls.Add(this.kolichestvoTerritorii);
            this.karta.Controls.Add(this.cenaZahvata);
            this.karta.Controls.Add(this.nazvanie);
            this.karta.Controls.Add(this.kartina);
            this.karta.Controls.Add(this.kNastroikeIgrokov);
            this.karta.Location = new System.Drawing.Point(395, 0);
            this.karta.Name = "karta";
            this.karta.Size = new System.Drawing.Size(520, 439);
            this.karta.TabIndex = 1;
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
            // kolichestvoTerritorii
            // 
            this.kolichestvoTerritorii.AutoSize = true;
            this.kolichestvoTerritorii.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolichestvoTerritorii.ForeColor = System.Drawing.Color.Yellow;
            this.kolichestvoTerritorii.Location = new System.Drawing.Point(3, 384);
            this.kolichestvoTerritorii.Name = "kolichestvoTerritorii";
            this.kolichestvoTerritorii.Size = new System.Drawing.Size(230, 24);
            this.kolichestvoTerritorii.TabIndex = 4;
            this.kolichestvoTerritorii.Text = "Количество Территорій";
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
            // kartina
            // 
            this.kartina.Image = global::Bitva_Polcovodcev.Properties.Resources.BitvaZaOstrov_Provincii;
            this.kartina.Location = new System.Drawing.Point(3, 4);
            this.kartina.Name = "kartina";
            this.kartina.Size = new System.Drawing.Size(514, 329);
            this.kartina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kartina.TabIndex = 1;
            this.kartina.TabStop = false;
            // 
            // kNastroikeIgrokov
            // 
            this.kNastroikeIgrokov.BackColor = System.Drawing.Color.DimGray;
            this.kNastroikeIgrokov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kNastroikeIgrokov.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kNastroikeIgrokov.ForeColor = System.Drawing.Color.Yellow;
            this.kNastroikeIgrokov.Location = new System.Drawing.Point(367, 336);
            this.kNastroikeIgrokov.Name = "kNastroikeIgrokov";
            this.kNastroikeIgrokov.Size = new System.Drawing.Size(150, 100);
            this.kNastroikeIgrokov.TabIndex = 0;
            this.kNastroikeIgrokov.Text = "Къ Настроке Игроковъ";
            this.kNastroikeIgrokov.UseVisualStyleBackColor = false;
            this.kNastroikeIgrokov.Click += new System.EventHandler(this.kNastroikeIgrokov_Click);
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
            this.Controls.Add(this.karta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViborKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выборъ Карты";
            this.Load += new System.EventHandler(this.ViborKarti_Load);
            this.karti.ResumeLayout(false);
            this.karta.ResumeLayout(false);
            this.karta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kartina)).EndInit();
            this.kartiFon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel karti;
        private System.Windows.Forms.Panel karta;
        private System.Windows.Forms.Button vibor;
        private System.Windows.Forms.PictureBox kartina;
        private System.Windows.Forms.Button kNastroikeIgrokov;
        private System.Windows.Forms.Label nazvanie;
        private System.Windows.Forms.Label kolichestvoTerritorii;
        private System.Windows.Forms.Label cenaZahvata;
        private System.Windows.Forms.Label kolichestvoIgrokov;
        private System.Windows.Forms.Panel kartiFon;
    }
}