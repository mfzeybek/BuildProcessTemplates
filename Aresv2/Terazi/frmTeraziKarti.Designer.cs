namespace Aresv2.Terazi
{
    partial class frmTeraziKarti
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
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtTeraziAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoTeraziAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTeraziStokButonGrupTanimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_ButonGruplari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrubuSil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeraziAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoTeraziAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_ButonGruplari)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(31, 328);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(128, 19);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtTeraziAdi
            // 
            this.txtTeraziAdi.Location = new System.Drawing.Point(19, 24);
            this.txtTeraziAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTeraziAdi.Name = "txtTeraziAdi";
            this.txtTeraziAdi.Size = new System.Drawing.Size(132, 20);
            this.txtTeraziAdi.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 6);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Terazi Adi";
            // 
            // memoTeraziAciklama
            // 
            this.memoTeraziAciklama.Location = new System.Drawing.Point(19, 65);
            this.memoTeraziAciklama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoTeraziAciklama.Name = "memoTeraziAciklama";
            this.memoTeraziAciklama.Size = new System.Drawing.Size(596, 78);
            this.memoTeraziAciklama.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 47);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Açıklama";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(10, 184);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_ButonGruplari});
            this.gridControl1.Size = new System.Drawing.Size(855, 140);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTeraziStokButonGrupTanimID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colTeraziStokButonGrupTanimID
            // 
            this.colTeraziStokButonGrupTanimID.Caption = "Grup Adi";
            this.colTeraziStokButonGrupTanimID.ColumnEdit = this.repositoryItemLookUpEdit_ButonGruplari;
            this.colTeraziStokButonGrupTanimID.FieldName = "TeraziStokGrupTanimID";
            this.colTeraziStokButonGrupTanimID.Name = "colTeraziStokButonGrupTanimID";
            this.colTeraziStokButonGrupTanimID.Visible = true;
            this.colTeraziStokButonGrupTanimID.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit_ButonGruplari
            // 
            this.repositoryItemLookUpEdit_ButonGruplari.AutoHeight = false;
            this.repositoryItemLookUpEdit_ButonGruplari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_ButonGruplari.Name = "repositoryItemLookUpEdit_ButonGruplari";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(210, 328);
            this.btnSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(128, 19);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGrubuSil
            // 
            this.btnGrubuSil.Location = new System.Drawing.Point(871, 212);
            this.btnGrubuSil.Name = "btnGrubuSil";
            this.btnGrubuSil.Size = new System.Drawing.Size(75, 23);
            this.btnGrubuSil.TabIndex = 6;
            this.btnGrubuSil.Text = "Grubu Sil";
            this.btnGrubuSil.Click += new System.EventHandler(this.btnGrubuSil_Click);
            // 
            // frmTeraziKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 357);
            this.Controls.Add(this.btnGrubuSil);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.memoTeraziAciklama);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtTeraziAdi);
            this.Controls.Add(this.btnKaydet);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTeraziKarti";
            this.Text = "frmTeraziKarti";
            this.Load += new System.EventHandler(this.frmTeraziKarti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTeraziAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoTeraziAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_ButonGruplari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtTeraziAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoTeraziAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraGrid.Columns.GridColumn colTeraziStokButonGrupTanimID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_ButonGruplari;
        private DevExpress.XtraEditors.SimpleButton btnGrubuSil;
    }
}