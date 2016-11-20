namespace TeraziSatis
{
    partial class frmIndirim
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
            this.txtIndirimYuzdesi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblStokBilgileri = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtIndirimliFiyat = new DevExpress.XtraEditors.TextEdit();
            this.txtNormalFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnYuzdeGir = new DevExpress.XtraEditors.SimpleButton();
            this.btnFiyatGir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndirimYuzdesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndirimliFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIndirimYuzdesi
            // 
            this.txtIndirimYuzdesi.Location = new System.Drawing.Point(204, 108);
            this.txtIndirimYuzdesi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIndirimYuzdesi.Name = "txtIndirimYuzdesi";
            this.txtIndirimYuzdesi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtIndirimYuzdesi.Properties.Appearance.Options.UseFont = true;
            this.txtIndirimYuzdesi.Properties.DisplayFormat.FormatString = "n2";
            this.txtIndirimYuzdesi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIndirimYuzdesi.Properties.EditFormat.FormatString = "n2";
            this.txtIndirimYuzdesi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIndirimYuzdesi.Size = new System.Drawing.Size(132, 30);
            this.txtIndirimYuzdesi.TabIndex = 0;
            this.txtIndirimYuzdesi.EditValueChanged += new System.EventHandler(this.txtIndirimYuzdesi_EditValueChanged);
            this.txtIndirimYuzdesi.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtIndirimYuzdesi_EditValueChanging);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Location = new System.Drawing.Point(204, 79);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(137, 24);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "İndirim Yüzdesi";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl2.Location = new System.Drawing.Point(399, 79);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(122, 24);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Indirimli Fiyat";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // lblStokBilgileri
            // 
            this.lblStokBilgileri.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblStokBilgileri.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStokBilgileri.Location = new System.Drawing.Point(10, 10);
            this.lblStokBilgileri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStokBilgileri.Name = "lblStokBilgileri";
            this.lblStokBilgileri.Size = new System.Drawing.Size(481, 64);
            this.lblStokBilgileri.TabIndex = 2;
            this.lblStokBilgileri.Text = "Stok Bilgileri";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(14, 339);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(185, 82);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Uygula";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(399, 339);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(185, 82);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Vazgeç";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtIndirimliFiyat
            // 
            this.txtIndirimliFiyat.Location = new System.Drawing.Point(399, 108);
            this.txtIndirimliFiyat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIndirimliFiyat.Name = "txtIndirimliFiyat";
            this.txtIndirimliFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtIndirimliFiyat.Properties.Appearance.Options.UseFont = true;
            this.txtIndirimliFiyat.Properties.DisplayFormat.FormatString = "c2";
            this.txtIndirimliFiyat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIndirimliFiyat.Properties.EditFormat.FormatString = "c2";
            this.txtIndirimliFiyat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtIndirimliFiyat.Size = new System.Drawing.Size(132, 30);
            this.txtIndirimliFiyat.TabIndex = 0;
            this.txtIndirimliFiyat.EditValueChanged += new System.EventHandler(this.txtIndirimliFiyat_EditValueChanged);
            // 
            // txtNormalFiyat
            // 
            this.txtNormalFiyat.Location = new System.Drawing.Point(10, 108);
            this.txtNormalFiyat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNormalFiyat.Name = "txtNormalFiyat";
            this.txtNormalFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtNormalFiyat.Properties.Appearance.Options.UseFont = true;
            this.txtNormalFiyat.Properties.DisplayFormat.FormatString = "c2";
            this.txtNormalFiyat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNormalFiyat.Properties.EditFormat.FormatString = "c2";
            this.txtNormalFiyat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNormalFiyat.Size = new System.Drawing.Size(132, 30);
            this.txtNormalFiyat.TabIndex = 0;
            this.txtNormalFiyat.EditValueChanged += new System.EventHandler(this.txtNormalFiyat_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl4.Location = new System.Drawing.Point(10, 79);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 24);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Normal Fiyat";
            // 
            // btnYuzdeGir
            // 
            this.btnYuzdeGir.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnYuzdeGir.Appearance.Options.UseFont = true;
            this.btnYuzdeGir.Location = new System.Drawing.Point(204, 142);
            this.btnYuzdeGir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYuzdeGir.Name = "btnYuzdeGir";
            this.btnYuzdeGir.Size = new System.Drawing.Size(132, 41);
            this.btnYuzdeGir.TabIndex = 4;
            this.btnYuzdeGir.Text = "Yüzde Gir";
            this.btnYuzdeGir.Click += new System.EventHandler(this.btnYuzdeGir_Click);
            // 
            // btnFiyatGir
            // 
            this.btnFiyatGir.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnFiyatGir.Appearance.Options.UseFont = true;
            this.btnFiyatGir.Location = new System.Drawing.Point(399, 142);
            this.btnFiyatGir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFiyatGir.Name = "btnFiyatGir";
            this.btnFiyatGir.Size = new System.Drawing.Size(132, 41);
            this.btnFiyatGir.TabIndex = 4;
            this.btnFiyatGir.Text = "Fiyat Gir";
            this.btnFiyatGir.Click += new System.EventHandler(this.btnFiyatGir_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl3.Location = new System.Drawing.Point(402, 230);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(122, 24);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "İndirimli Satış";
            this.labelControl3.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl5.Location = new System.Drawing.Point(10, 230);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(102, 24);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Satış Tutarı";
            this.labelControl5.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl6.Location = new System.Drawing.Point(190, 230);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(181, 24);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "İndirimli Satış Tutarı";
            this.labelControl6.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(399, 259);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.DisplayFormat.FormatString = "c2";
            this.textEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Properties.EditFormat.FormatString = "c2";
            this.textEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Size = new System.Drawing.Size(132, 30);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.Visible = false;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(10, 259);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.DisplayFormat.FormatString = "c2";
            this.textEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit2.Properties.EditFormat.FormatString = "c2";
            this.textEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit2.Size = new System.Drawing.Size(132, 30);
            this.textEdit2.TabIndex = 6;
            this.textEdit2.Visible = false;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(204, 259);
            this.textEdit3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.DisplayFormat.FormatString = "n2";
            this.textEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit3.Properties.EditFormat.FormatString = "n2";
            this.textEdit3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit3.Size = new System.Drawing.Size(132, 30);
            this.textEdit3.TabIndex = 7;
            this.textEdit3.Visible = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(204, 293);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(132, 41);
            this.simpleButton3.TabIndex = 11;
            this.simpleButton3.Text = "Yüzde Gir";
            this.simpleButton3.Visible = false;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(399, 293);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(132, 41);
            this.simpleButton4.TabIndex = 11;
            this.simpleButton4.Text = "Tutar Gir";
            this.simpleButton4.Visible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(615, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(521, 429);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // checkButton1
            // 
            this.checkButton1.Location = new System.Drawing.Point(615, 10);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(521, 32);
            this.checkButton1.TabIndex = 13;
            this.checkButton1.Text = "ÇOKLU SEÇİM";
            // 
            // frmIndirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 505);
            this.ControlBox = false;
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.btnFiyatGir);
            this.Controls.Add(this.btnYuzdeGir);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblStokBilgileri);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtIndirimliFiyat);
            this.Controls.Add(this.txtNormalFiyat);
            this.Controls.Add(this.txtIndirimYuzdesi);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmIndirim";
            this.Text = "frmIndirim";
            this.Load += new System.EventHandler(this.frmIndirim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtIndirimYuzdesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndirimliFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtIndirimYuzdesi;
        public DevExpress.XtraEditors.TextEdit txtIndirimliFiyat;
        public DevExpress.XtraEditors.TextEdit txtNormalFiyat;
        public DevExpress.XtraEditors.LabelControl lblStokBilgileri;
        private DevExpress.XtraEditors.SimpleButton btnYuzdeGir;
        private DevExpress.XtraEditors.SimpleButton btnFiyatGir;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        public DevExpress.XtraEditors.TextEdit textEdit2;
        public DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckButton checkButton1;
    }
}