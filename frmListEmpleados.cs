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
    public partial class frmListEmpleados : Form
    {
        public frmListEmpleados()
        {
            InitializeComponent();
            cargarCombos();
        }

        private void cargarCombos() {
            clsFunciones clsFunc = new clsFunciones();
            clsFunc.cargarCombos(cmbDepartamento,"select id_key_departamento,departamento from tg_departamento order by departamento","departamento","id_key_departamento",false);
            clsFunc.cargarCombos(cmbPuesto, "select id_key_puesto,puesto from tg_puesto order by puesto", "puesto", "id_key_puesto", false);
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
                String strSQL = "select id_key_empleado,NIF,Nombre,Apellido1,Apellido2,Departamento,Puesto from v_Empleados where";
                String txtWhere = String.Empty;

                this.grdEmpleados.DataSource = null;

                if (this.txtNombre.Text.Trim() != String.Empty)
                {
                    txtWhere = " nombre like '%" + txtNombre.Text + "%' and";
                }

                if (this.txtApellido1.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " apellido1 like '%" + txtApellido1.Text + "%' and";
                }
                if (this.txtApellido2.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " apellido2 like '%" + txtApellido2.Text + "%' and";
                }
                if (this.txtNIF.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " NIF like '%" + txtNIF.Text + "%' and";
                }
                if (this.cmbPuesto.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " id_key_puesto like '%" + cmbPuesto.SelectedValue.ToString() + "%' and";
                }
                if (this.cmbDepartamento.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " id_key_departamento like '%" + cmbDepartamento.SelectedValue.ToString() + "%' and";
                }



                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select id_key_empleado,NIF,Nombre,Apellido1,Apellido2,Departamento,Puesto from v_Empleados";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere + " order by NIF";

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdEmpleados.DataSource = ds.Tables[0];
                this.grdEmpleados.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void grdEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdEmpleados.RowCount > 0)
            {
                frmManEmpleados formulario = new frmManEmpleados();
                formulario.recogerDatos(Convert.ToInt32(this.grdEmpleados.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManEmpleados formulario = new frmManEmpleados();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0);
            formulario.ShowDialog();
            Buscar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
