namespace Aresv2.HemenAl
{
  partial class HemenAlUrunFoto
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
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl1
      // 
      this.gridControl1.Location = new System.Drawing.Point(12, 358);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(1075, 200);
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
      // gridControl2
      // 
      this.gridControl2.Location = new System.Drawing.Point(12, 12);
      this.gridControl2.MainView = this.gv;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.Size = new System.Drawing.Size(1075, 340);
      this.gridControl2.TabIndex = 1;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
      // 
      // gv
      // 
      this.gv.GridControl = this.gridControl2;
      this.gv.Name = "gv";
      // 
      // webBrowser1
      // 
      this.webBrowser1.Location = new System.Drawing.Point(1093, 225);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(306, 200);
      this.webBrowser1.TabIndex = 2;
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(1093, 196);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(306, 23);
      this.simpleButton1.TabIndex = 3;
      this.simpleButton1.Text = "simpleButton1";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(1093, 167);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(306, 23);
      this.simpleButton2.TabIndex = 4;
      this.simpleButton2.Text = "simpleButton2";
      // 
      // simpleButton3
      // 
      this.simpleButton3.Location = new System.Drawing.Point(12, 564);
      this.simpleButton3.Name = "simpleButton3";
      this.simpleButton3.Size = new System.Drawing.Size(244, 23);
      this.simpleButton3.TabIndex = 5;
      this.simpleButton3.Text = "Karşılaştır";
      // 
      // simpleButton4
      // 
      this.simpleButton4.Location = new System.Drawing.Point(1093, 12);
      this.simpleButton4.Name = "simpleButton4";
      this.simpleButton4.Size = new System.Drawing.Size(177, 23);
      this.simpleButton4.TabIndex = 6;
      this.simpleButton4.Text = "Foto Gönder";
      this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
      // 
      // HemenAlUrunFoto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1499, 599);
      this.Controls.Add(this.simpleButton4);
      this.Controls.Add(this.simpleButton3);
      this.Controls.Add(this.simpleButton2);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.gridControl2);
      this.Controls.Add(this.gridControl1);
      this.Name = "HemenAlUrunFoto";
      this.Text = "HemenAlUrunFoto";
      this.Load += new System.EventHandler(this.HemenAlUrunFoto_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Grid.GridView gv;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton simpleButton3;
    private DevExpress.XtraEditors.SimpleButton simpleButton4;
  }
}