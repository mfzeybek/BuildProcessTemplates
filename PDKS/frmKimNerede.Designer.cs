namespace PDKS
{
  partial class frmKimNerede
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
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl2
      // 
      this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl2.Location = new System.Drawing.Point(0, 0);
      this.gridControl2.MainView = this.gridView2;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.Size = new System.Drawing.Size(1200, 678);
      this.gridControl2.TabIndex = 4;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
      // 
      // gridView2
      // 
      this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsBehavior.ReadOnly = true;
      this.gridView2.OptionsView.ColumnAutoWidth = false;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      // 
      // gridColumn1
      // 
      this.gridColumn1.Caption = "CariTanim";
      this.gridColumn1.FieldName = "CariTanim";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn1.Width = 200;
      // 
      // gridColumn2
      // 
      this.gridColumn2.Caption = "Zaman1";
      this.gridColumn2.DisplayFormat.FormatString = "T";
      this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.gridColumn2.FieldName = "Zaman1";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 1;
      this.gridColumn2.Width = 125;
      // 
      // gridColumn3
      // 
      this.gridColumn3.Caption = "Zaman2";
      this.gridColumn3.DisplayFormat.FormatString = "T";
      this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.gridColumn3.FieldName = "Zaman2";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 2;
      this.gridColumn3.Width = 125;
      // 
      // gridColumn4
      // 
      this.gridColumn4.Caption = "Fark (dk)";
      this.gridColumn4.FieldName = "Fark (dk)";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 3;
      this.gridColumn4.Width = 100;
      // 
      // gridColumn5
      // 
      this.gridColumn5.Caption = "Aciklama";
      this.gridColumn5.FieldName = "Aciklama";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Visible = true;
      this.gridColumn5.VisibleIndex = 4;
      this.gridColumn5.Width = 200;
      // 
      // gridColumn6
      // 
      this.gridColumn6.Caption = "Turu";
      this.gridColumn6.FieldName = "Turu";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Visible = true;
      this.gridColumn6.VisibleIndex = 5;
      this.gridColumn6.Width = 200;
      // 
      // gridColumn7
      // 
      this.gridColumn7.Caption = "PersonelAdi";
      this.gridColumn7.FieldName = "PersonelAdi";
      this.gridColumn7.Name = "gridColumn7";
      // 
      // frmKimNerede
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1200, 678);
      this.Controls.Add(this.gridControl2);
      this.KeyPreview = true;
      this.Name = "frmKimNerede";
      this.Text = "frmKimNerede";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKimNerede_FormClosing);
      this.Load += new System.EventHandler(this.frmKimNerede_Load);
      this.Shown += new System.EventHandler(this.frmKimNerede_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKimNerede_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
  }
}