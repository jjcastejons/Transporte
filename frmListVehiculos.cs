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
    public partial class frmListVehiculos : Form
    {
        public frmListVehiculos()
        {
            InitializeComponent();
        }

       
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar() {
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select id_key_vehiculo,(marca + ' ' + modelo) as Marca,Matricula,num_bastidor as Numero_bastidor from Vehiculos where";
                String txtWhere = String.Empty;

                this.grdVehiculos.DataSource = null;

                if (this.txtMatricula.Text.Trim() != String.Empty)
                {
                    txtWhere = " matricula like '%" + txtMatricula.Text + "%' and";
                }

                if (this.txtNumBastidor.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " num_bastidor like '%" + txtNumBastidor.Text + "%' and";
                }

                if (this.txtMarca.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " marca like '%" + txtMarca.Text + "%' and";
                }


                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select id_key_vehiculo,(marca + ' ' + modelo) as Marca,matricula,num_bastidor as Numero_bastidor from Vehiculos";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere + " order by matricula";

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdVehiculos.DataSource = ds.Tables[0];
                this.grdVehiculos.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManVehiculos formulario = new frmManVehiculos();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0);
            formulario.ShowDialog();
            Buscar();
        }

        private void grdVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        if (this.grdVehiculos.RowCount > 0) {
                frmManVehiculos formulario = new frmManVehiculos();
                formulario.recogerDatos(Convert.ToInt32(this.grdVehiculos.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Buscar();
            }
        }

    }
}
