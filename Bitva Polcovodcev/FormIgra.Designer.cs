﻿namespace Bitva_Polcovodcev
{
    partial class FormIgra
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
            this.panelInterfeis = new System.Windows.Forms.Panel();
            this.buttonHod = new System.Windows.Forms.Button();
            this.labelOD = new System.Windows.Forms.Label();
            this.buttonBrosok = new System.Windows.Forms.Button();
            this.labelNazvanie = new System.Windows.Forms.Label();
            this.pictureBrosok = new System.Windows.Forms.PictureBox();
            this.pictureFlag = new System.Windows.Forms.PictureBox();
            this.pictureKarta = new System.Windows.Forms.PictureBox();
            this.panelInterfeis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrosok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKarta)).BeginInit();
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
            this.buttonBrosok.TabIndex = 0;
            this.buttonBrosok.Text = "Бросокъ Кубика";
            this.buttonBrosok.UseVisualStyleBackColor = false;
            this.buttonBrosok.Click += new System.EventHandler(this.ButtonBrosok_Click);
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
            this.pictureKarta.Image = global::Bitva_Polcovodcev.Properties.Resources.Proba_Igroki;
            this.pictureKarta.Location = new System.Drawing.Point(0, 0);
            this.pictureKarta.Margin = new System.Windows.Forms.Padding(4);
            this.pictureKarta.Name = "pictureKarta";
            this.pictureKarta.Size = new System.Drawing.Size(423, 351);
            this.pictureKarta.TabIndex = 0;
            this.pictureKarta.TabStop = false;
            this.pictureKarta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureKarta_MouseDown);
            // 
            // FormIgra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelInterfeis);
            this.Controls.Add(this.pictureKarta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIgra";
            this.Text = "Проба";
            this.Load += new System.EventHandler(this.FormIgra_Load);
            this.panelInterfeis.ResumeLayout(false);
            this.panelInterfeis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrosok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKarta)).EndInit();
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
    }
}

