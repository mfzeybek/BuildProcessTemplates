namespace Aresv2.Ajanda
{
  partial class frmNotGruplari
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
      this.treeList1 = new DevExpress.XtraTreeList.TreeList();
      this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // treeList1
      // 
      this.treeList1.Location = new System.Drawing.Point(12, 12);
      this.treeList1.Name = "treeList1";
      this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
      this.treeList1.Size = new System.Drawing.Size(672, 442);
      this.treeList1.TabIndex = 0;
      this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
      // 
      // textEdit1
      // 
      this.textEdit1.Location = new System.Drawing.Point(63, 487);
      this.textEdit1.Name = "textEdit1";
      this.textEdit1.Size = new System.Drawing.Size(619, 22);
      this.textEdit1.TabIndex = 1;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(12, 490);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(45, 16);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "GrupAdi";
      this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(63, 525);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(619, 23);
      this.simpleButton1.TabIndex = 3;
      this.simpleButton1.Text = "Ekle";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // checkEdit1
      // 
      this.checkEdit1.Location = new System.Drawing.Point(61, 460);
      this.checkEdit1.Name = "checkEdit1";
      this.checkEdit1.Properties.Caption = "Alt Kategori";
      this.checkEdit1.Size = new System.Drawing.Size(209, 21);
      this.checkEdit1.TabIndex = 7;
      // 
      // frmNotGruplari
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(694, 563);
      this.Controls.Add(this.checkEdit1);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.textEdit1);
      this.Controls.Add(this.treeList1);
      this.Name = "frmNotGruplari";
      this.Text = "frmNotGruplari";
      this.Load += new System.EventHandler(this.frmNotGruplari_Load);
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraTreeList.TreeList treeList1;
    private DevExpress.XtraEditors.TextEdit textEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.CheckEdit checkEdit1;
  }
}