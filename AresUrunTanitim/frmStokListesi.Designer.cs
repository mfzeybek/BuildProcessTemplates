namespace AresUrunTanitim
{
  partial class frmStokListesi
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
      this.gcUrun = new DevExpress.XtraGrid.GridControl();
      this.gvUrun = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gcResim = new DevExpress.XtraGrid.GridControl();
      this.cmsUrunResim = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.btnResimEkle = new System.Windows.Forms.ToolStripMenuItem();
      this.btnResimSil = new System.Windows.Forms.ToolStripMenuItem();
      this.btnResimDegistir = new System.Windows.Forms.ToolStripMenuItem();
      this.btnVarsayilanYap = new System.Windows.Forms.ToolStripMenuItem();
      this.gvResim = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.ofdDokuman = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.gcUrun)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvUrun)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcResim)).BeginInit();
      this.cmsUrunResim.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvResim)).BeginInit();
      this.SuspendLayout();
      // 
      // gcUrun
      // 
      this.gcUrun.Location = new System.Drawing.Point(12, -45);
      this.gcUrun.MainView = this.gvUrun;
      this.gcUrun.Name = "gcUrun";
      this.gcUrun.Size = new System.Drawing.Size(781, 295);
      this.gcUrun.TabIndex = 0;
      this.gcUrun.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUrun});
      // 
      // gvUrun
      // 
      this.gvUrun.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvUrun.GridControl = this.gcUrun;
      this.gvUrun.Name = "gvUrun";
      this.gvUrun.OptionsBehavior.Editable = false;
      this.gvUrun.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvUrun.OptionsView.ColumnAutoWidth = false;
      this.gvUrun.OptionsView.EnableAppearanceEvenRow = true;
      this.gvUrun.OptionsView.EnableAppearanceOddRow = true;
      this.gvUrun.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUrun_FocusedRowChanged);
      // 
      // gcResim
      // 
      this.gcResim.ContextMenuStrip = this.cmsUrunResim;
      this.gcResim.Location = new System.Drawing.Point(12, 256);
      this.gcResim.MainView = this.gvResim;
      this.gcResim.Name = "gcResim";
      this.gcResim.Size = new System.Drawing.Size(781, 218);
      this.gcResim.TabIndex = 1;
      this.gcResim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResim});
      // 
      // cmsUrunResim
      // 
      this.cmsUrunResim.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResimEkle,
            this.btnResimSil,
            this.btnResimDegistir,
            this.btnVarsayilanYap});
      this.cmsUrunResim.Name = "cmsUrunResim";
      this.cmsUrunResim.Size = new System.Drawing.Size(186, 114);
      // 
      // btnResimEkle
      // 
      this.btnResimEkle.Name = "btnResimEkle";
      this.btnResimEkle.Size = new System.Drawing.Size(185, 22);
      this.btnResimEkle.Text = "Ekle";
      this.btnResimEkle.Click += new System.EventHandler(this.btnResimEkle_Click);
      // 
      // btnResimSil
      // 
      this.btnResimSil.Name = "btnResimSil";
      this.btnResimSil.Size = new System.Drawing.Size(185, 22);
      this.btnResimSil.Text = "Sil";
      // 
      // btnResimDegistir
      // 
      this.btnResimDegistir.Name = "btnResimDegistir";
      this.btnResimDegistir.Size = new System.Drawing.Size(185, 22);
      this.btnResimDegistir.Text = "Değiştir";
      // 
      // btnVarsayilanYap
      // 
      this.btnVarsayilanYap.Name = "btnVarsayilanYap";
      this.btnVarsayilanYap.Size = new System.Drawing.Size(185, 22);
      this.btnVarsayilanYap.Text = "Varsayılan Resim Yap";
      this.btnVarsayilanYap.Click += new System.EventHandler(this.btnVarsayilanYap_Click);
      // 
      // gvResim
      // 
      this.gvResim.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvResim.GridControl = this.gcResim;
      this.gvResim.Name = "gvResim";
      this.gvResim.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvResim.OptionsBehavior.Editable = false;
      this.gvResim.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvResim.OptionsView.ColumnAutoWidth = false;
      this.gvResim.OptionsView.EnableAppearanceEvenRow = true;
      this.gvResim.OptionsView.EnableAppearanceOddRow = true;
      // 
      // frmStokListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(781, 495);
      this.Controls.Add(this.gcUrun);
      this.Controls.Add(this.gcResim);
      this.Name = "frmStokListesi";
      this.Text = "frmUrunListesi";
      this.Load += new System.EventHandler(this.frmUrunListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcUrun)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvUrun)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcResim)).EndInit();
      this.cmsUrunResim.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvResim)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcUrun;
    private DevExpress.XtraGrid.Views.Grid.GridView gvUrun;
    private DevExpress.XtraGrid.GridControl gcResim;
    private DevExpress.XtraGrid.Views.Grid.GridView gvResim;
    private System.Windows.Forms.ContextMenuStrip cmsUrunResim;
    private System.Windows.Forms.ToolStripMenuItem btnResimEkle;
    private System.Windows.Forms.ToolStripMenuItem btnResimSil;
    private System.Windows.Forms.ToolStripMenuItem btnResimDegistir;
    private System.Windows.Forms.OpenFileDialog ofdDokuman;
    private System.Windows.Forms.ToolStripMenuItem btnVarsayilanYap;
  }
}