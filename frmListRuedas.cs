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
    public partial class frmListRuedas : Form
    {
        public frmListRuedas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select * from Ruedas";
                String txtWhere = String.Empty;

                this.grdRuedas.DataSource = null;

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdRuedas.DataSource = ds.Tables[0];
                this.grdRuedas.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void grdRuedas_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdRuedas.RowCount > 0)
            {
                frmManRuedas formulario = new frmManRuedas();
                formulario.recogerDatos(Convert.ToInt32(this.grdRuedas.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManRuedas formulario = new frmManRuedas();
            formulario.recogerDatos(0);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            Buscar();
        }
    }
}
