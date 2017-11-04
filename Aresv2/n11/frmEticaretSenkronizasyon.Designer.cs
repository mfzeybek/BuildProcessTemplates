namespace Aresv2.n11
{
    partial class frmEticaretSenkronizasyon
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnN11BasitListeGetir = new DevExpress.XtraEditors.SimpleButton();
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnFiyatiGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokKartiniAc = new DevExpress.XtraEditors.SimpleButton();
            this.btnN11KartiniAc = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.btnButunN11StoklariniGetir = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout)).BeginInit();
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gridControl1.Location = new System.Drawing.Point(11, 199);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(983, 360);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // btnN11BasitListeGetir
            // 
            this.btnN11BasitListeGetir.Location = new System.Drawing.Point(448, 11);
            this.btnN11BasitListeGetir.Margin = new System.Windows.Forms.Padding(2);
            this.btnN11BasitListeGetir.Name = "btnN11BasitListeGetir";
            this.btnN11BasitListeGetir.Size = new System.Drawing.Size(546, 22);
            this.btnN11BasitListeGetir.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnN11BasitListeGetir.TabIndex = 2;
            this.btnN11BasitListeGetir.Text = "n11 Basit stok özelliklerini getir, Ares tek stoklarla karşılarştır";
            this.btnN11BasitListeGetir.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmEticaretSenkronizasyonlayoutControl1ConvertedLayout
            // 
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.lblBilgi);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnButunN11StoklariniGetir);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.simpleButton3);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnFiyatiGuncelle);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.simpleButton2);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.simpleButton1);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnStokEkle);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnStokKartiniAc);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnN11KartiniAc);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.gridControl1);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Controls.Add(this.btnN11BasitListeGetir);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Margin = new System.Windows.Forms.Padding(2);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Name = "frmEticaretSenkronizasyonlayoutControl1ConvertedLayout";
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1714, 748, 900, 800);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(1005, 587);
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.TabIndex = 5;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(448, 89);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(546, 22);
            this.simpleButton3.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.simpleButton3.TabIndex = 10;
            this.simpleButton3.Text = "simpleButton3";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click_1);
            // 
            // btnFiyatiGuncelle
            // 
            this.btnFiyatiGuncelle.Location = new System.Drawing.Point(11, 89);
            this.btnFiyatiGuncelle.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiyatiGuncelle.Name = "btnFiyatiGuncelle";
            this.btnFiyatiGuncelle.Size = new System.Drawing.Size(433, 22);
            this.btnFiyatiGuncelle.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnFiyatiGuncelle.TabIndex = 9;
            this.btnFiyatiGuncelle.Text = "Secili Stokun Fiyatini Guncelle";
            this.btnFiyatiGuncelle.Click += new System.EventHandler(this.btnFiyatiGuncelle_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(448, 63);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(546, 22);
            this.simpleButton2.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Seçili Olanı Beklemeye Al";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(11, 63);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(433, 22);
            this.simpleButton1.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Secili Olanı Satışa Al";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(258, 11);
            this.btnStokEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(186, 22);
            this.btnStokEkle.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnStokEkle.TabIndex = 7;
            this.btnStokEkle.Text = "Aresteki Karşılartıralacak Stokları Ekle";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // btnStokKartiniAc
            // 
            this.btnStokKartiniAc.Location = new System.Drawing.Point(11, 37);
            this.btnStokKartiniAc.Name = "btnStokKartiniAc";
            this.btnStokKartiniAc.Size = new System.Drawing.Size(433, 22);
            this.btnStokKartiniAc.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnStokKartiniAc.TabIndex = 6;
            this.btnStokKartiniAc.Text = "Stok Kartını Aç";
            this.btnStokKartiniAc.Click += new System.EventHandler(this.btnStokKartiniAc_Click);
            // 
            // btnN11KartiniAc
            // 
            this.btnN11KartiniAc.Location = new System.Drawing.Point(448, 37);
            this.btnN11KartiniAc.Name = "btnN11KartiniAc";
            this.btnN11KartiniAc.Size = new System.Drawing.Size(546, 22);
            this.btnN11KartiniAc.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnN11KartiniAc.TabIndex = 5;
            this.btnN11KartiniAc.Text = "N11 Kartını Aç";
            this.btnN11KartiniAc.Click += new System.EventHandler(this.btnN11KartiniAc_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 9, 9);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1005, 587);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem1.Name = "gridControl1item";
            this.layoutControlItem1.Size = new System.Drawing.Size(987, 448);
            this.layoutControlItem1.Text = "Burada basit karşılatırma yapılır,\r\nÜrün fiyatını,\r\nMiktarını\r\nTitle\r\nsub title\r\n" +
    " karşılaştırması yapılıyor sadece";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(152, 78);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnN11BasitListeGetir;
            this.layoutControlItem4.Location = new System.Drawing.Point(437, 0);
            this.layoutControlItem4.Name = "btnN11BasitListeGetiritem";
            this.layoutControlItem4.Size = new System.Drawing.Size(550, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnStokKartiniAc;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(437, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnStokEkle;
            this.layoutControlItem2.Location = new System.Drawing.Point(247, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(190, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnN11KartiniAc;
            this.layoutControlItem5.Location = new System.Drawing.Point(437, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(550, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(437, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton2;
            this.layoutControlItem7.Location = new System.Drawing.Point(437, 52);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(550, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnFiyatiGuncelle;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(437, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.simpleButton3;
            this.layoutControlItem9.Location = new System.Drawing.Point(437, 78);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(550, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // btnButunN11StoklariniGetir
            // 
            this.btnButunN11StoklariniGetir.Location = new System.Drawing.Point(11, 11);
            this.btnButunN11StoklariniGetir.Name = "btnButunN11StoklariniGetir";
            this.btnButunN11StoklariniGetir.Size = new System.Drawing.Size(243, 22);
            this.btnButunN11StoklariniGetir.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.btnButunN11StoklariniGetir.TabIndex = 11;
            this.btnButunN11StoklariniGetir.Text = "Bütün N11 Stoklarını Getir";
            this.btnButunN11StoklariniGetir.Click += new System.EventHandler(this.btnButunN11StoklariniGetir_Click);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnButunN11StoklariniGetir;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(247, 26);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Location = new System.Drawing.Point(11, 563);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(63, 13);
            this.lblBilgi.StyleController = this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
            this.lblBilgi.TabIndex = 12;
            this.lblBilgi.Text = "labelControl1";
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lblBilgi;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 552);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(987, 17);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // frmEticaretSenkronizasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 587);
            this.Controls.Add(this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEticaretSenkronizasyon";
            this.Text = "frmEticaretSenkronizasyon";
            this.Load += new System.EventHandler(this.frmEticaretSenkronizasyon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout)).EndInit();
            this.frmEticaretSenkronizasyonlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnN11BasitListeGetir;
        private DevExpress.XtraLayout.LayoutControl frmEticaretSenkronizasyonlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraEditors.SimpleButton btnStokKartiniAc;
        private DevExpress.XtraEditors.SimpleButton btnN11KartiniAc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnStokEkle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnFiyatiGuncelle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.SimpleButton btnButunN11StoklariniGetir;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
    }
}