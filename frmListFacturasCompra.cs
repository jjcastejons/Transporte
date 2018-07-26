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
    public partial class frmListFacturasCompra : Form
    {
        public frmListFacturasCompra()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select * from v_facturas_compra where";
                String txtWhere = String.Empty;

                this.grdFacturasCompra.DataSource = null;

                if (this.txtNumFactura.Text.Trim() != String.Empty)
                {
                    txtWhere = " num_factura like '%" + txtNumFactura.Text + "%' and";
                }

                if (this.txtProveedor.Text.Trim() != String.Empty)
                {
                    txtWhere = " nombre_proveedor like '%" + txtProveedor.Text + "%' and";
                }



                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select * from v_facturas_compra";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere;

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdFacturasCompra.DataSource = ds.Tables[0];
                this.grdFacturasCompra.Columns[0].Visible = false;
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

        private void grdFacturasCompra_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdFacturasCompra.RowCount > 0)
            {
                frmManFacturasCompra formulario = new frmManFacturasCompra();
                formulario.recogerDatos(Convert.ToInt32(this.grdFacturasCompra.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManFacturasCompra formulario = new frmManFacturasCompra();
            formulario.recogerDatos(0);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            Buscar();
        }
    }
}
