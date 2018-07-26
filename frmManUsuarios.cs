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
    public partial class frmManUsuarios : Form
    {
        int id_key_usuario = 0;
        public frmManUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevoTool_Click(object sender, EventArgs e)
        {

        }

        public void recogerDatos(int _id_key_usuario)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_usuario != 0)
            {
                dt = clsSQL.devolverDataTable("select * from usuarios where id_key_usuario = " + _id_key_usuario.ToString());
                this.id_key_usuario = _id_key_usuario;
                foreach (DataRow dr in dt.Rows)
                {
                    //this.txtNombre.Text = dr["nombre"].ToString();
                    //this.txtPassword.Text = dr["password"].ToString();
                    //cargaPermisos();
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
