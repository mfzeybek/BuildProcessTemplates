namespace Aresv2.Stok
{
  partial class frmATListesi
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
      this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
      this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
      this.lkpGirisAmbar = new DevExpress.XtraEditors.LookUpEdit();
      this.lkpCikisAmbar = new DevExpress.XtraEditors.LookUpEdit();
      this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.gcAmbarTransfer = new DevExpress.XtraGrid.GridControl();
      this.gvAmbarTransfer = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btnSil = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
      this.btnKaydiAc = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lkpGirisAmbar.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpCikisAmbar.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcAmbarTransfer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvAmbarTransfer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
      this.splitContainerControl1.Panel1.Controls.Add(this.btnTemizle);
      this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
      this.splitContainerControl1.Panel1.Controls.Add(this.lkpGirisAmbar);
      this.splitContainerControl1.Panel1.Controls.Add(this.lkpCikisAmbar);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl8);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
      this.splitContainerControl1.Panel1.Text = "Panel1";
      this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
      this.splitContainerControl1.Panel2.Controls.Add(this.gcAmbarTransfer);
      this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
      this.splitContainerControl1.Panel2.Text = "Panel2";
      this.splitContainerControl1.Size = new System.Drawing.Size(828, 469);
      this.splitContainerControl1.SplitterPosition = 246;
      this.splitContainerControl1.TabIndex = 0;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // btnTemizle
      // 
      this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTemizle.Location = new System.Drawing.Point(158, 76);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new System.Drawing.Size(78, 23);
      this.btnTemizle.TabIndex = 5;
      this.btnTemizle.Text = "Temizle";
      this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
      // 
      // btnFiltrele
      // 
      this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFiltrele.Location = new System.Drawing.Point(60, 76);
      this.btnFiltrele.Name = "btnFiltrele";
      this.btnFiltrele.Size = new System.Drawing.Size(87, 23);
      this.btnFiltrele.TabIndex = 4;
      this.btnFiltrele.Text = "Filtrele (F2)";
      this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
      // 
      // lkpGirisAmbar
      // 
      this.lkpGirisAmbar.Location = new System.Drawing.Point(91, 38);
      this.lkpGirisAmbar.Name = "lkpGirisAmbar";
      this.lkpGirisAmbar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
      this.lkpGirisAmbar.Properties.NullText = "";
      this.lkpGirisAmbar.Size = new System.Drawing.Size(145, 20);
      this.lkpGirisAmbar.TabIndex = 3;
      this.lkpGirisAmbar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpGirisAmbar_ButtonClick);
      // 
      // lkpCikisAmbar
      // 
      this.lkpCikisAmbar.Location = new System.Drawing.Point(91, 16);
      this.lkpCikisAmbar.Name = "lkpCikisAmbar";
      this.lkpCikisAmbar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
      this.lkpCikisAmbar.Properties.NullText = "";
      this.lkpCikisAmbar.Size = new System.Drawing.Size(145, 20);
      this.lkpCikisAmbar.TabIndex = 2;
      this.lkpCikisAmbar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpCikisAmbar_ButtonClick);
      // 
      // labelControl7
      // 
      this.labelControl7.Location = new System.Drawing.Point(81, 42);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new System.Drawing.Size(4, 13);
      this.labelControl7.TabIndex = 15;
      this.labelControl7.Text = ":";
      // 
      // labelControl8
      // 
      this.labelControl8.Location = new System.Drawing.Point(81, 20);
      this.labelControl8.Name = "labelControl8";
      this.labelControl8.Size = new System.Drawing.Size(4, 13);
      this.labelControl8.TabIndex = 14;
      this.labelControl8.Text = ":";
      // 
      // labelControl4
      // 
      this.labelControl4.Location = new System.Drawing.Point(10, 42);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(54, 13);
      this.labelControl4.TabIndex = 13;
      this.labelControl4.Text = "Giriş Ambar";
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(10, 20);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(55, 13);
      this.labelControl3.TabIndex = 12;
      this.labelControl3.Text = "Çıkış Ambar";
      // 
      // gcAmbarTransfer
      // 
      this.gcAmbarTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcAmbarTransfer.Location = new System.Drawing.Point(0, 36);
      this.gcAmbarTransfer.MainView = this.gvAmbarTransfer;
      this.gcAmbarTransfer.Name = "gcAmbarTransfer";
      this.gcAmbarTransfer.Size = new System.Drawing.Size(573, 429);
      this.gcAmbarTransfer.TabIndex = 3;
      this.gcAmbarTransfer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAmbarTransfer});
      // 
      // gvAmbarTransfer
      // 
      this.gvAmbarTransfer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvAmbarTransfer.GridControl = this.gcAmbarTransfer;
      this.gvAmbarTransfer.Name = "gvAmbarTransfer";
      this.gvAmbarTransfer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
      this.gvAmbarTransfer.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvAmbarTransfer.OptionsBehavior.Editable = false;
      this.gvAmbarTransfer.OptionsBehavior.ReadOnly = true;
      this.gvAmbarTransfer.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvAmbarTransfer.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gvAmbarTransfer.OptionsView.ColumnAutoWidth = false;
      this.gvAmbarTransfer.OptionsView.EnableAppearanceEvenRow = true;
      this.gvAmbarTransfer.OptionsView.EnableAppearanceOddRow = true;
      this.gvAmbarTransfer.OptionsView.ShowGroupPanel = false;
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btnSil);
      this.panelControl1.Controls.Add(this.labelControl15);
      this.panelControl1.Controls.Add(this.btnKaydiAc);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(573, 36);
      this.panelControl1.TabIndex = 2;
      // 
      // btnSil
      // 
      this.btnSil.Location = new System.Drawing.Point(395, 7);
      this.btnSil.Name = "btnSil";
      this.btnSil.Size = new System.Drawing.Size(75, 23);
      this.btnSil.TabIndex = 10;
      this.btnSil.Text = "Sil";
      this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
      // 
      // labelControl15
      // 
      this.labelControl15.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
      this.labelControl15.Location = new System.Drawing.Point(5, 8);
      this.labelControl15.Name = "labelControl15";
      this.labelControl15.Size = new System.Drawing.Size(190, 22);
      this.labelControl15.TabIndex = 9;
      this.labelControl15.Text = "Ambar Transfer Fişleri";
      // 
      // btnKaydiAc
      // 
      this.btnKaydiAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKaydiAc.Location = new System.Drawing.Point(313, 7);
      this.btnKaydiAc.Name = "btnKaydiAc";
      this.btnKaydiAc.Size = new System.Drawing.Size(75, 23);
      this.btnKaydiAc.TabIndex = 6;
      this.btnKaydiAc.Text = "Kaydı Aç ";
      this.btnKaydiAc.Click += new System.EventHandler(this.btnKaydiAc_Click);
      // 
      // frmATListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(828, 469);
      this.Controls.Add(this.splitContainerControl1);
      this.KeyPreview = true;
      this.Name = "frmATListesi";
      this.Text = "Ambar Transfer Fiş Listesi";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmATListesi_FormClosed);
      this.Load += new System.EventHandler(this.frmATListesi_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmATListesi_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lkpGirisAmbar.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpCikisAmbar.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcAmbarTransfer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvAmbarTransfer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraEditors.LookUpEdit lkpGirisAmbar;
    private DevExpress.XtraEditors.LookUpEdit lkpCikisAmbar;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    private DevExpress.XtraEditors.LabelControl labelControl8;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.SimpleButton btnTemizle;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraGrid.GridControl gcAmbarTransfer;
    private DevExpress.XtraGrid.Views.Grid.GridView gvAmbarTransfer;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl15;
    public DevExpress.XtraEditors.SimpleButton btnKaydiAc;
    private DevExpress.XtraEditors.SimpleButton btnSil;
  }
}