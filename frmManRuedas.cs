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
    public partial class frmManRuedas : Form
    {
        int id_Key_rueda = 0;
        public frmManRuedas()
        {
            InitializeComponent();
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            //addItem();
        }

        public void recogerDatos(int _id_key_rueda)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_rueda != 0)
            {
                dt = clsSQL.devolverDataTable("select * from ruedas where id_Key_tipo_ruedas = " + _id_key_rueda.ToString());
                this.id_Key_rueda = _id_key_rueda;
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtDescripcion.Text = dr["descripcion"].ToString();
                    this.txtDimensiones.Text = dr["dimensiones"].ToString();
                    this.cmbProveedor.SelectedValue = dr["id_key_proveedor"].ToString();
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
