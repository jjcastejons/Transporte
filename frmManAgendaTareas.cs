using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportes
{
    public partial class frmManAgendaTareas : Form
    {
        int columna = 100000;
        int fila = 100000;
        public void recogerDatos() {
            cargaServicios();
           
        }

        private void cargaServicios() {
            clsFunciones clsFunc = new clsFunciones();
            // Hora            
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "PropHora";
            colHora.HeaderText = "HORA";
            colHora.Name = "Hora";
            //// Formato hora
            /////colHora.DefaultCellStyle.Format = "hh:mm";
            /////
            ////int time = Convert.ToInt32(row.Cells[1].Value);
            ////var timeSpan = TimeSpan.FromMinutes(time);
            ////int hh = timeSpan.Hours;
            ////int mm = timeSpan.Minutes;
            ////int ss = timeSpan.Seconds;
            ////string hours = hh.ToString().Length == 1 ? hh.ToString().PadLeft(2, '0') : hh.ToString();
            ////string minutes = mm.ToString().Length == 1 ? mm.ToString().PadLeft(2, '0') : mm.ToString();
            ////string seconds = ss.ToString().Length == 1 ? ss.ToString().PadLeft(2, '0') : ss.ToString();
            ////colHora.DefaultCellStyle.Format =
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHora.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAgenda.Columns.Add(colHora);
            uneColumnas();
            //grdAgenda.Rows[0]
            //grdAgenda.Columns["Hora"].DefaultCellStyle.Format= @"hh\:mm";
            ////grdAgenda.Columns[0].DefaultCellStyle.NullValue = "00:00:00";
            //// Cliente
            DataGridViewComboBoxColumn colCliente = new DataGridViewComboBoxColumn();
            colCliente.DataPropertyName = "PropCliente";
            colCliente.HeaderText = "CLIENTE";
            colCliente.Name = "Cliente";
            colCliente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCliente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grdAgenda.Columns.Add(colCliente);
            // Desde
            DataGridViewComboBoxColumn colDesde = new DataGridViewComboBoxColumn();
            colDesde.DataPropertyName = "PropDesde";
            colDesde.HeaderText = "DESDE";
            colDesde.Name = "Desde";
            colDesde.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDesde.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grdAgenda.Columns.Add(colDesde);
            // Hasta
            DataGridViewComboBoxColumn colHasta = new DataGridViewComboBoxColumn();
            colHasta.DataPropertyName = "PropHasta";
            colHasta.HeaderText = "HASTA";
            colHasta.Name = "Hasta";
            colHasta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHasta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grdAgenda.Columns.Add(colHasta);
            // Conductor
            DataGridViewComboBoxColumn colConductor = new DataGridViewComboBoxColumn();
            colConductor.DataPropertyName = "PropConductor";
            colConductor.HeaderText = "CONDUCTOR";
            colConductor.Name = "Conductor";
            colConductor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colConductor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grdAgenda.Columns.Add(colConductor);
            // Vehiculo
            DataGridViewComboBoxColumn colVehiculo = new DataGridViewComboBoxColumn();
            colVehiculo.DataPropertyName = "PropVehiculo";
            colVehiculo.HeaderText = "VEHICULO";
            colVehiculo.Name = "Vehiculo";
            colVehiculo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colVehiculo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdAgenda.Columns.Add(colVehiculo);



            grdAgenda.Rows.Add();
            grdAgenda.Rows.Add();
            grdAgenda.Rows.Add();
        }

        public frmManAgendaTareas()
        {
            InitializeComponent();
            //dtPicker.Format = DateTimePickerFormat.Time;
            //dtPicker.ShowUpDown = true;
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {

        }

        private void uneColumnas() {

            this.grdAgenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grdAgenda.ColumnHeadersHeight = this.grdAgenda.ColumnHeadersHeight * 2;
            this.grdAgenda.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.grdAgenda.CellPainting += new DataGridViewCellPaintingEventHandler(grdAgenda_CellPainting);
            this.grdAgenda.Paint += new PaintEventHandler(grdAgenda_Paint);
            this.grdAgenda.Scroll += new ScrollEventHandler(grdAgenda_Scroll);
            this.grdAgenda.ColumnWidthChanged += new DataGridViewColumnEventHandler(grdAgenda_ColumnWidthChanged);
        }
            
        



        private void grdAgenda_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void grdAgenda_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.grdAgenda.DisplayRectangle;
            rtHeader.Height = this.grdAgenda.ColumnHeadersHeight / 2;
            this.grdAgenda.Invalidate(rtHeader);
        }

        private void grdAgenda_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.grdAgenda.DisplayRectangle;
            rtHeader.Height = this.grdAgenda.ColumnHeadersHeight / 2;
            this.grdAgenda.Invalidate(rtHeader);
        }

        private void grdAgenda_Paint(object sender, PaintEventArgs e)
        {
            string[] monthes = { "Emp Info", "", "", "", "" };
            for (int j = 0; j < 10;)
            {
                Rectangle r1 = this.grdAgenda.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.grdAgenda.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.grdAgenda.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j / 2],
                this.grdAgenda.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.grdAgenda.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 2;
            }
        }
    }
}
