namespace Aresv2.HemenAl
{
  partial class HemenAlUrunSecenekOnTanimlari
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
      this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl1
      // 
      this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControl1.Location = new System.Drawing.Point(12, 12);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(1068, 272);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      // 
      // simpleButton1
      // 
      this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButton1.Location = new System.Drawing.Point(12, 290);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(518, 23);
      this.simpleButton1.TabIndex = 1;
      this.simpleButton1.Text = "Yeni Kayıt";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // simpleButton2
      // 
      this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButton2.Location = new System.Drawing.Point(882, 290);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(199, 23);
      this.simpleButton2.TabIndex = 1;
      this.simpleButton2.Text = "Sil";
      // 
      // simpleButton3
      // 
      this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButton3.Location = new System.Drawing.Point(536, 290);
      this.simpleButton3.Name = "simpleButton3";
      this.simpleButton3.Size = new System.Drawing.Size(340, 23);
      this.simpleButton3.TabIndex = 1;
      this.simpleButton3.Text = "Kaydı Aç";
      this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
      // 
      // simpleButton4
      // 
      this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButton4.Location = new System.Drawing.Point(300, 319);
      this.simpleButton4.Name = "simpleButton4";
      this.simpleButton4.Size = new System.Drawing.Size(518, 23);
      this.simpleButton4.TabIndex = 2;
      this.simpleButton4.Text = "seç";
      this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
      // 
      // HemenAlUrunSecenekOnTanimlari
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1084, 349);
      this.Controls.Add(this.simpleButton4);
      this.Controls.Add(this.simpleButton3);
      this.Controls.Add(this.simpleButton2);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.gridControl1);
      this.Name = "HemenAlUrunSecenekOnTanimlari";
      this.Text = "HemenAlUrunSecenekOnTanimlari";
      this.Load += new System.EventHandler(this.HemenAlUrunSecenekOnTanimlari_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton simpleButton3;
    private DevExpress.XtraEditors.SimpleButton simpleButton4;
    public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
  }
}