namespace Aresv2.Fatura
{
    partial class frmFaturaKarAnalizi
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
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnaBirimMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnaBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturadakiSatisFiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaliyetFiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaliyetTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKarTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamKar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnFaturadanSec = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnStokHarekettenSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokKartiniAc = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(148, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(901, 680);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokID,
            this.colStokAdi,
            this.colAnaBirimMiktar,
            this.colAnaBirimID,
            this.colFaturadakiSatisFiyati,
            this.colMaliyetFiyati,
            this.colMaliyetTutari,
            this.colKarTutari,
            this.colToplamKar});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KarTutari", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colKarTutari", null, "")});
            this.gridView1.Name = "gridView1";
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            this.colStokID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KarTutari", "SUM={0:0.##}")});
            this.colStokID.Visible = true;
            this.colStokID.VisibleIndex = 0;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "StokAdi";
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 1;
            // 
            // colAnaBirimMiktar
            // 
            this.colAnaBirimMiktar.Caption = "AnaBirimMiktar";
            this.colAnaBirimMiktar.FieldName = "AnaBirimMiktar";
            this.colAnaBirimMiktar.Name = "colAnaBirimMiktar";
            this.colAnaBirimMiktar.Visible = true;
            this.colAnaBirimMiktar.VisibleIndex = 2;
            // 
            // colAnaBirimID
            // 
            this.colAnaBirimID.Caption = "AnaBirimID";
            this.colAnaBirimID.FieldName = "AnaBirimID";
            this.colAnaBirimID.Name = "colAnaBirimID";
            this.colAnaBirimID.Visible = true;
            this.colAnaBirimID.VisibleIndex = 3;
            // 
            // colFaturadakiSatisFiyati
            // 
            this.colFaturadakiSatisFiyati.Caption = "FaturadakiSatisFiyati";
            this.colFaturadakiSatisFiyati.FieldName = "FaturadakiSatisFiyati";
            this.colFaturadakiSatisFiyati.Name = "colFaturadakiSatisFiyati";
            this.colFaturadakiSatisFiyati.Visible = true;
            this.colFaturadakiSatisFiyati.VisibleIndex = 4;
            // 
            // colMaliyetFiyati
            // 
            this.colMaliyetFiyati.Caption = "MaliyetFiyati";
            this.colMaliyetFiyati.FieldName = "MaliyetFiyati";
            this.colMaliyetFiyati.Name = "colMaliyetFiyati";
            this.colMaliyetFiyati.Visible = true;
            this.colMaliyetFiyati.VisibleIndex = 5;
            // 
            // colMaliyetTutari
            // 
            this.colMaliyetTutari.Caption = "MaliyetTutari";
            this.colMaliyetTutari.FieldName = "MaliyetTutari";
            this.colMaliyetTutari.Name = "colMaliyetTutari";
            this.colMaliyetTutari.Visible = true;
            this.colMaliyetTutari.VisibleIndex = 6;
            // 
            // colKarTutari
            // 
            this.colKarTutari.Caption = "KarTutari";
            this.colKarTutari.FieldName = "KarTutari";
            this.colKarTutari.GroupFormat.FormatString = "c2";
            this.colKarTutari.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKarTutari.Name = "colKarTutari";
            this.colKarTutari.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KarTutari", "SUM={0:0.##}")});
            this.colKarTutari.Visible = true;
            this.colKarTutari.VisibleIndex = 7;
            // 
            // colToplamKar
            // 
            this.colToplamKar.Caption = "colToplamKar";
            this.colToplamKar.Name = "colToplamKar";
            this.colToplamKar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KarTutari", "SUM={0:0.##}")});
            this.colToplamKar.Visible = true;
            this.colToplamKar.VisibleIndex = 8;
            // 
            // btnFaturadanSec
            // 
            this.btnFaturadanSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFaturadanSec.Location = new System.Drawing.Point(14, 681);
            this.btnFaturadanSec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFaturadanSec.Name = "btnFaturadanSec";
            this.btnFaturadanSec.Size = new System.Drawing.Size(128, 69);
            this.btnFaturadanSec.TabIndex = 1;
            this.btnFaturadanSec.Text = "Fatura Seç";
            this.btnFaturadanSec.Click += new System.EventHandler(this.btnFaturadanSec_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "Stok Kartındaki Alış Fiyatı";
            this.comboBoxEdit1.Location = new System.Drawing.Point(207, 15);
            this.comboBoxEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Stok Kartındaki Alış Fiyatı",
            "Son Alış Fiyatı"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(212, 26);
            this.comboBoxEdit1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(107, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Maliyet Tanımı";
            // 
            // btnStokHarekettenSec
            // 
            this.btnStokHarekettenSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStokHarekettenSec.Appearance.Options.UseTextOptions = true;
            this.btnStokHarekettenSec.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnStokHarekettenSec.Location = new System.Drawing.Point(14, 605);
            this.btnStokHarekettenSec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStokHarekettenSec.Name = "btnStokHarekettenSec";
            this.btnStokHarekettenSec.Size = new System.Drawing.Size(128, 69);
            this.btnStokHarekettenSec.TabIndex = 4;
            this.btnStokHarekettenSec.Text = "Stok Hareketten Seç";
            // 
            // btnStokKartiniAc
            // 
            this.btnStokKartiniAc.Location = new System.Drawing.Point(14, 88);
            this.btnStokKartiniAc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStokKartiniAc.Name = "btnStokKartiniAc";
            this.btnStokKartiniAc.Size = new System.Drawing.Size(128, 61);
            this.btnStokKartiniAc.TabIndex = 5;
            this.btnStokKartiniAc.Text = "simpleButton1";
            this.btnStokKartiniAc.Click += new System.EventHandler(this.btnStokKartiniAc_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(460, 14);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(158, 49);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Stok A Göre Grupla";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmFaturaKarAnalizi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 765);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnStokKartiniAc);
            this.Controls.Add(this.btnStokHarekettenSec);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.btnFaturadanSec);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFaturaKarAnalizi";
            this.Text = "frmFaturaKarAnalizi";
            this.Load += new System.EventHandler(this.frmFaturaKarAnalizi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnFaturadanSec;
        private DevExpress.XtraGrid.Columns.GridColumn colStokID;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colAnaBirimMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colAnaBirimID;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturadakiSatisFiyati;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyetFiyati;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyetTutari;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colKarTutari;
        private DevExpress.XtraEditors.SimpleButton btnStokHarekettenSec;
        private DevExpress.XtraEditors.SimpleButton btnStokKartiniAc;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colToplamKar;
    }
}