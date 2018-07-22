namespace Transportes
{
    partial class frmVerInformes
    {
        public CrystalDecisions.Windows.Forms.CrystalReportViewer visorRPT;
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
        public void InitializeComponent()
        {
            this.visorRPT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // visorRPT
            // 
            this.visorRPT.ActiveViewIndex = -1;
            this.visorRPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visorRPT.Cursor = System.Windows.Forms.Cursors.Default;
            this.visorRPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visorRPT.Location = new System.Drawing.Point(0, 0);
            this.visorRPT.Name = "visorRPT";
            this.visorRPT.Size = new System.Drawing.Size(737, 482);
            this.visorRPT.TabIndex = 0;
            // 
            // frmVerInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 482);
            this.Controls.Add(this.visorRPT);
            this.Name = "frmVerInformes";
            this.Text = "frmVerInformes";
            this.ResumeLayout(false);

        }


        #endregion

        //public CrystalDecisions.Windows.Forms.CrystalReportViewer visorRPT;
    }
}