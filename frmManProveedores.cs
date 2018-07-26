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
    public partial class frmManProveedores : Form
    {
        int id_key_proveedor = 0;
        public frmManProveedores()
        {
            InitializeComponent();
        }


        public void recogerDatos(int _id_key_proveedor)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_proveedor != 0)
            {
                dt = clsSQL.devolverDataTable("select * from proveedores where id_key_proveedor = " + _id_key_proveedor.ToString());
                this.id_key_proveedor = _id_key_proveedor;
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

        private void btnModificarTool_Click(object sender, EventArgs e)
        {
            //modificarItem();
        }

        private void btnNuevoTool_Click(object sender, EventArgs e)
        {
            //nuevoItem();
        }
    }
}
