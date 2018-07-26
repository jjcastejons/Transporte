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
    public partial class frmListArticulos : Form
    {
        public frmListArticulos()
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
                String strSQL = "select * from Articulos where";
                String txtWhere = String.Empty;

                this.grdArticulos.DataSource = null;

                if (this.txtNombre.Text.Trim() != String.Empty)
                {
                    txtWhere = " descripcion like '%" + txtNombre.Text + "%' and";
                }

                


                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select * from articulos";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere ;

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdArticulos.DataSource = ds.Tables[0];
                this.grdArticulos.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void grdArticulos_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdArticulos.RowCount > 0)
            {
                frmManArticulos formulario = new frmManArticulos();
                formulario.recogerDatos(Convert.ToInt32(this.grdArticulos.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManArticulos formulario = new frmManArticulos();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0);
            formulario.ShowDialog();
            Buscar();
        }
    }
}
