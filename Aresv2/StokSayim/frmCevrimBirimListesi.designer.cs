namespace Aresv2.Stok
{
  partial class frmCevrimBirimListesi
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
      this.gcBirim = new DevExpress.XtraGrid.GridControl();
      this.gvBirim = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.gcBirim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvBirim)).BeginInit();
      this.SuspendLayout();
      // 
      // gcBirim
      // 
      this.gcBirim.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcBirim.Location = new System.Drawing.Point(0, 0);
      this.gcBirim.MainView = this.gvBirim;
      this.gcBirim.Name = "gcBirim";
      this.gcBirim.Size = new System.Drawing.Size(350, 461);
      this.gcBirim.TabIndex = 0;
      this.gcBirim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBirim});
      // 
      // gvBirim
      // 
      this.gvBirim.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvBirim.GridControl = this.gcBirim;
      this.gvBirim.Name = "gvBirim";
      this.gvBirim.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvBirim.OptionsBehavior.Editable = false;
      this.gvBirim.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvBirim.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gvBirim.OptionsView.EnableAppearanceEvenRow = true;
      this.gvBirim.OptionsView.EnableAppearanceOddRow = true;
      this.gvBirim.OptionsView.ShowAutoFilterRow = true;
      this.gvBirim.DoubleClick += new System.EventHandler(this.gvBirim_DoubleClick);
      // 
      // frmCevrimBirimListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(350, 461);
      this.Controls.Add(this.gcBirim);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmCevrimBirimListesi";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Stok Birim Çevriminde Kullanılan Birimler";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCevrimBirimListesi_FormClosed);
      this.Load += new System.EventHandler(this.frmCevrimBirimListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcBirim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvBirim)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcBirim;
    private DevExpress.XtraGrid.Views.Grid.GridView gvBirim;
  }
}