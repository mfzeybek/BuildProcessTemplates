namespace Aresv2.EksilenStokListesi
{
  partial class EksilenStokListesi
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
      this.gcStokListe = new DevExpress.XtraGrid.GridControl();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cbtnEkle = new System.Windows.Forms.ToolStripMenuItem();
      this.cbtnDegistir = new System.Windows.Forms.ToolStripMenuItem();
      this.cbtnSil = new System.Windows.Forms.ToolStripMenuItem();
      this.gvStokListe = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.gcStokListe)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvStokListe)).BeginInit();
      this.SuspendLayout();
      // 
      // gcStokListe
      // 
      this.gcStokListe.ContextMenuStrip = this.contextMenuStrip1;
      this.gcStokListe.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcStokListe.Location = new System.Drawing.Point(0, 0);
      this.gcStokListe.MainView = this.gvStokListe;
      this.gcStokListe.Name = "gcStokListe";
      this.gcStokListe.Size = new System.Drawing.Size(807, 467);
      this.gcStokListe.TabIndex = 0;
      this.gcStokListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokListe});
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbtnEkle,
            this.cbtnDegistir,
            this.cbtnSil});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(115, 70);
      // 
      // cbtnEkle
      // 
      this.cbtnEkle.Name = "cbtnEkle";
      this.cbtnEkle.Size = new System.Drawing.Size(114, 22);
      this.cbtnEkle.Text = "Ekle";
      this.cbtnEkle.Click += new System.EventHandler(this.cbtnEkle_Click);
      // 
      // cbtnDegistir
      // 
      this.cbtnDegistir.Name = "cbtnDegistir";
      this.cbtnDegistir.Size = new System.Drawing.Size(114, 22);
      this.cbtnDegistir.Text = "Değiştir";
      this.cbtnDegistir.Click += new System.EventHandler(this.cbtnDegistir_Click);
      // 
      // cbtnSil
      // 
      this.cbtnSil.Name = "cbtnSil";
      this.cbtnSil.Size = new System.Drawing.Size(114, 22);
      this.cbtnSil.Text = "Sil";
      this.cbtnSil.Click += new System.EventHandler(this.cbtnSil_Click);
      // 
      // gvStokListe
      // 
      this.gvStokListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvStokListe.GridControl = this.gcStokListe;
      this.gvStokListe.Name = "gvStokListe";
      this.gvStokListe.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvStokListe.OptionsBehavior.Editable = false;
      this.gvStokListe.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvStokListe.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gvStokListe.OptionsView.ColumnAutoWidth = false;
      this.gvStokListe.OptionsView.EnableAppearanceEvenRow = true;
      this.gvStokListe.OptionsView.EnableAppearanceOddRow = true;
      // 
      // EksilenStokListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(807, 467);
      this.Controls.Add(this.gcStokListe);
      this.Name = "EksilenStokListesi";
      this.Text = "EksilenStokListesi";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EksilenStokListesi_FormClosed);
      this.Load += new System.EventHandler(this.EksilenStokListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcStokListe)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvStokListe)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcStokListe;
    private DevExpress.XtraGrid.Views.Grid.GridView gvStokListe;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem cbtnEkle;
    private System.Windows.Forms.ToolStripMenuItem cbtnDegistir;
    private System.Windows.Forms.ToolStripMenuItem cbtnSil;
  }
}