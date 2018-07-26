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
    public partial class frmListProveedores : Form
    {
        public frmListProveedores()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select * from proveedores where";
                String txtWhere = String.Empty;

                this.grdProveedores.DataSource = null;

                if (this.txtNombre.Text.Trim() != String.Empty)
                {
                    txtWhere = " nombre like '%" + txtNombre.Text + "%' and";
                }

                if (this.txtCIF.Text.Trim() != String.Empty)
                {
                    txtWhere = " CIF like '%" + txtNombre.Text + "%' and";
                }



                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select * from proveedores";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere;

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdProveedores.DataSource = ds.Tables[0];
                this.grdProveedores.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManProveedores formulario = new frmManProveedores();
            formulario.recogerDatos(0);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            Buscar();
        }

        private void grdProveedores_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdProveedores.RowCount > 0)
            {
                frmManProveedores formulario = new frmManProveedores();
                formulario.recogerDatos(Convert.ToInt32(this.grdProveedores.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }
    }
}
