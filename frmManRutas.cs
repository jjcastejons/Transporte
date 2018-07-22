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
    public partial class frmManRutas : Form
    {
        int id_key_ruta = 0;
        public frmManRutas()
        {
            InitializeComponent();
        }
        public void recogerDatos(int _id_key_ruta)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_ruta != 0)
            {
                dt = clsSQL.devolverDataTable("select * from Rutas where id_key_ruta = " + _id_key_ruta.ToString());
                this.id_key_ruta = _id_key_ruta;
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtDescripcion.Text = dr["descripcion"].ToString();
                    this.txtOrigen.Text = dr["origen"].ToString();
                    this.txtDestino.Text = dr["destino"].ToString();
                    this.txtKm.Text = dr["destino"].ToString();
                    this.txtPrecio.Text = dr["precio"].ToString();
                    this.txtPeajes.Text = dr["peajes"].ToString();
                    if (dr["ruta_activa"].ToString() == "1")
                    {
                        this.chkActivo.Checked = true;
                    }
                    else
                    {
                        this.chkActivo.Checked = false;
                    }
                }
                //this.btnNuevoTool.Enabled = true;
                this.btnAddTool.Enabled = false;
                this.btnModificarTool.Enabled = true;
                this.btnEliminarTool.Enabled = true;
            }
            else
            {
                nuevoItem();
                //this.btnNuevoTool.Enabled = true;

            }


        }
        private void addItem()
        {
            clsFunciones clsFunc = new clsFunciones();
            String respuesta = String.Empty;
            clsSQL clsSQL = new clsSQL();
            int activo = 0;


            if (this.chkActivo.Checked == true)
            {
                activo = 1;
            }


            respuesta = clsSQL.ejecutarSP("SP_Man_Rutas", "@opcion=1=System.Int32",
                                                        "@id_key_ruta=0=System.Int32",
                                                        "@origen=" + this.txtOrigen.Text.Trim() + "=System.String",
                                                        "@destino=" + this.txtDestino.Text.Trim() + "=System.String",
                                                        "@km=" + this.txtKm.Text.Trim() + "=System.Int32",
                                                        "@precio=" + this.txtPrecio.Text.Trim() + "=System.String",
                                                        "@peajes=" + this.txtPeajes.Text.Trim() + "=System.String",
                                                        "@vehiculo_activo=" + activo.ToString() + "=System.Int32");
            if (respuesta != "OK")
            {
                MessageBox.Show("Error al crear el registro.", mdPrincipal.Error_SQL, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Registro añadido correctamente.");
            }

            this.Close();
        }

        private void modificarItem()
        {
            clsFunciones clsFunc = new clsFunciones();
            String respuesta = String.Empty;
            clsSQL clsSQL = new clsSQL();
            int activo = 0;


            if (this.chkActivo.Checked == true)
            {
                activo = 1;
            }


            respuesta = clsSQL.ejecutarSP("SP_Man_Rutas", "@opcion=3=System.Int32",
                                                        "@id_key_ruta=" + this.id_key_ruta.ToString() + "=System.Int32",
                                                        "@origen=" + this.txtOrigen.Text.Trim() + "=System.String",
                                                        "@destino=" + this.txtDestino.Text.Trim() + "=System.String",
                                                        "@km=" + this.txtKm.Text.Trim() + "=System.Int32",
                                                        "@peajes=" + this.txtPeajes.Text.Trim() + "=System.String",
                                                        "@precios=" + this.txtPrecio.Text.Trim() + "=System.String",
                                                        "@vehiculo_activo=" + activo.ToString() + "=System.Int32");
            if (respuesta != "OK")
            {
                MessageBox.Show("Error al modificar el registro.", mdPrincipal.Error_SQL, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Registro modificado correctamente.");
            }

            this.Close();

        }
        private void nuevoItem()
        {
            this.txtOrigen.Text = String.Empty;
            this.txtDestino.Text = String.Empty;
            this.txtPrecio.Text = String.Empty;
            this.txtKm.Text = String.Empty;
            this.txtPeajes.Text = null;
            this.chkActivo.Checked = false;
            this.id_key_ruta = 0;
            this.btnAddTool.Enabled = true;
            this.btnModificarTool.Enabled = false;
            this.btnEliminarTool.Enabled = false;
        }
        private void btnAddTool_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarTool_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoTool_Click(object sender, EventArgs e)
        {
            nuevoItem();
        }

        private void btnAddTool_Click_1(object sender, EventArgs e)
        {
            addItem();
        }

        private void btnModificarTool_Click_1(object sender, EventArgs e)
        {
            modificarItem();
        }

        private void btnEliminarTool_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarTool_Click(object sender, EventArgs e)
        {

        }

        private void ToolStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Escape:
                    this.Close();
                    break;
                case System.Windows.Forms.Keys.F5:
                    this.nuevoItem();
                    break;
                case System.Windows.Forms.Keys.F6:
                    this.addItem();
                    break;
                case System.Windows.Forms.Keys.F7:
                    this.modificarItem();
                    break;
                case System.Windows.Forms.Keys.F8:
                    //this.eliminarItem();
                    break;
                default:
                    break;

            }

        }
    }
}
