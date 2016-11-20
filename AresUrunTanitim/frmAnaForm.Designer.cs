namespace AresUrunTanitim
{
  partial class frmAnaForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnaForm));
      this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.gcUrunListesi = new DevExpress.XtraGrid.GridControl();
      this.gvUrunListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.StokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.txtArama = new DevExpress.XtraEditors.TextEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.gcResimler = new DevExpress.XtraGrid.GridControl();
      this.gvResimler = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
      this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
      this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
      this.timer1 = new System.Windows.Forms.Timer();
      this.lblStokAdi = new DevExpress.XtraEditors.LabelControl();
      this.lblRafyeri = new DevExpress.XtraEditors.LabelControl();
      this.pnlKisayolListesi = new DevExpress.XtraEditors.PanelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.lblFiyati = new DevExpress.XtraEditors.LabelControl();
      this.lblMiktari = new DevExpress.XtraEditors.LabelControl();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gcUrunListesi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvUrunListesi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcResimler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvResimler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pnlKisayolListesi)).BeginInit();
      this.pnlKisayolListesi.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 53);
      this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
      this.splitContainerControl1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Left;
      this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
      this.splitContainerControl1.Panel1.Controls.Add(this.gcResimler);
      this.splitContainerControl1.Panel1.Text = "Panel1";
      this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
      this.splitContainerControl1.Panel2.Controls.Add(this.pictureEdit2);
      this.splitContainerControl1.Panel2.Controls.Add(this.pictureEdit1);
      this.splitContainerControl1.Panel2.Text = "Panel2";
      this.splitContainerControl1.Size = new System.Drawing.Size(944, 516);
      this.splitContainerControl1.SplitterPosition = 214;
      this.splitContainerControl1.TabIndex = 1;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.gcUrunListesi);
      this.panelControl1.Controls.Add(this.txtArama);
      this.panelControl1.Controls.Add(this.labelControl2);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(210, 389);
      this.panelControl1.TabIndex = 2;
      // 
      // gcUrunListesi
      // 
      this.gcUrunListesi.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcUrunListesi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
      this.gcUrunListesi.Location = new System.Drawing.Point(2, 54);
      this.gcUrunListesi.MainView = this.gvUrunListesi;
      this.gcUrunListesi.Margin = new System.Windows.Forms.Padding(4);
      this.gcUrunListesi.Name = "gcUrunListesi";
      this.gcUrunListesi.Size = new System.Drawing.Size(206, 333);
      this.gcUrunListesi.TabIndex = 1;
      this.gcUrunListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUrunListesi});
      // 
      // gvUrunListesi
      // 
      this.gvUrunListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StokAdi});
      this.gvUrunListesi.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvUrunListesi.GridControl = this.gcUrunListesi;
      this.gvUrunListesi.Name = "gvUrunListesi";
      this.gvUrunListesi.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvUrunListesi.OptionsBehavior.Editable = false;
      this.gvUrunListesi.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvUrunListesi.OptionsView.ShowGroupPanel = false;
      this.gvUrunListesi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUrunListesi_FocusedRowChanged);
      // 
      // StokAdi
      // 
      this.StokAdi.Caption = "colStokAdi";
      this.StokAdi.FieldName = "StokAdi";
      this.StokAdi.Name = "StokAdi";
      this.StokAdi.Visible = true;
      this.StokAdi.VisibleIndex = 0;
      // 
      // txtArama
      // 
      this.txtArama.Dock = System.Windows.Forms.DockStyle.Top;
      this.txtArama.Location = new System.Drawing.Point(2, 32);
      this.txtArama.Margin = new System.Windows.Forms.Padding(4);
      this.txtArama.Name = "txtArama";
      this.txtArama.Size = new System.Drawing.Size(206, 22);
      this.txtArama.TabIndex = 3;
      this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
      // 
      // labelControl2
      // 
      this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
      this.labelControl2.Location = new System.Drawing.Point(2, 2);
      this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(206, 30);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "labelControl2";
      // 
      // gcResimler
      // 
      this.gcResimler.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.gcResimler.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
      this.gcResimler.Location = new System.Drawing.Point(0, 389);
      this.gcResimler.MainView = this.gvResimler;
      this.gcResimler.Margin = new System.Windows.Forms.Padding(4);
      this.gcResimler.Name = "gcResimler";
      this.gcResimler.Size = new System.Drawing.Size(210, 123);
      this.gcResimler.TabIndex = 1;
      this.gcResimler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResimler});
      // 
      // gvResimler
      // 
      this.gvResimler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAciklama});
      this.gvResimler.GridControl = this.gcResimler;
      this.gvResimler.Name = "gvResimler";
      this.gvResimler.OptionsBehavior.Editable = false;
      this.gvResimler.OptionsBehavior.ReadOnly = true;
      this.gvResimler.OptionsView.ShowGroupPanel = false;
      // 
      // colAciklama
      // 
      this.colAciklama.Caption = "colAciklama";
      this.colAciklama.FieldName = "colAciklama";
      this.colAciklama.Name = "colAciklama";
      this.colAciklama.Visible = true;
      this.colAciklama.VisibleIndex = 0;
      // 
      // pictureEdit2
      // 
      this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
      this.pictureEdit2.Location = new System.Drawing.Point(90, 76);
      this.pictureEdit2.Margin = new System.Windows.Forms.Padding(4);
      this.pictureEdit2.Name = "pictureEdit2";
      this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
      this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.pictureEdit2.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
      this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
      this.pictureEdit2.Size = new System.Drawing.Size(549, 380);
      this.pictureEdit2.TabIndex = 2;
      this.pictureEdit2.Visible = false;
      // 
      // pictureEdit1
      // 
      this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
      this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
      this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
      this.pictureEdit1.Name = "pictureEdit1";
      this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
      this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
      this.pictureEdit1.Size = new System.Drawing.Size(721, 512);
      this.pictureEdit1.TabIndex = 1;
      // 
      // timer1
      // 
      this.timer1.Interval = 100000;
      this.timer1.Tag = "100000";
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblStokAdi
      // 
      this.lblStokAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lblStokAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblStokAdi.Location = new System.Drawing.Point(96, 4);
      this.lblStokAdi.Margin = new System.Windows.Forms.Padding(4);
      this.lblStokAdi.Name = "lblStokAdi";
      this.lblStokAdi.Size = new System.Drawing.Size(351, 38);
      this.lblStokAdi.TabIndex = 0;
      this.lblStokAdi.Text = "STOK ADI";
      // 
      // lblRafyeri
      // 
      this.lblRafyeri.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lblRafyeri.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblRafyeri.Location = new System.Drawing.Point(607, 4);
      this.lblRafyeri.Margin = new System.Windows.Forms.Padding(4);
      this.lblRafyeri.Name = "lblRafyeri";
      this.lblRafyeri.Size = new System.Drawing.Size(123, 38);
      this.lblRafyeri.TabIndex = 0;
      this.lblRafyeri.Text = "RAF YERİ";
      // 
      // pnlKisayolListesi
      // 
      this.pnlKisayolListesi.Controls.Add(this.labelControl4);
      this.pnlKisayolListesi.Controls.Add(this.labelControl6);
      this.pnlKisayolListesi.Controls.Add(this.labelControl3);
      this.pnlKisayolListesi.Controls.Add(this.lblMiktari);
      this.pnlKisayolListesi.Controls.Add(this.lblRafyeri);
      this.pnlKisayolListesi.Controls.Add(this.labelControl1);
      this.pnlKisayolListesi.Controls.Add(this.lblFiyati);
      this.pnlKisayolListesi.Controls.Add(this.lblStokAdi);
      this.pnlKisayolListesi.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlKisayolListesi.Location = new System.Drawing.Point(0, 0);
      this.pnlKisayolListesi.Margin = new System.Windows.Forms.Padding(4);
      this.pnlKisayolListesi.Name = "pnlKisayolListesi";
      this.pnlKisayolListesi.Size = new System.Drawing.Size(944, 53);
      this.pnlKisayolListesi.TabIndex = 0;
      // 
      // labelControl4
      // 
      this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl4.Location = new System.Drawing.Point(346, 4);
      this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(88, 38);
      this.labelControl4.TabIndex = 6;
      this.labelControl4.Text = "FİYATI :";
      // 
      // labelControl3
      // 
      this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl3.Location = new System.Drawing.Point(519, 4);
      this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(80, 38);
      this.labelControl3.TabIndex = 5;
      this.labelControl3.Text = "RAF YERİ :";
      // 
      // labelControl1
      // 
      this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl1.Location = new System.Drawing.Point(8, 4);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(88, 38);
      this.labelControl1.TabIndex = 4;
      this.labelControl1.Text = "STOK ADI : ";
      // 
      // lblFiyati
      // 
      this.lblFiyati.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lblFiyati.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblFiyati.Location = new System.Drawing.Point(434, 4);
      this.lblFiyati.Margin = new System.Windows.Forms.Padding(4);
      this.lblFiyati.Name = "lblFiyati";
      this.lblFiyati.Size = new System.Drawing.Size(121, 38);
      this.lblFiyati.TabIndex = 3;
      this.lblFiyati.Text = "Fiyatı";
      // 
      // lblMiktari
      // 
      this.lblMiktari.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lblMiktari.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblMiktari.Location = new System.Drawing.Point(787, 4);
      this.lblMiktari.Margin = new System.Windows.Forms.Padding(4);
      this.lblMiktari.Name = "lblMiktari";
      this.lblMiktari.Size = new System.Drawing.Size(123, 38);
      this.lblMiktari.TabIndex = 0;
      this.lblMiktari.Text = "RAF YERİ";
      // 
      // labelControl6
      // 
      this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl6.Location = new System.Drawing.Point(699, 4);
      this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(80, 38);
      this.labelControl6.TabIndex = 5;
      this.labelControl6.Text = "Miktarı :";
      // 
      // frmAnaForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(944, 569);
      this.Controls.Add(this.splitContainerControl1);
      this.Controls.Add(this.pnlKisayolListesi);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmAnaForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Ürün tanıtım Ekranı";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAnaForm_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnaForm_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gcUrunListesi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvUrunListesi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcResimler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvResimler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pnlKisayolListesi)).EndInit();
      this.pnlKisayolListesi.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private System.Windows.Forms.Timer timer1;
    private DevExpress.XtraGrid.GridControl gcResimler;
    private DevExpress.XtraGrid.Views.Grid.GridView gvResimler;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraGrid.GridControl gcUrunListesi;
    private DevExpress.XtraGrid.Views.Grid.GridView gvUrunListesi;
    private DevExpress.XtraEditors.TextEdit txtArama;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraGrid.Columns.GridColumn StokAdi;
    private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraEditors.LabelControl lblStokAdi;
    private DevExpress.XtraEditors.LabelControl lblRafyeri;
    private DevExpress.XtraEditors.PanelControl pnlKisayolListesi;
    private DevExpress.XtraEditors.LabelControl lblFiyati;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.LabelControl lblMiktari;


  }
}

