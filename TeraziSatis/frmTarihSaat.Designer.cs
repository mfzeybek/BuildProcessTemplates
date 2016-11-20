namespace TeraziSatis
{
    partial class frmTarihSaat
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
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.btnOncekiAy = new DevExpress.XtraEditors.SimpleButton();
            this.btnSonrakiAy = new DevExpress.XtraEditors.SimpleButton();
            this.txtTarih = new DevExpress.XtraEditors.TextEdit();
            this.txtSaat = new DevExpress.XtraEditors.TextEdit();
            this.btnSaatGir = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabah = new DevExpress.XtraEditors.SimpleButton();
            this.btnOglen = new DevExpress.XtraEditors.SimpleButton();
            this.btnAksam = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaatiSil = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnBugun = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.AppearanceCalendar.Font = new System.Drawing.Font("Tahoma", 23F);
            this.dateNavigator1.AppearanceCalendar.Options.UseFont = true;
            this.dateNavigator1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 15F);
            this.dateNavigator1.AppearanceHeader.Options.UseFont = true;
            this.dateNavigator1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateNavigator1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dateNavigator1.DateTime = new System.DateTime(((long)(0)));
            this.dateNavigator1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateNavigator1.HighlightTodayCell = DevExpress.Utils.DefaultBoolean.Default;
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(30, 141);
            this.dateNavigator1.Multiselect = false;
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigator1.ShowTodayButton = false;
            this.dateNavigator1.ShowWeekNumbers = false;
            this.dateNavigator1.Size = new System.Drawing.Size(455, 409);
            this.dateNavigator1.TabIndex = 14;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            this.dateNavigator1.ClientSizeChanged += new System.EventHandler(this.dateNavigator1_ClientSizeChanged);
            this.dateNavigator1.Click += new System.EventHandler(this.dateNavigator1_Click);
            // 
            // btnOncekiAy
            // 
            this.btnOncekiAy.Location = new System.Drawing.Point(30, 73);
            this.btnOncekiAy.Name = "btnOncekiAy";
            this.btnOncekiAy.Size = new System.Drawing.Size(126, 62);
            this.btnOncekiAy.TabIndex = 15;
            this.btnOncekiAy.Text = "Önceki Ay";
            this.btnOncekiAy.Click += new System.EventHandler(this.btnOncekiAy_Click);
            // 
            // btnSonrakiAy
            // 
            this.btnSonrakiAy.Location = new System.Drawing.Point(359, 73);
            this.btnSonrakiAy.Name = "btnSonrakiAy";
            this.btnSonrakiAy.Size = new System.Drawing.Size(126, 62);
            this.btnSonrakiAy.TabIndex = 16;
            this.btnSonrakiAy.Text = "Sonraki Ay";
            this.btnSonrakiAy.Click += new System.EventHandler(this.btnSonrakiAy_Click);
            // 
            // txtTarih
            // 
            this.txtTarih.Location = new System.Drawing.Point(98, 12);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtTarih.Properties.Appearance.Options.UseFont = true;
            this.txtTarih.Properties.DisplayFormat.FormatString = "D";
            this.txtTarih.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTarih.Properties.Mask.EditMask = "D";
            this.txtTarih.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtTarih.Size = new System.Drawing.Size(438, 46);
            this.txtTarih.TabIndex = 18;
            // 
            // txtSaat
            // 
            this.txtSaat.Location = new System.Drawing.Point(655, 12);
            this.txtSaat.Name = "txtSaat";
            this.txtSaat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtSaat.Properties.Appearance.Options.UseFont = true;
            this.txtSaat.Properties.DisplayFormat.FormatString = "t";
            this.txtSaat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSaat.Properties.Mask.EditMask = "t";
            this.txtSaat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtSaat.Size = new System.Drawing.Size(242, 46);
            this.txtSaat.TabIndex = 19;
            this.txtSaat.EditValueChanged += new System.EventHandler(this.txtSaat_EditValueChanged);
            // 
            // btnSaatGir
            // 
            this.btnSaatGir.Location = new System.Drawing.Point(534, 73);
            this.btnSaatGir.Name = "btnSaatGir";
            this.btnSaatGir.Size = new System.Drawing.Size(147, 62);
            this.btnSaatGir.TabIndex = 20;
            this.btnSaatGir.Text = "Saat Gir";
            this.btnSaatGir.Click += new System.EventHandler(this.btnSaatGir_Click);
            // 
            // btnSabah
            // 
            this.btnSabah.Location = new System.Drawing.Point(534, 141);
            this.btnSabah.Name = "btnSabah";
            this.btnSabah.Size = new System.Drawing.Size(147, 62);
            this.btnSabah.TabIndex = 20;
            this.btnSabah.Text = "Sabah 10:00";
            this.btnSabah.Click += new System.EventHandler(this.btnSabah_Click);
            // 
            // btnOglen
            // 
            this.btnOglen.Location = new System.Drawing.Point(534, 209);
            this.btnOglen.Name = "btnOglen";
            this.btnOglen.Size = new System.Drawing.Size(147, 62);
            this.btnOglen.TabIndex = 20;
            this.btnOglen.Text = "Öğlen 13:00";
            this.btnOglen.Click += new System.EventHandler(this.btnOglen_Click);
            // 
            // btnAksam
            // 
            this.btnAksam.Location = new System.Drawing.Point(534, 277);
            this.btnAksam.Name = "btnAksam";
            this.btnAksam.Size = new System.Drawing.Size(147, 62);
            this.btnAksam.TabIndex = 20;
            this.btnAksam.Text = "Akşam 18:00";
            this.btnAksam.Click += new System.EventHandler(this.btnAksam_Click);
            // 
            // btnSaatiSil
            // 
            this.btnSaatiSil.Location = new System.Drawing.Point(750, 73);
            this.btnSaatiSil.Name = "btnSaatiSil";
            this.btnSaatiSil.Size = new System.Drawing.Size(147, 62);
            this.btnSaatiSil.TabIndex = 20;
            this.btnSaatiSil.Text = "Saati Sil";
            this.btnSaatiSil.Click += new System.EventHandler(this.btnSaatiSil_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Location = new System.Drawing.Point(17, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 30);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Tarih";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl2.Location = new System.Drawing.Point(589, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 30);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "Saat";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(530, 488);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(147, 62);
            this.btnTamam.TabIndex = 22;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(694, 488);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(147, 62);
            this.btnIptal.TabIndex = 22;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnBugun
            // 
            this.btnBugun.Location = new System.Drawing.Point(188, 73);
            this.btnBugun.Name = "btnBugun";
            this.btnBugun.Size = new System.Drawing.Size(128, 62);
            this.btnBugun.TabIndex = 23;
            this.btnBugun.Text = "Bugün";
            this.btnBugun.Click += new System.EventHandler(this.btnBugun_Click);
            // 
            // frmTarihSaat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 565);
            this.ControlBox = false;
            this.Controls.Add(this.btnBugun);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnAksam);
            this.Controls.Add(this.btnOglen);
            this.Controls.Add(this.btnSabah);
            this.Controls.Add(this.btnSaatiSil);
            this.Controls.Add(this.btnSaatGir);
            this.Controls.Add(this.txtSaat);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.btnSonrakiAy);
            this.Controls.Add(this.btnOncekiAy);
            this.Controls.Add(this.dateNavigator1);
            this.Name = "frmTarihSaat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarih Saat";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOncekiAy;
        private DevExpress.XtraEditors.SimpleButton btnSonrakiAy;
        private DevExpress.XtraEditors.TextEdit txtTarih;
        private DevExpress.XtraEditors.TextEdit txtSaat;
        private DevExpress.XtraEditors.SimpleButton btnSaatGir;
        private DevExpress.XtraEditors.SimpleButton btnSabah;
        private DevExpress.XtraEditors.SimpleButton btnOglen;
        private DevExpress.XtraEditors.SimpleButton btnAksam;
        private DevExpress.XtraEditors.SimpleButton btnSaatiSil;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnBugun;
        public DevExpress.XtraScheduler.DateNavigator dateNavigator1;
    }
}