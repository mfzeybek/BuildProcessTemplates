namespace Aresv2.Stok
{
  partial class frmStokSayim
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
            this.gcSayim = new DevExpress.XtraGrid.GridControl();
            this.gvSayim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSayimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSayimKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSayimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepoAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.lkpSayimDeposu = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deTarihAraligi2 = new DevExpress.XtraEditors.DateEdit();
            this.deTarihAraligi1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.txtSayimKodu = new DevExpress.XtraEditors.TextEdit();
            this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnSayimGuncelle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcSayim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSayim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSayimDeposu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayimKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcSayim
            // 
            this.gcSayim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSayim.Location = new System.Drawing.Point(0, 35);
            this.gcSayim.MainView = this.gvSayim;
            this.gcSayim.Name = "gcSayim";
            this.gcSayim.Size = new System.Drawing.Size(849, 543);
            this.gcSayim.TabIndex = 1;
            this.gcSayim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSayim});
            // 
            // gvSayim
            // 
            this.gvSayim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSayimID,
            this.colSayimKodu,
            this.colSayimTarihi,
            this.DepoID,
            this.colDepoAdi,
            this.Aciklama});
            this.gvSayim.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvSayim.GridControl = this.gcSayim;
            this.gvSayim.Name = "gvSayim";
            this.gvSayim.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvSayim.OptionsBehavior.Editable = false;
            this.gvSayim.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSayim.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvSayim.OptionsView.EnableAppearanceEvenRow = true;
            this.gvSayim.OptionsView.EnableAppearanceOddRow = true;
            this.gvSayim.OptionsView.ShowGroupPanel = false;
            // 
            // colSayimID
            // 
            this.colSayimID.Caption = "SayimID";
            this.colSayimID.FieldName = "SayimID";
            this.colSayimID.Name = "colSayimID";
            // 
            // colSayimKodu
            // 
            this.colSayimKodu.Caption = "Sayım Kodu";
            this.colSayimKodu.FieldName = "SayimKodu";
            this.colSayimKodu.Name = "colSayimKodu";
            this.colSayimKodu.Visible = true;
            this.colSayimKodu.VisibleIndex = 1;
            // 
            // colSayimTarihi
            // 
            this.colSayimTarihi.Caption = "Sayım Tarihi";
            this.colSayimTarihi.FieldName = "SayimTarihi";
            this.colSayimTarihi.Name = "colSayimTarihi";
            this.colSayimTarihi.Visible = true;
            this.colSayimTarihi.VisibleIndex = 0;
            // 
            // DepoID
            // 
            this.DepoID.Caption = "DepoID";
            this.DepoID.FieldName = "DepoID";
            this.DepoID.Name = "DepoID";
            // 
            // colDepoAdi
            // 
            this.colDepoAdi.Caption = "Sayım Deposu";
            this.colDepoAdi.FieldName = "DepoAdi";
            this.colDepoAdi.Name = "colDepoAdi";
            this.colDepoAdi.Visible = true;
            this.colDepoAdi.VisibleIndex = 2;
            // 
            // Aciklama
            // 
            this.Aciklama.Caption = "Aciklama";
            this.Aciklama.FieldName = "Aciklama";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Visible = true;
            this.Aciklama.VisibleIndex = 3;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnTemizle);
            this.splitContainerControl1.Panel1.Controls.Add(this.lkpSayimDeposu);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.deTarihAraligi2);
            this.splitContainerControl1.Panel1.Controls.Add(this.deTarihAraligi1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtAciklama);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSayimKodu);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSayim);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1081, 578);
            this.splitContainerControl1.SplitterPosition = 226;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Location = new System.Drawing.Point(120, 516);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(68, 53);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "Temizle";
            // 
            // lkpSayimDeposu
            // 
            this.lkpSayimDeposu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpSayimDeposu.EditValue = -1;
            this.lkpSayimDeposu.Location = new System.Drawing.Point(10, 195);
            this.lkpSayimDeposu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkpSayimDeposu.Name = "lkpSayimDeposu";
            this.lkpSayimDeposu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lkpSayimDeposu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoAdi", "DepoAdi")});
            this.lkpSayimDeposu.Properties.NullText = "";
            this.lkpSayimDeposu.Size = new System.Drawing.Size(180, 20);
            this.lkpSayimDeposu.TabIndex = 6;
            this.lkpSayimDeposu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpSayimDeposu_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 9);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Sayim Tarihi Aralığı";
            // 
            // deTarihAraligi2
            // 
            this.deTarihAraligi2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deTarihAraligi2.EditValue = null;
            this.deTarihAraligi2.Location = new System.Drawing.Point(10, 50);
            this.deTarihAraligi2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deTarihAraligi2.Name = "deTarihAraligi2";
            this.deTarihAraligi2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deTarihAraligi2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarihAraligi2.Size = new System.Drawing.Size(183, 20);
            this.deTarihAraligi2.TabIndex = 4;
            this.deTarihAraligi2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deTarihAraligi2_ButtonClick);
            // 
            // deTarihAraligi1
            // 
            this.deTarihAraligi1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deTarihAraligi1.EditValue = null;
            this.deTarihAraligi1.Location = new System.Drawing.Point(10, 27);
            this.deTarihAraligi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deTarihAraligi1.Name = "deTarihAraligi1";
            this.deTarihAraligi1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deTarihAraligi1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarihAraligi1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deTarihAraligi1.Size = new System.Drawing.Size(183, 20);
            this.deTarihAraligi1.TabIndex = 3;
            this.deTarihAraligi1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deTarihAraligi1_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 177);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Sayım Deposu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 131);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Açıklama";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 83);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Sayım Kodu";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(10, 149);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(180, 20);
            this.txtAciklama.TabIndex = 1;
            // 
            // txtSayimKodu
            // 
            this.txtSayimKodu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSayimKodu.Location = new System.Drawing.Point(10, 101);
            this.txtSayimKodu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayimKodu.Name = "txtSayimKodu";
            this.txtSayimKodu.Size = new System.Drawing.Size(183, 20);
            this.txtSayimKodu.TabIndex = 1;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnFiltrele.Appearance.Options.UseFont = true;
            this.btnFiltrele.Location = new System.Drawing.Point(10, 516);
            this.btnFiltrele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(105, 53);
            this.btnFiltrele.TabIndex = 0;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.btnSayimGuncelle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(849, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl15.Location = new System.Drawing.Point(4, 6);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(109, 22);
            this.labelControl15.TabIndex = 10;
            this.labelControl15.Text = "Stok Sayımı";
            // 
            // btnSayimGuncelle
            // 
            this.btnSayimGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSayimGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayimGuncelle.Location = new System.Drawing.Point(780, 3);
            this.btnSayimGuncelle.Name = "btnSayimGuncelle";
            this.btnSayimGuncelle.Size = new System.Drawing.Size(91, 27);
            this.btnSayimGuncelle.TabIndex = 1;
            this.btnSayimGuncelle.Text = "Sayımı Aç";
            this.btnSayimGuncelle.Click += new System.EventHandler(this.btnSayimGuncelle_Click);
            // 
            // frmStokSayim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 578);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmStokSayim";
            this.Text = "frmStokSayim";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStokSayim_FormClosed);
            this.Load += new System.EventHandler(this.frmStokSayim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSayim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSayim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpSayimDeposu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayimKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcSayim;
    private DevExpress.XtraGrid.Views.Grid.GridView gvSayim;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimID;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimKodu;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimTarihi;
    private DevExpress.XtraGrid.Columns.GridColumn DepoID;
    private DevExpress.XtraGrid.Columns.GridColumn colDepoAdi;
    private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraEditors.DateEdit deTarihAraligi2;
    private DevExpress.XtraEditors.DateEdit deTarihAraligi1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.TextEdit txtAciklama;
    private DevExpress.XtraEditors.TextEdit txtSayimKodu;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LookUpEdit lkpSayimDeposu;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.SimpleButton btnTemizle;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl15;
    private DevExpress.XtraEditors.SimpleButton btnSayimGuncelle;
  }
}