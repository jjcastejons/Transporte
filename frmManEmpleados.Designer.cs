namespace Transportes
{
    partial class frmManEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManEmpleados));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevoTool = new System.Windows.Forms.ToolStripButton();
            this.btnAddTool = new System.Windows.Forms.ToolStripButton();
            this.btnModificarTool = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarTool = new System.Windows.Forms.ToolStripButton();
            this.btnCancelarTool = new System.Windows.Forms.ToolStripButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.fechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fechaBaja = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNumSS = new System.Windows.Forms.TextBox();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(540, 25);
            this.ToolStrip1.TabIndex = 53;
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
            this.btnNuevoTool.Click += new System.EventHandler(this.btnNuevoTool_Click);
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
            this.btnEliminarTool.Click += new System.EventHandler(this.btnEliminarTool_Click);
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
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNombre.Location = new System.Drawing.Point(125, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 63;
            // 
            // txtNIF
            // 
            this.txtNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNIF.Location = new System.Drawing.Point(125, 179);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(200, 20);
            this.txtNIF.TabIndex = 55;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(125, 123);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(200, 21);
            this.cmbDepartamento.TabIndex = 67;
            // 
            // txtApellido1
            // 
            this.txtApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtApellido1.Location = new System.Drawing.Point(125, 71);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(200, 20);
            this.txtApellido1.TabIndex = 49;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(25, 131);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 13);
            this.Label1.TabIndex = 68;
            this.Label1.Text = "Departamento";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(80, 182);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(27, 13);
            this.Label11.TabIndex = 60;
            this.Label11.Text = "NIF";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPuesto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Items.AddRange(new object[] {
            "INFORMATICA",
            "ALIMENTACION"});
            this.cmbPuesto.Location = new System.Drawing.Point(125, 150);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(200, 21);
            this.cmbPuesto.TabIndex = 69;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(17, 78);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 13);
            this.Label2.TabIndex = 52;
            this.Label2.Text = "Primer apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Segundo apellido";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(65, 153);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(46, 13);
            this.Label12.TabIndex = 59;
            this.Label12.Text = "Puesto";
            // 
            // txtApellido2
            // 
            this.txtApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtApellido2.Location = new System.Drawing.Point(125, 97);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(200, 20);
            this.txtApellido2.TabIndex = 71;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(61, 48);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(50, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Nombre";
            // 
            // fechaAlta
            // 
            this.fechaAlta.CalendarForeColor = System.Drawing.Color.Blue;
            this.fechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaAlta.Location = new System.Drawing.Point(125, 234);
            this.fechaAlta.Name = "fechaAlta";
            this.fechaAlta.Size = new System.Drawing.Size(200, 20);
            this.fechaAlta.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Fecha alta";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivo.Location = new System.Drawing.Point(125, 302);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(62, 17);
            this.chkActivo.TabIndex = 75;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Fecha baja";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Nº S/S";
            // 
            // fechaBaja
            // 
            this.fechaBaja.CalendarForeColor = System.Drawing.Color.Blue;
            this.fechaBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaBaja.Location = new System.Drawing.Point(125, 260);
            this.fechaBaja.Name = "fechaBaja";
            this.fechaBaja.Size = new System.Drawing.Size(200, 20);
            this.fechaBaja.TabIndex = 78;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(352, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 180);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // txtNumSS
            // 
            this.txtNumSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumSS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNumSS.Location = new System.Drawing.Point(125, 205);
            this.txtNumSS.Name = "txtNumSS";
            this.txtNumSS.Size = new System.Drawing.Size(200, 20);
            this.txtNumSS.TabIndex = 80;
            // 
            // frmManEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 336);
            this.Controls.Add(this.txtNumSS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fechaBaja);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.fechaAlta);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtApellido2);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbPuesto);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtApellido1);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.txtNIF);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmManEmpleados";
            this.Text = "Mantenimiento de empleados";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnNuevoTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnAddTool;
        internal System.Windows.Forms.ToolStripButton btnModificarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnEliminarTool;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnCancelarTool;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.TextBox txtNIF;
        internal System.Windows.Forms.ComboBox cmbDepartamento;
        internal System.Windows.Forms.TextBox txtApellido1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.ComboBox cmbPuesto;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtApellido2;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.DateTimePicker fechaAlta;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker fechaBaja;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.TextBox txtNumSS;
    }
}