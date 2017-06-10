namespace Aresv2.Cek
{
  partial class frmCekListesi
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.monthEdit1 = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.deEvrakTarihi1 = new DevExpress.XtraEditors.DateEdit();
            this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtVerilenCeklerinToplami = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnKartiAc = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEvrakTarihi1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEvrakTarihi1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerilenCeklerinToplami.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.monthEdit1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateEdit2);
            this.splitContainerControl1.Panel1.Controls.Add(this.deEvrakTarihi1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1170, 406);
            this.splitContainerControl1.SplitterPosition = 167;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 99);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Evrak Tarihi Ay";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 50);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Evrak Tarihi 2";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 4);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Evrak Tarihi 1";
            // 
            // monthEdit1
            // 
            this.monthEdit1.Location = new System.Drawing.Point(3, 117);
            this.monthEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monthEdit1.Name = "monthEdit1";
            this.monthEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.monthEdit1.Size = new System.Drawing.Size(151, 20);
            this.monthEdit1.TabIndex = 2;
            this.monthEdit1.EditValueChanged += new System.EventHandler(this.monthEdit1_EditValueChanged);
            // 
            // dateEdit2
            // 
            this.dateEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(3, 67);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.NullDate = "1.1.0001 00:00:00";
            this.dateEdit2.Size = new System.Drawing.Size(151, 20);
            this.dateEdit2.TabIndex = 1;
            this.dateEdit2.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // deEvrakTarihi1
            // 
            this.deEvrakTarihi1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deEvrakTarihi1.EditValue = null;
            this.deEvrakTarihi1.Location = new System.Drawing.Point(3, 22);
            this.deEvrakTarihi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deEvrakTarihi1.Name = "deEvrakTarihi1";
            this.deEvrakTarihi1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEvrakTarihi1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEvrakTarihi1.Properties.NullDate = new System.DateTime(((long)(0)));
            this.deEvrakTarihi1.Size = new System.Drawing.Size(151, 20);
            this.deEvrakTarihi1.TabIndex = 1;
            this.deEvrakTarihi1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.Location = new System.Drawing.Point(5, 376);
            this.btnFiltrele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(159, 19);
            this.btnFiltrele.TabIndex = 0;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(998, 360);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtVerilenCeklerinToplami);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 360);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(998, 46);
            this.panelControl2.TabIndex = 1;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // txtVerilenCeklerinToplami
            // 
            this.txtVerilenCeklerinToplami.Location = new System.Drawing.Point(148, 2);
            this.txtVerilenCeklerinToplami.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVerilenCeklerinToplami.Name = "txtVerilenCeklerinToplami";
            this.txtVerilenCeklerinToplami.Properties.DisplayFormat.FormatString = "c2";
            this.txtVerilenCeklerinToplami.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtVerilenCeklerinToplami.Size = new System.Drawing.Size(149, 20);
            this.txtVerilenCeklerinToplami.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(4, 23);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Alınan Çeklerin Toplamı";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Verilen Çeklerin Toplamı";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnKartiAc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1170, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // btnKartiAc
            // 
            this.btnKartiAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKartiAc.Location = new System.Drawing.Point(771, 4);
            this.btnKartiAc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKartiAc.Name = "btnKartiAc";
            this.btnKartiAc.Size = new System.Drawing.Size(98, 38);
            this.btnKartiAc.TabIndex = 2;
            this.btnKartiAc.Text = "Karti Ac";
            this.btnKartiAc.Click += new System.EventHandler(this.btnKartiAc_Click);
            // 
            // frmCekListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 453);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCekListesi";
            this.Text = "frmCekListesi";
            this.Load += new System.EventHandler(this.frmCekListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEvrakTarihi1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEvrakTarihi1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerilenCeklerinToplami.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton btnKartiAc;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.DateEdit dateEdit2;
    private DevExpress.XtraEditors.DateEdit deEvrakTarihi1;
    private DevExpress.XtraEditors.TextEdit txtVerilenCeklerinToplami;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraScheduler.UI.MonthEdit monthEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl3;
  }
}