namespace Transportes
{
    partial class frmListAgenda
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendarioAnual = new System.Windows.Forms.MonthCalendar();
            this.grdAgenda = new System.Windows.Forms.DataGridView();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calendarioAnual);
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 590);
            this.panel1.TabIndex = 0;
            // 
            // calendarioAnual
            // 
            this.calendarioAnual.AnnuallyBoldedDates = new System.DateTime[] {
        new System.DateTime(2017, 7, 1, 0, 0, 0, 0)};
            this.calendarioAnual.BackColor = System.Drawing.SystemColors.Control;
            this.calendarioAnual.CalendarDimensions = new System.Drawing.Size(2, 3);
            this.calendarioAnual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarioAnual.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calendarioAnual.Location = new System.Drawing.Point(0, 0);
            this.calendarioAnual.MaxSelectionCount = 1;
            this.calendarioAnual.Name = "calendarioAnual";
            this.calendarioAnual.TabIndex = 0;
            this.calendarioAnual.TitleBackColor = System.Drawing.SystemColors.Highlight;
            this.calendarioAnual.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendarioAnual_DateChanged);
            this.calendarioAnual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.calendarioAnual_MouseDown);
            // 
            // grdAgenda
            // 
            this.grdAgenda.AllowUserToAddRows = false;
            this.grdAgenda.AllowUserToDeleteRows = false;
            this.grdAgenda.AllowUserToResizeRows = false;
            this.grdAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAgenda.Location = new System.Drawing.Point(511, 69);
            this.grdAgenda.MultiSelect = false;
            this.grdAgenda.Name = "grdAgenda";
            this.grdAgenda.ReadOnly = true;
            this.grdAgenda.RowHeadersVisible = false;
            this.grdAgenda.Size = new System.Drawing.Size(619, 560);
            this.grdAgenda.TabIndex = 55;
            this.grdAgenda.DoubleClick += new System.EventHandler(this.grdAgenda_DoubleClick);
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(52, 12);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.fechaDesde.TabIndex = 56;
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(307, 11);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(200, 20);
            this.fechaHasta.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(265, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Hasta";
            // 
            // lblServicios
            // 
            this.lblServicios.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblServicios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.Location = new System.Drawing.Point(513, 39);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(607, 24);
            this.lblServicios.TabIndex = 60;
            this.lblServicios.Text = "Servicios Julio 2017";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::Transportes.Properties.Resources.add;
            this.btnAddItem.Location = new System.Drawing.Point(548, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(29, 26);
            this.btnAddItem.TabIndex = 102;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Transportes.Properties.Resources.document_view1;
            this.btnBuscar.Location = new System.Drawing.Point(513, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 26);
            this.btnBuscar.TabIndex = 101;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmListAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Transportes.Properties.Resources.Fondo_Agenda;
            this.ClientSize = new System.Drawing.Size(1132, 632);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblServicios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.fechaDesde);
            this.Controls.Add(this.grdAgenda);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListAgenda";
            this.Text = "AGENDA";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar calendarioAnual;
        private System.Windows.Forms.DataGridView grdAgenda;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAddItem;
    }
}