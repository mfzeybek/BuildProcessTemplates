namespace Aresv2
{
    partial class frmMiktarGir
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
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.textEdit1 = new DevExpress.XtraEditors.CalcEdit();
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl1.Location = new System.Drawing.Point(14, 15);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(285, 96);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "labelControl1";
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(5, 244);
      this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(296, 28);
      this.simpleButton1.TabIndex = 2;
      this.simpleButton1.Text = "Tamam";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // textEdit1
      // 
      this.textEdit1.Location = new System.Drawing.Point(49, 118);
      this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textEdit1.Name = "textEdit1";
      this.textEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.textEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
      this.textEdit1.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      this.textEdit1.Size = new System.Drawing.Size(213, 22);
      this.textEdit1.TabIndex = 0;
      // 
      // frmMiktarGir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(313, 285);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.textEdit1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frmMiktarGir";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "XtraForm3";
      this.Load += new System.EventHandler(this.XtraForm3_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMiktarGir_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.CalcEdit textEdit1;
    }
}