using System.Data;
using System.Windows.Forms;
using System.Threading;


namespace Transportes {
    static class mdPrincipal
    {

        public static int Id_key_usuario_supervisor_ot = 21;
        // CATALOGO
        public static string Catalogo = "Transportes";
        //Public Catalogo As String = "DESARROLLO"


        
        //SERVIDOR Transportes
        //public static string Servidor = "WIN-86F85C1MI8I\\GESTIONTransportes";
        //public static string Cadena_Conexion_SQL = "Data Source=" + Servidor + ";Initial Catalog=" + Catalogo + ";user id=sa;password=rimeni14PT8;Connect Timeout=0";
        
        //SERVIDOR DESARROLLO
        public static string Servidor = "LUSER-PC\\SQLJV";
        public static string Cadena_Conexion_SQL = "Data Source=" + Servidor + ";Initial Catalog=" + Catalogo + ";user id=sa;password=aquenomepilla;Connect Timeout=0";
        

        //Aplicacion
        public static string Nombre_App = "Transportes";

        public static string Error_SQL = "Error SQL";
        public static string Error_Identificacion = "Error identificación";
        public static string Error_Usuario_Vacio = "El usuario debe contener algún caracter";
        public static string Error_Password_Vacio = "El password debe contener algún caracter";
        public static string Error_Password_Confirmacion = "La confirmación del Password es distinto del Password";

        public static string Error_Acceso = "El usuario o la contraseña no son correctos";
        public static int Id_Usuario;

        public static string Usuario;
        //Ruta del Archivo XML de configuracion
        public static string Ruta_XML = "config_Transportes.xml";
        public static string Nodo_Xml = "datos";
        //Rutas y Usuarios de los Crystal Reports
        public static string RPT_Usuario= clsSQL.devolverUnParametro("tg_parametros where nombre = 'rpt_usuario'", "valor");
        public static string RPT_Password= clsSQL.devolverUnParametro("tg_parametros where nombre = 'rpt_password'", "valor");
        public static string RPT_Server= clsSQL.devolverUnParametro("tg_parametros where nombre = 'rpt_server'", "valor");
        public static string RPT_Ruta_Informes= clsSQL.devolverUnParametro("tg_parametros where nombre = 'rpt_ruta_informes'", "valor");


        //public static string RPT_BaseDatos;


        //public static string Ruta_Ayuda;
        //Variables de permisos
        public static bool Permiso_Lectura = false;
        public static bool Permiso_Insertar = false;
        public static bool Permiso_Modificar = false;

        public static bool Permiso_Eliminar = false;
        //Constante Global de Acceso

        public static bool permitirAcceso = false;
        //Variables enteras
        public static int Variable_1 = 1;
        public static int Variable_2 = 2;
        public static int Variable_3 = 3;
        public static int Variable_4 = 4;
        public static int Variable_5 = 5;
        public static int Variable_6 = 6;
        public static int Variable_7 = 7;
        public static int Variable_8 = 8;
        public static int Variable_9 = 9;

        public static int Variable_0 = 0;
        public static int Variable_10 = 10;

        public static int Variable_11 = 11;
        //Constante Formato de Fecha
        public static string formatoFecha = string.Empty;

        static DataGridView gridMenu;
        //'******************************************************************************************
        //'**** Procedimiento Inicial de la Aplicación
        //'**** Muy Importante
        //'**** Muestra el formulario de autentificación y si el login es correcto
        //'**** accede a el aplicativo
        //'******************************************************************************************

        [System.STAThread]

        public static void Main()
        {
            frmMain formulario = new frmMain();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();



            //Id_Usuario = args(0)
            //Dim clsSQL As New clsSQL
            //Dim clsFunc As New clsFunciones

            //Usuario = clsFunc.leerXML(Nodo_Xml, "usuario")
            //'globalDelegacion = Convert.ToInt32(clsFunc.leerXML(Nodo_Xml, "cod_delegacion"))


            //Ruta_Ayuda = clsSQL.devolverUnParametro("tg_parametros where nombre = 'ruta_ayuda'", "valor")
            
            //If Cadena_Conexion_SQL.Substring(12, 8).ToUpper <> "SERVER01" Then
            //    formatoFecha = "dd/MM/yyyy"
            //Else
            //    formatoFecha = "yyyy-MM-dd"
            //End If

            //If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            //    MessageBox.Show("El sistema de gestion de ya esta abierto", "Transportes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            //    End
            //End If


            //'* Llamada a autentificar antes de abrir el principal
            //Dim respuesta As Integer = autentifica()
            //Select Case respuesta
            //    Case 0
            //        Dim frmInicio As frmPrincipal
            //        frmInicio = New frmPrincipal
            //        Application.Run(frmInicio)
            //    Case 2
            //        While respuesta <> 0
            //            If respuesta = 1 Then
            //                Exit While
            //            End If
            //            respuesta = autentifica()
            //        End While
            //        If respuesta = 0 Then
            //            Dim frmInicio As frmPrincipal
            //            frmInicio = New frmPrincipal
            //            Application.Run(frmInicio)
            //        Else
            //            Exit Sub
            //        End If
            //End Select
        }

