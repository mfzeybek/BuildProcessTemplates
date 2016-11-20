namespace Aresv2.Ajanda
{
  partial class frmNotKarti
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
      this.txtBaslik = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.memoEdit_Aciklama = new DevExpress.XtraEditors.MemoEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
      this.btnSil = new DevExpress.XtraEditors.SimpleButton();
      this.treeList1 = new DevExpress.XtraTreeList.TreeList();
      this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.lblGrup = new DevExpress.XtraEditors.LabelControl();
      this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
      ((System.ComponentModel.ISupportInitialize)(this.txtBaslik.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Aciklama.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // txtBaslik
      // 
      this.txtBaslik.Location = new System.Drawing.Point(106, 50);
      this.txtBaslik.Name = "txtBaslik";
      this.txtBaslik.Size = new System.Drawing.Size(554, 22);
      this.txtBaslik.TabIndex = 0;
      this.txtBaslik.EditValueChanged += new System.EventHandler(this.butunTextler_EditValueChanged);
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(12, 53);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(33, 16);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "Başlık";
      // 
      // memoEdit_Aciklama
      // 
      this.memoEdit_Aciklama.Location = new System.Drawing.Point(106, 78);
      this.memoEdit_Aciklama.Name = "memoEdit_Aciklama";
      this.memoEdit_Aciklama.Size = new System.Drawing.Size(554, 575);
      this.memoEdit_Aciklama.TabIndex = 2;
      this.memoEdit_Aciklama.EditValueChanged += new System.EventHandler(this.butunTextler_EditValueChanged);
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(12, 81);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(51, 16);
      this.labelControl2.TabIndex = 1;
      this.labelControl2.Text = "Açıklama";
      // 
      // btnKaydet
      // 
      this.btnKaydet.Location = new System.Drawing.Point(106, 674);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(349, 23);
      this.btnKaydet.TabIndex = 4;
      this.btnKaydet.Text = "Kaydet";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // btnVazgec
      // 
      this.btnVazgec.Location = new System.Drawing.Point(461, 674);
      this.btnVazgec.Name = "btnVazgec";
      this.btnVazgec.Size = new System.Drawing.Size(114, 23);
      this.btnVazgec.TabIndex = 4;
      this.btnVazgec.Text = "Vazgeç";
      // 
      // btnSil
      // 
      this.btnSil.Location = new System.Drawing.Point(581, 674);
      this.btnSil.Name = "btnSil";
      this.btnSil.Size = new System.Drawing.Size(79, 23);
      this.btnSil.TabIndex = 4;
      this.btnSil.Text = "Sil";
      this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
      // 
      // treeList1
      // 
      this.treeList1.Location = new System.Drawing.Point(669, 53);
      this.treeList1.Name = "treeList1";
      this.treeList1.Size = new System.Drawing.Size(258, 427);
      this.treeList1.TabIndex = 5;
      // 
      // dateEdit1
      // 
      this.dateEdit1.EditValue = new System.DateTime(2013, 2, 26, 18, 15, 45, 986);
      this.dateEdit1.Location = new System.Drawing.Point(106, 17);
      this.dateEdit1.Name = "dateEdit1";
      this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dateEdit1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
      this.dateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
      this.dateEdit1.Size = new System.Drawing.Size(142, 22);
      this.dateEdit1.TabIndex = 6;
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(12, 20);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(56, 16);
      this.labelControl3.TabIndex = 1;
      this.labelControl3.Text = "Not Tarihi";
      // 
      // lblGrup
      // 
      this.lblGrup.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblGrup.Location = new System.Drawing.Point(669, 486);
      this.lblGrup.Name = "lblGrup";
      this.lblGrup.Size = new System.Drawing.Size(258, 62);
      this.lblGrup.TabIndex = 7;
      this.lblGrup.Text = "Gruplari";
      // 
      // lookUpEdit1
      // 
      this.lookUpEdit1.Location = new System.Drawing.Point(669, 554);
      this.lookUpEdit1.Name = "lookUpEdit1";
      this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.lookUpEdit1.Size = new System.Drawing.Size(258, 22);
      this.lookUpEdit1.TabIndex = 8;
      this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.butunTextler_EditValueChanged);
      // 
      // frmNotKarti
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(939, 722);
      this.Controls.Add(this.lookUpEdit1);
      this.Controls.Add(this.lblGrup);
      this.Controls.Add(this.dateEdit1);
      this.Controls.Add(this.treeList1);
      this.Controls.Add(this.btnSil);
      this.Controls.Add(this.btnVazgec);
      this.Controls.Add(this.btnKaydet);
      this.Controls.Add(this.memoEdit_Aciklama);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl3);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.txtBaslik);
      this.Name = "frmNotKarti";
      this.Text = "Not";
      this.Load += new System.EventHandler(this.frmNotKarti_Load);
      ((System.ComponentModel.ISupportInitialize)(this.txtBaslik.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Aciklama.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.TextEdit txtBaslik;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.MemoEdit memoEdit_Aciklama;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.SimpleButton btnVazgec;
    private DevExpress.XtraEditors.SimpleButton btnSil;
    private DevExpress.XtraTreeList.TreeList treeList1;
    private DevExpress.XtraEditors.DateEdit dateEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl lblGrup;
    private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
  }
}