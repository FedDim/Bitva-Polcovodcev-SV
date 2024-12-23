namespace Bitva_Polcovodcev
{
    partial class Igra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Igra));
            this.panelInterfeis = new System.Windows.Forms.Panel();
            this.buttonHod = new System.Windows.Forms.Button();
            this.labelOD = new System.Windows.Forms.Label();
            this.buttonBrosok = new System.Windows.Forms.Button();
            this.pictureBrosok = new System.Windows.Forms.PictureBox();
            this.labelNazvanie = new System.Windows.Forms.Label();
            this.pictureFlag = new System.Windows.Forms.PictureBox();
            this.pictureKarta = new System.Windows.Forms.PictureBox();
            this.panelDeistvie = new System.Windows.Forms.Panel();
            this.panelPobeda = new System.Windows.Forms.Panel();
            this.labelTextPobedi = new System.Windows.Forms.Label();
            this.buttonPobedaVihod = new System.Windows.Forms.Button();
            this.buttonPobedaGlavnoeMenu = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonMenuVihod = new System.Windows.Forms.Button();
            this.buttonMenuVGlavnoeMenu = new System.Windows.Forms.Button();
            this.buttonMenuNabludatel = new System.Windows.Forms.Button();
            this.timerProverkaNazatia = new System.Windows.Forms.Timer(this.components);
            this.panelInterfeis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrosok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKarta)).BeginInit();
            this.panelDeistvie.SuspendLayout();
            this.panelPobeda.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInterfeis
            // 
            this.panelInterfeis.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelInterfeis.Controls.Add(this.buttonHod);
            this.panelInterfeis.Controls.Add(this.labelOD);
            this.panelInterfeis.Controls.Add(this.buttonBrosok);
            this.panelInterfeis.Controls.Add(this.pictureBrosok);
            this.panelInterfeis.Controls.Add(this.labelNazvanie);
            this.panelInterfeis.Controls.Add(this.pictureFlag);
            this.panelInterfeis.Location = new System.Drawing.Point(565, 33);
            this.panelInterfeis.Margin = new System.Windows.Forms.Padding(4);
            this.panelInterfeis.Name = "panelInterfeis";
            this.panelInterfeis.Size = new System.Drawing.Size(276, 468);
            this.panelInterfeis.TabIndex = 1;
            // 
            // buttonHod
            // 
            this.buttonHod.BackColor = System.Drawing.Color.Gray;
            this.buttonHod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHod.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHod.ForeColor = System.Drawing.Color.Yellow;
            this.buttonHod.Location = new System.Drawing.Point(15, 421);
            this.buttonHod.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHod.Name = "buttonHod";
            this.buttonHod.Size = new System.Drawing.Size(119, 46);
            this.buttonHod.TabIndex = 4;
            this.buttonHod.TabStop = false;
            this.buttonHod.Text = "Следующій Ходъ";
            this.buttonHod.UseVisualStyleBackColor = false;
            this.buttonHod.Click += new System.EventHandler(this.ButtonHod_Click);
            // 
            // labelOD
            // 
            this.labelOD.AutoSize = true;
            this.labelOD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOD.Location = new System.Drawing.Point(49, 389);
            this.labelOD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOD.Name = "labelOD";
            this.labelOD.Size = new System.Drawing.Size(80, 25);
            this.labelOD.TabIndex = 3;
            this.labelOD.Text = "label1";
            // 
            // buttonBrosok
            // 
            this.buttonBrosok.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonBrosok.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrosok.ForeColor = System.Drawing.Color.White;
            this.buttonBrosok.Location = new System.Drawing.Point(35, 342);
            this.buttonBrosok.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrosok.Name = "buttonBrosok";
            this.buttonBrosok.Size = new System.Drawing.Size(152, 31);
            this.buttonBrosok.TabIndex = 2;
            this.buttonBrosok.TabStop = false;
            this.buttonBrosok.Text = "Бросокъ Кубика";
            this.buttonBrosok.UseVisualStyleBackColor = false;
            this.buttonBrosok.Click += new System.EventHandler(this.ButtonBrosok_Click);
            // 
            // pictureBrosok
            // 
            this.pictureBrosok.Image = global::Bitva_Polcovodcev.Properties.Resources.Niet;
            this.pictureBrosok.Location = new System.Drawing.Point(35, 218);
            this.pictureBrosok.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBrosok.Name = "pictureBrosok";
            this.pictureBrosok.Size = new System.Drawing.Size(152, 117);
            this.pictureBrosok.TabIndex = 2;
            this.pictureBrosok.TabStop = false;
            // 
            // labelNazvanie
            // 
            this.labelNazvanie.AutoSize = true;
            this.labelNazvanie.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNazvanie.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelNazvanie.Location = new System.Drawing.Point(55, 171);
            this.labelNazvanie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNazvanie.Name = "labelNazvanie";
            this.labelNazvanie.Size = new System.Drawing.Size(80, 25);
            this.labelNazvanie.TabIndex = 1;
            this.labelNazvanie.Text = "label1";
            // 
            // pictureFlag
            // 
            this.pictureFlag.BackColor = System.Drawing.SystemColors.Info;
            this.pictureFlag.Location = new System.Drawing.Point(0, 0);
            this.pictureFlag.Margin = new System.Windows.Forms.Padding(4);
            this.pictureFlag.Name = "pictureFlag";
            this.pictureFlag.Size = new System.Drawing.Size(176, 144);
            this.pictureFlag.TabIndex = 0;
            this.pictureFlag.TabStop = false;
            // 
            // pictureKarta
            // 
            this.pictureKarta.Location = new System.Drawing.Point(0, 0);
            this.pictureKarta.Margin = new System.Windows.Forms.Padding(4);
            this.pictureKarta.Name = "pictureKarta";
            this.pictureKarta.Size = new System.Drawing.Size(423, 351);
            this.pictureKarta.TabIndex = 0;
            this.pictureKarta.TabStop = false;
            this.pictureKarta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureKarta_MouseDown);
            // 
            // panelDeistvie
            // 
            this.panelDeistvie.Controls.Add(this.panelPobeda);
            this.panelDeistvie.Controls.Add(this.panelMenu);
            this.panelDeistvie.Location = new System.Drawing.Point(0, 33);
            this.panelDeistvie.Name = "panelDeistvie";
            this.panelDeistvie.Size = new System.Drawing.Size(721, 414);
            this.panelDeistvie.TabIndex = 1;
            this.panelDeistvie.Visible = false;
            this.panelDeistvie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelDeistvie_MouseDown);
            // 
            // panelPobeda
            // 
            this.panelPobeda.Controls.Add(this.labelTextPobedi);
            this.panelPobeda.Controls.Add(this.buttonPobedaVihod);
            this.panelPobeda.Controls.Add(this.buttonPobedaGlavnoeMenu);
            this.panelPobeda.Location = new System.Drawing.Point(428, 52);
            this.panelPobeda.Name = "panelPobeda";
            this.panelPobeda.Size = new System.Drawing.Size(270, 190);
            this.panelPobeda.TabIndex = 1;
            this.panelPobeda.Visible = false;
            // 
            // labelTextPobedi
            // 
            this.labelTextPobedi.AutoEllipsis = true;
            this.labelTextPobedi.AutoSize = true;
            this.labelTextPobedi.Location = new System.Drawing.Point(69, 44);
            this.labelTextPobedi.Name = "labelTextPobedi";
            this.labelTextPobedi.Size = new System.Drawing.Size(44, 16);
            this.labelTextPobedi.TabIndex = 2;
            this.labelTextPobedi.Text = "label1";
            // 
            // buttonPobedaVihod
            // 
            this.buttonPobedaVihod.Location = new System.Drawing.Point(37, 130);
            this.buttonPobedaVihod.Name = "buttonPobedaVihod";
            this.buttonPobedaVihod.Size = new System.Drawing.Size(197, 42);
            this.buttonPobedaVihod.TabIndex = 1;
            this.buttonPobedaVihod.TabStop = false;
            this.buttonPobedaVihod.Text = "На рабочій столъ";
            this.buttonPobedaVihod.UseVisualStyleBackColor = true;
            this.buttonPobedaVihod.Click += new System.EventHandler(this.ButtonVixod_Click);
            // 
            // buttonPobedaGlavnoeMenu
            // 
            this.buttonPobedaGlavnoeMenu.Location = new System.Drawing.Point(37, 82);
            this.buttonPobedaGlavnoeMenu.Name = "buttonPobedaGlavnoeMenu";
            this.buttonPobedaGlavnoeMenu.Size = new System.Drawing.Size(197, 42);
            this.buttonPobedaGlavnoeMenu.TabIndex = 0;
            this.buttonPobedaGlavnoeMenu.TabStop = false;
            this.buttonPobedaGlavnoeMenu.Text = "Въ главное меню";
            this.buttonPobedaGlavnoeMenu.UseVisualStyleBackColor = true;
            this.buttonPobedaGlavnoeMenu.Click += new System.EventHandler(this.ButtonGlavnoeMenu_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonMenuVihod);
            this.panelMenu.Controls.Add(this.buttonMenuVGlavnoeMenu);
            this.panelMenu.Controls.Add(this.buttonMenuNabludatel);
            this.panelMenu.Location = new System.Drawing.Point(46, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(305, 242);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Visible = false;
            // 
            // buttonMenuVihod
            // 
            this.buttonMenuVihod.Location = new System.Drawing.Point(66, 161);
            this.buttonMenuVihod.Name = "buttonMenuVihod";
            this.buttonMenuVihod.Size = new System.Drawing.Size(170, 54);
            this.buttonMenuVihod.TabIndex = 2;
            this.buttonMenuVihod.TabStop = false;
            this.buttonMenuVihod.Text = "На рабочій столъ";
            this.buttonMenuVihod.UseVisualStyleBackColor = true;
            this.buttonMenuVihod.Click += new System.EventHandler(this.ButtonVixod_Click);
            // 
            // buttonMenuVGlavnoeMenu
            // 
            this.buttonMenuVGlavnoeMenu.Location = new System.Drawing.Point(66, 107);
            this.buttonMenuVGlavnoeMenu.Name = "buttonMenuVGlavnoeMenu";
            this.buttonMenuVGlavnoeMenu.Size = new System.Drawing.Size(170, 54);
            this.buttonMenuVGlavnoeMenu.TabIndex = 1;
            this.buttonMenuVGlavnoeMenu.TabStop = false;
            this.buttonMenuVGlavnoeMenu.Text = "Въ главное меню";
            this.buttonMenuVGlavnoeMenu.UseVisualStyleBackColor = true;
            this.buttonMenuVGlavnoeMenu.Click += new System.EventHandler(this.ButtonGlavnoeMenu_Click);
            // 
            // buttonMenuNabludatel
            // 
            this.buttonMenuNabludatel.Enabled = false;
            this.buttonMenuNabludatel.Location = new System.Drawing.Point(66, 53);
            this.buttonMenuNabludatel.Name = "buttonMenuNabludatel";
            this.buttonMenuNabludatel.Size = new System.Drawing.Size(170, 54);
            this.buttonMenuNabludatel.TabIndex = 0;
            this.buttonMenuNabludatel.TabStop = false;
            this.buttonMenuNabludatel.Text = "Наблюдатель";
            this.buttonMenuNabludatel.UseVisualStyleBackColor = true;
            // 
            // timerProverkaNazatia
            // 
            this.timerProverkaNazatia.Tick += new System.EventHandler(this.TimerProverkaNazatia_Tick);
            // 
            // Igra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelDeistvie);
            this.Controls.Add(this.panelInterfeis);
            this.Controls.Add(this.pictureKarta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Igra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Битва Поководцевъ";
            this.Load += new System.EventHandler(this.FormIgra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Igra_KeyDown);
            this.panelInterfeis.ResumeLayout(false);
            this.panelInterfeis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrosok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKarta)).EndInit();
            this.panelDeistvie.ResumeLayout(false);
            this.panelPobeda.ResumeLayout(false);
            this.panelPobeda.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureKarta;
        private System.Windows.Forms.Panel panelInterfeis;
        private System.Windows.Forms.PictureBox pictureFlag;
        private System.Windows.Forms.Label labelNazvanie;
        private System.Windows.Forms.PictureBox pictureBrosok;
        private System.Windows.Forms.Button buttonBrosok;
        private System.Windows.Forms.Label labelOD;
        private System.Windows.Forms.Button buttonHod;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelPobeda;
        private System.Windows.Forms.Label labelTextPobedi;
        private System.Windows.Forms.Button buttonPobedaVihod;
        private System.Windows.Forms.Button buttonPobedaGlavnoeMenu;
        private System.Windows.Forms.Button buttonMenuVihod;
        private System.Windows.Forms.Button buttonMenuVGlavnoeMenu;
        private System.Windows.Forms.Button buttonMenuNabludatel;
        private System.Windows.Forms.Timer timerProverkaNazatia;
        public System.Windows.Forms.Panel panelDeistvie;
    }
}

