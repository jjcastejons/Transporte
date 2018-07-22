using System;
using System.Data.Linq;
using System.Data;
using System.Windows.Forms;


namespace Transportes
{
    public partial class frmManClientes : Form
    {
        int id_key_cliente = 0;
        public frmManClientes()
        {
            InitializeComponent();
            CargarCombos();

        }

        public void recogerDatos(int _id_key_cliente)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_cliente != 0)
            {
                dt = clsSQL.devolverDataTable("select * from Clientes where id_key_cliente = " + _id_key_cliente.ToString());
                this.id_key_cliente = _id_key_cliente;
                
                


                foreach (DataRow dr in dt.Rows)
                {
                    id_key_cliente = dr.Field<int>("id_key_cliente");
                    this.txtCIF.Text = dr.Field<string>("CIF");
                    this.txtNombre.Text = dr.Field<string>("Nombre");
                    this.txtDireccion.Text = dr["Direccion_fiscal"].ToString();
                    //this.cmbProvincias.SelectedValue = dr["Provincia_fiscal"].ToString();
                    //this.txtLocalidad.Text = dr["Localidad_fiscal"].ToString();
                    this.txtTelefono.Text = dr["Telefono"].ToString();
                    this.txtEmail.Text = dr["Email"].ToString();
                    //if (dr["vehiculo_activo"].ToString() == "1")
                    //{
                    //    this.chkActivo.Checked = true;
                    //}
                    //else
                    //{
                    //    this.chkActivo.Checked = false;
                    //}

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
        public void CargarCombos()
        {
            clsFunciones clsFunc = new clsFunciones();
            clsFunc.cargarCombos(cmbProvincias, "select id_key_provincia,provincia from tg_provincias", "provincia", "id_key_provincia", true);
        }
        private void nuevoItem()
        {
            this.txtCIF.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.cmbProvincias.DataSource = null;
            this.txtLocalidad.Text = null;
            this.txtTelefono.Text = null;
            this.txtEmail.Text = null;
            this.chkActivo.Checked = false;
            CargarCombos();
            this.id_key_cliente = 0;
            this.btnAddTool.Enabled = true;
            this.btnModificarTool.Enabled = false;
            this.btnEliminarTool.Enabled = false;

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

            


            respuesta = clsSQL.ejecutarSP("SP_Man_Clientes", "@opcion=1=System.Int32",
                                                        "@id_key_cliente=0=System.Int32",
                                                        "@CIF=" + this.txtCIF.Text.Trim() + "=System.String",
                                                        "@Nombre=" + this.txtNombre.Text.Trim() + "=System.String",
                                                        "@Direccion_fiscal=" + this.txtDireccion.Text.Trim() + "=System.String",
                                                        "@id_key_provincia_fiscal=" + this.cmbProvincias.SelectedValue + "=System.Int32",
                                                        "@pais_fiscal=spain=System.String",
                                                        "@CP_fiscal=0=System.Int32",
                                                        "@Direccion_postal=" + this.txtDireccion.Text.Trim() + "=System.String",
                                                        "@id_key_provincia_postal=" + this.cmbProvincias.SelectedValue + "=System.Int32",
                                                        "@pais_postal=spain=System.String",
                                                        "@CP_postal=0=System.Int32",
                                                        "@Telefono=" + this.txtTelefono.Text.Trim() + "=System.String",
                                                        "@Fax=" + this.txtTelefono.Text.Trim() + "=System.String",
                                                        "@Email=" + this.txtEmail.Text.Trim() + "=System.String",
                                                        "@web=" + this.txtEmail.Text.Trim() + "=System.String",
                                                        "@notas=" + this.txtEmail.Text.Trim() + "=System.String");
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


            respuesta = clsSQL.ejecutarSP("SP_Man_Clientes", "@opcion=1=System.Int32",
                                                        "@id_key_cliente=0=System.Int32",
                                                        "@CIF=" + this.txtCIF.Text.Trim() + "=System.String",
                                                        "@Nombre=" + this.txtNombre.Text.Trim() + "=System.String",
                                                        "@Direccion_fiscal=" + this.txtDireccion.Text.Trim() + "=System.Int32",
                                                        "@Provincia_fiscal=" + this.cmbProvincias.SelectedValue + "=System.String",
                                                        "@Localidad_fiscal=" + this.txtLocalidad.Text.Trim() + "=System.String",
                                                        "@pais_fiscal=spain=System.String",
                                                        "@CP_fiscal=0=System.Int32",
                                                        "@Direccion_postal=" + this.txtDireccion.Text.Trim() + "=System.String",
                                                        "@id_key_provincia_postal=" + this.cmbProvincias.SelectedValue + "=System.Int32",
                                                        "@pais_postal=spain=System.String",
                                                        "@CP_postal=0=System.Int32",
                                                        "@Telefono=" + this.txtTelefono.Text.Trim() + "=System.Datetime",
                                                        "@Email=" + this.txtEmail.Text.Trim() + "=System.Int32",
                                                        "@cliente_activo=" + activo.ToString() + "=System.Int32");
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
        private void btnNuevoTool_Click(object sender, EventArgs e)
        {
            nuevoItem();
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void btnModificarTool_Click(object sender, EventArgs e)
        {
            modificarItem();
        }

        private void btnEliminarTool_Click(object sender, EventArgs e)
        {
            // eliminarItem();
        }

        private void btnCancelarTool_Click(object sender, EventArgs e)
        {

        }

        private void frmManClientes_KeyDown(object sender, KeyEventArgs e)
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
