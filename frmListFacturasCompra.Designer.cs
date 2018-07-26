namespace Transportes
{
    partial class frmListFacturasCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListFacturasCompra));
            this.grdFacturasCompra = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasCompra)).BeginInit();
            this.panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFacturasCompra
            // 
            this.grdFacturasCompra.AllowUserToAddRows = false;
            this.grdFacturasCompra.AllowUserToDeleteRows = false;
            this.grdFacturasCompra.AllowUserToResizeRows = false;
            this.grdFacturasCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFacturasCompra.Location = new System.Drawing.Point(-1, 83);
            this.grdFacturasCompra.MultiSelect = false;
            this.grdFacturasCompra.Name = "grdFacturasCompra";
            this.grdFacturasCompra.ReadOnly = true;
            this.grdFacturasCompra.RowHeadersVisible = false;
            this.grdFacturasCompra.Size = new System.Drawing.Size(521, 304);
            this.grdFacturasCompra.TabIndex = 65;
            this.grdFacturasCompra.DoubleClick += new System.EventHandler(this.grdFacturasCompra_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Controls.Add(this.txtNumFactura);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 49);
            this.panel1.TabIndex = 64;
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(73, 12);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(145, 20);
            this.txtNumFactura.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº Factura";
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
            this.ToolStrip1.Size = new System.Drawing.Size(526, 25);
            this.ToolStrip1.TabIndex = 63;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 22);
            this.btnNuevo.Text = "F5: Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 22);
            this.btnCancelar.Text = "Cancelar";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(295, 12);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(159, 20);
            this.txtProveedor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proveedor";
            // 
            // frmListFacturasCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 390);
            this.Controls.Add(this.grdFacturasCompra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmListFacturasCompra";
            this.Text = "Listado de facturas de compra";
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFacturasCompra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnBuscar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnNuevo;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProveedor;
    }
}