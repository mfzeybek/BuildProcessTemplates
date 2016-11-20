namespace Aresv2.Stok
{
  partial class frmAmbarTransfer
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
      this.components = new System.ComponentModel.Container();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
      this.btnSave = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.lkpGirisAmbar = new DevExpress.XtraEditors.LookUpEdit();
      this.lkpCikisAmbar = new DevExpress.XtraEditors.LookUpEdit();
      this.deTarih = new DevExpress.XtraEditors.DateEdit();
      this.txtFicheNo = new DevExpress.XtraEditors.TextEdit();
      this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.grdMain = new DevExpress.XtraGrid.GridControl();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.satırEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.satırSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colStokFisDetayID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
      this.btnStok = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lkpGirisAmbar.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpCikisAmbar.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties.VistaTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtFicheNo.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnStok)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btnCancel);
      this.panelControl1.Controls.Add(this.btnSave);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl1.Location = new System.Drawing.Point(0, 340);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(734, 40);
      this.panelControl1.TabIndex = 0;
      // 
      // btnCancel
      // 
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCancel.Location = new System.Drawing.Point(79, 3);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 35);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Vazgeç";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnSave
      // 
      this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSave.Location = new System.Drawing.Point(3, 3);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 35);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Kaydet";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.lkpGirisAmbar);
      this.panelControl2.Controls.Add(this.lkpCikisAmbar);
      this.panelControl2.Controls.Add(this.deTarih);
      this.panelControl2.Controls.Add(this.txtFicheNo);
      this.panelControl2.Controls.Add(this.labelControl7);
      this.panelControl2.Controls.Add(this.labelControl8);
      this.panelControl2.Controls.Add(this.labelControl5);
      this.panelControl2.Controls.Add(this.labelControl6);
      this.panelControl2.Controls.Add(this.labelControl4);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Controls.Add(this.labelControl1);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl2.Location = new System.Drawing.Point(0, 0);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(734, 60);
      this.panelControl2.TabIndex = 1;
      // 
      // lkpGirisAmbar
      // 
      this.lkpGirisAmbar.Location = new System.Drawing.Point(299, 31);
      this.lkpGirisAmbar.Name = "lkpGirisAmbar";
      this.lkpGirisAmbar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.lkpGirisAmbar.Properties.NullText = "";
      this.lkpGirisAmbar.Size = new System.Drawing.Size(135, 20);
      this.lkpGirisAmbar.TabIndex = 11;
      // 
      // lkpCikisAmbar
      // 
      this.lkpCikisAmbar.Location = new System.Drawing.Point(299, 9);
      this.lkpCikisAmbar.Name = "lkpCikisAmbar";
      this.lkpCikisAmbar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.lkpCikisAmbar.Properties.NullText = "";
      this.lkpCikisAmbar.Size = new System.Drawing.Size(135, 20);
      this.lkpCikisAmbar.TabIndex = 10;
      // 
      // deTarih
      // 
      this.deTarih.EditValue = null;
      this.deTarih.Location = new System.Drawing.Point(57, 31);
      this.deTarih.Name = "deTarih";
      this.deTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.deTarih.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.deTarih.Size = new System.Drawing.Size(145, 20);
      this.deTarih.TabIndex = 9;
      // 
      // txtFicheNo
      // 
      this.txtFicheNo.Location = new System.Drawing.Point(57, 9);
      this.txtFicheNo.Name = "txtFicheNo";
      this.txtFicheNo.Size = new System.Drawing.Size(145, 20);
      this.txtFicheNo.TabIndex = 8;
      // 
      // labelControl7
      // 
      this.labelControl7.Location = new System.Drawing.Point(289, 34);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new System.Drawing.Size(4, 13);
      this.labelControl7.TabIndex = 7;
      this.labelControl7.Text = ":";
      // 
      // labelControl8
      // 
      this.labelControl8.Location = new System.Drawing.Point(289, 12);
      this.labelControl8.Name = "labelControl8";
      this.labelControl8.Size = new System.Drawing.Size(4, 13);
      this.labelControl8.TabIndex = 6;
      this.labelControl8.Text = ":";
      // 
      // labelControl5
      // 
      this.labelControl5.Location = new System.Drawing.Point(47, 34);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(4, 13);
      this.labelControl5.TabIndex = 5;
      this.labelControl5.Text = ":";
      // 
      // labelControl6
      // 
      this.labelControl6.Location = new System.Drawing.Point(47, 12);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(4, 13);
      this.labelControl6.TabIndex = 4;
      this.labelControl6.Text = ":";
      // 
      // labelControl4
      // 
      this.labelControl4.Location = new System.Drawing.Point(228, 34);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(54, 13);
      this.labelControl4.TabIndex = 3;
      this.labelControl4.Text = "Giriş Ambar";
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(228, 12);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(55, 13);
      this.labelControl3.TabIndex = 2;
      this.labelControl3.Text = "Çıkış Ambar";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(12, 34);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(24, 13);
      this.labelControl2.TabIndex = 1;
      this.labelControl2.Text = "Tarih";
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(12, 12);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(29, 13);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "Fiş No";
      // 
      // grdMain
      // 
      this.grdMain.ContextMenuStrip = this.contextMenuStrip1;
      this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdMain.Location = new System.Drawing.Point(0, 60);
      this.grdMain.MainView = this.gvMain;
      this.grdMain.Name = "grdMain";
      this.grdMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnStok});
      this.grdMain.Size = new System.Drawing.Size(734, 280);
      this.grdMain.TabIndex = 2;
      this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satırEkleToolStripMenuItem,
            this.satırSilToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
      // 
      // satırEkleToolStripMenuItem
      // 
      this.satırEkleToolStripMenuItem.Name = "satırEkleToolStripMenuItem";
      this.satırEkleToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
      this.satırEkleToolStripMenuItem.Text = "Satır Ekle";
      this.satırEkleToolStripMenuItem.Click += new System.EventHandler(this.satırEkleToolStripMenuItem_Click);
      // 
      // satırSilToolStripMenuItem
      // 
      this.satırSilToolStripMenuItem.Name = "satırSilToolStripMenuItem";
      this.satırSilToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
      this.satırSilToolStripMenuItem.Text = "Satır Sil";
      this.satırSilToolStripMenuItem.Click += new System.EventHandler(this.satırSilToolStripMenuItem_Click);
      // 
      // gvMain
      // 
      this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokFisDetayID,
            this.colStokID,
            this.colStokKodu,
            this.colStokAdi,
            this.colMiktar});
      this.gvMain.GridControl = this.grdMain;
      this.gvMain.Name = "gvMain";
      this.gvMain.OptionsView.ColumnAutoWidth = false;
      this.gvMain.OptionsView.ShowGroupPanel = false;
      // 
      // colStokFisDetayID
      // 
      this.colStokFisDetayID.Caption = "StokFisDetayID";
      this.colStokFisDetayID.FieldName = "StokFisDetayID";
      this.colStokFisDetayID.Name = "colStokFisDetayID";
      // 
      // colStokID
      // 
      this.colStokID.Caption = "StokID";
      this.colStokID.FieldName = "StokID";
      this.colStokID.Name = "colStokID";
      // 
      // colStokKodu
      // 
      this.colStokKodu.Caption = "Stok Kodu";
      this.colStokKodu.FieldName = "StokKodu";
      this.colStokKodu.Name = "colStokKodu";
      this.colStokKodu.Visible = true;
      this.colStokKodu.VisibleIndex = 0;
      // 
      // colStokAdi
      // 
      this.colStokAdi.Caption = "Stok Adı";
      this.colStokAdi.FieldName = "StokAdi";
      this.colStokAdi.Name = "colStokAdi";
      this.colStokAdi.Visible = true;
      this.colStokAdi.VisibleIndex = 1;
      // 
      // colMiktar
      // 
      this.colMiktar.Caption = "Miktar";
      this.colMiktar.FieldName = "Miktar";
      this.colMiktar.Name = "colMiktar";
      this.colMiktar.Visible = true;
      this.colMiktar.VisibleIndex = 2;
      // 
      // btnStok
      // 
      this.btnStok.AutoHeight = false;
      this.btnStok.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.btnStok.Name = "btnStok";
      this.btnStok.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnStok_ButtonClick);
      // 
      // frmAmbarTransfer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(734, 380);
      this.Controls.Add(this.grdMain);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Name = "frmAmbarTransfer";
      this.Text = "Ambar Transfer Fişi";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAmbarTransfer_FormClosed);
      this.Load += new System.EventHandler(this.frmAmbarTransfer_Load);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lkpGirisAmbar.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpCikisAmbar.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties.VistaTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtFicheNo.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnStok)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraGrid.GridControl grdMain;
    private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
    private DevExpress.XtraEditors.SimpleButton btnCancel;
    private DevExpress.XtraEditors.SimpleButton btnSave;
    private DevExpress.XtraEditors.LookUpEdit lkpGirisAmbar;
    private DevExpress.XtraEditors.LookUpEdit lkpCikisAmbar;
    private DevExpress.XtraEditors.DateEdit deTarih;
    private DevExpress.XtraEditors.TextEdit txtFicheNo;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    private DevExpress.XtraEditors.LabelControl labelControl8;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem satırEkleToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem satırSilToolStripMenuItem;
    private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnStok;
    private DevExpress.XtraGrid.Columns.GridColumn colStokFisDetayID;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colStokKodu;
    private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
  }
}