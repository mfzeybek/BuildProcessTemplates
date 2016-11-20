namespace Aresv2.Stok
{
  partial class frmStokListeSecim
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
      this.gcStok = new DevExpress.XtraGrid.GridControl();
      this.gvStok = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.gcStok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvStok)).BeginInit();
      this.SuspendLayout();
      // 
      // gcStok
      // 
      this.gcStok.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcStok.Location = new System.Drawing.Point(0, 0);
      this.gcStok.MainView = this.gvStok;
      this.gcStok.Name = "gcStok";
      this.gcStok.Size = new System.Drawing.Size(380, 419);
      this.gcStok.TabIndex = 0;
      this.gcStok.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStok});
      // 
      // gvStok
      // 
      this.gvStok.GridControl = this.gcStok;
      this.gvStok.Name = "gvStok";
      this.gvStok.OptionsBehavior.Editable = false;
      this.gvStok.DoubleClick += new System.EventHandler(this.gvStok_DoubleClick);
      // 
      // frmStokListeSecim
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(380, 419);
      this.Controls.Add(this.gcStok);
      this.Name = "frmStokListeSecim";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Stok Seçim";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStokListeSecim_FormClosed);
      this.Load += new System.EventHandler(this.frmStokListeSecim_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcStok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvStok)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcStok;
    private DevExpress.XtraGrid.Views.Grid.GridView gvStok;
  }
}