namespace Aresv2.NumaraSablon
{
  partial class frmNumaraSablon
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcModul = new DevExpress.XtraGrid.GridControl();
            this.gvModul = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIslemTipiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumaraSablon = new DevExpress.XtraGrid.GridControl();
            this.gvNumaraSablon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumaraSablonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMModulID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIlkKarakter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKarakterSayisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarsayilan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSatirEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnSatirSil = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.cbtnYeniSatir = new System.Windows.Forms.ToolStripMenuItem();
            this.cbtnSatirSil = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNumaraSablon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumaraSablon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.gcModul);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.gcNumaraSablon);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(821, 327);
            this.splitContainerControl1.SplitterPosition = 319;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcModul
            // 
            this.gcModul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcModul.Location = new System.Drawing.Point(0, 0);
            this.gcModul.MainView = this.gvModul;
            this.gcModul.Name = "gcModul";
            this.gcModul.Size = new System.Drawing.Size(270, 323);
            this.gcModul.TabIndex = 1;
            this.gcModul.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvModul});
            // 
            // gvModul
            // 
            this.gvModul.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdi,
            this.colIslemTipiID});
            this.gvModul.GridControl = this.gcModul;
            this.gvModul.Name = "gvModul";
            this.gvModul.OptionsBehavior.Editable = false;
            this.gvModul.OptionsView.ShowGroupPanel = false;
            this.gvModul.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvModul_FocusedRowChanged);
            // 
            // colAdi
            // 
            this.colAdi.Caption = "Adi";
            this.colAdi.FieldName = "Adi";
            this.colAdi.Name = "colAdi";
            this.colAdi.Visible = true;
            this.colAdi.VisibleIndex = 1;
            // 
            // colIslemTipiID
            // 
            this.colIslemTipiID.Caption = "IslemTipiID";
            this.colIslemTipiID.FieldName = "IslemTipiID";
            this.colIslemTipiID.Name = "colIslemTipiID";
            this.colIslemTipiID.Visible = true;
            this.colIslemTipiID.VisibleIndex = 0;
            // 
            // gcNumaraSablon
            // 
            this.gcNumaraSablon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNumaraSablon.Location = new System.Drawing.Point(0, 0);
            this.gcNumaraSablon.MainView = this.gvNumaraSablon;
            this.gcNumaraSablon.Name = "gcNumaraSablon";
            this.gcNumaraSablon.Size = new System.Drawing.Size(538, 288);
            this.gcNumaraSablon.TabIndex = 0;
            this.gcNumaraSablon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNumaraSablon});
            // 
            // gvNumaraSablon
            // 
            this.gvNumaraSablon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumaraSablonID,
            this.colMModulID,
            this.colIlkKarakter,
            this.colKarakterSayisi,
            this.colNumara,
            this.colVarsayilan});
            this.gvNumaraSablon.GridControl = this.gcNumaraSablon;
            this.gvNumaraSablon.Name = "gvNumaraSablon";
            this.gvNumaraSablon.OptionsView.ShowGroupPanel = false;
            // 
            // colNumaraSablonID
            // 
            this.colNumaraSablonID.Caption = "NumaraSablonID";
            this.colNumaraSablonID.FieldName = "NumaraSablonID";
            this.colNumaraSablonID.Name = "colNumaraSablonID";
            // 
            // colMModulID
            // 
            this.colMModulID.Caption = "ModulID";
            this.colMModulID.FieldName = "ModulID";
            this.colMModulID.Name = "colMModulID";
            // 
            // colIlkKarakter
            // 
            this.colIlkKarakter.Caption = "İlk Karakter";
            this.colIlkKarakter.FieldName = "IlkKarakter";
            this.colIlkKarakter.Name = "colIlkKarakter";
            this.colIlkKarakter.Visible = true;
            this.colIlkKarakter.VisibleIndex = 0;
            // 
            // colKarakterSayisi
            // 
            this.colKarakterSayisi.Caption = "Karakter Sayısı";
            this.colKarakterSayisi.FieldName = "KarakterSayisi";
            this.colKarakterSayisi.Name = "colKarakterSayisi";
            this.colKarakterSayisi.Visible = true;
            this.colKarakterSayisi.VisibleIndex = 1;
            // 
            // colNumara
            // 
            this.colNumara.Caption = "Numara";
            this.colNumara.FieldName = "Numara";
            this.colNumara.Name = "colNumara";
            this.colNumara.Visible = true;
            this.colNumara.VisibleIndex = 2;
            // 
            // colVarsayilan
            // 
            this.colVarsayilan.Caption = "Varsayılan";
            this.colVarsayilan.FieldName = "Varsayilan";
            this.colVarsayilan.Name = "colVarsayilan";
            this.colVarsayilan.Visible = true;
            this.colVarsayilan.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSatirEkle);
            this.panelControl1.Controls.Add(this.btnKaydet);
            this.panelControl1.Controls.Add(this.btnSatirSil);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 288);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(538, 35);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSatirEkle
            // 
            this.btnSatirEkle.Location = new System.Drawing.Point(246, 7);
            this.btnSatirEkle.Name = "btnSatirEkle";
            this.btnSatirEkle.Size = new System.Drawing.Size(75, 23);
            this.btnSatirEkle.TabIndex = 2;
            this.btnSatirEkle.Text = "Satır Ekle";
            this.btnSatirEkle.Click += new System.EventHandler(this.btnSatirEkle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(408, 6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSatirSil
            // 
            this.btnSatirSil.Location = new System.Drawing.Point(327, 6);
            this.btnSatirSil.Name = "btnSatirSil";
            this.btnSatirSil.Size = new System.Drawing.Size(75, 23);
            this.btnSatirSil.TabIndex = 0;
            this.btnSatirSil.Text = "Satır Sil";
            this.btnSatirSil.Click += new System.EventHandler(this.btnSatirSil_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbtnYeniSatir,
            this.cbtnSatirSil});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // cbtnYeniSatir
            // 
            this.cbtnYeniSatir.Name = "cbtnYeniSatir";
            this.cbtnYeniSatir.Size = new System.Drawing.Size(123, 22);
            this.cbtnYeniSatir.Text = "Yeni Satır";
            // 
            // cbtnSatirSil
            // 
            this.cbtnSatirSil.Name = "cbtnSatirSil";
            this.cbtnSatirSil.Size = new System.Drawing.Size(123, 22);
            this.cbtnSatirSil.Text = "Satır Sil";
            // 
            // frmNumaraSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 327);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumaraSablon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numara Şablon";
            this.Load += new System.EventHandler(this.frmNumaraSablon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNumaraSablon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNumaraSablon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraGrid.GridControl gcModul;
    private DevExpress.XtraGrid.Views.Grid.GridView gvModul;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem cbtnYeniSatir;
    private System.Windows.Forms.ToolStripMenuItem cbtnSatirSil;
    private DevExpress.XtraGrid.GridControl gcNumaraSablon;
    private DevExpress.XtraGrid.Views.Grid.GridView gvNumaraSablon;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btnSatirEkle;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.SimpleButton btnSatirSil;
    private DevExpress.XtraGrid.Columns.GridColumn colAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colIslemTipiID;
    private DevExpress.XtraGrid.Columns.GridColumn colNumaraSablonID;
    private DevExpress.XtraGrid.Columns.GridColumn colMModulID;
    private DevExpress.XtraGrid.Columns.GridColumn colIlkKarakter;
    private DevExpress.XtraGrid.Columns.GridColumn colKarakterSayisi;
    private DevExpress.XtraGrid.Columns.GridColumn colNumara;
    private DevExpress.XtraGrid.Columns.GridColumn colVarsayilan;
  }
}