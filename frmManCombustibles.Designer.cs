﻿namespace Transportes
{
    partial class frmManCombustibles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManCombustibles));
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevoTool = new System.Windows.Forms.ToolStripButton();
            this.btnAddTool = new System.Windows.Forms.ToolStripButton();
            this.btnModificarTool = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarTool = new System.Windows.Forms.ToolStripButton();
            this.btnCancelarTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(17, 55);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(74, 13);
            this.Label5.TabIndex = 77;
            this.Label5.Text = "Descripcion";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 92);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 13);
            this.Label1.TabIndex = 79;
            this.Label1.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(107, 84);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(200, 21);
            this.cmbProveedor.TabIndex = 78;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDescripcion.Location = new System.Drawing.Point(107, 48);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 76;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoTool,
            this.ToolStripSeparator2,
            this.btnAddTool,
            this.btnModificarTool,
            this.ToolStripSeparator1,
            this.btnEliminarTool,
            this.ToolStripSeparator3,
            this.btnCancelarTool});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(453, 25);
            this.ToolStrip1.TabIndex = 75;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // btnNuevoTool
            // 
            this.btnNuevoTool.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoTool.Image")));
            this.btnNuevoTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoTool.Name = "btnNuevoTool";
            this.btnNuevoTool.Size = new System.Drawing.Size(80, 22);
            this.btnNuevoTool.Text = "F5: Nuevo";
            // 
            // btnAddTool
            // 
            this.btnAddTool.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTool.Image")));
            this.btnAddTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTool.Name = "btnAddTool";
            this.btnAddTool.Size = new System.Drawing.Size(80, 22);
            this.btnAddTool.Text = "F6: Añadir";
            this.btnAddTool.Click += new System.EventHandler(this.btnAddTool_Click);
            // 
            // btnModificarTool
            // 
            this.btnModificarTool.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarTool.Image")));
            this.btnModificarTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarTool.Name = "btnModificarTool";
            this.btnModificarTool.Size = new System.Drawing.Size(96, 22);
            this.btnModificarTool.Text = "F7: Modificar";
            this.btnModificarTool.Click += new System.EventHandler(this.btnModificarTool_Click);
            // 
            // btnEliminarTool
            // 
            this.btnEliminarTool.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarTool.Image")));
            this.btnEliminarTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarTool.Name = "btnEliminarTool";
            this.btnEliminarTool.Size = new System.Drawing.Size(88, 22);
            this.btnEliminarTool.Text = "F8: Eliminar";
            // 
            // btnCancelarTool
            // 
            this.btnCancelarTool.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarTool.Image")));
            this.btnCancelarTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelarTool.Name = "btnCancelarTool";
            this.btnCancelarTool.Size = new System.Drawing.Size(73, 22);
            this.btnCancelarTool.Text = "Cancelar";
            // 
            // frmManCombustibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 127);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmManCombustibles";
            this.Text = "Pantalla de mantenimiento de combustibles";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbProveedor;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnNuevoTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnAddTool;
        internal System.Windows.Forms.ToolStripButton btnModificarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnEliminarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnCancelarTool;
    }
}