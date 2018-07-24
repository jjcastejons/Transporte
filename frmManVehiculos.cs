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
    public partial class frmManVehiculos : Form
    {
        int id_key_vehiculo = 0;
        public frmManVehiculos()
        {
            InitializeComponent();
            cargarCombos();
            tabControl1.TabPages["Datos"].ImageIndex = 0;
            tabControl1.TabPages["Revisiones"].ImageIndex = 2;
            tabControl1.TabPages["Extintores"].ImageIndex = 3;
            tabControl1.TabPages["Seguro"].ImageIndex = 1;

        }

        public void recogerDatos(int _id_key_vehiculo) {
            clsFunciones clsFunc = new clsFunciones();
            clsSQL clsSQL = new clsSQL();
            DataTable dt = new DataTable();
             
            if (_id_key_vehiculo != 0)
            {
                dt = clsSQL.devolverDataTable("select * from Vehiculos where id_key_vehiculo = " + _id_key_vehiculo.ToString());
                this.id_key_vehiculo = _id_key_vehiculo;
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtModelo.Text = dr["modelo"].ToString();
                    this.txtMarca.Text = dr["marca"].ToString();
                    this.txtNumBastidor.Text = dr["num_bastidor"].ToString();
                    this.txtMatricula.Text = dr["matricula"].ToString();
                    this.cmbTipoVehiculo.SelectedValue= dr["id_key_tipo_vehiculo"].ToString();
                    this.cmbTipoRuedas.SelectedValue = dr["id_key_tipo_ruedas"].ToString();
                    if (dr["vehiculo_activo"].ToString() == "1")
                    {
                        this.chkActivo.Checked = true;
                    }
                    else
                    {
                        this.chkActivo.Checked = false;
                    }
                    this.fechaMatriculacion.Value = DateTime.Parse(dr["fecha_matriculacion"].ToString());
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


        public void cargarCombos() {
            clsFunciones clsFunc = new clsFunciones();
            clsFunc.cargarCombos(cmbTipoVehiculo, "select id_key_tipo_vehiculo,tipo_vehiculo from tg_tipos_vehiculo","tipo_vehiculo","id_key_tipo_vehiculo",true);
            clsFunc.cargarCombos(cmbTipoRuedas, "select id_key_tipo_ruedas,descripcion from tg_tipos_ruedas", "descripcion", "id_key_tipo_ruedas", true);
        }


        private void btnAddTool_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void addItem()
        {
            clsFunciones clsFunc = new clsFunciones();
            String respuesta = String.Empty;
            clsSQL clsSQL = new clsSQL();
            int activo = 0;


            if (this.chkActivo.Checked == true) {
                activo = 1;
            }


            respuesta = clsSQL.ejecutarSP("SP_Man_Vehiculos", "@opcion=1=System.Int32",
                                                        "@id_key_vehiculo=0=System.Int32",
                                                        "@matricula=" + this.txtMatricula.Text.Trim() + "=System.String",
                                                        "@num_bastidor=" + this.txtNumBastidor.Text.Trim() + "=System.String",
                                                        "@id_key_tipo_vehiculo=" + this.cmbTipoVehiculo.SelectedValue + "=System.Int32",
                                                        "@marca=" + this.txtMarca.Text.Trim() + "=System.String",
                                                        "@modelo=" + this.txtModelo.Text.Trim() + "=System.String",
                                                        "@fecha_matriculacion=" + this.fechaMatriculacion.Value + "=System.Datetime",
                                                        "@id_key_tipo_ruedas=" + this.cmbTipoRuedas.SelectedValue + "=System.Int32",
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


        private void modificarItem() {
            clsFunciones clsFunc = new clsFunciones();
            String respuesta = String.Empty;
            clsSQL clsSQL = new clsSQL();
            int activo = 0;


            if (this.chkActivo.Checked == true)
            {
                activo = 1;
            }


            respuesta = clsSQL.ejecutarSP("SP_Man_Vehiculos", "@opcion=3=System.Int32",
                                                        "@id_key_vehiculo=" + this.id_key_vehiculo.ToString() + "=System.Int32",
                                                        "@matricula=" + this.txtMatricula.Text.Trim() + "=System.String",
                                                        "@num_bastidor=" + this.txtNumBastidor.Text.Trim() + "=System.String",
                                                        "@id_key_tipo_vehiculo=" + this.cmbTipoVehiculo.SelectedValue + "=System.Int32",
                                                        "@marca=" + this.txtMarca.Text.Trim() + "=System.String",
                                                        "@modelo=" + this.txtModelo.Text.Trim() + "=System.String",
                                                        "@fecha_matriculacion=" + this.fechaMatriculacion.Value + "=System.Datetime",
                                                        "@id_key_tipo_ruedas=" + this.cmbTipoRuedas.SelectedValue + "=System.Int32",
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

        private void nuevoItem() {
            this.txtMarca.Text = String.Empty;
            this.txtMatricula.Text = String.Empty;
            this.txtNumBastidor.Text = String.Empty;
            this.txtModelo.Text = String.Empty;
            this.cmbTipoRuedas.DataSource = null;
            this.cmbTipoVehiculo.DataSource = null;
            this.chkActivo.Checked = false;
            cargarCombos();
            this.id_key_vehiculo = 0;
            this.btnAddTool.Enabled = true;
            this.btnModificarTool.Enabled = false;
            this.btnEliminarTool.Enabled = false;
        }

        private void btnNuevoTool_Click(object sender, EventArgs e)
        {
            nuevoItem();
        }

        private void btnModificarTool_Click(object sender, EventArgs e)
        {
            modificarItem();
        }

        
        // Para controlar teclas acceso rapido F5,F6...
        private void frmManVehiculos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
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
