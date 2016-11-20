namespace clsTablolar.Yazdirma
{
    partial class frmYaziciAyarlari
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbYaziciAdi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbCiftTarafliYazdirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbKagitKaynagi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbKagitTipi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbKagitBoyutu = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYaziciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCiftTarafliYazdirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitKaynagi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitBoyutu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Yazıcı Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Çift Taraflı Yazdırma";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 145);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Kağıt Kaynağı";
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(12, 369);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(137, 23);
            this.btnTamam.TabIndex = 3;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(215, 369);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(176, 23);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(27, 207);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Kağıt Tipi";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(27, 269);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Kağıt Boyutu";
            // 
            // cmbYaziciAdi
            // 
            this.cmbYaziciAdi.Location = new System.Drawing.Point(27, 40);
            this.cmbYaziciAdi.Name = "cmbYaziciAdi";
            this.cmbYaziciAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYaziciAdi.Size = new System.Drawing.Size(278, 20);
            this.cmbYaziciAdi.TabIndex = 4;
            this.cmbYaziciAdi.SelectedIndexChanged += new System.EventHandler(this.cmbYaziciAdi_SelectedIndexChanged);
            // 
            // cmbCiftTarafliYazdirma
            // 
            this.cmbCiftTarafliYazdirma.Location = new System.Drawing.Point(27, 102);
            this.cmbCiftTarafliYazdirma.Name = "cmbCiftTarafliYazdirma";
            this.cmbCiftTarafliYazdirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCiftTarafliYazdirma.Properties.Items.AddRange(new object[] {
            "Varsayılan",
            "Tek taraflı",
            "Yatay",
            "Dikey"});
            this.cmbCiftTarafliYazdirma.Size = new System.Drawing.Size(278, 20);
            this.cmbCiftTarafliYazdirma.TabIndex = 5;
            // 
            // cmbKagitKaynagi
            // 
            this.cmbKagitKaynagi.Location = new System.Drawing.Point(27, 164);
            this.cmbKagitKaynagi.Name = "cmbKagitKaynagi";
            this.cmbKagitKaynagi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKagitKaynagi.Size = new System.Drawing.Size(278, 20);
            this.cmbKagitKaynagi.TabIndex = 6;
            // 
            // cmbKagitTipi
            // 
            this.cmbKagitTipi.Location = new System.Drawing.Point(27, 226);
            this.cmbKagitTipi.Name = "cmbKagitTipi";
            this.cmbKagitTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKagitTipi.Size = new System.Drawing.Size(278, 20);
            this.cmbKagitTipi.TabIndex = 6;
            // 
            // cmbKagitBoyutu
            // 
            this.cmbKagitBoyutu.Location = new System.Drawing.Point(27, 288);
            this.cmbKagitBoyutu.Name = "cmbKagitBoyutu";
            this.cmbKagitBoyutu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKagitBoyutu.Size = new System.Drawing.Size(278, 20);
            this.cmbKagitBoyutu.TabIndex = 6;
            // 
            // frmYaziciAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 419);
            this.Controls.Add(this.cmbKagitBoyutu);
            this.Controls.Add(this.cmbKagitTipi);
            this.Controls.Add(this.cmbKagitKaynagi);
            this.Controls.Add(this.cmbCiftTarafliYazdirma);
            this.Controls.Add(this.cmbYaziciAdi);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmYaziciAyarlari";
            this.Text = "frmYaziciAyarlari";
            this.Load += new System.EventHandler(this.frmYaziciAyarlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbYaziciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCiftTarafliYazdirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitKaynagi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKagitBoyutu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.ComboBoxEdit cmbYaziciAdi;
        public DevExpress.XtraEditors.ComboBoxEdit cmbCiftTarafliYazdirma;
        public DevExpress.XtraEditors.ComboBoxEdit cmbKagitKaynagi;
        public DevExpress.XtraEditors.ComboBoxEdit cmbKagitTipi;
        public DevExpress.XtraEditors.ComboBoxEdit cmbKagitBoyutu;
    }
}