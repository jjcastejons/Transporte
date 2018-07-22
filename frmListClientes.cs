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
    public partial class frmListClientes : Form
    {
        public frmListClientes()
        {
            InitializeComponent();
        }

        private void Busqueda (){
            try
            {
                clsSQL Consulta = new clsSQL();
                DataSet ds;
                String strSQL = "select id_key_cliente,Nombre,id_key_Provincia_fiscal, Direccion_fiscal, CP_fiscal from Clientes where";
                String txtWhere = String.Empty;



                this.grdClientes.DataSource = null;

                if (this.txtCIF.Text.Trim() != String.Empty)
                {
                    txtWhere = " CIF like '%" + txtCIF.Text + "%' and";
                }

                if (this.txtNombre.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " Nombre like '%" + txtNombre.Text + "%' and";
                }

                if (this.txtProvincia.Text.Trim() != String.Empty)
                {
                    txtWhere = txtWhere + " Provincia like '%" + txtProvincia.Text + "%' and";
                }


                if (txtWhere.Trim() == String.Empty)
                {
                    strSQL = "select id_key_cliente,Nombre,id_key_Provincia_fiscal, Direccion_fiscal, CP_fiscal from Clientes";
                }

                if (txtWhere.Trim().EndsWith("and"))
                {
                    txtWhere = txtWhere.Substring(0, txtWhere.Length - 3);
                }

                strSQL = strSQL + txtWhere + " order by Nombre";

                ds = Consulta.devolverDataSetSelect(strSQL);

                this.grdClientes.DataSource = ds.Tables[0];
                this.grdClientes.Columns[0].Visible = false;
                //this.grdVehiculos.Columns[0].Visible = false;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManClientes formulario = new frmManClientes();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.recogerDatos(0);
            formulario.ShowDialog();
            Busqueda();
        }

        private void grdClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.grdClientes.RowCount > 0)
            {
                frmManClientes formulario = new frmManClientes();
                formulario.recogerDatos(Convert.ToInt32(this.grdClientes.CurrentRow.Cells[0].Value));
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
                Busqueda();
            }
        }

       
        private void grdClientes_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.grdClientes.CurrentRow.Selected = true;
                    int Fila = grdClientes.CurrentCell.RowIndex;

                    if ((grdClientes.Rows.Count) != Fila)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            mnuOpciones.Show(grdClientes, e.X, e.Y);
                            mdPrincipal.mostrarMenuMouse(mnuOpciones, e.Button, MousePosition.X, MousePosition.Y, false, this.grdClientes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }




}


