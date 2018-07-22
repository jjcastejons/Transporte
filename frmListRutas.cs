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
    public partial class frmListRutas : Form
    {
        public frmListRutas()
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
            String strSQL = "select id_key_ruta,Descripcion,origen,destino,km,precio,peajes from Rutas where";
            String txtWhere = String.Empty;

            this.grdRutas.DataSource = null;

            if (this.txtDescripcion.Text.Trim() != String.Empty)
            {
                txtWhere = " descripcion like '%" + txtDescripcion.Text + "%' and";
            }

            if (this.txtOrigen.Text.Trim() != String.Empty)
            {
                txtWhere = txtWhere + " origen like '%" + txtOrigen.Text + "%' and";
            }
            if (this.txtDestino.Text.Trim() != String.Empty)
            {
                txtWhere = txtWhere + " destino like '%" + txtDestino.Text + "%' and";
            }

           
            if (txtWhere.Trim() == String.Empty)
            {
                strSQL = "select id_key_ruta,origen,destino,km,precio,peajes from Rutas";
            }

            if (txtWhere.Trim().EndsWith("and"))
            {
                txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
            }

            strSQL = strSQL + txtWhere + " order by descripcion";

            ds = Consulta.devolverDataSetSelect(strSQL);

            this.grdRutas.DataSource = ds.Tables[0];
            this.grdRutas.Columns[0].Visible = false;
            //this.grdVehiculos.Columns[0].Visible = false;
            ds.Dispose();
        }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}
private void btnNuevo_Click(object sender, EventArgs e)
        {
            //frmManRutas formulario = new frmRutas();
            //formulario.StartPosition = FormStartPosition.CenterScreen;
            //formulario.recogerDatos(0);
            //formulario.ShowDialog();
            //Buscar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdRutas_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdRutas.RowCount > 0)
            {
                //frmManRutas formulario = new frmRutas();
                //formulario.recogerDatos(Convert.ToInt32(this.grdVehiculos.CurrentRow.Cells[0].Value));
                //formulario.StartPosition = FormStartPosition.CenterScreen;
                //formulario.ShowDialog();
                //Buscar();
            }
        }
    }
}
