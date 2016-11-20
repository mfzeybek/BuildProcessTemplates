namespace Aresv2.NumaraSablon
{
  partial class frmNumaraSablonListesi
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
      this.gcNumaraSablon = new DevExpress.XtraGrid.GridControl();
      this.gvNumaraSablon = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.gcNumaraSablon)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvNumaraSablon)).BeginInit();
      this.SuspendLayout();
      // 
      // gcNumaraSablon
      // 
      this.gcNumaraSablon.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcNumaraSablon.Location = new System.Drawing.Point(0, 0);
      this.gcNumaraSablon.MainView = this.gvNumaraSablon;
      this.gcNumaraSablon.Name = "gcNumaraSablon";
      this.gcNumaraSablon.Size = new System.Drawing.Size(283, 381);
      this.gcNumaraSablon.TabIndex = 0;
      this.gcNumaraSablon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNumaraSablon});
      // 
      // gvNumaraSablon
      // 
      this.gvNumaraSablon.GridControl = this.gcNumaraSablon;
      this.gvNumaraSablon.Name = "gvNumaraSablon";
      this.gvNumaraSablon.OptionsBehavior.Editable = false;
      this.gvNumaraSablon.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvNumaraSablon.OptionsView.EnableAppearanceEvenRow = true;
      this.gvNumaraSablon.OptionsView.EnableAppearanceOddRow = true;
      this.gvNumaraSablon.OptionsView.ShowGroupPanel = false;
      this.gvNumaraSablon.DoubleClick += new System.EventHandler(this.gvNumaraSablon_DoubleClick);
      // 
      // frmNumaraSablonListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(283, 381);
      this.Controls.Add(this.gcNumaraSablon);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmNumaraSablonListesi";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Numara Şablonları";
      this.Load += new System.EventHandler(this.frmNumaraSablonListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcNumaraSablon)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvNumaraSablon)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcNumaraSablon;
    private DevExpress.XtraGrid.Views.Grid.GridView gvNumaraSablon;
  }
}