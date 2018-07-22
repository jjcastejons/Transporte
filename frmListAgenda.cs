using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;


namespace Transportes
{
    public partial class frmListAgenda : Form
    {

        public frmListAgenda()
        {
            InitializeComponent();
            // Da formato al calendario
            this.calendarioAnual.SelectionStart=System.DateTime.Today;
            this.calendarioAnual.SelectionEnd = System.DateTime.Today;
            //this.calendarioAnual.d
        }




        private void calendarioAnual_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location.ToString());
            
        }

        //void DayRender(Object source, DayRenderEventArgs e)
        //{
        //    // Change the background color of the days in the month to Red.
        //    if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        //        e.Cell.BackColor = System.Drawing.Color.Red;
        //}


        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
        }

        private void cargaServicios(DateTime _fecha_desde,DateTime _fecha_hasta) {
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select id_key_servicio,fecha,hora,cliente,desde,hasta,conductor,vehiculo,menus,km,estado from v_Servicios where convert(date,fecha) between (convert(date,'" + _fecha_desde.ToShortDateString() + "')) and (convert(date,'" + _fecha_hasta.ToShortDateString() + "'))";
                String txtWhere = String.Empty;

                this.grdAgenda.DataSource = null;

                strSQL = strSQL + txtWhere + " order by hora";

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdAgenda.DataSource = ds.Tables[0];
                this.grdAgenda.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void calendarioAnual_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.lblServicios.Text = "Servicios el día " + e.Start.ToShortDateString();
            cargaServicios(e.Start, e.End);
        }

   

        private void grdAgenda_DoubleClick(object sender, EventArgs e)
        {
            frmManAgenda formulario = new frmManAgenda();
            formulario.recogerDatos(Convert.ToInt32(this.grdAgenda.CurrentRow.Cells[0].Value),this.calendarioAnual.SelectionStart);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            cargaServicios(this.calendarioAnual.SelectionStart, this.calendarioAnual.SelectionStart);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.lblServicios.Text = "Servicios desde " + fechaDesde.Value.ToShortDateString() + " hasta " + fechaHasta.Value.ToShortDateString();
            cargaServicios(fechaDesde.Value, fechaHasta.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmManAgenda formulario = new frmManAgenda();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0,this.calendarioAnual.SelectionStart);
            formulario.ShowDialog();
            cargaServicios(fechaDesde.Value, fechaHasta.Value);
        }
    }
}