        // Obviado de momento para los test
        public static int autentifica()
        {
            //frmUsuario Formulario = new frmUsuario();
            //System.Windows.Forms.DialogResult respuesta = Formulario.ShowDialog();
            //switch (respuesta) {
            //	case DialogResult.OK:
            //		return 0;
            //	case DialogResult.Cancel:
            //		return 1;
            //	case DialogResult.No:
            //		return 2;
            //}
            return 3;
        }

        /// <summary>
        /// Devuelve un vacio si es valor Nulo
        /// </summary>
        /// <param name="_valor">Objeto a comprobar</param>
        /// <returns></returns>
        /// <remarks></remarks>
   
        ///// <summary>
        ///// Caracteres permitidos en un textbox, según los parámetros pasados en la cadena
        ///// </summary>
        ///// <param name="cadenaPermitida">Caracteres permitidos en forma de cadena</param>
        ///// <param name="e">Evento</param>
        ///// <returns>Devuelve el caracter permitido</returns>
        ///// <remarks></remarks>
        //public static char caracteresPermitidos(string cadenaPermitida, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //	if (InStr(1, cadenaPermitida + (char)8, e.KeyChar) == 0) {
        //		return '\0';
        //	} else {
        //		return e.KeyChar;
        //	}
        //}
        /// <summary>
        /// Mostrar el menu desplegable del Mouse
        /// </summary>
        /// <param name="_Objeto">Objeto del Menu que queremos mostrar</param>
        /// <param name="_boton">Boton que pulsamos</param>
        /// <param name="_posicionX">posicion X del mouse</param>
        /// <param name="_posicionY">posicion Y del mouse</param>
        /// <param name="NoMostrarExportar">Si es True el menu NO muestra el botón de Exportar a Excel</param>
        /// <param name="_grid">Grid del que queremos exportar los datos</param>
        /// <remarks></remarks>

        public static void mostrarMenuMouse(object _Objeto, System.Windows.Forms.MouseButtons _boton, int _posicionX, int _posicionY, bool NoMostrarExportar = true, DataGridView _grid = null/* TODO Change to default(_) if this is not a reference type */, bool _conColores = false)
        {
            try
            {
                var Objeto = typeof(ContextMenuStrip);
                if (_Objeto == null == true)
                    return;

                if (_boton == System.Windows.Forms.MouseButtons.Right)
                {
                    System.Windows.Forms.ContextMenuStrip _menu = new System.Windows.Forms.ContextMenuStrip();

                    if (Objeto.Equals(_Objeto.GetType()) )
                        _menu = (ContextMenuStrip)_Objeto;
                    else
                        NoMostrarExportar = false;

                    if (NoMostrarExportar == true)
                        // *** Mostrar el Menu normal
                        _menu.Show(_posicionX + 10, _posicionY + 10);
                    else
                    {
                        // *** Mostrar el Menu con el botón de exportar
                        // **  Si el último Item es el del Excel, borrarlo y añadirlo de nuevo
                        if ((_menu.Items.Count > 0))
                        {
                            if (_menu.Items[_menu.Items.Count - 1].Text == "Exportar a Excel")
                            {
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                            }
                            if (_menu.Items[_menu.Items.Count - 1].Text == "Exportar a Excel con colores")
                            {
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                                _menu.Items.Remove(_menu.Items[_menu.Items.Count - 1]);
                            }
                        }

                        // ** Añadimos botón y le insertamos el evento que queremos que haga
                        // ** Antes de añadir el botón, le ponemos el separador, para que quede más mono.
                        _menu.Items.Add("-");
                        _menu.Items.Add("Exportar a Excel", global::Transportes.Properties.Resources.Page_excel, accionExportar);
                        if (_conColores == true)
                        {
                            _menu.Items.Add("-");
                            //_menu.Items.Add("Exportar a Excel con colores", global::Transportes.Properties.Resources.Page_excel, accionExportarEnColor);
                        }
                        _menu.Show(_posicionX + 10, _posicionY + 10);
                        if (_grid!=null)
                            gridMenu = _grid;
                    }
                }
            }
            catch (java.lang.Exception ex)
            {
                MessageBox.Show(ex.ToString(), Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        /// <summary>
        /// Accion para exportar los archivos de un grid a Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        public static void accionExportar(object sender, System.EventArgs e)
        {
            //Try
            if ((gridMenu != null)) {
                clsFunciones clsFunc = new clsFunciones();
                if (gridMenu == null)
                    return;
                if (gridMenu.RowCount > 0) {
                    clsFunc.exportarAExcel(gridMenu, "Excel");
                }
            }
            //Catch ex As Exception
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            //End Try
        }
        /// <summary>
        /// Pasamos el formulario padre al formulario hijo y nos dice si está abierto o no.
        /// </summary>
        /// <param name="hijo">Formulario que queremos abrir</param>
        /// <param name="padre">Padre del formulario que queremos abrir</param>
        /// <returns>Devuelve True si el formulario NO está abierto. False si ya está abierto para no volverlo a abrir</returns>
        /// <remarks></remarks>
        public static bool herenciaFormulario(Form hijo, Form padre)
        {
            try {
                //*** Buscamos en los hijos que no esté el formulario que estamos abriendo
                //For Each f As Form In padre.MdiChildren
                //    If f.Name = hijo.Name Then
                //        Return False
                //    End If
                //Next

                //'*** Asignar padre al formulario que estamos abriendo
                //hijo.MdiParent = padre

                return true;
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}