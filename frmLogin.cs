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
    public partial class frmLogin : Form
    {
        Boolean existe;
        Boolean respuesta = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            aceptar();
        }
        public void aceptar()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Usuario incorrecto", "Usuario incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Select();
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                return;
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password incorrecto", "Password incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Select();
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                return;
            }
            else
            {
                // Ir a formulario principal
                clsSQL clsSQL = new clsSQL();
                existe = clsSQL.existeConsulta("select usuario from usuarios where usuario = '" + txtUsuario.Text + "' and password = '" + txtPassword.Text + "' AND ESTADO = 'A'");
                if (existe == false)
                {
                    MessageBox.Show("Fallo de acceso", "Fallo de identificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Select();
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
                else
                {
                    clsFunciones Fun = new clsFunciones();
                    mdPrincipal.Id_Usuario = Convert.ToInt32(clsSQL.devolverUnParametro("usuarios where usuario = '" + txtUsuario.Text + "'", "id_key_usuario"));
                    mdPrincipal.Id_Key_Departamento = Convert.ToInt32(clsSQL.devolverUnParametro("usuarios where usuario = '" + txtUsuario.Text + "'", "id_key_departamento"));
                    mdPrincipal.Usuario = this.txtUsuario.Text;

                    //Fun.grabarLogUsuario("Logon Aplicación", "Usuario : " + mdPrincipal.Usuario);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    respuesta = true;
                }
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
            {
                        //SendKeys.Send("{TAB}");
                        aceptar();
                        break;
                    }
            }
        }
    }
}
