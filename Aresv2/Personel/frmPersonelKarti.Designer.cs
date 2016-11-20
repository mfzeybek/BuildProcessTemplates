namespace Aresv2.Personel
{
    partial class frmPersonelKarti
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaasi = new DevExpress.XtraEditors.TextEdit();
            this.txtPersonelAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.gcGorevleri = new DevExpress.XtraGrid.GridControl();
            this.gvGorevleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGorevID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_GorevTanimlari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaasi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGorevleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGorevleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GorevTanimlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtSifre);
            this.panelControl2.Controls.Add(this.txtMaasi);
            this.panelControl2.Controls.Add(this.txtPersonelAdi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(377, 109);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(50, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Maaşı";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Personel Adi";
            // 
            // txtMaasi
            // 
            this.txtMaasi.Location = new System.Drawing.Point(89, 37);
            this.txtMaasi.Name = "txtMaasi";
            this.txtMaasi.Size = new System.Drawing.Size(281, 22);
            this.txtMaasi.TabIndex = 0;
            // 
            // txtPersonelAdi
            // 
            this.txtPersonelAdi.Location = new System.Drawing.Point(89, 9);
            this.txtPersonelAdi.Name = "txtPersonelAdi";
            this.txtPersonelAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPersonelAdi.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtPersonelAdi_Properties_ButtonClick);
            this.txtPersonelAdi.Size = new System.Drawing.Size(281, 22);
            this.txtPersonelAdi.TabIndex = 0;
            this.txtPersonelAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtPersonelAdi_ButtonClick);
            this.txtPersonelAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPersonelAdi_KeyDown);
            // 
            // gcGorevleri
            // 
            this.gcGorevleri.Location = new System.Drawing.Point(0, 115);
            this.gcGorevleri.MainView = this.gvGorevleri;
            this.gcGorevleri.Name = "gcGorevleri";
            this.gcGorevleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_GorevTanimlari});
            this.gcGorevleri.Size = new System.Drawing.Size(370, 276);
            this.gcGorevleri.TabIndex = 1;
            this.gcGorevleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGorevleri});
            // 
            // gvGorevleri
            // 
            this.gvGorevleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGorevID});
            this.gvGorevleri.CustomizationFormBounds = new System.Drawing.Rectangle(911, 412, 218, 205);
            this.gvGorevleri.GridControl = this.gcGorevleri;
            this.gvGorevleri.Name = "gvGorevleri";
            this.gvGorevleri.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvGorevleri.OptionsView.ShowGroupPanel = false;
            // 
            // colGorevID
            // 
            this.colGorevID.Caption = "Gorev Adi";
            this.colGorevID.ColumnEdit = this.repositoryItemLookUpEdit_GorevTanimlari;
            this.colGorevID.FieldName = "PersonelGorevID";
            this.colGorevID.Name = "colGorevID";
            this.colGorevID.Visible = true;
            this.colGorevID.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit_GorevTanimlari
            // 
            this.repositoryItemLookUpEdit_GorevTanimlari.AutoHeight = false;
            this.repositoryItemLookUpEdit_GorevTanimlari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_GorevTanimlari.Name = "repositoryItemLookUpEdit_GorevTanimlari";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(0, 410);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(210, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(216, 410);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(80, 23);
            this.btnVazgec.TabIndex = 2;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(302, 410);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(61, 23);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(89, 65);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(281, 22);
            this.txtSifre.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(50, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 16);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Şifre";
            // 
            // frmPersonelKarti
            // 
            this.ClientSize = new System.Drawing.Size(377, 442);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gcGorevleri);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "frmPersonelKarti";
            this.Text = "Personel Kartı";
            this.Load += new System.EventHandler(this.frmPersonelKarti_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPersonelKarti_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaasi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGorevleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGorevleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GorevTanimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMaasi;
        private DevExpress.XtraGrid.GridControl gcGorevleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGorevleri;
        private DevExpress.XtraGrid.Columns.GridColumn colGorevID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_GorevTanimlari;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.ButtonEdit txtPersonelAdi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSifre;
    }
}