namespace Transportes
{
    partial class frmManClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManClientes));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbProvincias = new System.Windows.Forms.ComboBox();
            this.txtCIF = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddTool = new System.Windows.Forms.ToolStripButton();
            this.btnModificarTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelarTool = new System.Windows.Forms.ToolStripButton();
            this.GroupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtEmail);
            this.GroupBox1.Controls.Add(this.txtTelefono);
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtLocalidad);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbProvincias);
            this.GroupBox1.Controls.Add(this.txtCIF);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtNombre);
            this.GroupBox1.Controls.Add(this.txtDireccion);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Location = new System.Drawing.Point(0, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(585, 135);
            this.GroupBox1.TabIndex = 54;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos Cliente";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(364, 75);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 77;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(364, 47);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 76;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(364, 98);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(90, 17);
            this.chkActivo.TabIndex = 75;
            this.chkActivo.Text = "Cliente activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Email";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(78, 101);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(157, 20);
            this.txtLocalidad.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Provincia";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(20, 98);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 68;
            this.Label1.Text = "Localidad";
            // 
            // cmbProvincias
            // 
            this.cmbProvincias.FormattingEnabled = true;
            this.cmbProvincias.Location = new System.Drawing.Point(79, 74);
            this.cmbProvincias.Name = "cmbProvincias";
            this.cmbProvincias.Size = new System.Drawing.Size(157, 21);
            this.cmbProvincias.TabIndex = 67;
            // 
            // txtCIF
            // 
            this.txtCIF.Location = new System.Drawing.Point(78, 17);
            this.txtCIF.Name = "txtCIF";
            this.txtCIF.Size = new System.Drawing.Size(157, 20);
            this.txtCIF.TabIndex = 63;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(20, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(23, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "CIF";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(364, 15);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 55;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(78, 44);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(157, 20);
            this.txtDireccion.TabIndex = 49;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(298, 51);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(49, 13);
            this.Label11.TabIndex = 60;
            this.Label11.Text = "Telefono";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(20, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 52;
            this.Label2.Text = "Dirección";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(298, 22);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(44, 13);
            this.Label12.TabIndex = 59;
            this.Label12.Text = "Nombre";
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
            this.ToolStrip1.Size = new System.Drawing.Size(593, 25);
            this.ToolStrip1.TabIndex = 55;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnNuevoTool
            // 
            this.btnNuevoTool.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoTool.Image")));
            this.btnNuevoTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoTool.Name = "btnNuevoTool";
            this.btnNuevoTool.Size = new System.Drawing.Size(80, 22);
            this.btnNuevoTool.Text = "F5: Nuevo";
            this.btnNuevoTool.Click += new System.EventHandler(this.btnNuevoTool_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEliminarTool
            // 
            this.btnEliminarTool.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarTool.Image")));
            this.btnEliminarTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarTool.Name = "btnEliminarTool";
            this.btnEliminarTool.Size = new System.Drawing.Size(88, 22);
            this.btnEliminarTool.Text = "F8: Eliminar";
            this.btnEliminarTool.Click += new System.EventHandler(this.btnEliminarTool_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancelarTool
            // 
            this.btnCancelarTool.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarTool.Image")));
            this.btnCancelarTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelarTool.Name = "btnCancelarTool";
            this.btnCancelarTool.Size = new System.Drawing.Size(73, 22);
            this.btnCancelarTool.Text = "Cancelar";
            this.btnCancelarTool.Click += new System.EventHandler(this.btnCancelarTool_Click);
            // 
            // frmManClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 170);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frmManClientes";
            this.Text = "Mantenimiento de clientes";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManClientes_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtLocalidad;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbProvincias;
        internal System.Windows.Forms.TextBox txtCIF;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.TextBox txtDireccion;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnAddTool;
        internal System.Windows.Forms.ToolStripButton btnModificarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnEliminarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnCancelarTool;
        internal System.Windows.Forms.ToolStripButton btnNuevoTool;
    }
}