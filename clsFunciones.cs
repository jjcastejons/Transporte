using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Text;


using java.io;


namespace Transportes {
    //Imports Microsoft.Office.Interop
    //using Microsoft.Office.Interop;



    //** Para el envío de SMS
    //Imports SMSCOM
    //** Estas de debajo necesitan la libreria vjslib.dll de J# para los ZIP
    //using java.util;
    //using java.util.zip;
    //using java.io;

    //public class cApp
    //{
    //	//' Evento para indicar que una propiedad no está disponible
    //	//' aunque se puede ampliar si se quieren capturar errores
    //	//Public Event ErrorMsg(ByVal PropertyName As String, ByVal sMessage As String)
    //	//
    //	private System.Reflection.Assembly mAssembly;
    //	private string mLocation;

    //	private System.Diagnostics.FileVersionInfo mFileVersionInfo;


    //	// Al crear la clase hay que pasar forzosamente el tipo del Assembly a usar
    //	// por ejemplo: Dim app As New cApp(Me.GetType)
    //	// Este constructor es útil para aplicaciones de Windows o librerías (DLL)
    //	public cApp(Type theType) : this(System.Reflection.Assembly.GetAssembly(theType))
    //	{
    //	}
    //	//
    //	// Crear una nueva instancia usando un ensamblado.
    //	// por ejemplo: Dim App As cApp = New cApp(System.Reflection.Assembly.GetExecutingAssembly)
    //	public cApp(System.Reflection.Assembly theAssembly)
    //	{
    //		mAssembly = theAssembly;
    //		mLocation = mAssembly.Location;
    //		mFileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation);
    //	}
    //	//
    //	public string Comments {
    //		get { return mFileVersionInfo.Comments; }
    //	}
    //	//
    //	public string CompanyName {
    //		get { return mFileVersionInfo.CompanyName; }
    //	}
    //	//
    //	public string EXEName {
    //		get { return System.IO.Path.GetFileName(mLocation); }
    //	}
    //	//
    //	public string FileDescription {
    //		get { return mFileVersionInfo.FileDescription; }
    //	}
    //	//
    //	public Int32 HInstance {
    //		get { return System.Runtime.InteropServices.Marshal.GetHINSTANCE(mAssembly.GetModules()[0]).ToInt32(); }
    //	}
    //	//
    //	public string LegalCopyright {
    //		get { return mFileVersionInfo.LegalCopyright; }
    //	}
    //	//
    //	public string LegalTrademarks {
    //		get { return mFileVersionInfo.LegalTrademarks; }
    //	}
    //	//
    //	public Int32 Major {
    //		get { return this.FileMajorPart; }
    //	}
    //	//
    //	public Int32 Minor {
    //		get { return this.FileMinorPart; }
    //	}
    //	//
    //	public string Path (Boolean conBackSlash) {

    //			if (conBackSlash) {
    //				return System.IO.Path.GetDirectoryName(mLocation) + "\\";
    //			} else {
    //				return System.IO.Path.GetDirectoryName(mLocation);
    //			}

    //	}
    //	//
    //	public bool PrevInstance {
    //		get {
    //            //String a = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
    //            return System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).GetUpperBound(0) > 0;
    //		}
    //	}
    //	//
    //	public string ProductName {
    //		get { return mFileVersionInfo.ProductName; }
    //	}
    //	//
    //	public Int32 Revision {
    //		get { return this.FileBuildPart; }
    //	}
    //	//
    //	public string Title {
    //		get {
    //			try {
    //				return mAssembly.GetName().Name;
    //			} catch {
    //				return mFileVersionInfo.ProductName;
    //			}
    //		}
    //	}
    //	//
    //	//--------------------------------------------------------------------------
    //	// Estas propiedades no son parte del objeto App.
    //	//--------------------------------------------------------------------------
    //	//
    //	public Int32 Build {
    //		get { return this.FileBuildPart; }
    //	}
    //	public Int32 FileBuildPart {
    //		get { return mFileVersionInfo.FileBuildPart; }
    //	}
    //	public Int32 FileMajorPart {
    //		get { return mFileVersionInfo.FileMajorPart; }
    //	}
    //	public Int32 FileMinorPart {
    //		get { return mFileVersionInfo.FileMinorPart; }
    //	}
    //	public Int32 FilePrivatePart {
    //		get { return mFileVersionInfo.FilePrivatePart; }
    //	}
    //	public string FileVersion {
    //		get { return mFileVersionInfo.FileVersion; }
    //	}
    //	//
    //	// Devuelve el valor del Location del Assemby usado              (09/Dic/01)
    //	public string Location {
    //		get { return mLocation; }
    //	}
    //}

    ///**********************************************************************
    ///***** Principio de Clase de Funciones...
    ///*****
    ///**********************************************************************
    public class clsFunciones
    {

        string cMontext;
        //' Constantes para imprimir directamente sin Crystal
        internal string textoAImprimir;
        private int coordenadaX = 0;

        private int coordenadaY = 0;
        private System.Drawing.Font printFont;

        private StreamReader streamToPrint;
        public enum DireccionCeros
        {
            Izquierda = 1,
            Derecha = 2
        }


