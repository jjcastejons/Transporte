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
    public partial class frmManAgenda : Form
    {
        int id_key_servicio = 0;
        public void recogerDatos(int _id_key_servicio,DateTime _fecha)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();
            Fecha.Value = _fecha;
            

            if (_id_key_servicio != 0)
            {
                dt = clsSQL.devolverDataTable("select * from v_servicios where id_key_servicio = " + _id_key_servicio.ToString());
                this.id_key_servicio = _id_key_servicio;
                foreach (DataRow dr in dt.Rows)
                {
                    this.Hora.Value= Convert.ToDateTime(dr["Hora"].ToString());
                    this.cmbClientes.SelectedValue= dr["id_key_cliente"].ToString();
                    //this.txtCIF.Text = dr["CIF"].ToString();
                    //this.txtNombre.Text = dr["Nombre"].ToString();
                    //this.txtDireccion.Text = dr["Direccion_fiscal"].ToString();
                    ////this.cmbProvincias.SelectedValue = dr["Provincia_fiscal"].ToString();
                    ////this.txtLocalidad.Text = dr["Localidad_fiscal"].ToString();
                    //this.txtTelefono.Text = dr["Telefono"].ToString();
                    //this.txtEmail.Text = dr["Email"].ToString();
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

        private void nuevoItem() {
        }


        private void addItem()
        {
            clsFunciones clsFunc = new clsFunciones();
            String respuesta = String.Empty;
            clsSQL clsSQL = new clsSQL();
      
            respuesta = clsSQL.ejecutarSP("SP_Man_Servicios", "@opcion=1=System.Int32",
                                                        "@id_key_servicio=0=System.Int32",
                                                        "@fecha=" + this.Fecha.Value + "=System.Datetime",
                                                        "@hora=" + this.Hora.Value + "=System.Datetime",
                                                        "@id_Key_cliente=" + this.cmbClientes.SelectedValue + "=System.Int32",
                                                        "@id_key_origen=" + this.cmbDesde.SelectedValue + "=System.Int32",
                                                        "@id_key_destino=" + this.cmbHasta.SelectedValue + "=System.Int32",
                                                        "@id_key_empleado=" + this.cmbConductor.SelectedValue + "=System.Int32",
                                                        "@id_key_vehiculo=" + this.cmbVehiculos.SelectedValue + "=System.Int32",
                                                        "@Menus=" + this.txtMenus.Text.Trim() + "=System.Decimal",
                                                        "@Km=" + this.txtKm.Text.Trim() + "=System.Decimal",
                                                        "@id_key_estado=" + this.cmbEstado.SelectedIndex + "=System.Int32",
                                                        "@notas=" + this.txtNotas.Text.Trim() + "=System.String");
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

        public frmManAgenda()
        {
            InitializeComponent();
            cargarCombos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmManClientes formulario = new frmManClientes();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0);
            formulario.ShowDialog();
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            addItem();
        }


        private void cargarCombos() {
            clsFunciones clsFunc = new clsFunciones();
            clsFunc.cargarCombos(cmbClientes, "select nombre,id_key_cliente from Clientes", "nombre", "id_key_cliente", true);
            clsFunc.cargarCombos(cmbDesde, "select ubicacion,id_key_origen_destino from tg_origen_destino where origen_destino=0", "ubicacion", "id_key_origen_destino", true);
            clsFunc.cargarCombos(cmbHasta, "select ubicacion,id_key_origen_destino from tg_origen_destino where origen_destino=1", "ubicacion", "id_key_origen_destino", true);
            clsFunc.cargarCombos(cmbConductor, "select (nombre + apellido1) as nombre,id_key_empleado from Empleados", "nombre", "id_key_empleado", true);
            clsFunc.cargarCombos(cmbVehiculos, "select matricula,id_key_vehiculo from Vehiculos", "matricula", "id_key_vehiculo", true);
        }
    }
}
