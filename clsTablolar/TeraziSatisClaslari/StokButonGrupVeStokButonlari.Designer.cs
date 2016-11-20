namespace clsTablolar.TeraziSatisClaslari
{
    partial class StokButonGrupVeStokButonlari
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokButonGrupVeStokButonlari));
            this.flpGrupButonlari = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpGrupButonlari
            // 
            resources.ApplyResources(this.flpGrupButonlari, "flpGrupButonlari");
            this.flpGrupButonlari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpGrupButonlari.Name = "flpGrupButonlari";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // StokButonGrupVeStokButonlari
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flpGrupButonlari);
            this.Name = "StokButonGrupVeStokButonlari";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flpGrupButonlari;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