        //Outlook.Application m_OutLook;
        /// <summary>
        /// Limpia los controles del formulario
        /// </summary>
        /// <param name="ofrm">Formulario que queremos limpiar</param>
        /// <remarks></remarks>
        private void LimpiarTextBox(Form ofrm)
        {
            foreach (Control oControl in ofrm.Controls) {
                if (oControl is System.Windows.Forms.TextBox) {
                    oControl.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// Muestra el formulario en modo vbModal(del vb6.0) y así no se puede ver el de debajo
        /// </summary>
        /// <param name="_formulario">Formulario a mostrar</param>
        /// <remarks></remarks>
        public void mostrarForm(Form _formulario)
        {
            _formulario.StartPosition = FormStartPosition.CenterParent;
            _formulario.ShowDialog();

            //formularioAmostrar.Dispose()
        }
        /// <summary>
        /// Cargar el combobox pasado en la funcion
        /// </summary>
        /// <param name="_combo">ComboBox a cargar</param>
        /// <param name="_display">Valor que queremos ver en el combo</param>
        /// <param name="_value">Valor que va relacionado con lo que veremos en el combo</param>
        /// <param name="_select">Select de donde cogemos los datos</param>
        /// <remarks></remarks>
        public void cargarCombos(ComboBox _combo, string _select, string _display, string _value, bool _SinBlancoPrimero = false)
        {
            clsSQL clsSQL = new clsSQL();
            DataSet ds = new DataSet();

            try {
                ds = clsSQL.devolverDataSetSelect(_select);
                if (_SinBlancoPrimero == false) {
                    DataRow drow = default(DataRow);
                    System.Data.DataTable dtable = ds.Tables[0];

                    dtable = ds.Tables[0];
                    drow = dtable.NewRow();

                    drow[_value] = 0;
                    drow[_display] = string.Empty;

                    dtable.Rows.InsertAt(drow, 0);
                }
                _combo.DisplayMember = _display;
                _combo.ValueMember = _value;
                _combo.DataSource = ds.Tables[0];
            } catch (System.Exception ex) {
                MessageBox.Show(ex.ToString(), mdPrincipal.Error_SQL, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }




        public void cargarCombosEnGrid(DataGridViewComboBoxColumn _combo, String _select , String _display, String _value , Boolean _SinBlancoPrimero) { 
        clsSQL clsSQL =new clsSQL();
            DataSet ds = new DataSet();
            try {
                ds = clsSQL.devolverDataSetSelect(_select);
                if (_SinBlancoPrimero == false) {
                    DataRow drow;
                    System.Data.DataTable dtable = ds.Tables[0];
                    dtable = ds.Tables[0];
                    drow = dtable.NewRow();
                    drow[_value] = 0;
                    drow[_display] = String.Empty;
                    dtable.Rows.InsertAt(drow, 0);
                }
                _combo.DisplayMember = _display;
                _combo.ValueMember = _value;
                _combo.DataSource = ds.Tables[0];
                _combo.AutoComplete = false;
       } catch (System.Exception ex) {
                MessageBox.Show(ex.ToString(), mdPrincipal.Error_SQL, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}





        /// <summary>
        /// Habilita o deshabilita (Enabled) los objetos que le pasamos en el Paramarray, según _accion
        /// </summary>
        /// <param name="_accion">True habilitar, False deshabilitar</param>
        /// <param name="_objetos">Array de objetos a pasarles la accion</param>
        /// <remarks></remarks>
        //public void habilitarControles(bool _accion, params object[] _objetos)
        //{
        //	object objeto = null;
        //	string nombreObjeto = string.Empty;
        //	clsSQL clsSQL = new clsSQL();

        //	foreach (object objeto_loopVariable in _objetos) {
        //		objeto = objeto_loopVariable;
        //		nombreObjeto = objeto.Name;
        //		objeto.Enabled() = _accion;
        //	}

        //}

        //public void habilitarBotones(bool _accion, string _formulario, params object[] _objetos)
        //{
        //       object objeto = null;
        //       string nombreObjeto = string.Empty;
        //	clsSQL clsSQL = new clsSQL();

        //	clsSQL.mostrarPermisos(mdPrincipal.mdPrincipal.Id_Usuario, _formulario);

        //	foreach (object objeto_loopVariable in _objetos) {
        //		objeto = objeto_loopVariable;
        //		nombreObjeto = objeto.GetType().Name;
        //		objeto.GetType. = _accion;

        //		if (_accion == true) {
        //			switch (nombreObjeto.ToUpper()) {
        //				case "BTNADDTOOL":
        //					objeto.Enabled = mdPrincipal.Permiso_Insertar;

        //					break;
        //				case "BTNMODIFICARTOOL":
        //					objeto.Enabled = mdPrincipal.Permiso_Modificar;
        //					break;
        //				case "BTNELIMINARTOOL":
        //					objeto.Enabled = mdPrincipal.Permiso_Eliminar;
        //					break;
        //			}
        //		}
        //	}

        //}

        /// <summary>
        /// Abre el documento pasado a la ruta. El procedimiento ya asigna la extension al archivo a abrir
        /// </summary>
        /// <param name="_ruta">Ruta del documento</param>
        /// <remarks></remarks>
        //public void abrirArchivo(string _ruta)
        //{
        //	System.Diagnostics.ProcessStartInfo objArchivo = new System.Diagnostics.ProcessStartInfo();

        //	objArchivo.WindowStyle = ProcessWindowStyle.Maximized;
        //	//'p.FileName = "C:\documentos\hotel.xls"
        //	objArchivo.FileName = _ruta;
        //	objArchivo.UseShellExecute = true;
        //	System.Diagnostics.Process.Start(objArchivo);

        //}
        /// <summary>
        /// Comprueba que existe el directorio que buscamos. Devuelve True si existe
        /// </summary>
        /// <param name="elDirectorio">Directorio a buscar</param>
        /// <remarks></remarks>
        public bool existeDirInfo(string elDirectorio)
        {
            DirectoryInfo direc = new DirectoryInfo(elDirectorio);
            bool existe = direc.Exists;

            return existe;
        }

        /// <summary>
        /// Muestra los subdirectorios del directorio principal
        /// </summary>
        /// <param name="elDirectorio">Directorio principal</param>
        /// <remarks></remarks>
        public void subDir(string elDirectorio)
        {
            string[] subdirs = Directory.GetDirectories(elDirectorio);

            System.Console.WriteLine("Los subdirectorios del directorio {0}", elDirectorio);
            foreach (string s in subdirs) {
                System.Console.WriteLine("  {0}", s);
            }
        }
        /// <summary>
        /// Crea un directorio pasandole la ruta del mismo
        /// </summary>
        /// <param name="_rutaDirectorio">Ruta del directorio a crear</param>
        /// <remarks></remarks>
        public void creaDirectorio(string _rutaDirectorio)
        {
            DirectoryInfo direc = new DirectoryInfo(_rutaDirectorio);
            if (existeDirInfo(_rutaDirectorio) == false) {
                direc.Create();
            }
        }
        /// <summary>
        /// Rellena el Check dependiendo de la Expresion pasada por valor
        /// </summary>
        /// <param name="Expresion">Expresion a comprobar</param>
        /// <param name="Check">CheckBox a rellenar</param>
        /// <remarks></remarks>
        public void rellenaCheck(bool Expresion, System.Windows.Forms.CheckBox Check)
        {
            if (Expresion == true) {
                Check.CheckState = CheckState.Checked;
            } else {
                Check.CheckState = CheckState.Unchecked;
            }
        }
        /// <summary>
        /// Devuelve los valores que le pasamos, según el estado del CheckBox que le pasamos por valor
        /// </summary>
        /// <param name="check">CheckBox para mirar el estado</param>
        /// <param name="valorVerdadero">Valor que devuelve en caso de True</param>
        /// <param name="valorFalso">Valor que devuelve en caso de False</param>
        /// <returns>Valor que hemos configurado según los parámetros pasados</returns>
        /// <remarks></remarks>
        public string devuelveValordeCheck(System.Windows.Forms.CheckBox check, string valorVerdadero, string valorFalso)
        {

            if (check.CheckState == CheckState.Checked) {
                return valorVerdadero;
            } else {
                return valorFalso;
            }

        }
        /// <summary>
        /// Cambia la coma por el punto a los decimales, para la instruccion INSERT
        /// </summary>
        /// <param name="expresion">Expresion a cambiar la coma por el punto</param>
        /// <returns>expresion con el punto en lugar de la coma</returns>
        /// <remarks></remarks>
        public string ponerDecimales(string expresion)
        {
            string devuelve = expresion;
            devuelve = expresion.Replace(",", ".");
            return devuelve;
        }
        /// <summary>
        /// Cambia el punto decumal por la coma 
        /// </summary>
        /// <param name="expresion">Expresion a cambiar el punto por la coma</param>
        /// <returns>expresion con la coma en lugar del punto</returns>
        /// <remarks></remarks>
        public string ponerComasADecimales(string expresion)
        {
            //Dim devuelve As String = StrReverse(expresion)

            //Dim donde_primer_punto As Integer = devuelve.IndexOf(".")
            //Dim decimales As String = devuelve.Substring(0, donde_primer_punto)

            //devuelve = devuelve.Substring(donde_primer_punto, devuelve)

            //devuelve = StrReverse(devuelve)
            string devuelve = expresion;

            devuelve = expresion.Replace(".", ",");

            //devuelve = devuelve & "," & decimales

            return devuelve;
        }
        /// <summary>
        /// Devuelve la Delegacion a la que pertenece el Usuario
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public int devolverDelegacionUsuario(string _User)
        {
            clsSQL clsSQL = new clsSQL();
            int idDelegacion = Convert.ToInt32(clsSQL.devolverUnParametro("seg_usuarios where usuario = '" + _User + "'", "cod_delegacion"));

            return idDelegacion;
        }
        /// <summary>
        /// Borra Archivo de la ruta especificada
        /// </summary>
        /// <param name="_ruta">Ruta y nombre del archivo a borrar</param>
        /// <remarks></remarks>
        public void borrarArchivo(string _ruta)
        {
            if (System.IO.File.Exists(_ruta) == true) {
                System.IO.File.Delete(_ruta);
            }
        }
        /// <summary>
        /// Comprueba que exista un archivo en la ruta especificada
        /// </summary>
        /// <param name="_ruta">directorio especificado donde está el archivo a comprobar</param>
        /// <returns>True si existe el archivo</returns>
        /// <remarks></remarks>
        public bool existeArchivo(string _ruta)
        {

            bool devuelve = false;
            //string RutaSinArchivo = StrReverse(_ruta);
            //int dondeEstaLaBarra = RutaSinArchivo.IndexOf("\\", 0);
            //RutaSinArchivo = RutaSinArchivo.Substring(dondeEstaLaBarra + 1);

            //RutaSinArchivo = Strings.StrReverse(RutaSinArchivo);

            //DirectoryInfo diSource = new DirectoryInfo(RutaSinArchivo);
            //if (diSource.Exists == true) {
            //    if (System.IO.File.Exists(_ruta) == true) {
            //        devuelve = true;
            //    } else {
            //        devuelve = false;
            //    }
            //} else {
            //    devuelve = false;
            //}

            return devuelve;
        }
        /// <summary>
        /// Copiar Ficheros desde un origen a un destino que debe existir. Si en accion = "mover", los mueve
        /// </summary>
        /// <param name="origen">directorio Origen (debe existir)</param>
        /// <param name="destino">directorio Destino (debe existir)</param>
        /// <param name="mascara">nombre archivo</param>
        /// <param name="accion">copiar o mover</param>
        /// <param name="blOverwrite">True si sobreescribimos, False si no queremos sobreescribir</param>
        /// <remarks></remarks>

        public void copiarFicheros(string origen, string destino, string mascara, string accion, bool blOverwrite)
        {
            FileInfo[] fiSourceFiles = null;


            DirectoryInfo diSource = new DirectoryInfo(origen);
            DirectoryInfo diDestination = new DirectoryInfo(destino);


            //obtengo todos los archivos del directorio origen
            fiSourceFiles = diSource.GetFiles(mascara, SearchOption.TopDirectoryOnly);
            //obtengo los subdirectorios (si existen)

            //si no existe el directorio destino crearlo
            //If Not diDestination.Exists Then diDestination.Create()
            //'buscarXMLycrearDir("c:\canon\canon.xml", "menu", "ruta")

            //Usar la recursividad para navegar por los subdirectorios
            //e ir obteniendo los archivos hasta llegar al final
            //For Each diSourceSubDirectory As DirectoryInfo In diSourceSubDirectories
            //    CopyFiles(diSourceSubDirectory, New DirectoryInfo(diDestination.FullName & "\" & _
            //    diSourceSubDirectory.Name), blOverwrite)
            //Next

            foreach (FileInfo fiSourceFile in fiSourceFiles) {
                fiSourceFile.CopyTo(diDestination.FullName + "\\" + fiSourceFile.Name, blOverwrite);
                switch (accion.Trim()) {
                    case "mover":
                        fiSourceFile.Delete();
                        break;
                }
            }

        }
        /// <summary>
        /// inserta en la tabla log_usuarios
        /// </summary>
        /// <param name="Pantalla">pantalla</param>
        /// <param name="Operacion">descripcion de la operacion realizada</param>
        /// <returns>ok</returns>
        /// <remarks></remarks>
        public bool grabarLogUsuario(string Pantalla, string Operacion)
        {
            clsSQL clsSQL = new clsSQL();
            clsFunciones clsFunc = new clsFunciones();
            string Respuesta = null;

            Respuesta = clsSQL.ejecutarSP("SP_Add_Log_Usuarios", "@id_key_usuario=" + mdPrincipal.Id_Usuario + "=System.int32", "@pantalla=" + Pantalla + "=System.String", "@operacion=" + Operacion + "=System.String").Trim().ToUpper();

            return true;
        }
        /// <summary>
        /// Leer valores del XML. 
        /// </summary>
        /// <param name="nodo">Nodo del cual queremos en valor</param>
        /// <param name="dato">Dato dentro del nodo del cual queremos el valor</param>
        /// <returns>Valor del dato dentro del nodo en String</returns>
        /// <remarks></remarks>
        public string leerXML(string nodo, string dato)
        {

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(System.IO.Directory.GetCurrentDirectory() + "\\" + mdPrincipal.Ruta_XML);
            XmlNode node = null;

            string dato_devuelto = string.Empty;

            node = myXmlDocument.DocumentElement;

            if (node.Name == nodo) {
                if (node.Attributes[dato].Value != string.Empty) {
                    dato_devuelto = node.Attributes[dato].Value;
                }
            }

            return dato_devuelto;
        }
        /// <summary>
        /// Graba dentro del XML los parámetros pasados
        /// </summary>
        /// <param name="nodo">nodo donde se encuentra el dato</param>
        /// <param name="dato">Dato a modificar</param>
        /// <param name="valor">Valor pasado para modificar</param>
        /// <remarks></remarks>
        public void grabarenXML(string nodo, string dato, string valor)
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(System.IO.Directory.GetCurrentDirectory() + "\\" + mdPrincipal.Ruta_XML);
            XmlNode node = null;

            node = myXmlDocument.DocumentElement;

            //Buscar los nodos secundarios mascara y destino según el nodo id. 
            if (node.Name == nodo) {
                if (node.Attributes[dato].Value != string.Empty) {
                    //If node.ChildNodes(0).InnerText = id Then
                    //'Modificar los nodos
                    node.Attributes[dato].Value = valor;
                }
            }

            myXmlDocument.Save(System.IO.Directory.GetCurrentDirectory() + "\\" + mdPrincipal.Ruta_XML);

        }
        /// <summary>
        /// Rellenar de Ceros una cadena
        /// </summary>
        /// <param name="_dato">Dato que queremos rellenar de ceros</param>
        /// <param name="_Len">Tamaño del dato que devolvemos</param>
        /// <param name="_direccion">Direccion a la que queremos rellenar los ceros</param>
        /// <returns>Cadena formateada con los ceros añadidos</returns>
        /// <remarks></remarks>
        public string rellenarDeCeros(string _dato, int _Len, DireccionCeros _direccion)
        {
            string devuelve = _dato;
            //string cadenaCeros = string.Empty;
            //int i = 0;

            //for (i = 1; i <= _Len; i++) {
            //    cadenaCeros = cadenaCeros + "0";
            //}

            //if (_direccion == DireccionCeros.Izquierda) {
            //    devuelve = cadenaCeros + _dato;
            //    devuelve = Strings.Right(devuelve, _Len);
            //} else {
            //    devuelve = _dato + cadenaCeros;
            //    devuelve = Strings.Left(devuelve, _Len);
            //}

            return devuelve;
        }
        /// <summary>
        /// Rellena de Espacios una cadena
        /// </summary>
        /// <param name="_dato">Cadena que queremos rellenar</param>
        /// <param name="_Len">Tamaño de la cadena de salida</param>
        /// <param name="_direccion">Hacia donde se rellena de espacios</param>
        /// <returns>Cadena formateada con los espacios añadidos</returns>
        /// <remarks></remarks>
        public string rellenarDeEspacios(string _dato, int _Len, DireccionCeros _direccion)
        {
            string devuelve = _dato;
            //int i = 0;
            //string cadenaEspacios = string.Empty;

            //for (i = 1; i <= _Len; i++) {
            //    cadenaEspacios = cadenaEspacios + " ";
            //}

            //if (_direccion == DireccionCeros.Izquierda) {
            //    devuelve = cadenaEspacios + _dato;
            //    devuelve = Strings.Right(devuelve, _Len);
            //} else {
            //    devuelve = _dato + cadenaEspacios;
            //    devuelve = Strings.Left(devuelve, _Len);
            //}

            return devuelve;
        }
        /// <summary>
        /// Rellenar con el caracter especificado una cadena
        /// </summary>
        /// <param name="_dato">Dato que queremos rellenar de caracteres</param>
        /// <param name="_caracter">Caracter con el que rellenamos</param>
        /// <param name="_Len">Tamaño del dato que devolvemos</param>
        /// <param name="_direccion">Direccion a la que queremos rellenar el caracter</param>
        /// <returns>Cadena formateada con los caracteres añadidos</returns>
        /// <remarks></remarks>
        public string rellenarDeCaracter(string _dato, char _caracter, int _Len, DireccionCeros _direccion)
        {
            string devuelve = _dato;
            //string cadenaCeros = string.Empty;
            //int i = 0;

            //for (i = 1; i <= _Len; i++) {
            //    cadenaCeros = cadenaCeros + _caracter;
            //}

            //if (_direccion == DireccionCeros.Izquierda) {
            //    devuelve = cadenaCeros + _dato;
            //    devuelve = Strings.Right(devuelve, _Len);
            //} else {
            //    devuelve = _dato + cadenaCeros;
            //    devuelve = Strings.Left(devuelve, _Len);
            //}

            return devuelve;
        }
        /// <summary>
        /// Devuelve el nombre del mes como cadena pasandole un entero
        /// </summary>
        /// <param name="_mes">Mes como entero para devolver su nombre</param>
        /// <returns>nombre del mes como cadena</returns>
        /// <remarks></remarks>
        public string devolverMesCadena(int _mes)
        {
            string devuelve = "";

            switch (_mes) {
                case 1:
                    devuelve = "ENERO";
                    break;
                case 2:
                    devuelve = "FEBRERO";
                    break;
                case 3:
                    devuelve = "MARZO";
                    break;
                case 4:
                    devuelve = "ABRIL";
                    break;
                case 5:
                    devuelve = "MAYO";
                    break;
                case 6:
                    devuelve = "JUNIO";
                    break;
                case 7:
                    devuelve = "JULIO";
                    break;
                case 8:
                    devuelve = "AGOSTO";
                    break;
                case 9:
                    devuelve = "SEPTIEMBRE";
                    break;
                case 10:
                    devuelve = "OCTUBRE";
                    break;
                case 11:
                    devuelve = "NOVIEMBRE";
                    break;
                case 12:
                    devuelve = "DICIEMBRE";
                    break;
            }

            return devuelve;
        }
        /// <summary>
        /// Escribe una cadena de texto en un archivo pasando la ruta completa
        /// </summary>
        /// <param name="_archivo">Nombre del archivo con la ruta completa</param>
        /// <param name="_texto">Cadena que queremos insertar en el archivo</param>
        /// <remarks></remarks>
        public void escribirEnArchivo(string _archivo, string _texto)
        {
            //' esto inserta texto en un archivo existente, si el archivo no existe lo crea
            StreamWriter writer = new StreamWriter(_archivo, true, System.Text.Encoding.ASCII);

            writer.WriteLine(_texto);
            writer.Close();

        }


        /// <summary>
        /// Calcula que el NIF sea correcto y le pone letra o solo nos devuelve la Letra
        /// </summary>
        /// <param name="NIF">NIF que queremos calcular, SIN letra</param>
        /// <param name="soloLetra">A True si solo queremos la letra</param>
        /// <returns>Cadena con el Nif+Letra o solo la Letra dependiendo de variable soloLetra</returns>
        /// <remarks></remarks>
        public string CalculaNIF(string NIF, bool soloLetra)
        {
            string functionReturnValue = null;
            ////Calcula el NIF para ver si es correcto
            //string sCalculaNif = null;
            //string DNI = null;
            //if ((NIF.Trim().Length) >= 8) {
            //    DNI = Strings.Mid(NIF.Trim(), 1, 8);
            //} else {
            //    DNI = NIF.Trim();
            //}
            ////Calcula la Letra
            //sCalculaNif = Strings.Mid("TRWAGMYFPDXBNJZSQVHLCKE", 1 + DNI % 23, 1);
            ////Si solo queremos la letra la variable debe ser soloLetra = True
            //if (soloLetra == false) {
            //    functionReturnValue = DNI + sCalculaNif;
            //    //Devuelve el NIF con letra incluida
            //} else {
            //    functionReturnValue = sCalculaNif;
            //    //Solo devuelve la Letra
            //}

            //return functionReturnValue;
            return functionReturnValue;
        }

        /// <summary>
        /// Calcula la edad pasandole una Fecha como Date
        /// </summary>
        /// <param name="_fecha_nac">Valor de la fecha para calcular la edad</param>
        /// <returns>Entero con la edad</returns>
        /// <remarks></remarks>
        //public int calcularEdad(System.DateTime _fecha_nac)
        //{
        //    System.DateTime actual = Now;
        //    int devuelve = 0;

        //    if (actual > _fecha_nac) {
        //        devuelve = actual.Year - _fecha_nac.Year;
        //        if (actual.Month < _fecha_nac.Month) {
        //            devuelve = devuelve - 1;
        //        } else if (actual.Month == _fecha_nac.Month) {
        //            if (actual.Day < _fecha_nac.Day) {
        //                devuelve = devuelve - 1;
        //            }
        //        }
        //    } else {
        //        devuelve = 0;
        //    }

        //    return devuelve;

        //}
        /// <summary>
        /// Calcula los dos dígitos de control de los bancos
        /// </summary>
        /// <param name="bancosucursal">Los 8 números del banco y sucursal como cadena</param>
        /// <param name="cuenta">Los 10 números de la cuenta como cadena</param>
        /// <returns>Los dos dígitos de control con entero</returns>
        /// <remarks></remarks>
        public int calcularDigitoControl(string bancosucursal, string cuenta)
        {
            int sumaControluno = 0;
            int sumaControldos = 0;

            sumaControluno = Convert.ToInt32(bancosucursal.Substring(0, 1)) * mdPrincipal.Variable_4;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(1, 1)) * mdPrincipal.Variable_8;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(2, 1)) * mdPrincipal.Variable_5;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(3, 1)) * mdPrincipal.Variable_10;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(4, 1)) * mdPrincipal.Variable_9;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(5, 1)) * mdPrincipal.Variable_7;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(6, 1)) * mdPrincipal.Variable_3;
            sumaControluno = sumaControluno + Convert.ToInt32(bancosucursal.Substring(7, 1)) * mdPrincipal.Variable_6;

            sumaControluno = sumaControluno % mdPrincipal.Variable_11;
            sumaControluno = mdPrincipal.Variable_11 - sumaControluno;

            sumaControldos = Convert.ToInt32(cuenta.Substring(0, 1)) * mdPrincipal.Variable_1;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(1, 1)) * mdPrincipal.Variable_2;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(2, 1)) * mdPrincipal.Variable_4;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(3, 1)) * mdPrincipal.Variable_8;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(4, 1)) * mdPrincipal.Variable_5;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(5, 1)) * mdPrincipal.Variable_10;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(6, 1)) * mdPrincipal.Variable_9;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(7, 1)) * mdPrincipal.Variable_7;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(8, 1)) * mdPrincipal.Variable_3;
            sumaControldos = sumaControldos + Convert.ToInt32(cuenta.Substring(9, 1)) * mdPrincipal.Variable_6;

            sumaControldos = sumaControldos % mdPrincipal.Variable_11;
            sumaControldos = mdPrincipal.Variable_11 - sumaControldos;

            return sumaControluno + sumaControldos;
        }
        /// <summary>
        /// Redondear decimales a 2 digitos
        /// </summary>
        /// <param name="Numero">Decimal que queremos redondear en formato String</param>
        /// <returns>Cadena con el decimal redondeado</returns>
        /// <remarks></remarks>
        public string RedondearDecimales(string Numero)
        {
            string devuelve = null;
            //string ParteEntera = Conversion.Int(Numero);
            //string ParteDecimal = null;
            //if (!((Strings.Len(Numero) - Strings.Len(ParteEntera)) == 0)) {
            //    ParteDecimal = Strings.Right(Numero, Strings.Len(Numero) - Strings.Len(ParteEntera) - 1);
            //} else {
            //    ParteDecimal = "00";
            //}
            //double Num = 0;
            //if (Strings.Len(ParteDecimal) >= 3) {
            //    ParteDecimal = Strings.Left(ParteDecimal, 3);
            //    if (Strings.Mid(ParteDecimal, 3, 1) >= "5") {
            //        ParteDecimal = Strings.Left(ParteDecimal, 2);
            //        Num = Convert.ToDouble(ParteDecimal);
            //        Num = Num + 1;
            //        if (Strings.Len(Convert.ToString(Num)) == 3)
            //            ParteEntera = ParteEntera + 1;
            //        ParteDecimal = Strings.Right(Convert.ToString(Num), 2);
            //        ParteDecimal = rellenarDeCeros(ParteDecimal, 2, DireccionCeros.Izquierda);
            //    }
            //} else {
            //    ParteDecimal = Strings.Left(ParteDecimal, 2);
            //}
            //devuelve = ParteEntera + "," + ParteDecimal;

            return devuelve;
        }

        // Aca comienza la funcion

    //    public string NumPalabra(double Numero)
    //    {
    //        string Numerofmt = null;
    //        int centenas = 0;
    //        int pos = 0;
    //        int cen = 0;
    //        int dec = 0;
    //        int uni = 0;
    //        string textuni = null;
    //        string textdec = null;
    //        string textcen = null;
    //        string milestxt = null;
    //        string monedatxt = null;
    //        string txtPalabra = null;

    //        Numerofmt = Strings.Format(Numero, "000000000000000.00");
    //        //Le da un formato fijo
    //        centenas = 1;
    //        pos = 1;
    //        txtPalabra = "";
    //        while (centenas <= 5) {
    //            // extrae series de Centena, Decena, Unidad
    //            cen = Conversion.Val(Strings.Mid(Numerofmt, pos, 1));
    //            dec = Conversion.Val(Strings.Mid(Numerofmt, pos + 1, 1));
    //            uni = Conversion.Val(Strings.Mid(Numerofmt, pos + 2, 1));
    //            pos = pos + 3;
    //            textcen = Centena(uni, dec, cen);
    //            textdec = Decena(uni, dec);
    //            textuni = Unidad(uni, dec);
    //            // determina separador de miles/millones
    //            switch (centenas) {
    //                case 1:
    //                    if (cen + dec + uni == 1) {
    //                        milestxt = "Billon ";
    //                    } else if (cen + dec + uni > 1) {
    //                        milestxt = "Billones ";
    //                    }
    //                    break;
    //                case 2:
    //                    if (cen + dec + uni >= 1 & Conversion.Val(Strings.Mid(Numerofmt, 7, 3)) == 0) {
    //                        milestxt = "Mil Millones ";
    //                    } else if (cen + dec + uni >= 1) {
    //                        milestxt = "Mil ";
    //                    }
    //                    break;
    //                case 3:
    //                    if (cen + dec == 0 & uni == 1) {
    //                        milestxt = "Millon ";
    //                    } else if (cen > 0 | dec > 0 | uni > 1) {
    //                        milestxt = "Millones ";
    //                    }
    //                    break;
    //                case 4:
    //                    if (cen + dec + uni >= 1) {
    //                        milestxt = "Mil ";
    //                    }
    //                    break;
    //                case 5:
    //                    if (cen + dec + uni >= 1) {
    //                        milestxt = "";
    //                    }
    //                    break;
    //            }
    //            centenas = centenas + 1;
    //            //va formando el texto del importe en palabras
    //            txtPalabra = txtPalabra + textcen + textdec + textuni + milestxt;
    //            milestxt = "";
    //            textuni = "";
    //            textdec = "";
    //            textcen = "";
    //        }
    //        // agrega denominacion de moneda
    //        switch (Conversion.Val(Numerofmt)) {
    //            case 0:
    //                monedatxt = "Cero Pesos ";
    //                break;
    //            case 1:
    //                monedatxt = "Peso ";
    //                break;
    //            case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //1000000:
    //                monedatxt = "Pesos ";
    //                break;
    //            case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
    //1000000:
    //                monedatxt = "de Pesos ";
    //                break;
    //        }
    //        //txtPalabra = txtPalabra & monedatxt & "con " & Mid(Numerofmt, 17) & "/100"
    //        return txtPalabra.ToUpper();
    //    }
    //    private string Centena(int uni, int dec, int cen)
    //    {
    //        string functionReturnValue = null;
    //        switch (cen) {
    //            case 1:
    //                if (dec + uni == 0) {
    //                    cMontext = "cien ";
    //                } else {
    //                    cMontext = "ciento ";
    //                }
    //                break;
    //            case 2:
    //                cMontext = "doscientos ";
    //                break;
    //            case 3:
    //                cMontext = "trescientos ";
    //                break;
    //            case 4:
    //                cMontext = "cuatrocientos ";
    //                break;
    //            case 5:
    //                cMontext = "quinientos ";
    //                break;
    //            case 6:
    //                cMontext = "seiscientos ";
    //                break;
    //            case 7:
    //                cMontext = "setecientos ";
    //                break;
    //            case 8:
    //                cMontext = "ochocientos ";
    //                break;
    //            case 9:
    //                cMontext = "novecientos ";
    //                break;
    //            default:
    //                cMontext = "";
    //                break;
    //        }
    //        functionReturnValue = cMontext;
    //        cMontext = "";
    //        return functionReturnValue;
    //    }

    //    private string Decena(int uni, int dec)
    //    {
    //        string functionReturnValue = null;
    //        switch (dec) {
    //            case 1:
    //                switch (uni) {
    //                    case 0:
    //                        cMontext = "diez ";
    //                        break;
    //                    case 1:
    //                        cMontext = "once ";
    //                        break;
    //                    case 2:
    //                        cMontext = "doce ";
    //                        break;
    //                    case 3:
    //                        cMontext = "trece ";
    //                        break;
    //                    case 4:
    //                        cMontext = "catorce ";
    //                        break;
    //                    case 5:
    //                        cMontext = "quince ";
    //                        break;
    //                    case 6:
    //                    case 7:
    //                    case 8:
    //                    case 9:
    //                        cMontext = "dieci";
    //                        break;
    //                }
    //                break;
    //            case 2:
    //                if (uni == 0) {
    //                    cMontext = "veinte ";
    //                } else if (uni > 0) {
    //                    cMontext = "veinti";
    //                }
    //                break;
    //            case 3:
    //                cMontext = "treinta ";
    //                break;
    //            case 4:
    //                cMontext = "cuarenta ";
    //                break;
    //            case 5:
    //                cMontext = "cincuenta ";
    //                break;
    //            case 6:
    //                cMontext = "sesenta ";
    //                break;
    //            case 7:
    //                cMontext = "setenta ";
    //                break;
    //            case 8:
    //                cMontext = "ochenta ";
    //                break;
    //            case 9:
    //                cMontext = "noventa ";
    //                break;
    //            default:
    //                cMontext = "";
    //                break;
    //        }
    //        if (uni > 0 & dec > 2)
    //            cMontext = cMontext + "y ";
    //        functionReturnValue = cMontext;
    //        cMontext = "";
    //        return functionReturnValue;
    //    }

    //    private string Unidad(int uni, int dec)
    //    {
    //        string functionReturnValue = null;
    //        if (dec != 1) {
    //            switch (uni) {
    //                case 1:
    //                    cMontext = "un ";
    //                    break;
    //                case 2:
    //                    cMontext = "dos ";
    //                    break;
    //                case 3:
    //                    cMontext = "tres ";
    //                    break;
    //                case 4:
    //                    cMontext = "cuatro ";
    //                    break;
    //                case 5:
    //                    cMontext = "cinco ";
    //                    break;
    //            }
    //        }
    //        switch (uni) {
    //            case 6:
    //                cMontext = "seis ";
    //                break;
    //            case 7:
    //                cMontext = "siete ";
    //                break;
    //            case 8:
    //                cMontext = "ocho ";
    //                break;
    //            case 9:
    //                cMontext = "nueve ";
    //                break;
    //        }
    //        functionReturnValue = cMontext;
    //        cMontext = "";
    //        return functionReturnValue;
    //    }

    //    public string devolverLetradeNumero(int _numero)
    //    {
    //        return NumPalabra(Conversion.Val(_numero));

    //    }

        //private void PrintPageHandler(object sender, Printing.PrintPageEventArgs args)
        //{
        //    Font myFont = new Font("Microsoft San Serif", 10);

        //    //Dim pepe As New PaperSize("doc", 85, 30)

        //    //args.PageSettings.PaperSize = pepe

        //    //args.PageSettings.PaperSize.Height = 85

        //    args.Graphics.DrawString(textoAImprimir, new Font(myFont, FontStyle.Regular), Brushes.Black, coordenadaX, coordenadaY);
        //}
        /// <summary>
        /// Mandar mail desde VB.NET. Admite archivos adjuntos
        /// </summary>
        /// <param name="_direccionCorreo">Dirección de Envío. Separar con ';' para varias direcciones</param>
        /// <param name="_textoAsunto">Asunto del Mail</param>
        /// <param name="_textoEmail">Cuerpo del Mensaje</param>
        /// <returns>True si se ha mandado correctamento el mensaje</returns>
        /// <remarks></remarks>
        //Public Function mandarEmail(ByVal _direccionCorreo As String, _
        //                            Optional ByVal _textoAsunto As String = "", _
        //                            Optional ByVal _textoEmail As String = "") As Boolean

        //    Dim m_outLook As Outlook.Application

        //    Try
        //        '* Creamos un Objeto tipo Mail
        //        Dim objMail As Outlook.MailItem
        //        Dim sBodyLen As String
        //        Dim oAttachs As Outlook.Attachments '= objMail.Attachments
        //        Dim oAttach As Outlook.Attachment
        //        Dim TextoEmail As String = String.Empty
        //        Dim arrayAdjuntos() As String

        //        '* Inicializamos nuestra apliación OutLook
        //        m_outLook = New Outlook.Application

        //        '* Creamos una instancia de un objeto tipo MailItem
        //        objMail = m_outLook.CreateItem(Outlook.OlItemType.olMailItem)


        //        '* Asignamos las propiedades a nuestra Instancia del objeto
        //        If _direccionCorreo.Contains("@") = False Then
        //            MessageBox.Show("La direccion de correo es incorrecta. Falta '@'", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information)
        //            Return False
        //            Exit Function
        //        End If

        //        objMail.Importance = Outlook.OlImportance.olImportanceHigh
        //        objMail.To = _direccionCorreo
        //        objMail.Subject = _textoAsunto
        //        objMail.Body = _textoEmail

        //        '* Adjuntar Archivos, dentro del array 
        //        If MessageBox.Show("¿Desea adjuntar algún archivo?", mdPrincipal.Nombre_App, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        //            '* Datos adjuntos
        //            oAttachs = objMail.Attachments

        //            '* Dimensionar el Array
        //            ReDim arrayAdjuntos(0)
        //            '* Valor por defecto
        //            Dim valoresMatriz As Integer = 1

        //            arrayAdjuntos(0) = buscarArchivos()
        //            While MessageBox.Show("¿Desea adjuntar otro archivo más?", "Adjuntar Varios Archivos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
        //                '* Dimensionar sin borrar datos
        //                ReDim Preserve arrayAdjuntos(valoresMatriz)

        //                arrayAdjuntos(valoresMatriz) = buscarArchivos()
        //                valoresMatriz += 1
        //            End While

        //            Dim adjunto As String = String.Empty
        //            Dim adjunto2 As String = String.Empty

        //            '* Buscar los adjuntos en las posiciones del array para insertarlos en el mail
        //            For i As Integer = 0 To arrayAdjuntos.Length - 1
        //                adjunto = arrayAdjuntos(i)
        //                If adjunto.Trim <> Nothing Then
        //                    '* Evitar adjuntos duplicados
        //                    For j As Integer = 0 To arrayAdjuntos.Length - 1
        //                        If j <> i Then
        //                            adjunto2 = arrayAdjuntos(j)
        //                            If adjunto = adjunto2 Then
        //                                arrayAdjuntos(j) = String.Empty
        //                            End If
        //                        End If
        //                    Next
        //                    adjunto = arrayAdjuntos(i)
        //                    If adjunto.Trim <> String.Empty Then
        //                        sBodyLen = objMail.Body.Length
        //                        oAttach = oAttachs.Add(adjunto, , sBodyLen + 1, )
        //                    End If
        //                End If
        //            Next
        //        End If

        //        '* Enviamos nuestro Mail y listo!
        //        objMail.Send()

        //        '* Desplegamos un mensaje indicando que todo fue exitoso
        //        MessageBox.Show("Correo Enviado", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information)

        //        Return True
        //    Catch ex As Exception
        //        '* Si se produce algun Error Notificar al usuario
        //        MessageBox.Show("Error enviando mail")
        //        Return False
        //    Finally
        //        m_outLook = Nothing
        //    End Try
        //End Function
        /// <summary>
        /// Abre una ventana de windows para buscar archivos
        /// </summary>
        /// <param name="_directorioOrigen">Directorio Opcional donde se inicia a buscar el archivo</param>
        /// <returns>Devuelve la ruta y nombre del archivo</returns>
        /// <remarks></remarks>
        public string buscarArchivos(string _directorioOrigen = "")
        {

            try {
                string respuesta = string.Empty;
                System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();

                if (_directorioOrigen.Trim() != string.Empty) {
                    openFile.InitialDirectory = _directorioOrigen;
                }
                openFile.ShowDialog();
                respuesta = openFile.FileName;

                return respuesta;
            } catch (System.Exception ex) {
                MessageBox.Show("Error al buscar archivo", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        //* Función auxiliar para crearZIP que copia los bytes de un inputStream a un outputStream
        public static void CopyStream(java.io.InputStream inputStream, ref java.io.OutputStream outputStream)
        {
            //sbyte buffer = -102;
            //int got = 0;
            //got = inputStream.read(buffer, 0, buffer.);
            //while (got > 0) {
            //    outputStream.write(buffer, 0, got);
            //    got = inputStream.read(buffer, 0, buffer.Length);
            //}
            //outputStream.flush();
        }
        /// <summary>
        /// Crea un Archivo ZIP con el array de archivos que pasamos a la función
        /// </summary>
        /// <param name="zipPath">Path del archivo ZIP. Debe existir; si no, no crea nada</param>
        /// <param name="zipName">Archivo ZIP. Si no existe, lo crea</param>
        /// <param name="files2Zip">Array de archivos a introducir en el ZIP</param>
        /// <returns>True si todo ha salido bien</returns>
        /// <remarks></remarks>
        public bool crearZip(string zipPath, string zipName, params string[] files2Zip)
        {
            //ZipOutputStream zipOutputStream = null;
            //ZipEntry zipEntry = default(ZipEntry);
            //java.io.FileInputStream fileInputStream = default(java.io.FileInputStream);
            //string file2Zip = null;
            //object auxObj = null;
            //* Contiene el valor que la función retornara
            dynamic created = true;
            //try {
            //    //* Comprobamos que el directorio Exista
            //    if (System.IO.Directory.Exists(zipPath) == false) {
            //        MessageBox.Show("El directorio donde se va a crear el Archivo ZIP no existe", "crearZIP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    if (zipPath.EndsWith("\\") == false) {
            //        zipPath = zipPath + "\\";
            //    }
            //    zipPath = zipPath + zipName;

            //    //* Crea el fichero zip
            //    zipOutputStream = new ZipOutputStream(new java.io.FileOutputStream(zipPath));

            //    if ((files2Zip != null)) {
            //        foreach (object auxObj_loopVariable in files2Zip) {
            //            auxObj = auxObj_loopVariable;
            //            file2Zip = Convert.ToString(auxObj);
            //            zipEntry = new ZipEntry(System.IO.Path.GetFileName(file2Zip));
            //            //* Comprimimos los datos
            //            zipEntry.setMethod(zipEntry.DEFLATED);

            //            //* Añadimos el fichero al zip
            //            zipOutputStream.putNextEntry(zipEntry);

            //            try {
            //                fileInputStream = new java.io.FileInputStream(file2Zip);
            //                try {
            //                    CopyStream(fileInputStream, ref zipOutputStream);
            //                } finally {
            //                    fileInputStream.close();
            //                }
            //            } catch (Exception e) {
            //                created = false;
            //            } finally {
            //                zipOutputStream.closeEntry();
            //            }
            //        }
            //    }
            //} catch (Exception e) {
            //    MessageBox.Show(e.Message);

            //    created = false;
            //} finally {
            //    if ((zipOutputStream != null)) {
            //        zipOutputStream.close();
            //    }
            //}
            return created;
        }

        // ''Function envioSMS()
        // ''    Dim objSendSMS As New SMSSend
        // ''    'Defino las propiedades
        // ''    objSendSMS.setHost("http://217.76.128.8:8080/smsarsys")

        // ''    objSendSMS.setAccount("solucione@terra.es")
        // ''    objSendSMS.setPwd("Auryn99")
        // ''    objSendSMS.setText("Esta es una prueba de los mensajes estos")
        // ''    objSendSMS.setTo("628072604")
        // ''    objSendSMS.setFrom("Solucione S.C.")      ' Parámetro opcional

        // ''    'Recupero los valores establecidos
        // ''    'Account = objSendSMS.getAccount
        // ''    'Pwd = objSendSMS.getPwd
        // ''    'Texto = objSendSMS.getText
        // ''    'Para = objSendSMS.getTo
        // ''    'Remite = objSendSMS.getFrom

        // ''    'Envío del mensaje


        // ''    Dim resultado As String = objSendSMS.Send

        // ''    'Resultado de la operación
        // ''    Dim getResult As String = objSendSMS.getResult
        // ''    Dim getDescription As String = objSendSMS.getDescription
        // ''    Dim getCredit As String = objSendSMS.getCredit

        // ''    MessageBox.Show(resultado & "; " & getResult & "; " & getDescription & "; " & getCredit)
        // ''End Function

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 0;
            //ev.MarginBounds.Left
            float topMargin = 0;
            //ev.MarginBounds.Top
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = 26;
            // una linea menos tiene 26 'ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

            // Print each line of the file.
            while (count < linesPerPage) {
                line = streamToPrint.ReadLine();
                if (line == null) {
                    break; // TODO: might not be correct. Was : Exit While
                }
                yPos = topMargin + count * printFont.GetHeight(ev.Graphics);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count += 1;
            }

            // If more lines exist, print another page.
            if ((line != null)) {
                ev.HasMorePages = true;
            } else {
                ev.HasMorePages = false;
            }
        }
        /// <summary>
        /// Devuelve la resta del intervalo de fechas pasado con la Fecha Actual del sistema
        /// </summary>
        /// <param name="_Fecha">Fecha desde la cual queremos hacer el cálculo</param>
        /// <param name="_intervalo">Intervalo Dia, Mes o Año</param>
        /// <returns>Número de días, meses o años desde la cual hacemos el cálculo</returns>
        /// <remarks></remarks>
        //public object devolverDiferenciasFecha(System.DateTime _Fecha, DateInterval _intervalo)
        //{
        //    int devuelve = 0;

        //    if (_intervalo == DateInterval.Day)
        //    {
        //        devuelve = DateDiff(_intervalo, _Fecha, Now);
        //    }
        //    if (_intervalo == DateInterval.Month)
        //    {
        //        devuelve = DateDiff(_intervalo, _Fecha, Now);
        //    }
        //    if (_intervalo == DateInterval.Year)
        //    {
        //        devuelve = DateDiff(_intervalo, _Fecha, Now);
        //    }

        //    return devuelve;
        //}
        /// <summary>
        /// Borra o Inicializa los campos contenidos en un Objecto (Panel, tab, formulario, etc...)
        /// </summary>
        /// <param name="_objeto">Objeto donde están los controles a inicializar</param>
        /// <remarks></remarks>

        public void borrarCampos(object _objeto)
        {
            //foreach (Control c in _objeto.GetType().Controls) {
            //    ComboBox comboAux = new ComboBox();
            //    CheckBox checkAux = new CheckBox();
            //    RadioButton rdaux = new RadioButton();

            //    DataGridView grdAux = new DataGridView();
            //    if (c is ComboBox) {
            //        comboAux = c;
            //        comboAux.SelectedValue = 0;
            //    }
            //    if (c is CheckBox) {
            //        checkAux = c;
            //        checkAux.Checked = false;
            //    }
            //    if (c is RadioButton) {
            //        rdaux = c;
            //        rdaux.Checked = false;
            //    }
            //    if (c is TextBox) {
            //        c.Text = string.Empty;
            //    }
            //    if (c is DataGridView) {
            //        grdAux.Rows.Clear();
            //    }
            //}
        }
        /// <summary>
        /// Carga Documento en campo de SQL de modo image en la base de datos
        /// </summary>
        /// <param name="_id_key">Id de la fila de la base de datos</param>
        /// <param name="_ruta">Ruta del directorio del archivo</param>
        /// <param name="_archivo">Archivo a cargar</param>
        /// <param name="_extension">Extension del archivo</param>
        /// <param name="_tabla_documento">Tabla donde se va a introducir el documento</param>
        /// <param name="_nombre_id_key">Nombre de la columna del id_key que alberga la tabla</param>
        /// <remarks></remarks>
        public void cargarDocumentoSQL(int _id_key, string _ruta_y_documento, string _ruta, string _archivo, string _extension, string _tabla_documento, string _nombre_id_key)
        {
            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            try {
                if (_tabla_documento.Trim() == string.Empty) {
                    MessageBox.Show("Error al cargar el Documento en la Base de Datos. El valor de tabla_documento no puede ser vacío", "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_nombre_id_key.Trim() == string.Empty) {
                    MessageBox.Show("Error al cargar el Documento en la Base de Datos. El valor de nombre_id no puede ser cero", "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                SqlCommand cmd = new SqlCommand("update " + _tabla_documento + " set documento = @documento, " + " nombre_documento = @nombre_documento, " + " extension_documento = @extension_documento, " + " ruta = @ruta_documento " + " where " + _nombre_id_key + " = @id_key ", conSQL);

                clsSQL clsSQL = new clsSQL();
                string selectFinal = string.Empty;

                string strImageFilePath = _ruta_y_documento;

                FileStream fsImageFile = new FileStream(strImageFilePath, FileMode.Open, FileAccess.Read);
                byte[] bytImageData = new byte[fsImageFile.Length];
                fsImageFile.Read(bytImageData, 0, bytImageData.Length);
                fsImageFile.Close();

                SqlParameter documento = new SqlParameter("@documento", SqlDbType.Image, bytImageData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytImageData);
                SqlParameter nombre_documento = new SqlParameter("@nombre_documento", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _archivo);
                SqlParameter extension_documento = new SqlParameter("@extension_documento", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _extension);
                SqlParameter id_key_nota = new SqlParameter("@id_key", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _id_key);
                SqlParameter ruta_documento = new SqlParameter("@ruta_documento", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _ruta);

                cmd.Parameters.Add(documento);
                cmd.Parameters.Add(nombre_documento);
                cmd.Parameters.Add(extension_documento);
                cmd.Parameters.Add(id_key_nota);
                cmd.Parameters.Add(ruta_documento);

                conSQL.Open();
                cmd.ExecuteNonQuery();

                grabarLogUsuario("grabaDocumentoSQL", "Documento subido a la BBDD");
                MessageBox.Show("Archivo Cargado OK", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conSQL.Close();
            }
        }
        /// <summary>
        /// Muestra el documento de la Base de Datos SQL
        /// </summary>
        /// <param name="_id_key">Id de la fila de la tabla donde se encuentra el documento</param>
        /// <param name="_tabla_documento">tabla SQL donde se encuentra el documento</param>
        /// <param name="_nombre_id_key">Nombre de la columna Id de la fila donde se encuentra el documento</param>
        /// <remarks></remarks>
        public void verDocumentoSQL(int _id_key, string _tabla_documento, string _nombre_id_key)
        {
            clsSQL clsSQL = new clsSQL();
            SqlConnection cn = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            FileStream _FS = null;

            try {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = clsSQL.devolverDataTable("select documento,nombre_documento from " + _tabla_documento + " where " + _nombre_id_key + " = " + _id_key);
                //da.Fill(ds, "Image")
                byte[] bytImageData = null;
                string nombre_documento = string.Empty;

                foreach (DataRow dr in dt.Rows) {
                    nombre_documento = dr[1].ToString();
                    if (nombre_documento == string.Empty) {
                        return;
                    }
                    bytImageData = Encoding.ASCII.GetBytes(dr[0].ToString());
                }

                //Crear un nuevo archivo

                if (nombre_documento == string.Empty) {
                    return;
                }

                
                
                _FS = new FileStream(Path.GetTempPath() + "\\" + nombre_documento, FileMode.Create, FileAccess.Write);
                //_FS = New FileStream("", FileMode.Open, FileAccess.Read)
                //escribirlo a partir del array intermedio

                _FS.Write(bytImageData, 0, bytImageData.Length);

                _FS.Close();
                //Cerrar el fstrm

                _FS.Dispose();
                //Liberarlo

                Process.Start(Path.GetTempPath() + "\\" + nombre_documento);
                //End If
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "verDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void verDocumentoSQLSelect(string _select)
        {
            clsSQL clsSQL = new clsSQL();
            SqlConnection cn = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            FileStream _FS = null;

            try {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = clsSQL.devolverDataTable(_select);
                //da.Fill(ds, "Image")
                byte[] bytImageData = null;
                string nombre_documento = string.Empty;

                foreach (DataRow dr in dt.Rows) {
                    nombre_documento = dr["nombre_documento"].ToString();
                    if (nombre_documento == string.Empty) {
                        return;
                    }
                    bytImageData = Encoding.ASCII.GetBytes(dr["documento"].ToString());
                }

                if (nombre_documento == string.Empty) {
                    return;
                }

                //Crear un nuevo archivo
                _FS = new FileStream(Path.GetTempPath() + "\\" + nombre_documento, FileMode.Create, FileAccess.Write);
                //_FS = New FileStream("", FileMode.Open, FileAccess.Read)
                //escribirlo a partir del array intermedio

                _FS.Write(bytImageData, 0, bytImageData.Length);

                _FS.Close();
                //Cerrar el fstrm

                _FS.Dispose();
                //Liberarlo



                Process.Start(Path.GetTempPath() + "\\" + nombre_documento);
                //End If
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "verDocumentoSQLSelect.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool borrarDocumentoSQL(int _id_key, string _tabla_documento, string _nombre_id_key)
        {
            clsSQL clsSQL = new clsSQL();

            try {
                if (clsSQL.ejecutarQuery("update " + _tabla_documento + " set documento = null, " + " nombre_documento = '', " + " extension_documento = '', " + " ruta = '' " + " where " + _nombre_id_key + " = " + _id_key) == false) {
                    return false;
                }

                grabarLogUsuario("borrarDocumentoSQL", "Documento borrado de la BBDD; tabla: " + _tabla_documento + "; id=" + _id_key);
                return true;
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public void cargarImagen(int _id_key, string _Ruta, string _archivo, string _extension)
        {
            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            try {
                SqlCommand cmd = new SqlCommand("update equipos_medida_notas set documento = @documento, " + " nombre_documento = @nombre_documento, " + " extension_documento = @extension_documento " + " where id_key = @id_key ", conSQL);
                clsSQL clsSQL = new clsSQL();
                string selectFinal = string.Empty;

                string strImageFilePath = _Ruta;

                FileStream fsImageFile = new FileStream(strImageFilePath, FileMode.Open, FileAccess.Read);
                byte[] bytImageData = new byte[fsImageFile.Length];
                fsImageFile.Read(bytImageData, 0, bytImageData.Length);
                fsImageFile.Close();

                SqlParameter documento = new SqlParameter("@documento", SqlDbType.Image, bytImageData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytImageData);
                SqlParameter nombre_documento = new SqlParameter("@nombre_documento", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _archivo);
                SqlParameter extension_documento = new SqlParameter("@extension_documento", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _extension);
                SqlParameter id_key_nota = new SqlParameter("@id_key", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _id_key);

                cmd.Parameters.Add(documento);
                cmd.Parameters.Add(nombre_documento);
                cmd.Parameters.Add(extension_documento);
                cmd.Parameters.Add(id_key_nota);

                conSQL.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Archivo Cargado OK", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conSQL.Close();
            }

        }

        public void verImagen(int _id_key)
        {
            clsSQL clsSQL = new clsSQL();
            SqlConnection cn = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            FileStream _FS = null;


            System.Data.DataTable dt = new System.Data.DataTable();
            dt = clsSQL.devolverDataTable("select documento,nombre_documento from equipos_medida_notas where id_key = " + _id_key);
            //da.Fill(ds, "Image")
            byte[] bytImageData = null;
            string nombre_documento = string.Empty;

            foreach (DataRow dr in dt.Rows) {
                nombre_documento = dr[1].ToString();
                if (nombre_documento == string.Empty) {
                    return;
                }
                bytImageData = Encoding.ASCII.GetBytes(dr[0].ToString());
            }
            //bytImageData = devolverParametroSelect("select imagen from usr_transportes.image where id_key = 1")

            //Dim RowCount As Integer = 
            //ds.Tables("Image").Rows.Count
            //If RowCount > 0 Then
            //Dim bytImageData() As Byte = ds.Tables("Image").Rows(0)("Picture")
            //Dim stmImageData As New MemoryStream(bytImageData)
            //MessageBox.Show("Eo")
            //PictureBox1.Image = Image.FromStream(stmImageData)
            //TextBox3.Text = ds.Tables("Image").Rows(0)("Id")
            //TextBox3.Visible = True
            //Label3.Visible = True
            //Dim Buffer() As Byte = Archivos.Recuperar(Nombre).Rows(0).Item("Imagen")

            //Crear un nuevo archivo
            //
            _FS = new FileStream("c:\\temp\\" + nombre_documento, FileMode.Create, FileAccess.Write);
            //_FS = New FileStream("", FileMode.Open, FileAccess.Read)
            //escribirlo a partir del array intermedio

            _FS.Write(bytImageData, 0, bytImageData.Length);

            _FS.Close();
            //Cerrar el fstrm

            _FS.Dispose();
            //Liberarlo

            Process.Start("c:\\temp\\" + nombre_documento);
            //End If
        }


        //Esta función convierte la imagen a Byte
        public byte[] ImageToByte(Image pImagen)
        {
            byte[] mImage = null;
            try {
                if ((pImagen != null)) {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pImagen.Save(ms, pImagen.RawFormat);
                    mImage = ms.GetBuffer();
                    ms.Close();
                    return mImage;
                }
            } catch {
                return mImage;
            }
            return mImage;
        }

        /// <summary>
        /// Carga Documento en campo de SQL de modo image en la base de datos
        /// </summary>
        /// <param name="_id_key">Id de la fila de la base de datos</param>
        /// <param name="_ruta">Ruta del directorio del archivo</param>
        /// <param name="_archivo">Archivo a cargar</param>
        /// <param name="_extension">Extension del archivo</param>
        /// <param name="_tabla_documento">Tabla donde se va a introducir el documento</param>
        /// <param name="_nombre_id_key">Nombre de la columna del id_key que alberga la tabla</param>
        /// <remarks></remarks>
        public void cargarDocumentoSQL2(int _id_key, string _nombre_id_key, string _ruta_y_documento, string _ruta, string _archivo, string _extension, string _tabla_documento, int _id_Carpeta, string _descripcion = "")
        {
            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            string respuesta = string.Empty;

            try {
                if (_tabla_documento.Trim() == string.Empty) {
                    MessageBox.Show("Error al cargar el Documento en la Base de Datos. El valor de tabla_documento no puede ser vacío", "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_nombre_id_key.Trim() == string.Empty) {
                    MessageBox.Show("Error al cargar el Documento en la Base de Datos. El valor de nombre_id no puede ser cero", "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Dim cmd As New SqlCommand("update " & _tabla_documento & " set documento = @documento, " & _
                //                                                            " nombre_documento = @nombre_documento, " & _
                //                                                            " extension_documento = @extension_documento, " & _
                //                                                            " ruta_documento = @ruta_documento " & _
                //                                                            " where " & _nombre_id_key & " = @id_key ", conSQL)
                SqlCommand cmd = new SqlCommand("insert into " + _tabla_documento + " (documento,nombre_documento,ruta_documento,extension_documento,id_key_carpeta," + _nombre_id_key + ",descripcion,id_key_usuario) " + " values(@documento,@nombre_documento,@ruta_documento,@extension_documento,@id_key_carpeta,@" + _nombre_id_key + ",@descripcion,@id_key_usuario)", conSQL);

                clsSQL clsSQL = new clsSQL();
                string selectFinal = string.Empty;

                string strImageFilePath = _ruta_y_documento;

                FileStream fsImageFile = new FileStream(strImageFilePath, FileMode.Open, FileAccess.Read);
                byte[] bytImageData = new byte[fsImageFile.Length];
                fsImageFile.Read(bytImageData, 0, bytImageData.Length);
                fsImageFile.Close();

                SqlParameter documento = new SqlParameter("@documento", SqlDbType.Image, bytImageData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytImageData);
                SqlParameter nombre_documento = new SqlParameter("@nombre_documento", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _archivo);
                SqlParameter extension_documento = new SqlParameter("@extension_documento", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _extension);
                SqlParameter id_key = new SqlParameter("@" + _nombre_id_key, SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _id_key);
                SqlParameter id_key_carpeta = new SqlParameter("@id_key_carpeta", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _id_Carpeta);
                SqlParameter ruta_documento = new SqlParameter("@ruta_documento", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _ruta);
                SqlParameter descripcion = new SqlParameter("@descripcion", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, _descripcion);
                SqlParameter id_key_usuario = new SqlParameter("@id_key_usuario", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mdPrincipal.Id_Usuario);

                cmd.Parameters.Add(documento);
                cmd.Parameters.Add(nombre_documento);
                cmd.Parameters.Add(extension_documento);
                cmd.Parameters.Add(id_key);
                cmd.Parameters.Add(id_key_carpeta);
                cmd.Parameters.Add(ruta_documento);
                cmd.Parameters.Add(descripcion);
                cmd.Parameters.Add(id_key_usuario);

                conSQL.Open();
                cmd.ExecuteNonQuery();

                //respuesta = clsSQL.ejecutarSP("SP_Man_IAP_Documentos", "@opcion=1=System.Int32", _
                //                                                        "@id_key_documento=0=System.Int32", _
                //                                                        "@documento=" & bytImageData & "=System.Image", _
                //                                                        "@nombre_documento=" & _archivo & "=System.String", _
                //                                                        "@extension_documento=" & _extension & "=System.String")


                grabarLogUsuario("grabaDocumentoSQL", "Documento subido a la BBDD");
                MessageBox.Show("Archivo Cargado OK", mdPrincipal.Nombre_App, MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "cargarDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conSQL.Close();
            }
        }
        /// <summary>
        /// Muestra el documento de la Base de Datos SQL
        /// </summary>
        /// <param name="_select">Select con la tabla donde está el documento a mostrar</param>
        /// <remarks></remarks>
        public string devolverRutaDocumentoSQL(string _select)
        {
            clsSQL clsSQL = new clsSQL();
            SqlConnection cn = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            FileStream _FS = null;
            string devuelve = string.Empty;

            try {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = clsSQL.devolverDataTable(_select);
                byte[] bytImageData = null;
                string nombre_documento = string.Empty;

                foreach (DataRow dr in dt.Rows) {
                    nombre_documento = dr["nombre_documento"].ToString();
                    if (nombre_documento == string.Empty) {
                        return string.Empty;
                    }
                    bytImageData = Encoding.ASCII.GetBytes(dr["documento"].ToString());
                }
                //Crear un nuevo archivo

                if (nombre_documento == string.Empty) {
                    return string.Empty;
                }

                _FS = new FileStream(Path.GetTempPath() + "\\" + nombre_documento, FileMode.Create, FileAccess.Write);
                //_FS = New FileStream("", FileMode.Open, FileAccess.Read)
                //escribirlo a partir del array intermedio

                _FS.Write(bytImageData, 0, bytImageData.Length);

                _FS.Close();
                //Cerrar el fstrm

                _FS.Dispose();
                //Liberarlo

                //Process.Start(Path.GetTempPath() & "\" & nombre_documento)
                devuelve = Path.GetTempPath() + "\\" + nombre_documento;
                //End If
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "devolverRutaDocumentoSQL.Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                devuelve = string.Empty;
            }

            return devuelve;

        }
        /// <summary>
        /// Borrar el documento de la fila de la base de datos
        /// </summary>
        /// <param name="_id_key">Valor de la fila a borrar</param>
        /// <returns>True si no ha habido fallos</returns>
        /// <remarks></remarks>
        public bool borrarDocumentoSQL2(int _id_key)
        {
            //Function borrarDocumentoSQL(ByVal _id_key As Integer, ByVal _tabla_documento As String, ByVal _nombre_id_key As String) As Boolean
            clsSQL clsSQL = new clsSQL();

            try {
                //If clsSQL.ejecutarQuery("update " & _tabla_documento & " set documento = null, " & _
                //                                                    " nombre_documento = '', " & _
                //                                                    " extension_documento = '', " & _
                //                                                    " ruta_documento = '' " & _
                //                                                    " where " & _nombre_id_key & " = " & _id_key) = False Then

                if (clsSQL.ejecutarQuery("delete from iap_documentos where id_key_documento = " + _id_key) == false) {
                    return false;
                }

                //grabarLogUsuario("borrarDocumentoSQL", "Documento borrado de la BBDD; tabla: " & _tabla_documento & "; id=" & _id_key)
                return true;
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        /// <summary>
        /// Completa un textBox mientras escribes pasandole un select de datos
        /// </summary>
        /// <param name="tBox">Textbox en el que estas trabajando</param>
        /// <param name="_select">Select del que quieres que saque los datos (Sólo saca 1 parámetro)</param>
        /// <param name="key">Tecla pulsada</param>
        /// <param name="_NoHacerNada">False por defecto, True si viene de un evento que no queremos que haga nada</param>
        /// <remarks></remarks>

        public void autoCompletarTextBox(object tBox, string _select, System.Windows.Forms.Keys key, bool _NoHacerNada = false)
        {
            //if (_NoHacerNada == true) {
            //    return;
            //}

            //clsSQL clsSQL = new clsSQL();
            //string respuesta = string.Empty;
            //int pos_SelStart = 0;

            //switch (key) {
            //    case Keys.Back:
            //    case Keys.Delete:
            //    case Keys.Space:
            //        // ..si hay texto en el Textbox   
            //        //If tBox.Text.Length <> 0 Then
            //        return;

            //        break;
            //        //End If
            //}

            //if (tBox.Text() == string.Empty)
            //    return;

            //respuesta = Qnull(clsSQL.devolverParametroSelect(_select));

            //pos_SelStart = tBox.SelectionStart;
            ////Asignamos el valor de la celda actual al textbox   
            //if (respuesta != string.Empty) {
            //    tBox.Text = respuesta;
            //}
            ////Indicamos el comienzo de la selección   
            //tBox.SelectionStart = pos_SelStart;
            ////seleccionamos la porción de texto en el Text  
            //if (respuesta.Length > pos_SelStart) {
            //    tBox.SelectionLength = respuesta.Length - pos_SelStart;
            //}
        }


        //public void autocompletarCeldaGrid(DataGridView grid, int iCelda, int iFila, string _select, System.Windows.Forms.Keys key, bool _NoHacerNada = false)
        //{
        //    if (_NoHacerNada == true) {
        //        return;
        //    }

        //    clsSQL clsSQL = new clsSQL();
        //    string respuesta = string.Empty;
        //    int pos_SelStart = 0;

        //    switch (key) {
        //        case Keys.Back:
        //        case Keys.Delete:
        //        case Keys.Space:
        //            // ..si hay texto en el Textbox   
        //            //If tBox.Text.Length <> 0 Then
        //            return;

        //            break;
        //            //End If
        //    }

        //    if (Qnull(grid.Rows[iFila].Cells[iCelda].Value) == string.Empty)
        //        return;

        //    respuesta = Qnull(clsSQL.devolverParametroSelect(_select));

        //    //'pos_SelStart = tBox.SelectionStart
        //    //Asignamos el valor de la celda actual al textbox   
        //    if (respuesta != string.Empty) {
        //        grid.CurrentRow.Cells[iCelda].Value = respuesta;
        //    }
        //    //Indicamos el comienzo de la selección   
        //    //tBox.SelectionStart = pos_SelStart
        //    //'seleccionamos la porción de texto en el Text  
        //    //If respuesta.Length > pos_SelStart Then
        //    //    tBox.SelectionLength = respuesta.Length - pos_SelStart
        //    //End If
        //}

        /// <summary>
        /// Exporta a Excel el contenido de un grid
        /// </summary>
        /// <param name="grid">Data grid que queremos exportar</param>
        /// <param name="_nombreExcel">Nombre para mostrar en la hoja excel</param>
        /// <param name="rutaArchivo">Ruta del archivo</param>
        /// <remarks></remarks>
        public void exportarAExcel(DataGridView grid, string _nombreExcel = "", string rutaArchivo = "")
        {
            //'Create an instance of Excel 2003, add a workbook, 
            //'and let the user know what's happening
            //'Dim xl As New Excel.Application
            System.Data.DataTable dt = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            xl.Workbooks.Add();
            xl.ActiveSheet.name = _nombreExcel;
            //"Clientes"
            xl.Visible = true;
            xl.Range["A1"].Value = "Cargando Datos, Espere....";
            int columnas = 0;
            Color color ;

            try {
                for (int iCol = 0; iCol <= grid.ColumnCount - 1; iCol++) {
                    //' oculta las columanas que no se ven
                    if (grid.Columns[iCol].Visible == true) {
                        if (dt.Columns.Contains(grid.Columns[iCol].HeaderText) == false) {
                            dt.Columns.Add(grid.Columns[iCol].HeaderText);
                        } else {
                            dt.Columns.Add(grid.Columns[iCol].HeaderText + "(" + iCol + ")");
                        }
                    }
                }

                for (int iRow = 0; iRow <= grid.RowCount - 1; iRow++) {
                    string filaEntera = string.Empty;
                    object valores = null;
                    //dt.Columns.Count - 1
                    for (int iCol = 0; iCol <= grid.Columns.Count - 1; iCol++) {
                        //' oculta las columanas que no se ven
                        if (grid.Columns[iCol].Visible == true) {
                            if (grid.Rows[iRow].Cells[iCol].Value is Bitmap) {
                                valores = "";
                            } else {
                                valores = grid.Rows[iRow].Cells[iCol].Value;
                                //.ToString.Replace("|", "/")

                                //grid.Rows(iRow).Cells(iCol).Selected = True
                                //color = grid.CurrentRow.DefaultCellStyle.BackColor
                                //MessageBox.Show(color.Name)

                            }
                            int a = 0;
                            if (int.TryParse(valores.ToString(), out a) == false) {
                                valores = " " + valores;
                            }

                            //If filaEntera.Length + valores.ToString.Length > 35126 Then
                            //MessageBox.Show("los datos seleccionados superan el maximo permitido", "Exportaciones a excell", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            //Else
                            filaEntera = filaEntera + valores + "|";
                            //End If


                        }
                    }
                    filaEntera = filaEntera.Trim();
                    filaEntera = filaEntera.Substring(0, filaEntera.Length - 1);

                    string[] matrizFila = filaEntera.Split('|');
                    dt.Rows.Add(matrizFila);
                }

                xl.ScreenUpdating = false;

                //DataColumn dc = default[DataColumn];
                Int32 iCols = 0;
                foreach (DataColumn dc in dt.Columns) {
                    xl.Range["A1"].Offset[0, iCols].Value = dc.ColumnName;
                    iCols += 1;
                }

                //Add the data
                Int32 iRows = default(Int32);
                for (iRows = 0; iRows <= dt.Rows.Count - 1; iRows++) {
                    xl.Range["A2"].Offset[iRows].Resize[1, iCols].Value = dt.Rows[iRows].ItemArray;                }
            } catch (System.Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xl.ScreenUpdating = true;
                return;
            } finally {
                xl.ScreenUpdating = true;
            }

            //Make the sheet pretty
            var _with1 = xl.ActiveSheet.Range("A1");
            _with1.AutoFilter();
            _with1.AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple);

            xl = null;

        }
        /// <summary>
        /// Mostrar pantalla de Ms. Outlook para mandar mail
        /// </summary>
        /// <param name="_dtAdjuntos">Tabla de Archivos Adjuntos</param>
        /// <param name="_direccion">Dirección a la que queremos mandar mail</param>
        /// <param name="_asunto">Asunto del mail</param>
        /// <param name="_textoCorreo">Texto del correo que aparecerá en el mensaje</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public void enviarMail(System.Data.DataTable _dtAdjuntos, string _direccion = "", string _asunto = "", string _textoCorreo = "")
        {



            Microsoft.Office.Interop.Outlook.MailItem objMail = default(Microsoft.Office.Interop.Outlook.MailItem);

            try {
                //* Creamos un Objeto tipo Mail
                string directorio = string.Empty;
                string sBodyLen = null;
                Microsoft.Office.Interop.Outlook.Attachments oAttachs = default(Microsoft.Office.Interop.Outlook.Attachments);
                //= objMail.Attachments
                Microsoft.Office.Interop.Outlook.Attachment oAttach = default(Microsoft.Office.Interop.Outlook.Attachment);
                string TextoEmail = string.Empty;
                clsSQL clsSQL = new clsSQL();
                clsFunciones clsFunc = new clsFunciones();
                string Texto = null;
                string direccionCorreo = "";
                bool Primero = true;

                string nombre_completo = clsSQL.devolverParametroSelect("select rtrim(nombre) + ' ' + rtrim(apellido1) from seg_usuarios where id_key_usuario = " + mdPrincipal.Id_Usuario);



                //* Inicializamos nuestra apliación OutLook 
                Microsoft.Office.Interop.Outlook.Application m_OutLook = new Microsoft.Office.Interop.Outlook.Application();

                //* Creamos una instancia de un objeto tipo MailItem 
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                direccionCorreo = _direccion.Trim();

                objMail.To = direccionCorreo;
                objMail.Subject = _asunto.Trim();
                //TextoEmail = "CORREO ENVIADO DESDE EL SISTEMA DE GESTION" & Chr(13) + Chr(10) & Chr(13) + Chr(10)
                TextoEmail = (char)13 + (char)10 + _textoCorreo;

                //objMail.Body = TextoEmail
                //objMail.Importance = IIf(Me.ck_importancia.Checked = True, Outlook.OlImportance.olImportanceHigh, Outlook.OlImportance.olImportanceNormal)
                objMail.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                //objMail.ReadReceiptRequested = True

                //'datos adjuntos
                foreach (DataRow dr in _dtAdjuntos.Rows) {
                    string sSource = dr[0].ToString();
                    sBodyLen = objMail.HTMLBody.Length.ToString();
                    oAttachs = objMail.Attachments;
                    oAttach = oAttachs.Add(sSource,"" , Convert.ToInt32(sBodyLen) + 1, "");
                }

                objMail.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;

                //* Poner el texto junto con la firma en HTML, casi ná... lo que piden
                switch (mdPrincipal.Id_Usuario) {
                    case 46:
                        //ajimenez
                        objMail.HTMLBody = "<html><style>body{font-family:'Calibri','sans-serif';font-size:11.0pt;color:navy}</style>" + "<body>" + TextoEmail + "<br><br><br>Ana Jiménez Cardona <br> " + "Jefa Adjunta de Compras / Deputy Purchasing Manager <br>" + "Teléfono directo / Phone number: + 34 976 45 49 40 (Ext. 250) / +34 976 45 48 90<br>" + "Visite nuestra página web: <a href='http://www.transporzara.com' target='_blank'>www.transporzara.com</a>";
                        break;
                    case 64:
                        //mpons
                        objMail.HTMLBody = "<html><style>body{font-family:'Calibri','sans-serif';font-size:11.0pt;color:navy}</style>" + "<body>" + TextoEmail + "<br><br><br>Miguel Pons <br> " + "Departamento de Compras / Purchasing Department<br>" + "Teléfono directo / Phone number: + 34 976 45 49 40 (Ext. 259) / +34 976 45 48 90<br>" + "Visite nuestra página web: <a href='http://www.transporzara.com' target='_blank'>www.transporzara.com</a>";

                        break;
                    case 19:
                        //jlsalvador
                        objMail.HTMLBody = "<html><style>body{font-family:'Calibri','sans-serif';font-size:11.0pt;color:navy}</style>" + "<body>" + TextoEmail + "<br><br><br>Jose Luis Salvador <br> " + "Jefe Compras / Purchasing Department<br>" + "Teléfono directo / Phone number: + 34 976 45 49 40 (Ext. 259) / +34 976 45 48 90<br>" + "Visite nuestra página web: <a href='http://www.transporzara.com' target='_blank'>www.transporzara.com</a>";
                        break;
                    case 39:
                        //jpelles
                        objMail.HTMLBody = "<html><style>body{font-family:'Calibri','sans-serif';font-size:11.0pt;color:navy}</style>" + "<body>" + TextoEmail + "<br><br><br>" + nombre_completo + "<br>" + "Departamento de Fabricacion / Manufacturing Manager <br>" + "Teléfono directo / Phone number: +34 976 45 49 40 / + 34 976 45 48 90<br>" + "Visite nuestra página web: <a href='http://www.transporzara.com' target='_blank'>www.transporzara.com</a>";
                        break;
                    default:
                        objMail.HTMLBody = "<html><style>body{font-family:'Calibri','sans-serif';font-size:11.0pt;color:navy}</style>" + "<body>" + TextoEmail + "<br><br><br>" + nombre_completo + "<br>" + "Teléfono directo / Phone number: +34 976 45 49 40 / + 34 976 45 48 90<br>" + "Visite nuestra página web: <a href='http://www.transporzara.com' target='_blank'>www.transporzara.com</a>";
                        break;
                }

                //* Enviamos nuestro Mail y listo!
                objMail.Display();

                //* Desplegamos un mensaje indicando que todo fue exitoso
                //MessageBox.Show("Correo Enviado", "MANTENIMIENTO DE EMAIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                //Texto = "Envio mail: " & direccionCorreo & " para autorización médica nº: " & Volante & "; Poliza:" & Poliza & "; Colectivo:" & Delegacion & "; Usuario: " & Usuario
                Texto = "to: " + direccionCorreo + " , mensaje: " + TextoEmail;
                clsFunc.grabarLogUsuario("Envio mail: ", Texto);

            } catch (System.Exception ex) {
                //* Si se produce algun Error Notificar al usuario

                MessageBox.Show("Error enviando mail" + ex.Message);

            } finally {
            }
        }




        public void conFoco(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.TextBox)sender).BackColor = Color.Yellow;
        }
        public void sinFoco(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.TextBox)sender).BackColor = Color.White;
        }

        public void conFocoChk(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.CheckBox)sender).BackColor = Color.Yellow;
        }

        public void sinFocoChk(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.CheckBox)sender).BackColor = Color.White;
        }

        public bool crearArchivoRemesa(System.DateTime _fec_emision, System.DateTime _fec_efecto, int id_key_remesa, string _ruta)
        {
            bool functionReturnValue = false;

            bool devuelve = true;

            try {
                clsSQL clsSQL = new clsSQL();
                clsSQL Consulta = new clsSQL();

                // Dim anio As Integer = 0
                string strMes = string.Empty;
                System.Data.DataTable dt = new System.Data.DataTable();

                //anio = Convert.ToInt32(_fec_emision.Year.ToString.Substring(2, 2))

                int linea = 0;
                string fecha_emision = rellenarDeCeros(_fec_emision.Day.ToString(), 2, clsFunciones.DireccionCeros.Izquierda) + rellenarDeCeros(_fec_emision.Month.ToString(), 2, clsFunciones.DireccionCeros.Izquierda) + rellenarDeCeros(_fec_emision.ToString(), 2, clsFunciones.DireccionCeros.Izquierda);
                string fecha_efecto = rellenarDeCeros(_fec_efecto.Day.ToString(), 2, clsFunciones.DireccionCeros.Izquierda) + rellenarDeCeros(_fec_efecto.Month.ToString(), 2, clsFunciones.DireccionCeros.Izquierda) + rellenarDeCeros(_fec_efecto.ToString(), 2, clsFunciones.DireccionCeros.Izquierda);

                string entidad = "";
                string oficina = "";
                string dcontrol = "";
                string ccc = "";
                string Cif_Ordenante = "B50852110";

                string Nif_beneficiario = string.Empty;
                string importe_talon = string.Empty;
                string Importe_talon_formateado = string.Empty;
                string Nombre_beneficiario = string.Empty;
                string Domicilio_beneficiario = string.Empty;
                string Domicilio_beneficiario_ampliacion = string.Empty;
                string CPostal_beneficiario = string.Empty;
                string Provincia_beneficiario = string.Empty;
                string Concepto_talon = string.Empty;
                string Concepto_talon_ampliacion = string.Empty;
                int Total_registros_010 = 0;
                string Total_registros_010_formateado = string.Empty;
                decimal Suma_importes = 0;
                string Suma_importes_formateado = string.Empty;
                int Total_registros = 0;
                string Total_registros_formateado = string.Empty;
                int Total_registros_detalle = 0;
                string Total_registros_detalle_formateado = string.Empty;
                string Importe_aux = string.Empty;
                int id_key_banco = 11;

                //datos del banco
                dt = Consulta.devolverDataTable(" select * from tg_bancos where id_key = " + id_key_banco);
                foreach (DataRow row in dt.Rows) {
                    entidad = row["entidad"].ToString();
                    oficina = row["oficina"].ToString();
                    dcontrol = row["dcontrol"].ToString();
                    ccc = row["cuenta"].ToString();
                }


                //dt = clsSQL.devolverDataTable("select * from v_Clientes_Recibos_COBROS_Vencimiento where id_key_remesa = " & id_key_remesa)

                int filastotales = dt.Rows.Count;
                int registrostotales = 0;

                if (existeArchivo(_ruta) == true) {
                    //'** Borrar archivo existente
                    System.IO.File.Delete(_ruta);

                    //devuelve = False
                    //Exit Try
                }


                // REGISTRO DE CABECERA  GENERAL ----------------------------------------------------------------------------------
                // NUMERO 1 -- DATOS BANCARIOS
                escribirEnArchivo(_ruta, "03" + "62" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + "001" + fecha_emision + fecha_efecto + entidad + oficina + dcontrol + ccc + "0" + rellenarDeEspacios("", 8, DireccionCeros.Derecha));


                // NUMERO 2 - EMPRESA
                escribirEnArchivo(_ruta, "03" + "62" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + "002" + rellenarDeEspacios("TRANSPORTES", 33, DireccionCeros.Derecha) + rellenarDeEspacios("", 8, DireccionCeros.Derecha));

                // NUMERO 3 - DIRECCION
                escribirEnArchivo(_ruta, "03" + "62" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + "003" + rellenarDeEspacios("POL. EL CAMINO", 33, DireccionCeros.Derecha) + rellenarDeEspacios("", 8, DireccionCeros.Derecha));

                // NUMERO 4 - POBLACION
                escribirEnArchivo(_ruta, "03" + "62" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + "004" + rellenarDeEspacios("ZARAGOZA", 33, DireccionCeros.Derecha) + rellenarDeEspacios("", 8, DireccionCeros.Derecha));


                // REGISTRO DE CABECERA BENEFICIARIO ----------------------------------------------------------------------------------
                escribirEnArchivo(_ruta, "04" + "56" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + rellenarDeEspacios("", 3, DireccionCeros.Derecha) + rellenarDeEspacios("", 41, DireccionCeros.Derecha));

                Total_registros = 5;


                // REGISTROS DE DETALLE BENEFICIARIO ----------------------------------------------------------------------------------
                dt = Consulta.devolverDataTable(" select * from V_Tesoreria_Remesas_Detalle where id_key_remesa = " + id_key_remesa + "  order by cif");


                foreach (DataRow row in dt.Rows) {
                    Nif_beneficiario = row["cif"].ToString();
                    Nombre_beneficiario = row["nombre_proveedor"].ToString();
                    Domicilio_beneficiario = row["direccion"].ToString();
                    //Domicilio_beneficiario_ampliacion  
                    CPostal_beneficiario = row["cod_postal"].ToString() + "" + row["poblacion"].ToString();
                    Provincia_beneficiario = row["provincia"].ToString();
                    Concepto_talon = row["concepto"].ToString();

                    //formateo del importe
                    //para quitar la coma de los decimales
                    importe_talon = row["importe_detalle"].ToString();
                    Importe_aux = importe_talon;

                    if (Importe_aux.Contains(",")) {
                        Importe_talon_formateado = Importe_aux.Substring(0, Importe_aux.IndexOf(","));
                        Importe_talon_formateado = Importe_talon_formateado + Importe_aux.Substring(Importe_aux.IndexOf(",") + 1, Importe_aux.Length - (Importe_aux.IndexOf(",") + 1));
                    }
                    //Importe_talon_formateado = "+" & Importe_talon_formateado

                    // NUMERO 1 --> IMPORTE
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "010" + rellenarDeCeros(Importe_talon_formateado, 12, DireccionCeros.Izquierda) + "00000000000000000000" + "2" + "9" + "+" + rellenarDeEspacios("", 6, DireccionCeros.Derecha));


                    // NUMERO 2 --> NOMBRE
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "011" + rellenarDeEspacios(Nombre_beneficiario, 36, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                    // NUMERO 3 --> DOMICILIO 
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "012" + rellenarDeEspacios(Domicilio_beneficiario, 36, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                    //' NUMERO 4 --> DOMICILIO  AMPLIACION
                    //escribirEnArchivo(_ruta, "06" & _
                    //                        "57" & _
                    //                        Cif_Ordenante & _
                    //                        "000" & _
                    //                        rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) & _
                    //                        "01" & _
                    //                        rellenarDeEspacios(Domicilio_beneficiario_ampliacion, 36, DireccionCeros.Derecha) & _
                    //                        rellenarDeEspacios("", 5, DireccionCeros.Derecha))



                    // NUMERO 5 --> COD POSTAL 
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "014" + rellenarDeEspacios(CPostal_beneficiario, 36, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                    // NUMERO 6 --> COD PROVINCIA 
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "015" + rellenarDeEspacios(Provincia_beneficiario, 36, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                    // NUMERO 7 --> CONCEPTO 
                    escribirEnArchivo(_ruta, "06" + "57" + Cif_Ordenante + "000" + rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) + "016" + rellenarDeEspacios(Concepto_talon, 36, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));


                    //' NUMERO 8 --> CONCEPTO AMPLIACION
                    //escribirEnArchivo(_ruta, "06" & _
                    //                        "57" & _
                    //                        Cif_Ordenante & _
                    //                        "000" & _
                    //                        rellenarDeEspacios(Nif_beneficiario, 12, DireccionCeros.Derecha) & _
                    //                        "017" & _
                    //                        rellenarDeEspacios(Concepto_talon_ampliacion, 36, DireccionCeros.Derecha) & _
                    //                        rellenarDeEspacios("", 5, DireccionCeros.Derecha))



                    Total_registros_010 = Total_registros_010 + 1;
                    Suma_importes = Suma_importes + Convert.ToDecimal(importe_talon);
                    Total_registros = Total_registros + 6;

                }

                //formateo de totales
                Suma_importes_formateado = Suma_importes.ToString();
                //System.Math.Round(Suma_importes, 2)
                Importe_aux = Suma_importes.ToString();
                //System.Math.Round(Suma_importes, 2)

                if (Importe_aux.Contains(",")) {
                    Suma_importes_formateado = Importe_aux.Substring(0, Importe_aux.IndexOf(","));
                    Suma_importes_formateado = Suma_importes_formateado + rellenarDeCeros(Importe_aux.Substring(Importe_aux.IndexOf(",") + 1, Importe_aux.Length - (Importe_aux.IndexOf(",") + 1)), 2, DireccionCeros.Izquierda);
                } else {
                    Suma_importes_formateado = Suma_importes_formateado + "00";
                    // añadimos los decimales si no los lleva
                }

                //Suma_importes_formateado = "+" & Suma_importes_formateado

                Total_registros_010_formateado = Total_registros_010.ToString();
                Total_registros = Total_registros + 2;
                // sumamos los 2 totales
                Total_registros_detalle = Total_registros - 5;
                // todos los registros menos los 4 de cabecera y el del total
                Total_registros_detalle_formateado = Total_registros_detalle.ToString();
                Total_registros_formateado = Total_registros.ToString();


                // REGISTRO DE TOTALES ----------------------------------------------------------------------------------
                escribirEnArchivo(_ruta, "08" + "56" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + rellenarDeEspacios("", 3, DireccionCeros.Derecha) + rellenarDeCeros(Suma_importes_formateado, 12, DireccionCeros.Izquierda) + rellenarDeCeros(Total_registros_010_formateado, 8, DireccionCeros.Izquierda) + rellenarDeCeros(Total_registros_detalle_formateado, 10, DireccionCeros.Izquierda) + rellenarDeEspacios("", 6, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                // REGISTRO DE TOTAL GENERAL ----------------------------------------------------------------------------------
                escribirEnArchivo(_ruta, "09" + "62" + Cif_Ordenante + "000" + rellenarDeEspacios("", 12, DireccionCeros.Derecha) + rellenarDeEspacios("", 3, DireccionCeros.Derecha) + rellenarDeCeros(Suma_importes_formateado, 12, DireccionCeros.Izquierda) + rellenarDeCeros(Total_registros_010_formateado, 8, DireccionCeros.Izquierda) + rellenarDeCeros(Total_registros_formateado, 10, DireccionCeros.Izquierda) + rellenarDeEspacios("", 6, DireccionCeros.Derecha) + rellenarDeEspacios("", 5, DireccionCeros.Derecha));

                functionReturnValue = true;


            } catch (System.Exception ex) {
                devuelve = false;
                MessageBox.Show("Error enviando mail" + ex.Message);

            }
            return devuelve;
            return functionReturnValue;
        }

    }


}