namespace Aresv2.AyarlarHemeAl
{
	partial class frmHAMarka
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
			this.gcStokMarka = new DevExpress.XtraGrid.GridControl();
			this.gvStokMarka = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.btnWebeGonder = new DevExpress.XtraEditors.SimpleButton();
			this.btnIceriBilgiAl = new DevExpress.XtraEditors.SimpleButton();
			this.gcHAMarka = new DevExpress.XtraGrid.GridControl();
			this.gvHAMarka = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcStokMarka)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvStokMarka)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcHAMarka)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvHAMarka)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
			this.splitContainerControl1.Panel1.Controls.Add(this.gcStokMarka);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.splitContainerControl1.Panel2.Controls.Add(this.gcHAMarka);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(759, 489);
			this.splitContainerControl1.SplitterPosition = 360;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// gcStokMarka
			// 
			this.gcStokMarka.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcStokMarka.Location = new System.Drawing.Point(0, 0);
			this.gcStokMarka.MainView = this.gvStokMarka;
			this.gcStokMarka.Name = "gcStokMarka";
			this.gcStokMarka.Size = new System.Drawing.Size(356, 485);
			this.gcStokMarka.TabIndex = 1;
			this.gcStokMarka.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokMarka});
			// 
			// gvStokMarka
			// 
			this.gvStokMarka.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gvStokMarka.GridControl = this.gcStokMarka;
			this.gvStokMarka.Name = "gvStokMarka";
			this.gvStokMarka.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvStokMarka.OptionsBehavior.Editable = false;
			this.gvStokMarka.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gvStokMarka.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gvStokMarka.OptionsView.ColumnAutoWidth = false;
			this.gvStokMarka.OptionsView.EnableAppearanceEvenRow = true;
			this.gvStokMarka.OptionsView.EnableAppearanceOddRow = true;
			this.gvStokMarka.OptionsView.ShowGroupPanel = false;
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.btnWebeGonder);
			this.panelControl2.Controls.Add(this.btnIceriBilgiAl);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl2.Location = new System.Drawing.Point(0, 454);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(356, 31);
			this.panelControl2.TabIndex = 0;
			// 
			// btnWebeGonder
			// 
			this.btnWebeGonder.Location = new System.Drawing.Point(5, 3);
			this.btnWebeGonder.Name = "btnWebeGonder";
			this.btnWebeGonder.Size = new System.Drawing.Size(99, 23);
			this.btnWebeGonder.TabIndex = 1;
			this.btnWebeGonder.Text = "Web e Gönder ->>";
			this.btnWebeGonder.Click += new System.EventHandler(this.btnWebeGonder_Click);
			// 
			// btnIceriBilgiAl
			// 
			this.btnIceriBilgiAl.Location = new System.Drawing.Point(110, 3);
			this.btnIceriBilgiAl.Name = "btnIceriBilgiAl";
			this.btnIceriBilgiAl.Size = new System.Drawing.Size(99, 23);
			this.btnIceriBilgiAl.TabIndex = 0;
			this.btnIceriBilgiAl.Text = "İçeri Bilgi Al <<-";
			this.btnIceriBilgiAl.Click += new System.EventHandler(this.btnIceriBilgiAl_Click);
			// 
			// gcHAMarka
			// 
			this.gcHAMarka.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcHAMarka.Location = new System.Drawing.Point(0, 0);
			this.gcHAMarka.MainView = this.gvHAMarka;
			this.gcHAMarka.Name = "gcHAMarka";
			this.gcHAMarka.Size = new System.Drawing.Size(390, 485);
			this.gcHAMarka.TabIndex = 0;
			this.gcHAMarka.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHAMarka});
			// 
			// gvHAMarka
			// 
			this.gvHAMarka.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gvHAMarka.GridControl = this.gcHAMarka;
			this.gvHAMarka.Name = "gvHAMarka";
			this.gvHAMarka.OptionsBehavior.Editable = false;
			this.gvHAMarka.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gvHAMarka.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gvHAMarka.OptionsView.ColumnAutoWidth = false;
			this.gvHAMarka.OptionsView.EnableAppearanceEvenRow = true;
			this.gvHAMarka.OptionsView.EnableAppearanceOddRow = true;
			// 
			// frmHAMarka
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 489);
			this.Controls.Add(this.splitContainerControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmHAMarka";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HemenAL Marka Entegrasyonu";
			this.Load += new System.EventHandler(this.frmHAKategori_Load);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcStokMarka)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvStokMarka)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcHAMarka)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvHAMarka)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraGrid.GridControl gcHAMarka;
		private DevExpress.XtraGrid.Views.Grid.GridView gvHAMarka;
		private DevExpress.XtraGrid.GridControl gcStokMarka;
		private DevExpress.XtraGrid.Views.Grid.GridView gvStokMarka;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.SimpleButton btnWebeGonder;
		private DevExpress.XtraEditors.SimpleButton btnIceriBilgiAl;
	}
}