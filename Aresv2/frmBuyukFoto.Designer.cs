﻿namespace Aresv2
{
  partial class frmBuyukFoto
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
      this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureEdit1
      // 
      this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureEdit1.ImeMode = System.Windows.Forms.ImeMode.On;
      this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
      this.pictureEdit1.Name = "pictureEdit1";
      this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
      this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
      this.pictureEdit1.Properties.ShowScrollBars = true;
      this.pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
      this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
      this.pictureEdit1.Size = new System.Drawing.Size(1296, 617);
      this.pictureEdit1.TabIndex = 0;
      // 
      // frmBuyukFoto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1296, 617);
      this.Controls.Add(this.pictureEdit1);
      this.Name = "frmBuyukFoto";
      this.Text = "frmBüyükFoto";
      this.Load += new System.EventHandler(this.frmBuyukFoto_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PictureEdit pictureEdit1;
  }
}