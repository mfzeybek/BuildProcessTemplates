namespace TeraziSatisGuncelleme
{
    partial class Form1
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
            this.btnTamGuncelleme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHizliGuncelleme = new System.Windows.Forms.Button();
            this.btnBetaSurumKur = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTamGuncelleme
            // 
            this.btnTamGuncelleme.Location = new System.Drawing.Point(13, 331);
            this.btnTamGuncelleme.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTamGuncelleme.Name = "btnTamGuncelleme";
            this.btnTamGuncelleme.Size = new System.Drawing.Size(593, 64);
            this.btnTamGuncelleme.TabIndex = 2;
            this.btnTamGuncelleme.Text = "Tam Güncelleme";
            this.btnTamGuncelleme.UseVisualStyleBackColor = true;
            this.btnTamGuncelleme.Click += new System.EventHandler(this.btnTamGuncelleme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnHizliGuncelleme
            // 
            this.btnHizliGuncelleme.Location = new System.Drawing.Point(13, 231);
            this.btnHizliGuncelleme.Margin = new System.Windows.Forms.Padding(2);
            this.btnHizliGuncelleme.Name = "btnHizliGuncelleme";
            this.btnHizliGuncelleme.Size = new System.Drawing.Size(593, 64);
            this.btnHizliGuncelleme.TabIndex = 4;
            this.btnHizliGuncelleme.Text = "Hızlı Güncelleme";
            this.btnHizliGuncelleme.UseVisualStyleBackColor = true;
            this.btnHizliGuncelleme.Click += new System.EventHandler(this.btnHizliGuncelleme_Click);
            // 
            // btnBetaSurumKur
            // 
            this.btnBetaSurumKur.Location = new System.Drawing.Point(13, 131);
            this.btnBetaSurumKur.Margin = new System.Windows.Forms.Padding(2);
            this.btnBetaSurumKur.Name = "btnBetaSurumKur";
            this.btnBetaSurumKur.Size = new System.Drawing.Size(593, 64);
            this.btnBetaSurumKur.TabIndex = 5;
            this.btnBetaSurumKur.Text = "Beta Sürüm";
            this.btnBetaSurumKur.UseVisualStyleBackColor = true;
            this.btnBetaSurumKur.Click += new System.EventHandler(this.btnBetaSurumKur_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(593, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "xml dosyasını indir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBetaSurumKur);
            this.Controls.Add(this.btnHizliGuncelleme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTamGuncelleme);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "v.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTamGuncelleme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHizliGuncelleme;
        private System.Windows.Forms.Button btnBetaSurumKur;
        private System.Windows.Forms.Button button1;
    }
}

