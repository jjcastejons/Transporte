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
    public partial class frmManFacturasCompra : Form
    {
        int id_key_factura_compra = 0;
        public frmManFacturasCompra()
        {
            InitializeComponent();
        }

        public void recogerDatos(int _id_key_factura_compra)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_factura_compra != 0)
            {
                dt = clsSQL.devolverDataTable("select * from facturas_compra where id_key_factura_compra = " + _id_key_factura_compra.ToString());
                this.id_key_factura_compra = _id_key_factura_compra;
                foreach (DataRow dr in dt.Rows)
                {
                    //Carga datos proveedor
                    //this.txtNombre.Text = dr["Nombre"].ToString();
                    //this.txtCIF.SelectedValue = dr["CIF"].ToString();
                }
                //this.btnNuevoTool.Enabled = true;
                this.btnAddTool.Enabled = false;
                this.btnModificarTool.Enabled = true;

            }
            else
            {
                //nuevoItem();
                //this.btnNuevoTool.Enabled = true;

            }
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            //addItem();
        }
    }
}
