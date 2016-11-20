namespace Aresv2.Personel
{
    partial class frmPersonelListesi
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
      this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
      this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.txtPersonelAdi = new DevExpress.XtraEditors.TextEdit();
      this.gcPersonel = new DevExpress.XtraGrid.GridControl();
      this.gvPersonel = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colPersonelID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnKaydiAc = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcPersonel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvPersonel)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 46);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.Controls.Add(this.btnTemizle);
      this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
      this.splitContainerControl1.Panel1.Controls.Add(this.txtPersonelAdi);
      this.splitContainerControl1.Panel1.Text = "Panel1";
      this.splitContainerControl1.Panel2.Controls.Add(this.gcPersonel);
      this.splitContainerControl1.Panel2.Text = "Panel2";
      this.splitContainerControl1.Size = new System.Drawing.Size(1001, 470);
      this.splitContainerControl1.SplitterPosition = 217;
      this.splitContainerControl1.TabIndex = 1;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // btnTemizle
      // 
      this.btnTemizle.Location = new System.Drawing.Point(141, 315);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new System.Drawing.Size(75, 23);
      this.btnTemizle.TabIndex = 3;
      this.btnTemizle.Text = "Temizle";
      // 
      // btnFiltrele
      // 
      this.btnFiltrele.Location = new System.Drawing.Point(12, 315);
      this.btnFiltrele.Name = "btnFiltrele";
      this.btnFiltrele.Size = new System.Drawing.Size(123, 23);
      this.btnFiltrele.TabIndex = 3;
      this.btnFiltrele.Text = "Filtrele (F2)";
      this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(4, 15);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(71, 16);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "Personel Adı";
      // 
      // txtPersonelAdi
      // 
      this.txtPersonelAdi.Location = new System.Drawing.Point(85, 12);
      this.txtPersonelAdi.Name = "txtPersonelAdi";
      this.txtPersonelAdi.Size = new System.Drawing.Size(119, 22);
      this.txtPersonelAdi.TabIndex = 0;
      // 
      // gcPersonel
      // 
      this.gcPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcPersonel.Location = new System.Drawing.Point(0, 0);
      this.gcPersonel.MainView = this.gvPersonel;
      this.gcPersonel.Name = "gcPersonel";
      this.gcPersonel.Size = new System.Drawing.Size(779, 470);
      this.gcPersonel.TabIndex = 1;
      this.gcPersonel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersonel});
      // 
      // gvPersonel
      // 
      this.gvPersonel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariID,
            this.colCariAdi,
            this.colCariAciklama,
            this.colPersonelID});
      this.gvPersonel.GridControl = this.gcPersonel;
      this.gvPersonel.Name = "gvPersonel";
      this.gvPersonel.OptionsView.ShowGroupPanel = false;
      // 
      // colCariID
      // 
      this.colCariID.Caption = "Cari ID";
      this.colCariID.FieldName = "CariID";
      this.colCariID.Name = "colCariID";
      this.colCariID.Visible = true;
      this.colCariID.VisibleIndex = 0;
      // 
      // colCariAdi
      // 
      this.colCariAdi.Caption = "Cari Adı";
      this.colCariAdi.FieldName = "CariTanim";
      this.colCariAdi.Name = "colCariAdi";
      this.colCariAdi.Visible = true;
      this.colCariAdi.VisibleIndex = 1;
      // 
      // colCariAciklama
      // 
      this.colCariAciklama.Caption = "Cari Açıklama";
      this.colCariAciklama.FieldName = "Aciklama";
      this.colCariAciklama.Name = "colCariAciklama";
      this.colCariAciklama.Visible = true;
      this.colCariAciklama.VisibleIndex = 2;
      // 
      // colPersonelID
      // 
      this.colPersonelID.Caption = "Personel ID";
      this.colPersonelID.FieldName = "PersonelID";
      this.colPersonelID.Name = "colPersonelID";
      this.colPersonelID.Visible = true;
      this.colPersonelID.VisibleIndex = 3;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnKaydiAc);
      this.panel1.Controls.Add(this.labelControl3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1001, 46);
      this.panel1.TabIndex = 2;
      // 
      // btnKaydiAc
      // 
      this.btnKaydiAc.Location = new System.Drawing.Point(623, 3);
      this.btnKaydiAc.Name = "btnKaydiAc";
      this.btnKaydiAc.Size = new System.Drawing.Size(82, 37);
      this.btnKaydiAc.TabIndex = 4;
      this.btnKaydiAc.Text = "Kartı Aç";
      this.btnKaydiAc.Click += new System.EventHandler(this.btnKaydiAc_Click);
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(12, 12);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(110, 16);
      this.labelControl3.TabIndex = 3;
      this.labelControl3.Text = "PERSONEL LİSTESİ";
      // 
      // frmPersonelListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1001, 516);
      this.Controls.Add(this.splitContainerControl1);
      this.Controls.Add(this.panel1);
      this.Name = "frmPersonelListesi";
      this.Text = "frmPersonelListesi";
      this.Load += new System.EventHandler(this.frmPersonelListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcPersonel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvPersonel)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcPersonel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn colCariID;
        private DevExpress.XtraGrid.Columns.GridColumn colCariAdi;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnFiltrele;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPersonelAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colCariAciklama;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnKaydiAc;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelID;

    }
}