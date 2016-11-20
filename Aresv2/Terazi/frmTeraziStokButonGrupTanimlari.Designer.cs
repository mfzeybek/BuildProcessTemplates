namespace Aresv2.Terazi
{
    partial class frmTeraziStokButonGrupTanimlari
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
            this.gcStokButonGruplari = new DevExpress.XtraGrid.GridControl();
            this.gvStokButonGruplari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrubunStoklariniDuzenle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcStokButonGruplari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokButonGruplari)).BeginInit();
            this.SuspendLayout();
            // 
            // gcStokButonGruplari
            // 
            this.gcStokButonGruplari.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcStokButonGruplari.Location = new System.Drawing.Point(10, 10);
            this.gcStokButonGruplari.MainView = this.gvStokButonGruplari;
            this.gcStokButonGruplari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcStokButonGruplari.Name = "gcStokButonGruplari";
            this.gcStokButonGruplari.Size = new System.Drawing.Size(362, 362);
            this.gcStokButonGruplari.TabIndex = 0;
            this.gcStokButonGruplari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokButonGruplari});
            // 
            // gvStokButonGruplari
            // 
            this.gvStokButonGruplari.GridControl = this.gcStokButonGruplari;
            this.gvStokButonGruplari.Name = "gvStokButonGruplari";
            this.gvStokButonGruplari.NewItemRowText = "Yeni Grup Buradan Ekleniyor";
            this.gvStokButonGruplari.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvStokButonGruplari.OptionsView.ShowGroupPanel = false;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseBorderColor = true;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Appearance.Options.UseTextOptions = true;
            this.btnKaydet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnKaydet.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None;
            this.btnKaydet.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord;
            this.btnKaydet.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnKaydet.Image = global::Aresv2.Properties.Resources.blue_cross_icon_1_;
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnKaydet.Location = new System.Drawing.Point(10, 376);
            this.btnKaydet.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnKaydet.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnKaydet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(123, 89);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet dfsdfsdfsdfdfsdfs dfsdfdsfsdfsdf";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGrubunStoklariniDuzenle
            // 
            this.btnGrubunStoklariniDuzenle.Location = new System.Drawing.Point(400, 11);
            this.btnGrubunStoklariniDuzenle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGrubunStoklariniDuzenle.Name = "btnGrubunStoklariniDuzenle";
            this.btnGrubunStoklariniDuzenle.Size = new System.Drawing.Size(145, 19);
            this.btnGrubunStoklariniDuzenle.TabIndex = 2;
            this.btnGrubunStoklariniDuzenle.Text = "Grubun Stoklarını Düzenle";
            this.btnGrubunStoklariniDuzenle.Click += new System.EventHandler(this.btnGrubunStoklariniDuzenle_Click);
            // 
            // frmTeraziStokButonGrupTanimlari
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 466);
            this.Controls.Add(this.btnGrubunStoklariniDuzenle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gcStokButonGruplari);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTeraziStokButonGrupTanimlari";
            this.Text = "Terazi Grup Tanımları";
            this.Load += new System.EventHandler(this.frmTeraziStokButonGrupTanimlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcStokButonGruplari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokButonGruplari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcStokButonGruplari;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStokButonGruplari;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGrubunStoklariniDuzenle;
    }
}