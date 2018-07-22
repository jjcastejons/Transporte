using System;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Transportes
{
    public class clsSQL
    {

        public void rellenarGrid(string _select, DataGridView grid, int parametros = 0)
        {
            int i = 0;
            string[] matrix = null;

            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            string parametro = string.Empty;
            conSql.Open();

            SqlCommand cmdSql = new SqlCommand(_select, conSql);
            SqlDataReader drSql = cmdSql.ExecuteReader();

            string strparametro = string.Empty;




            if (parametros == 0)
            {
                strparametro = _select.Replace("select", "");
                strparametro = strparametro.Replace("from", "#");
                int corte = strparametro.IndexOf("#");
                strparametro = strparametro.Substring(0, corte - 1).Trim();

            }

            matrix = strparametro.Split(',');

            for (i = 0; i <= matrix.Length - 1; i++)
            {
                grid.Columns.Add(matrix[i], matrix[i]);
            }


            string[] pepe = new string[matrix.Length];


            while (drSql.Read())
            {
                for (i = 0; i <= matrix.Length - 1; i++)
                {
                    pepe[i] = drSql[i].ToString();
                }
                grid.Rows.Add(pepe);
            }

        }
        /// <summary>
        /// Devuelve solo una tabla segun un select pasado
        /// </summary>
        /// <param name="_select">Sentencia SQL de la tabla a devolver</param>
        /// <param name="_tabla">Opcional el nombre que queramos darle a la tabla del Data</param>
        /// <param name="_ConexionAuxiliar">Si queremos utilizar otra conexion distinta a la predeterminada</param>
        /// <returns>Devuelve un DataTable con la sentencia SQL</returns>
        /// <remarks></remarks>
        public DataTable devolverDataTable(string _select, string _tabla = "", string _ConexionAuxiliar = "")
        {
            string cadenaConexion = string.Empty;

            if (_ConexionAuxiliar.Trim() == string.Empty)
            {
                cadenaConexion = mdPrincipal.Cadena_Conexion_SQL;
            }
            else
            {
                cadenaConexion = _ConexionAuxiliar.Trim();
            }

            SqlConnection conSql = new SqlConnection(cadenaConexion);

            SqlDataAdapter daSql = new SqlDataAdapter(_select, conSql);
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            try
            {
                daSql.Fill(ds, _select);

                table = ds.Tables[0];
                if (_tabla == string.Empty)
                {
                    _tabla = "0";
                }
                table.TableName = _tabla;

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return table;
            }

        }

        /// <summary>
        /// Devuelve un DataSet con el Select especificado
        /// </summary>
        /// <param name="_select">Nombre de la cadena del select a buscar</param>
        /// <param name="_ConexionAuxiliar">Si queremos utilizar otra conexion distinta a la predeterminada</param>
        /// <returns>DataSet del select con la tabla devuelta</returns>
        /// <remarks></remarks>
        public DataSet devolverDataSetSelect(string _select, string _ConexionAuxiliar = "", string _tabla = "")
        {
            string cadenaConexion = string.Empty;

            if (_ConexionAuxiliar.Trim() == string.Empty)
            {
                cadenaConexion = mdPrincipal.Cadena_Conexion_SQL;
            }
            else
            {
                cadenaConexion = _ConexionAuxiliar.Trim();
            }

            SqlConnection conSql = new SqlConnection(cadenaConexion);

            SqlDataAdapter daSql = new SqlDataAdapter(_select, conSql);

            daSql.SelectCommand.CommandTimeout = 120;

            DataSet ds = new DataSet();
            try
            {
                if (_tabla == string.Empty)
                {
                    daSql.Fill(ds, _select);
                }
                else
                {
                    daSql.Fill(ds, _tabla);
                }

            }
            catch (SqlException exSQL)
            {
                MessageBox.Show(exSQL.ToString(), "Error en clsSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conSql.Close();
            }

            return ds;
        }

        /// <summary>
        /// Devuelve un DataSet con la tabla especificada
        /// </summary>
        /// <param name="_tabla">Nombre de la tabla a devolver</param>
        /// <returns>DataSet de la tabla devuelta</returns>
        /// <remarks></remarks>
        public DataSet devolverDatasetTabla(string _tabla)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            SqlDataAdapter daSql = new SqlDataAdapter("select * from " + _tabla, conSql);
            DataSet ds = new DataSet();

            daSql.Fill(ds, _tabla);

            return ds;
        }
        /// <summary>
        /// Devuelve un solo parametro pasandole la tabla y la columna
        /// </summary>
        /// <param name="_tabla">Tabla a buscar el parametro</param>
        /// <param name="_parametro">Columna del parametro</param>
        /// <returns>Valor del parametro buscado</returns>
        /// <remarks></remarks>
        public static string devolverUnParametro(string _tabla, string _parametro)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            string parametro = string.Empty;
            conSql.Open();

            SqlCommand cmdSql = new SqlCommand("select " + _parametro + " from " + _tabla, conSql);

            SqlDataReader drSql = cmdSql.ExecuteReader();
            try
            {
                while (drSql.Read())
                {
                    parametro = drSql[_parametro].ToString();
                }
                return parametro;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                drSql.Close();
            }
            return parametro;
        }
        /// <summary>
        /// Devolver un parametro pasando un Select. SOLO devuelve un parametro
        /// </summary>
        /// <param name="_select">Select del parámetro a devolver</param>
        /// <returns>Devuelve el parámetro especificado</returns>
        /// <remarks></remarks>
        public string devolverParametroSelect(string _select)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            string parametro = string.Empty;
            conSql.Open();

            SqlCommand cmdSql = new SqlCommand(_select, conSql);

            SqlDataReader drSql = cmdSql.ExecuteReader();
            try
            {
                while (drSql.Read())
                {
                    parametro = drSql[0].ToString();
                }
                return parametro;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                drSql.Close();
                conSql.Close();
            }
            return parametro;
        }

        public DataTable devolverVariosParametrosSelect(string _select)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            DataTable parametro = new DataTable();
            parametro.Columns.Add("nombre");
            parametro.Columns.Add("valor");

            conSql.Open();

            SqlCommand cmdSql = new SqlCommand(_select, conSql);

            int dondeFrom = _select.ToUpper().IndexOf("FROM", 0);
            //Dim juan As Integer = _select.ToUpper.IndexOf("SELECT", 0)

            string mParametros = _select.Substring(0, dondeFrom);
            mParametros = mParametros.ToUpper().Replace("SELECT", "");

            string[] matrizParametros = mParametros.Split(',');

            SqlDataReader drSql = cmdSql.ExecuteReader();
            try
            {
                while (drSql.Read())
                {
                    for (int i = 0; i <= matrizParametros.Length - 1; i++)
                    {
                        parametro.Rows.Add(matrizParametros[i], drSql[matrizParametros[i]].ToString());
                    }

                }
                return parametro;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // Always call Close when done reading.
                drSql.Close();
            }
            return parametro;
        }

        /// <summary>
        /// Comprueba si existe la consulta realizada en el Select
        /// </summary>
        /// <param name="_select">Consulta a comprobar</param>
        /// <returns>True si existe la consulta realizada</returns>
        /// <remarks></remarks>
        public bool existeConsulta(string _select)
        {

            bool existe = false;
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            conSql.Open();

            SqlCommand cmdSql = new SqlCommand(_select, conSql);
            //executing the command and assigning it to connection 

            SqlDataReader drSql = cmdSql.ExecuteReader();
            try
            {
                while (drSql.Read())
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                existe = false;
                return existe;
            }
            finally
            {
                // Always call Close when done reading.
                drSql.Close();

            }
        }
        /// <summary>
        /// Ejecutar sentencia SQL que no sea SELECT (INSERT,UPDATE,DELETE)
        /// </summary>
        /// <param name="_sql">Sentencia SQL a ejecutar</param>
        /// <returns>True si ha hecho bien la ejecución</returns>
        /// <remarks></remarks>
        public bool ejecutarQuery(string _sql, bool noImportaFilasProcesadas = false)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            clsFunciones clsFunc = new clsFunciones();
            conSql.Open();
            try
            {
                string tabla = string.Empty;
                string[] matrizTabla = null;
                bool devuelve = false;

                SqlCommand cmdSql = new SqlCommand(_sql, conSql);
                if (cmdSql.ExecuteNonQuery() > 0)
                {
                    devuelve = true;
                }
                else
                {
                    if (noImportaFilasProcesadas == false)
                    {
                        devuelve = false;
                    }
                    else
                    {
                        devuelve = true;
                    }
                }
                cmdSql.Dispose();

                if (_sql.ToUpper().Contains("DELETE") == true)
                {
                    tabla = _sql.Replace(" ", "|");
                    matrizTabla = tabla.Split('|');

                    tabla = matrizTabla[2];
                    clsFunc.grabarLogUsuario("Delete en tabla: " + tabla, "Delete en la tabla: " + tabla);
                }
                if (_sql.ToUpper().Contains("UPDATE") == true)
                {
                    tabla = _sql.Replace(" ", "|");
                    matrizTabla = tabla.Split('|');

                    tabla = matrizTabla[1];
                    clsFunc.grabarLogUsuario("Modif. tabla: " + tabla, "Modificación en la tabla: " + tabla);
                }
                if (_sql.ToUpper().Contains("INSERT") == true)
                {
                    tabla = _sql.Replace(" ", "|");
                    matrizTabla = tabla.Split('|');

                    tabla = matrizTabla[2];
                    clsFunc.grabarLogUsuario("INSERT en tabla: " + tabla, "INSERT en la tabla: " + tabla);
                }

                return devuelve;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conSql.Dispose();
            }

        }
        /// <summary>
        /// Comprueba que existe un registro en la tabla especificada según campo y valor pasado
        /// </summary>
        /// <param name="_tabla">Tabla a buscar el Valor</param>
        /// <param name="_campo">Campo a especificar en la búsqueda</param>
        /// <param name="_valor">Valor a comprobar</param>
        /// <returns>True si existe ese valor, False si no existe</returns>
        /// <remarks></remarks>
        public bool comprobarUnRegistro(string _tabla, string _campo, string _valor)
        {
            bool existe = false;
            string _select = "select top 1 " + _campo + " from " + _tabla + " where " + _campo + " = '" + _valor + "'";

            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            conSql.Open();

            SqlCommand cmdSql = new SqlCommand(_select, conSql);

            SqlDataReader drSql = cmdSql.ExecuteReader();
            try
            {
                while (drSql.Read())
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                existe = false;
                return existe;
            }
            finally
            {
                // Always call Close when done reading.
                drSql.Close();

            }

        }

        /// <summary>
        /// Ejecuta un SP pasando un DataTable con los valores del SP
        /// </summary>
        /// <param name="_dt">DataTable con los valores del SP</param>
        /// <returns>Un DataTable con los valores de retorno</returns>
        /// <remarks></remarks>
        public DataTable ejecutarSPdt(DataTable _dt)
        {
            DataTable devuelveDT = new DataTable();
            clsFunciones clsFunc = new clsFunciones();

            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            SqlCommand cmdSQL = new SqlCommand(_dt.TableName, conSQL);

            cmdSQL.CommandType = CommandType.StoredProcedure;
            cmdSQL.CommandTimeout = 600;

            devuelveDT.Columns.Add("retorno", Type.GetType("System.String"));

            SqlParameterCollection paramColl = cmdSQL.Parameters;
            try
            {
                foreach (DataColumn col in _dt.Columns)
                {
                    SqlParameter valorEntrada = new SqlParameter();
                    valorEntrada.ParameterName = col.ColumnName;

                    valorEntrada.Direction = ParameterDirection.Input;
                    valorEntrada.Value = _dt.Rows[0][col];

                    valorEntrada.SqlDbType = verSqlType(col.DataType.ToString());

                    if (valorEntrada.SqlDbType.ToString().ToUpper() == "SYSTEM.DECIMAL")
                    {
                        valorEntrada.Value = clsFunc.ponerDecimales(_dt.Rows[0][col].ToString());
                        if ((string)valorEntrada.Value == string.Empty)
                        {
                            valorEntrada.Value = 0;
                        }
                    }
                    paramColl.Add(valorEntrada);
                }

                SqlParameter valorRetorno = new SqlParameter("@msgerror", SqlDbType.VarChar, 200);
                valorRetorno.Direction = ParameterDirection.Output;
                paramColl.Add(valorRetorno);

                conSQL.Open();

                cmdSQL.ExecuteNonQuery();

                devuelveDT.Rows.Add(valorRetorno.Value);

                return devuelveDT;
            }
            catch (Exception ex)
            {
                devuelveDT.Rows.Add(ex.ToString());
                return devuelveDT;
            }
            finally
            {
                conSQL.Close();

            }
        }

        public string devolverParametrodeSP(string _nombreSp, string _nombreParametroADevolver, params object[] parametros)
        {
            clsFunciones clsFunc = new clsFunciones();

            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            SqlCommand cmdSQL = new SqlCommand(_nombreSp, conSQL);
            cmdSQL.CommandType = CommandType.StoredProcedure;
            cmdSQL.CommandTimeout = 600;

            SqlParameterCollection paramColl = cmdSQL.Parameters;
            try
            {
                foreach (object parametro in parametros)
                {
                    //**** Creamos la matriz cogiendo el primer igual y el último
                    //**** Por si meten algún signo igual en el parámetro a insertar
                    int posprimerIgual = parametro.ToString().IndexOf("=");
                    string primerParametro = parametro.ToString().Substring(0, posprimerIgual);
                    int posultimoIgual = parametro.ToString().LastIndexOf("=");
                    string tercerParametro = parametro.ToString().Substring(posultimoIgual + 1, parametro.ToString().Length - (posultimoIgual + 1));
                    string segundoParametro = parametro.ToString().Substring(posprimerIgual + 1, posultimoIgual - (posprimerIgual + 1));

                    string[] matriz = {
                    primerParametro,
                    segundoParametro,
                    tercerParametro
                };

                    string parametro_sp = matriz[0];

                    SqlParameter valorEntrada = new SqlParameter();
                    valorEntrada.ParameterName = parametro_sp;
                    valorEntrada.Direction = ParameterDirection.Input;
                    valorEntrada.Value = matriz[1];
                    valorEntrada.SqlDbType = verSqlType(matriz[2]);
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.DECIMAL")
                    {
                        valorEntrada.Value = clsFunc.ponerDecimales(matriz[1]);
                        if ((string)valorEntrada.Value == string.Empty)
                        {
                            valorEntrada.Value = 0;
                        }
                    }
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.IMAGE")
                    {
                        if (valorEntrada.Value.ToString().ToUpper() == "NULL")
                        {
                            valorEntrada.Value = DBNull.Value;
                        }
                        if (valorEntrada.Value.ToString().ToUpper() == string.Empty)
                        {
                            valorEntrada.Value = DBNull.Value;
                        }
                    }
                    paramColl.Add(valorEntrada);
                }

                SqlParameter valorRetorno = new SqlParameter(_nombreParametroADevolver, SqlDbType.VarChar, 200);
                valorRetorno.Direction = ParameterDirection.Output;
                paramColl.Add(valorRetorno);

                conSQL.Open();

                cmdSQL.ExecuteNonQuery();

                return valorRetorno.Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                conSQL.Close();

            }
        }
        /// <summary>
        /// Ejecuta Stored Procedure pasando el Nombre y los parametros con sus valores
        /// </summary>
        /// <param name="_nombreSp">Nombre del Stored Procedure de la Base de Datos</param>
        /// <param name="parametros">Array de los parametros y valores siguiendo el patron "@parametro=valor=System.Tipo"</param>
        /// <returns>Valor del retorno como String</returns>
        /// <remarks></remarks>
        public string ejecutarSP(string _nombreSp, params object[] parametros)
        {
            clsFunciones clsFunc = new clsFunciones();

            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            SqlCommand cmdSQL = new SqlCommand(_nombreSp, conSQL);
            cmdSQL.CommandType = CommandType.StoredProcedure;
            cmdSQL.CommandTimeout = 600;

            SqlParameterCollection paramColl = cmdSQL.Parameters;
            try
            {
                foreach (object parametro in parametros)
                {
                    //**** Creamos la matriz cogiendo el primer igual y el último
                    //**** Por si meten algún signo igual en el parámetro a insertar
                    int posprimerIgual = parametro.ToString().IndexOf("=");
                    string primerParametro = parametro.ToString().Substring(0, posprimerIgual);
                    int posultimoIgual = parametro.ToString().LastIndexOf("=");
                    string tercerParametro = parametro.ToString().Substring(posultimoIgual + 1, parametro.ToString().Length - (posultimoIgual + 1));
                    string segundoParametro = parametro.ToString().Substring(posprimerIgual + 1, posultimoIgual - (posprimerIgual + 1));

                    string[] matriz = {
                    primerParametro,
                    segundoParametro,
                    tercerParametro
                };

                    string parametro_sp = matriz[0];

                    SqlParameter valorEntrada = new SqlParameter();
                    valorEntrada.ParameterName = parametro_sp;
                    valorEntrada.Direction = ParameterDirection.Input;
                    valorEntrada.Value = matriz[1];
                    valorEntrada.SqlDbType = verSqlType(matriz[2]);
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.DECIMAL")
                    {
                        valorEntrada.Value = clsFunc.ponerDecimales(matriz[1]);
                        if ((string)valorEntrada.Value == string.Empty)
                        {
                            valorEntrada.Value = 0;
                        }
                    }
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.IMAGE")
                    {
                        if (valorEntrada.Value.ToString().ToUpper() == "NULL")
                        {
                            valorEntrada.Value = DBNull.Value;
                        }
                        if (valorEntrada.Value.ToString().ToUpper() == string.Empty)
                        {
                            valorEntrada.Value = DBNull.Value;
                        }
                    }
                    paramColl.Add(valorEntrada);
                }

                SqlParameter valorRetorno = new SqlParameter("@msgerror", SqlDbType.VarChar, 200);
                valorRetorno.Direction = ParameterDirection.Output;
                paramColl.Add(valorRetorno);

                conSQL.Open();

                cmdSQL.ExecuteNonQuery();

                return valorRetorno.Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            finally
            {
                conSQL.Close();

            }

        }

        /// <summary>
        /// Ejecuta Stored Procedure pasando el Nombre y los parametros con sus valores
        /// </summary>
        /// <param name="_nombreSp">Nombre del Stored Procedure de la Base de Datos</param>
        /// <param name="parametros">Array de los parametros y valores siguiendo el patron "@parametro=valor=System.Tipo"</param>
        /// <returns>Valor del retorno como un SqlCommand</returns>
        /// <remarks></remarks>
        public SqlCommand ejecutarSPSelect(string _nombreSp, params object[] parametros)
        {
            clsFunciones clsFunc = new clsFunciones();

            SqlConnection conSQL = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);

            SqlCommand cmdSQL = new SqlCommand(_nombreSp, conSQL);
            cmdSQL.CommandType = CommandType.StoredProcedure;
            cmdSQL.CommandTimeout = 600;

            SqlParameterCollection paramColl = cmdSQL.Parameters;
            try
            {
                foreach (object parametro in parametros)
                {
                    object[] matriz = parametro.ToString().Split('=');

                    string parametro_sp = matriz[0].ToString();

                    SqlParameter valorEntrada = new SqlParameter();
                    valorEntrada.ParameterName = parametro_sp;
                    valorEntrada.Direction = ParameterDirection.Input;
                    valorEntrada.Value = matriz[1];
                    valorEntrada.SqlDbType = verSqlType(matriz[2].ToString());
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.DECIMAL")
                    {
                        valorEntrada.Value = clsFunc.ponerDecimales(matriz[1].ToString());
                        if ((string)valorEntrada.Value == string.Empty)
                        {
                            valorEntrada.Value = 0;
                        }
                    }
                    if (matriz[2].ToString().ToUpper() == "SYSTEM.IMAGE")
                    {
                        if (valorEntrada.Value.ToString().ToUpper() == "NULL")
                        {
                            valorEntrada.Value = null;
                        }
                    }
                    paramColl.Add(valorEntrada);
                }

                SqlParameter valorRetorno = new SqlParameter("@msgerror", SqlDbType.VarChar, 200);
                valorRetorno.Direction = ParameterDirection.Output;
                paramColl.Add(valorRetorno);

                conSQL.Open();

                return cmdSQL;

            }
            catch (SqlException ex)
            {
                return new System.Data.SqlClient.SqlCommand(ex.Message);
            }
            finally
            {
                conSQL.Close();

            }
        }
        /// <summary>
        /// Cambiar los tipos de C# a los de SQL
        /// </summary>
        /// <param name="_objeto">Objeto del tipo a cambiar</param>
        /// <returns>Objeto cambiado a SQL</returns>
        /// <remarks></remarks>
        public SqlDbType verSqlType(string _objeto)
        {
            switch (_objeto.ToUpper())
            {
                case "SYSTEM.STRING":
                    return SqlDbType.VarChar;
                case "SYSTEM.INT16":
                    return SqlDbType.SmallInt;
                case "SYSTEM.INT32":
                    return SqlDbType.Int;
                case "SYSTEM.INT64":
                    return SqlDbType.BigInt;
                case "SYSTEM.DECIMAL":
                    return SqlDbType.VarChar;
                case "SYSTEM.DATETIME":
                    return SqlDbType.DateTime;
                case "SYSTEM.IMAGE":
                    return SqlDbType.Image;
                case "SYSTEM.VARBINARY":
                    return SqlDbType.VarBinary;
                default:
                    return SqlDbType.VarChar;
            }

        }
        /// <summary>
        /// Ver si podemos acceder o no al formulario especificado
        /// </summary>
        /// <param name="_usuario">número entero con el id_key_usuario</param>
        /// <param name="_formulario">Formulario al cual queremos acceder</param>
        /// <returns>True si podemos acceder</returns>
        /// <remarks></remarks>
        public bool verAcceso(int _usuario, string _formulario)
        {
            bool devuelve = false;


            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            conSql.Open();


            string _select = "select lectura from v_permisos where id_key_usuario = " + _usuario + " and formulario = '" + _formulario.ToUpper() + "'";

            SqlCommand cmdSql = new SqlCommand(_select, conSql);
            SqlDataReader drSql = cmdSql.ExecuteReader();

            try
            {
                while (drSql.Read())
                {
                    //devuelve = drSql.GetValue(0);
                    devuelve = drSql.GetBoolean(0);
                    if (devuelve == true)
                    {
                        break; // TODO: might not be correct. Was : Exit While
                    }
                }
                if (devuelve == false)
                {
                    MessageBox.Show("No tiene permiso para Mostrar este formulario", "PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                devuelve = false;
                //Return existe
            }
            finally
            {
                drSql.Close();
            }

            return devuelve;
        }
        /// <summary>
        /// Mostrar los permisos del formulario especificado
        /// </summary>
        /// <param name="_usuario">Numero entero con el id_key_usuario</param>
        /// <param name="_formulario">Formulario al cual queremos acceder</param>
        /// <remarks></remarks>

        public void mostrarPermisos(int _usuario, string _formulario)
        {
            SqlConnection conSql = new SqlConnection(mdPrincipal.Cadena_Conexion_SQL);
            conSql.Open();

            //Permiso_Lectura = true;
            //Permiso_Insertar = true;
            //Permiso_Modificar = true;
            //Permiso_Eliminar = true;

            //Dim _select As String = "select Lectura,insertar,modificar,eliminar from v_permisos where id_key_usuario = " & _usuario &
            //                        " and  formulario = '" & _formulario.ToUpper & "'"

            //Dim cmdSql As New SqlCommand(_select, conSql)
            //Dim drSql As SqlDataReader = cmdSql.ExecuteReader()

            try
            {
                //While drSql.Read()

                //    If Permiso_Lectura <> True Then Permiso_Lectura = drSql.GetValue(0)
                //    If Permiso_Insertar <> True Then Permiso_Insertar = drSql.GetValue(1)
                //    If Permiso_Modificar <> True Then Permiso_Modificar = drSql.GetValue(2)
                //    If Permiso_Eliminar <> True Then Permiso_Eliminar = drSql.GetValue(3)

                //End While

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Permiso_Lectura = false;
                //Permiso_Insertar = false;
                //Permiso_Modificar = false;
                //Permiso_Eliminar = false;
            }
            finally
            {
                //drSql.Close()
            }

        }

    }
}