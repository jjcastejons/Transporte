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
    public partial class frmListCombustibles : Form
    {
        public frmListCombustibles()
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
                String strSQL = "select * from combustibles";
                String txtWhere = String.Empty;

                this.grdCombustibles.DataSource = null;

                
                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdCombustibles.DataSource = ds.Tables[0];
                this.grdCombustibles.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManCombustibles formulario = new frmManCombustibles();
            formulario.recogerDatos(0);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            Buscar();
        }

        private void grdCombustibles_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdCombustibles.RowCount > 0)
            {
                frmManCombustibles formulario = new frmManCombustibles();
                formulario.recogerDatos(Convert.ToInt32(this.grdCombustibles.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }


    }
}
