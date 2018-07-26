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
    public partial class frmManEmpleados : Form
    {
        int id_key_empleado = 0;



        public frmManEmpleados()
        {
            InitializeComponent();
            cargarCombos();
        }


        public void recogerDatos(int _id_key_empleado)
        {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();

            if (_id_key_empleado != 0)
            {
                dt = clsSQL.devolverDataTable("select * from Empleados where id_key_empleado = " + _id_key_empleado.ToString());
                this.id_key_empleado = _id_key_empleado;
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtNombre.Text = dr["nombre"].ToString();
                    this.txtApellido1.Text = dr["apellido1"].ToString();
                    this.txtApellido2.Text = dr["apellido2"].ToString();
                    this.txtNIF.Text = dr["NIF"].ToString();
                    this.txtNumSS.Text = dr["num_SS"].ToString();
                    this.cmbPuesto.SelectedValue = dr["id_key_puesto"].ToString();
                    this.cmbDepartamento.SelectedValue = dr["id_key_departamento"].ToString();
                    if (dr["activo"].ToString() == "1")
                    {
                        this.chkActivo.Checked = true;
                        this.fechaBaja.Enabled = false;
                    }
                    else
                    {
                        this.chkActivo.Checked = false;
                        this.fechaBaja.Value = DateTime.Parse(dr["fecha_baja"].ToString());
                    }
                    this.fechaAlta.Value = DateTime.Parse(dr["fecha_alta"].ToString());
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



        private void cargarCombos()
        {
            clsFunciones clsFunc = new clsFunciones();
            clsFunc.cargarCombos(cmbDepartamento, "select id_key_departamento,departamento from tg_departamento order by departamento", "departamento", "id_key_departamento", false);
            clsFunc.cargarCombos(cmbPuesto, "select id_key_puesto,puesto from tg_puesto order by puesto", "puesto", "id_key_puesto", false);
        }



        //****************************************************
        // INICIO METODOS PPALES ALTA, BAJA, MODIFICACION ****
        //****************************************************
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

            respuesta = clsSQL.ejecutarSP("SP_Man_Empleados", "@opcion=1=System.Int32",
                                                        "@id_key_empleado=0=System.Int32",
                                                        "@NIF=" + this.txtNIF.Text.Trim() + "=System.String",
                                                        "@nombre=" + this.txtNombre.Text.Trim() + "=System.String",
                                                        "@apellido1=" + this.txtApellido1.Text.Trim() + "=System.String",
                                                        "@apellido2=" + this.txtApellido2.Text.Trim() + "=System.String",
                                                        "@num_SS=" + this.txtNumSS.Text.Trim() + "=System.String",
                                                        "@fecha_alta=" + this.fechaAlta.Value + "=System.Datetime",
                                                        "@fecha_baja=" + fechaBaja.Value + "=System.Datetime",
                                                        "@id_key_departamento=" + this.cmbDepartamento.SelectedValue + "=System.Int32",
                                                        "@id_key_puesto=" + this.cmbPuesto.SelectedValue + "=System.Int32",
                                                        "@activo=" + activo.ToString() + "=System.Int32");
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

            respuesta = clsSQL.ejecutarSP("SP_Man_Empleados", "@opcion=3=System.Int32",
                                                        "@id_key_empleado=" + this.id_key_empleado.ToString() + "=System.Int32",
                                                       "@NIF=" + this.txtNIF.Text.Trim() + "=System.String",
                                                        "@nombre=" + this.txtNombre.Text.Trim() + "=System.String",
                                                        "@apellido1=" + this.txtApellido1.Text.Trim() + "=System.String",
                                                        "@apellido2=" + this.txtApellido2.Text.Trim() + "=System.String",
                                                        "@num_SS=" + this.txtNumSS.Text.Trim() + "=System.String",
                                                        "@fecha_alta=" + this.fechaAlta.Value + "=System.Datetime",
                                                        "@fecha_baja=" + fechaBaja.Value + "=System.Datetime",
                                                        "@id_key_departamento=" + this.cmbDepartamento.SelectedValue + "=System.Int32",
                                                        "@id_key_puesto=" + this.cmbPuesto.SelectedValue + "=System.Int32",
                                                        "@activo=" + activo.ToString() + "=System.Int32");
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


        //*************************************************
        // FIN METODOS PPALES ALTA, BAJA, MODIFICACION ****
        //*************************************************

        private void nuevoItem()
        {
            this.txtNombre.Text = String.Empty;
            this.txtApellido1.Text = String.Empty;
            this.txtApellido2.Text = String.Empty;
            this.txtNIF.Text = String.Empty;
            this.txtNumSS.Text = String.Empty;
            this.cmbDepartamento.DataSource = null;
            this.cmbPuesto.DataSource = null;
            this.chkActivo.Checked = false;
            cargarCombos();
            this.id_key_empleado = 0;
            this.btnAddTool.Enabled = true;
            this.btnModificarTool.Enabled = false;
            this.btnEliminarTool.Enabled = false;
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void btnNuevoTool_Click(object sender, EventArgs e)
        {
            nuevoItem();
        }

        private void btnModificarTool_Click(object sender, EventArgs e)
        {
            modificarItem();
        }

        private void btnEliminarTool_Click(object sender, EventArgs e)
        {
            //eliminarItem();
        }

        private void btnCancelarTool_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Activar desactivar usuario
        }
    }
}
