namespace Aresv2.cs
{
  partial class frmHesapMak
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
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(12, 49);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(288, 23);
      this.simpleButton1.TabIndex = 1;
      this.simpleButton1.Text = "Hesapla";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // textEdit1
      // 
      this.textEdit1.Location = new System.Drawing.Point(12, 21);
      this.textEdit1.Name = "textEdit1";
      this.textEdit1.Size = new System.Drawing.Size(288, 22);
      this.textEdit1.TabIndex = 2;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(12, 92);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(226, 16);
      this.labelControl1.TabIndex = 3;
      this.labelControl1.Text = "Şimdilik sadece 2 sayılı işlemler yapılsın";
      // 
      // frmHesapMak
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(312, 125);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.textEdit1);
      this.Controls.Add(this.simpleButton1);
      this.Name = "frmHesapMak";
      this.Text = "frmHesapMak";
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.TextEdit textEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
  }
}