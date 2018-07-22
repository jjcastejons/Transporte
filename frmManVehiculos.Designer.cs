namespace Transportes
{
    partial class frmManVehiculos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManVehiculos));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddTool = new System.Windows.Forms.ToolStripButton();
            this.btnModificarTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarTool = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelarTool = new System.Windows.Forms.ToolStripButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaMatriculacion = new System.Windows.Forms.DateTimePicker();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbTipoRuedas = new System.Windows.Forms.ComboBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtNumBastidor = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Datos = new System.Windows.Forms.TabPage();
            this.Revisiones = new System.Windows.Forms.TabPage();
            this.imagenesPaneles = new System.Windows.Forms.ImageList(this.components);
            this.Mantenimiento = new System.Windows.Forms.TabPage();
            this.Extintores = new System.Windows.Forms.TabPage();
            this.Seguro = new System.Windows.Forms.TabPage();
            this.Financiacion = new System.Windows.Forms.TabPage();
            this.ToolStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Datos.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(751, 25);
            this.ToolStrip1.TabIndex = 52;
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
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.fechaMatriculacion);
            this.GroupBox1.Controls.Add(this.txtModelo);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.cmbTipoVehiculo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbTipoRuedas);
            this.GroupBox1.Controls.Add(this.txtMatricula);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtNumBastidor);
            this.GroupBox1.Controls.Add(this.txtMarca);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(6, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(718, 163);
            this.GroupBox1.TabIndex = 53;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Ficha";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivo.Location = new System.Drawing.Point(426, 102);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(116, 17);
            this.chkActivo.TabIndex = 75;
            this.chkActivo.Text = "Vehículo activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(329, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Fecha matriculación";
            // 
            // fechaMatriculacion
            // 
            this.fechaMatriculacion.CalendarForeColor = System.Drawing.Color.Blue;
            this.fechaMatriculacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaMatriculacion.Location = new System.Drawing.Point(458, 76);
            this.fechaMatriculacion.Name = "fechaMatriculacion";
            this.fechaMatriculacion.Size = new System.Drawing.Size(231, 20);
            this.fechaMatriculacion.TabIndex = 72;
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtModelo.Location = new System.Drawing.Point(83, 76);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(200, 20);
            this.txtModelo.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Modelo";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoVehiculo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Items.AddRange(new object[] {
            "INFORMATICA",
            "ALIMENTACION"});
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(458, 49);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(231, 21);
            this.cmbTipoVehiculo.TabIndex = 69;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(20, 103);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 68;
            this.Label1.Text = "Ruedas";
            // 
            // cmbTipoRuedas
            // 
            this.cmbTipoRuedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoRuedas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbTipoRuedas.FormattingEnabled = true;
            this.cmbTipoRuedas.Location = new System.Drawing.Point(83, 102);
            this.cmbTipoRuedas.Name = "cmbTipoRuedas";
            this.cmbTipoRuedas.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoRuedas.TabIndex = 67;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMatricula.Location = new System.Drawing.Point(83, 19);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(200, 20);
            this.txtMatricula.TabIndex = 63;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(12, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(61, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Matrícula";
            // 
            // txtNumBastidor
            // 
            this.txtNumBastidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumBastidor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNumBastidor.Location = new System.Drawing.Point(458, 17);
            this.txtNumBastidor.Name = "txtNumBastidor";
            this.txtNumBastidor.Size = new System.Drawing.Size(231, 20);
            this.txtNumBastidor.TabIndex = 55;
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMarca.Location = new System.Drawing.Point(83, 50);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(200, 20);
            this.txtMarca.TabIndex = 49;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(368, 52);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(84, 13);
            this.Label11.TabIndex = 60;
            this.Label11.Text = "Tipo vehiculo";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 52;
            this.Label2.Text = "Marca";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(379, 21);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(71, 13);
            this.Label12.TabIndex = 59;
            this.Label12.Text = "Nº Bastidor";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Datos);
            this.tabControl1.Controls.Add(this.Revisiones);
            this.tabControl1.Controls.Add(this.Mantenimiento);
            this.tabControl1.Controls.Add(this.Extintores);
            this.tabControl1.Controls.Add(this.Seguro);
            this.tabControl1.Controls.Add(this.Financiacion);
            this.tabControl1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imagenesPaneles;
            this.tabControl1.Location = new System.Drawing.Point(1, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 222);
            this.tabControl1.TabIndex = 54;
            // 
            // Datos
            // 
            this.Datos.Controls.Add(this.GroupBox1);
            this.Datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datos.Location = new System.Drawing.Point(4, 43);
            this.Datos.Name = "Datos";
            this.Datos.Padding = new System.Windows.Forms.Padding(3);
            this.Datos.Size = new System.Drawing.Size(730, 175);
            this.Datos.TabIndex = 0;
            this.Datos.Text = "Datos";
            this.Datos.UseVisualStyleBackColor = true;
            // 
            // Revisiones
            // 
            this.Revisiones.Location = new System.Drawing.Point(4, 43);
            this.Revisiones.Name = "Revisiones";
            this.Revisiones.Padding = new System.Windows.Forms.Padding(3);
            this.Revisiones.Size = new System.Drawing.Size(721, 245);
            this.Revisiones.TabIndex = 1;
            this.Revisiones.Text = "Revisiones";
            this.Revisiones.UseVisualStyleBackColor = true;
            // 
            // imagenesPaneles
            // 
            this.imagenesPaneles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesPaneles.ImageStream")));
            this.imagenesPaneles.Tag = "1";
            this.imagenesPaneles.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesPaneles.Images.SetKeyName(0, "Camion_mini.png");
            this.imagenesPaneles.Images.SetKeyName(1, "bloc_mini2.png");
            this.imagenesPaneles.Images.SetKeyName(2, "mantenimiento_mini.png");
            this.imagenesPaneles.Images.SetKeyName(3, "Extintor_mini.png");
            // 
            // Mantenimiento
            // 
            this.Mantenimiento.Location = new System.Drawing.Point(4, 43);
            this.Mantenimiento.Name = "Mantenimiento";
            this.Mantenimiento.Padding = new System.Windows.Forms.Padding(3);
            this.Mantenimiento.Size = new System.Drawing.Size(730, 175);
            this.Mantenimiento.TabIndex = 2;
            this.Mantenimiento.Text = "Mantenim.";
            this.Mantenimiento.UseVisualStyleBackColor = true;
            // 
            // Extintores
            // 
            this.Extintores.Location = new System.Drawing.Point(4, 39);
            this.Extintores.Name = "Extintores";
            this.Extintores.Padding = new System.Windows.Forms.Padding(3);
            this.Extintores.Size = new System.Drawing.Size(721, 249);
            this.Extintores.TabIndex = 3;
            this.Extintores.Text = "Extintores";
            this.Extintores.UseVisualStyleBackColor = true;
            // 
            // Seguro
            // 
            this.Seguro.Location = new System.Drawing.Point(4, 43);
            this.Seguro.Name = "Seguro";
            this.Seguro.Padding = new System.Windows.Forms.Padding(3);
            this.Seguro.Size = new System.Drawing.Size(721, 142);
            this.Seguro.TabIndex = 4;
            this.Seguro.Text = "Seguro";
            this.Seguro.UseVisualStyleBackColor = true;
            // 
            // Financiacion
            // 
            this.Financiacion.Location = new System.Drawing.Point(4, 43);
            this.Financiacion.Name = "Financiacion";
            this.Financiacion.Padding = new System.Windows.Forms.Padding(3);
            this.Financiacion.Size = new System.Drawing.Size(721, 142);
            this.Financiacion.TabIndex = 5;
            this.Financiacion.Text = "Financiacion";
            this.Financiacion.UseVisualStyleBackColor = true;
            // 
            // frmManVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 252);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManVehiculos";
            this.Text = "Mantenimiento de vehiculos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManVehiculos_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Datos.ResumeLayout(false);
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
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaMatriculacion;
        internal System.Windows.Forms.TextBox txtModelo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbTipoVehiculo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbTipoRuedas;
        internal System.Windows.Forms.TextBox txtMatricula;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtNumBastidor;
        internal System.Windows.Forms.TextBox txtMarca;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label12;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Datos;
        private System.Windows.Forms.TabPage Revisiones;
        private System.Windows.Forms.ImageList imagenesPaneles;
        private System.Windows.Forms.TabPage Mantenimiento;
        private System.Windows.Forms.TabPage Extintores;
        private System.Windows.Forms.TabPage Seguro;
        private System.Windows.Forms.TabPage Financiacion;
    }
}