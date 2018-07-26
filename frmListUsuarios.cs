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
    public partial class frmListUsuarios : Form
    {
        public frmListUsuarios()
        {
            InitializeComponent();
        }

        private void grdUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdUsuarios.RowCount > 0)
            {
                frmManUsuarios formulario = new frmManUsuarios();
                formulario.recogerDatos(Convert.ToInt32(this.grdUsuarios.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
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
                String strSQL = "select * from Usuarios where";
                String txtWhere = String.Empty;

                this.grdUsuarios.DataSource = null;

                if (this.txtNombre.Text.Trim() != String.Empty)
                {
                    txtWhere = " nombre like '%" + txtNombre.Text + "%' and";
                }

                
                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select * from Usuarios";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere;

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdUsuarios.DataSource = ds.Tables[0];
                this.grdUsuarios.Columns[0].Visible = false;
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
            frmManUsuarios formulario = new frmManUsuarios();
            formulario.recogerDatos(0);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            Buscar();

        }
    }
}
