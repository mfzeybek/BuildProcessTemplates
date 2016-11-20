namespace Aresv2
{
    partial class frmEvrakYonetimi
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
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.cameraControl1 = new DevExpress.XtraEditors.Camera.CameraControl();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentViewer1
            // 
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(73, 64);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(238, 300);
            this.documentViewer1.TabIndex = 0;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.documentViewer1);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(23, 29);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(436, 490);
            this.xtraScrollableControl1.TabIndex = 1;
            // 
            // cameraControl1
            // 
            this.cameraControl1.Location = new System.Drawing.Point(635, 159);
            this.cameraControl1.Name = "cameraControl1";
            this.cameraControl1.Size = new System.Drawing.Size(270, 281);
            this.cameraControl1.TabIndex = 2;
            this.cameraControl1.Text = "cameraControl1";
            // 
            // frmEvrakYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 673);
            this.Controls.Add(this.cameraControl1);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "frmEvrakYonetimi";
            this.Text = "frmEvrakYonetimi";
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.Camera.CameraControl cameraControl1;
    }
}