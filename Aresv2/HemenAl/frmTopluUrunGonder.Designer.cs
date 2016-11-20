namespace Aresv2.HemenAl
{
  partial class frmTopluUrunGonder
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
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
      this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
      this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl1
      // 
      this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControl1.Location = new System.Drawing.Point(47, 46);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(1269, 315);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsView.ShowGroupPanel = false;
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(5, 46);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(36, 23);
      this.simpleButton1.TabIndex = 1;
      this.simpleButton1.Text = "+";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(47, 367);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(198, 23);
      this.simpleButton2.TabIndex = 2;
      this.simpleButton2.Text = "Güncelle";
      this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(518, 3);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(278, 16);
      this.labelControl1.TabIndex = 3;
      this.labelControl1.Text = "Eklenen Stokları Toplu Bi Şekilde Siteye Gönderir";
      // 
      // directorySearcher1
      // 
      this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
      this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
      this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
      // 
      // memoEdit1
      // 
      this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.memoEdit1.Location = new System.Drawing.Point(47, 396);
      this.memoEdit1.Name = "memoEdit1";
      this.memoEdit1.Size = new System.Drawing.Size(1268, 71);
      this.memoEdit1.TabIndex = 4;
      // 
      // simpleButton3
      // 
      this.simpleButton3.Location = new System.Drawing.Point(5, 75);
      this.simpleButton3.Name = "simpleButton3";
      this.simpleButton3.Size = new System.Drawing.Size(36, 23);
      this.simpleButton3.TabIndex = 5;
      this.simpleButton3.Text = "-";
      this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
      // 
      // simpleButton4
      // 
      this.simpleButton4.Location = new System.Drawing.Point(5, 104);
      this.simpleButton4.Name = "simpleButton4";
      this.simpleButton4.Size = new System.Drawing.Size(36, 23);
      this.simpleButton4.TabIndex = 5;
      this.simpleButton4.Text = "A";
      this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
      // 
      // frmTopluUrunGonder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1319, 479);
      this.Controls.Add(this.simpleButton4);
      this.Controls.Add(this.simpleButton3);
      this.Controls.Add(this.memoEdit1);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.simpleButton2);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.gridControl1);
      this.Name = "frmTopluUrunGonder";
      this.Text = "frmTopluUrunGonder";
      this.Load += new System.EventHandler(this.frmTopluUrunGonder_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private System.DirectoryServices.DirectorySearcher directorySearcher1;
    private DevExpress.XtraEditors.MemoEdit memoEdit1;
    private DevExpress.XtraEditors.SimpleButton simpleButton3;
    private DevExpress.XtraEditors.SimpleButton simpleButton4;
  }
}