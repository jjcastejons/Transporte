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
    public partial class frmManArticulos : Form
    {
        int id_key_articulo = 0;
        public frmManArticulos()
        {
            InitializeComponent();
            cargarCombos();
        }

        private void cargarCombos()
        {
            clsFunciones clsFunc = new clsFunciones();
            //clsFunc.cargarCombos(cmbProveedor, "select id_Key_proveedor from proveedores", "proveedor", "id_key_proveedor", false);
        }

        private void frmManArticulos_Load(object sender, EventArgs e)
        {

        }

        public void recogerDatos(int _id_key_articulo)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_articulo != 0)
            {
                dt = clsSQL.devolverDataTable("select * from articulos where id_key_articulo = " + _id_key_articulo.ToString());
                this.id_key_articulo = _id_key_articulo;
                foreach (DataRow dr in dt.Rows)
                {
                    //this.txtDescripcion.Text = dr["descripcion"].ToString();
                    //this.cmbProveedor.SelectedValue = dr["id_key_proveedor"].ToString();
                }
                //this.btnNuevoTool.Enabled = true;
                this.btnAddTool.Enabled = false;
                this.btnModificarTool.Enabled = true;
                this.btnEliminarTool.Enabled = true;
            }
            else
            {
                //nuevoItem();
                //this.btnNuevoTool.Enabled = true;

            }
        }
    }
}
