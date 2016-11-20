namespace Aresv2.Ajanda
{
  partial class frmNotListesi
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
      this.treeList1 = new DevExpress.XtraTreeList.TreeList();
      this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
      this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
      this.splitContainerControl1.Panel1.Controls.Add(this.btnTemizle);
      this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
      this.splitContainerControl1.Panel1.Text = "Panel1";
      this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
      this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
      this.splitContainerControl1.Panel2.Text = "Panel2";
      this.splitContainerControl1.Size = new System.Drawing.Size(1103, 699);
      this.splitContainerControl1.SplitterPosition = 239;
      this.splitContainerControl1.TabIndex = 0;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // treeList1
      // 
      this.treeList1.Location = new System.Drawing.Point(8, 54);
      this.treeList1.Name = "treeList1";
      this.treeList1.Size = new System.Drawing.Size(230, 336);
      this.treeList1.TabIndex = 1;
      // 
      // btnTemizle
      // 
      this.btnTemizle.Location = new System.Drawing.Point(133, 581);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new System.Drawing.Size(85, 23);
      this.btnTemizle.TabIndex = 0;
      this.btnTemizle.Text = "Temizle";
      // 
      // btnFiltrele
      // 
      this.btnFiltrele.Location = new System.Drawing.Point(12, 581);
      this.btnFiltrele.Name = "btnFiltrele";
      this.btnFiltrele.Size = new System.Drawing.Size(115, 23);
      this.btnFiltrele.TabIndex = 0;
      this.btnFiltrele.Text = "Filtrele";
      this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
      // 
      // gridControl1
      // 
      this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl1.Location = new System.Drawing.Point(0, 54);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(860, 645);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsBehavior.ReadOnly = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.simpleButton1);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(860, 54);
      this.panelControl1.TabIndex = 1;
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(679, 5);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(100, 36);
      this.simpleButton1.TabIndex = 0;
      this.simpleButton1.Text = "Kaydı Aç";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // frmNotListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1103, 699);
      this.Controls.Add(this.splitContainerControl1);
      this.Name = "frmNotListesi";
      this.Text = "frmNotListesi";
      this.Load += new System.EventHandler(this.frmNotListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraEditors.SimpleButton btnTemizle;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraTreeList.TreeList treeList1;

  }
}