namespace Bitva_Polcovodcev
{
    partial class NastroikaIgri
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NastroikaIgri));
            this.igrat = new System.Windows.Forms.Button();
            this.sohranitIzmenenia = new System.Windows.Forms.Button();
            this.panelSpisokFon = new System.Windows.Forms.Panel();
            this.panelSpisok = new System.Windows.Forms.Panel();
            this.panelElement = new System.Windows.Forms.Panel();
            this.vniz = new System.Windows.Forms.Button();
            this.vverch = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Button();
            this.cvet = new System.Windows.Forms.PictureBox();
            this.ima = new System.Windows.Forms.Label();
            this.primenitIzmenenia = new System.Windows.Forms.Button();
            this.timerProverka = new System.Windows.Forms.Timer(this.components);
            this.panelSpisokFon.SuspendLayout();
            this.panelSpisok.SuspendLayout();
            this.panelElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvet)).BeginInit();
            this.SuspendLayout();
            // 
            // igrat
            // 
            this.igrat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.igrat.ForeColor = System.Drawing.Color.Yellow;
            this.igrat.Location = new System.Drawing.Point(360, 224);
            this.igrat.Margin = new System.Windows.Forms.Padding(4);
            this.igrat.Name = "igrat";
            this.igrat.Size = new System.Drawing.Size(173, 85);
            this.igrat.TabIndex = 0;
            this.igrat.Text = "Играть";
            this.igrat.UseVisualStyleBackColor = false;
            this.igrat.Click += new System.EventHandler(this.igrat_Click);
            // 
            // sohranitIzmenenia
            // 
            this.sohranitIzmenenia.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sohranitIzmenenia.Enabled = false;
            this.sohranitIzmenenia.ForeColor = System.Drawing.Color.Yellow;
            this.sohranitIzmenenia.Location = new System.Drawing.Point(0, 224);
            this.sohranitIzmenenia.Margin = new System.Windows.Forms.Padding(4);
            this.sohranitIzmenenia.Name = "sohranitIzmenenia";
            this.sohranitIzmenenia.Size = new System.Drawing.Size(173, 85);
            this.sohranitIzmenenia.TabIndex = 1;
            this.sohranitIzmenenia.Text = "Сохранить измененія";
            this.sohranitIzmenenia.UseVisualStyleBackColor = false;
            this.sohranitIzmenenia.Click += new System.EventHandler(this.SohranitIzmenenia_Click);
            // 
            // panelSpisokFon
            // 
            this.panelSpisokFon.AutoScroll = true;
            this.panelSpisokFon.Controls.Add(this.panelSpisok);
            this.panelSpisokFon.Location = new System.Drawing.Point(0, 0);
            this.panelSpisokFon.Margin = new System.Windows.Forms.Padding(4);
            this.panelSpisokFon.Name = "panelSpisokFon";
            this.panelSpisokFon.Size = new System.Drawing.Size(533, 224);
            this.panelSpisokFon.TabIndex = 2;
            // 
            // panelSpisok
            // 
            this.panelSpisok.BackColor = System.Drawing.Color.Tan;
            this.panelSpisok.Controls.Add(this.panelElement);
            this.panelSpisok.Location = new System.Drawing.Point(0, 0);
            this.panelSpisok.Margin = new System.Windows.Forms.Padding(4);
            this.panelSpisok.Name = "panelSpisok";
            this.panelSpisok.Size = new System.Drawing.Size(509, 450);
            this.panelSpisok.TabIndex = 0;
            // 
            // panelElement
            // 
            this.panelElement.BackColor = System.Drawing.Color.DarkGreen;
            this.panelElement.Controls.Add(this.vniz);
            this.panelElement.Controls.Add(this.vverch);
            this.panelElement.Controls.Add(this.status);
            this.panelElement.Controls.Add(this.cvet);
            this.panelElement.Controls.Add(this.ima);
            this.panelElement.Location = new System.Drawing.Point(7, 6);
            this.panelElement.Margin = new System.Windows.Forms.Padding(4);
            this.panelElement.Name = "panelElement";
            this.panelElement.Size = new System.Drawing.Size(500, 53);
            this.panelElement.TabIndex = 0;
            this.panelElement.Tag = "0";
            // 
            // vniz
            // 
            this.vniz.BackColor = System.Drawing.Color.Silver;
            this.vniz.Location = new System.Drawing.Point(4, 25);
            this.vniz.Margin = new System.Windows.Forms.Padding(4);
            this.vniz.Name = "vniz";
            this.vniz.Size = new System.Drawing.Size(45, 25);
            this.vniz.TabIndex = 6;
            this.vniz.Tag = "0";
            this.vniz.Text = "↓";
            this.vniz.UseVisualStyleBackColor = false;
            this.vniz.Click += new System.EventHandler(this.Vniz_Click);
            // 
            // vverch
            // 
            this.vverch.BackColor = System.Drawing.Color.Silver;
            this.vverch.Location = new System.Drawing.Point(4, 2);
            this.vverch.Margin = new System.Windows.Forms.Padding(4);
            this.vverch.Name = "vverch";
            this.vverch.Size = new System.Drawing.Size(45, 25);
            this.vverch.TabIndex = 5;
            this.vverch.Tag = "0";
            this.vverch.Text = "↑";
            this.vverch.UseVisualStyleBackColor = false;
            this.vverch.Click += new System.EventHandler(this.Vverch_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.status.Location = new System.Drawing.Point(248, 11);
            this.status.Margin = new System.Windows.Forms.Padding(4);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(60, 26);
            this.status.TabIndex = 4;
            this.status.Tag = "0";
            this.status.Text = "button1";
            this.status.UseVisualStyleBackColor = false;
            this.status.Click += new System.EventHandler(this.Status_Click);
            // 
            // cvet
            // 
            this.cvet.BackColor = System.Drawing.Color.White;
            this.cvet.Location = new System.Drawing.Point(192, 12);
            this.cvet.Margin = new System.Windows.Forms.Padding(4);
            this.cvet.Name = "cvet";
            this.cvet.Size = new System.Drawing.Size(48, 25);
            this.cvet.TabIndex = 3;
            this.cvet.TabStop = false;
            this.cvet.Tag = "0";
            // 
            // ima
            // 
            this.ima.AutoSize = true;
            this.ima.BackColor = System.Drawing.Color.White;
            this.ima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ima.Location = new System.Drawing.Point(53, 12);
            this.ima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ima.Name = "ima";
            this.ima.Size = new System.Drawing.Size(54, 25);
            this.ima.TabIndex = 2;
            this.ima.Tag = "0";
            this.ima.Text = "Имя";
            // 
            // primenitIzmenenia
            // 
            this.primenitIzmenenia.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.primenitIzmenenia.Enabled = false;
            this.primenitIzmenenia.ForeColor = System.Drawing.Color.Yellow;
            this.primenitIzmenenia.Location = new System.Drawing.Point(179, 224);
            this.primenitIzmenenia.Margin = new System.Windows.Forms.Padding(4);
            this.primenitIzmenenia.Name = "primenitIzmenenia";
            this.primenitIzmenenia.Size = new System.Drawing.Size(173, 85);
            this.primenitIzmenenia.TabIndex = 3;
            this.primenitIzmenenia.Text = "Применить измененія";
            this.primenitIzmenenia.UseVisualStyleBackColor = false;
            this.primenitIzmenenia.Click += new System.EventHandler(this.PrimenitIzmenenia_Click);
            // 
            // timerProverka
            // 
            this.timerProverka.Interval = 500;
            this.timerProverka.Tick += new System.EventHandler(this.TimerProverka_Tick);
            // 
            // NastroikaIgri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(533, 308);
            this.Controls.Add(this.primenitIzmenenia);
            this.Controls.Add(this.panelSpisokFon);
            this.Controls.Add(this.sohranitIzmenenia);
            this.Controls.Add(this.igrat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NastroikaIgri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Настройка Игры";
            this.Load += new System.EventHandler(this.NastroikaIgri_Load);
            this.panelSpisokFon.ResumeLayout(false);
            this.panelSpisok.ResumeLayout(false);
            this.panelElement.ResumeLayout(false);
            this.panelElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button igrat;
        private System.Windows.Forms.Button sohranitIzmenenia;
        private System.Windows.Forms.Panel panelSpisokFon;
        private System.Windows.Forms.Panel panelSpisok;
        private System.Windows.Forms.Panel panelElement;
        private System.Windows.Forms.Label ima;
        private System.Windows.Forms.PictureBox cvet;
        private System.Windows.Forms.Button status;
        private System.Windows.Forms.Button vniz;
        private System.Windows.Forms.Button vverch;
        private System.Windows.Forms.Button primenitIzmenenia;
        private System.Windows.Forms.Timer timerProverka;
    }
}