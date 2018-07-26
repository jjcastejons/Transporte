namespace Transportes
{
    partial class frmListUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUsuarios));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdUsuarios = new System.Windows.Forms.DataGridView();
            this.ToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscar,
            this.ToolStripSeparator1,
            this.btnNuevo,
            this.ToolStripSeparator3,
            this.btnCancelar});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(533, 25);
            this.ToolStrip1.TabIndex = 55;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Transportes.Properties.Resources.document_view;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 22);
            this.btnBuscar.Text = "F3: Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 22);
            this.btnNuevo.Text = "F5: Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 22);
            this.btnCancelar.Text = "Cancelar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 35);
            this.panel1.TabIndex = 56;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(96, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(159, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // grdUsuarios
            // 
            this.grdUsuarios.AllowUserToAddRows = false;
            this.grdUsuarios.AllowUserToDeleteRows = false;
            this.grdUsuarios.AllowUserToResizeRows = false;
            this.grdUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsuarios.Location = new System.Drawing.Point(0, 69);
            this.grdUsuarios.MultiSelect = false;
            this.grdUsuarios.Name = "grdUsuarios";
            this.grdUsuarios.ReadOnly = true;
            this.grdUsuarios.RowHeadersVisible = false;
            this.grdUsuarios.Size = new System.Drawing.Size(529, 301);
            this.grdUsuarios.TabIndex = 57;
            this.grdUsuarios.DoubleClick += new System.EventHandler(this.grdUsuarios_DoubleClick);
            // 
            // frmListUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 374);
            this.Controls.Add(this.grdUsuarios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmListUsuarios";
            this.Text = "Listado de usuarios";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnBuscar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnNuevo;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdUsuarios;
    }
}