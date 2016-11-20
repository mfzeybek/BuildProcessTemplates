namespace Aresv2.Personel
{
    partial class frmPersonelGorevTanimi
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
      this.gcGorev = new DevExpress.XtraGrid.GridControl();
      this.gvGorev = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colGorevAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSatistaGorevliMi = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gcGorev)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvGorev)).BeginInit();
      this.SuspendLayout();
      // 
      // gcGorev
      // 
      this.gcGorev.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcGorev.Location = new System.Drawing.Point(0, 0);
      this.gcGorev.MainView = this.gvGorev;
      this.gcGorev.Name = "gcGorev";
      this.gcGorev.Size = new System.Drawing.Size(512, 496);
      this.gcGorev.TabIndex = 0;
      this.gcGorev.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGorev});
      // 
      // gvGorev
      // 
      this.gvGorev.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGorevAdi,
            this.colSatistaGorevliMi});
      this.gvGorev.GridControl = this.gcGorev;
      this.gvGorev.Name = "gvGorev";
      this.gvGorev.NewItemRowText = "YENİ GÖREV";
      this.gvGorev.OptionsView.AllowHtmlDrawHeaders = true;
      this.gvGorev.OptionsView.AutoCalcPreviewLineCount = true;
      this.gvGorev.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
      this.gvGorev.OptionsView.ShowGroupPanel = false;
      // 
      // colGorevAdi
      // 
      this.colGorevAdi.Caption = "GorevAdi";
      this.colGorevAdi.FieldName = "GorevAdi";
      this.colGorevAdi.Name = "colGorevAdi";
      this.colGorevAdi.Visible = true;
      this.colGorevAdi.VisibleIndex = 0;
      // 
      // colSatistaGorevliMi
      // 
      this.colSatistaGorevliMi.Caption = "Satışta Görevli Mi";
      this.colSatistaGorevliMi.FieldName = "SatistaGorevliMi";
      this.colSatistaGorevliMi.Name = "colSatistaGorevliMi";
      this.colSatistaGorevliMi.Visible = true;
      this.colSatistaGorevliMi.VisibleIndex = 1;
      // 
      // frmPersonelGorevTanimi
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(512, 496);
      this.Controls.Add(this.gcGorev);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.MaximumSize = new System.Drawing.Size(530, 541);
      this.Name = "frmPersonelGorevTanimi";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmPersonelGorevTanimi";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPersonelGorevTanimi_FormClosing);
      this.Load += new System.EventHandler(this.frmPersonelGorevTanimi_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPersonelGorevTanimi_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.gcGorev)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvGorev)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGorev;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGorev;
        private DevExpress.XtraGrid.Columns.GridColumn colGorevAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colSatistaGorevliMi;
    }
}