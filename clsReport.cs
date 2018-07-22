using System;
using System.IO;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Transportes
{
    public class clsReport : IPrintReport
    {
        private bool DidPreviouslyConnect = false;

        /// <summary>
        ///     ''' Imprime el informe en pantalla antes de pasarlo a la impresora
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del informe</param>
        ///     ''' <param name="DataSource">DataSet pasado para ver en el informe</param>
        ///     ''' <param name="Filter">filtro opcional que queramos pasarle</param>
        ///     ''' <remarks></remarks>
        public void PrintPreview(string FileReport, System.Data.DataSet DataSource, string Filter = "")
        {
            frmVerInformes frmCRNet = new frmVerInformes();
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();

            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    {
                        var withBlock = frmCRNet;
                        {
                            var withBlock1 = crNicasoftStandarReport;
                            withBlock1.Load(FileReport);
                            withBlock1.SetDataSource(DataSource);
                        }

                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;

                        if (Filter != string.Empty)
                            withBlock.visorRPT.SelectionFormula = Filter;

                        withBlock.visorRPT.Refresh();
                        withBlock.Show();

                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;
                }
            }
        }
        /// <summary>
        ///     ''' Imprime directamente el informe a la impresora determinada
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del informe</param>
        ///     ''' <param name="DataSource">DataSet pasado para mostrar</param>
        ///     ''' <param name="Filter">Filtro que queramos pasarle</param>
        ///     ''' <remarks></remarks>
        public void Print(string FileReport, System.Data.DataSet DataSource, string Filter = "")
        {
            frmVerInformes frmCRNet = new frmVerInformes();
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();


            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    {
                        var withBlock = frmCRNet;
                        {
                            var withBlock1 = crNicasoftStandarReport;
                            withBlock1.Load(FileReport);
                            withBlock1.SetDataSource(DataSource);
                        }

                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;

                        if (Filter != "")
                            withBlock.visorRPT.SelectionFormula = Filter;


                        withBlock.visorRPT.Refresh();
                        withBlock.visorRPT.PrintReport();

                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;
                }
            }
        }

        /// <summary>
        ///     ''' Mostrar informe pasando los valores directamente de la Base de Datos
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del informe</param>
        ///     ''' <param name="Username">Usuario de la BBDD</param>
        ///     ''' <param name="Password">Password de la BBDD</param>
        ///     ''' <param name="Servername">Servidor SQL</param>
        ///     ''' <param name="Filter">Filtro opcional a pasarle</param>
        ///     ''' <remarks></remarks>
        public void PrintLogon(string FileReport, string Username, string Password, string Servername, string Filter = "")
        {
            clsFunciones clsFunciones = new clsFunciones();

            clsFunciones.grabarLogUsuario("Informes", "Visualizacion informe : " + FileReport + " Filtro: " + Filter);

            frmVerInformes frmCRNet = new frmVerInformes();
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();

            Sections crSections;
            ReportObjects crReportObjects;
            SubreportObject crSubreportObject;
            ReportDocument crSubreportDocument;

            Database crDatabase;
            Tables crTables;
            //Table crTable;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectioninfo;
            string BaseDatos = "TRANSPORTES";

            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    crConnectioninfo = new ConnectionInfo();

                    {
                        var withBlock = crConnectioninfo;
                        withBlock.ServerName = Servername;
                        withBlock.DatabaseName = BaseDatos;
                        withBlock.UserID = Username;
                        withBlock.Password = Password;
                        withBlock.IntegratedSecurity = false;
                    }

                    {
                        var withBlock = frmCRNet;
                        crNicasoftStandarReport.Load(FileReport);

                        crDatabase = crNicasoftStandarReport.Database;

                        crTables = crDatabase.Tables;

                        foreach (Table crTable in crTables)
                        {
                            crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                            crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = false;
                            crTableLogOnInfo.ConnectionInfo.ServerName = Servername;
                            crTableLogOnInfo.ConnectionInfo.UserID = Username;
                            crTableLogOnInfo.ConnectionInfo.Password = Password;
                            crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos;
                            crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL;

                            crTableLogOnInfo.ReportName = FileReport;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }

                        crSections = crNicasoftStandarReport.ReportDefinition.Sections;

                        foreach (Section crSection in crSections)
                        {
                            crReportObjects = crSection.ReportObjects;

                            foreach (ReportObject crReportObject in crReportObjects)
                            {
                                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                                {
                                    crSubreportObject = (SubreportObject)crReportObject;

                                    crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

                                    crDatabase = crSubreportDocument.Database;
                                    crTables = crDatabase.Tables;

                                    foreach (Table crTable in crTables)
                                    {
                                        {
                                            var withBlock1 = crConnectioninfo;
                                            withBlock1.ServerName = Servername;
                                            withBlock1.DatabaseName = BaseDatos;
                                            withBlock1.UserID = Username;
                                            withBlock1.Password = Password;
                                        }
                                        crTableLogOnInfo = crTable.LogOnInfo;
                                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                                        crTable.ApplyLogOnInfo(crTableLogOnInfo);
                                    }
                                }
                            }
                        }

                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;
                        withBlock.visorRPT.LogOnInfo[0].ConnectionInfo.Type = ConnectionInfoType.SQL;
                        if (Filter != "")
                            withBlock.visorRPT.SelectionFormula = Filter;
                        withBlock.visorRPT.Refresh();
                        withBlock.Show();

                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;

                }
            }
        }

        /// <summary>
        ///     ''' Mostrar informe pasando los valores de un Procedimiento Almacenado de la Base de Datos
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del informe</param>
        ///     ''' <param name="Username">Usuario de la BBDD</param>
        ///     ''' <param name="Password">Password de la BBDD</param>
        ///     ''' <param name="Servername">Servidor SQL</param>
        ///     ''' <param name="Filter">Filtro opcional a pasarle</param>
        ///     ''' <remarks></remarks>
        public void PrintLogonSP(string FileReport, string Username, string Password, string Servername, ParameterFields listadeParametros, string Filter = "", bool GuardarPDF = false, string NombrePdf = "")
        {
            clsFunciones clsFunciones = new clsFunciones();

            clsFunciones.grabarLogUsuario("Informes", "Visualización informe : " + FileReport + " Filtro: " + Filter);

            frmVerInformes frmCRNet = new frmVerInformes();
            // Dim frmStatusMessage As New frmStatus
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();

            Sections crSections;
            //Section crSection;
            ReportObjects crReportObjects;
            //ReportObject crReportObject;
            SubreportObject crSubreportObject;
            ReportDocument crSubreportDocument;

            Database crDatabase;
            Tables crTables;
            //Table crTable;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectioninfo;
            string BaseDatos = "TRANSPORTES";

            // If Not DidPreviouslyConnect Then
            // frmStatusMessage.Show("Estableciendo conexión...")
            // End If

            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    crConnectioninfo = new ConnectionInfo();

                    {
                        var withBlock = crConnectioninfo;
                        withBlock.ServerName = Servername;
                        withBlock.DatabaseName = BaseDatos;
                        withBlock.UserID = Username;
                        withBlock.Password = Password;
                        withBlock.IntegratedSecurity = false;
                    }

                    {
                        var withBlock = frmCRNet;
                        crNicasoftStandarReport.Load(FileReport);

                        crDatabase = crNicasoftStandarReport.Database;

                        crTables = crDatabase.Tables;

                        foreach (Table crTable in crTables)
                        {
                            crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                            crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = false;
                            crTableLogOnInfo.ConnectionInfo.ServerName = Servername;
                            crTableLogOnInfo.ConnectionInfo.UserID = Username;
                            crTableLogOnInfo.ConnectionInfo.Password = Password;
                            crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos;
                            crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL;

                            crTableLogOnInfo.ReportName = FileReport;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }

                        crSections = crNicasoftStandarReport.ReportDefinition.Sections;

                        foreach (Section crSection in crSections)
                        {
                            crReportObjects = crSection.ReportObjects;


                            foreach (ReportObject crReportObject in crReportObjects)
                            {
                                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                                {
                                    crSubreportObject = (SubreportObject)crReportObject;



                                    crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

                                    crDatabase = crSubreportDocument.Database;
                                    crTables = crDatabase.Tables;

                                    foreach (Table crTable in crTables)
                                    {
                                        {
                                            var withBlock1 = crConnectioninfo;
                                            withBlock1.ServerName = Servername;
                                            withBlock1.DatabaseName = BaseDatos;
                                            withBlock1.UserID = Username;
                                            withBlock1.Password = Password;
                                        }
                                        crTableLogOnInfo = crTable.LogOnInfo;
                                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                                        crTable.ApplyLogOnInfo(crTableLogOnInfo);
                                    }
                                }
                            }
                        }



                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;
                        withBlock.visorRPT.LogOnInfo[0].ConnectionInfo.Type = ConnectionInfoType.SQL;

                        if (Filter != "")
                            withBlock.visorRPT.SelectionFormula = Filter;

                        withBlock.visorRPT.ParameterFieldInfo = listadeParametros;
                        withBlock.visorRPT.Refresh();
                        withBlock.Show();

                        if (GuardarPDF == true)
                        {
                            // guardar como pdf
                            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                            ExportOptions CrExportOptions;
                            CrDiskFileDestinationOptions.DiskFileName = NombrePdf;



                            CrExportOptions = crNicasoftStandarReport.ExportOptions;

                            {
                                var withBlock1 = CrExportOptions;
                                withBlock1.ExportDestinationType = ExportDestinationType.DiskFile;
                                withBlock1.ExportFormatType = ExportFormatType.PortableDocFormat;
                                withBlock1.DestinationOptions = CrDiskFileDestinationOptions;
                                withBlock1.FormatOptions = CrFormatTypeOptions;
                            }
                            // guradamos el documento el el temporal de win
                            crNicasoftStandarReport.ExportToDisk(ExportFormatType.PortableDocFormat, Path.GetTempPath() + @"\" + NombrePdf + ".pdf");
                            withBlock.Close();
                        }



                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;
                }
            }
        }
        /// <summary>
        ///     ''' Imprime el Report directamente en archivo con la ruta pasada y el tipo de archivo
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del Report</param>
        ///     ''' <param name="Username">usuario Base datos</param>
        ///     ''' <param name="Password">password del usuario Base de datos</param>
        ///     ''' <param name="Servername">Servidor de la Base de Datos</param>
        ///     ''' <param name="Filter">Filtro del crystal</param>
        ///     ''' <param name="_rutadestinoAGuardar">Ruta donde se guarda el archivo</param>
        ///     ''' <param name="Export">Tipo de Archivo a guardar</param>
        ///     ''' <remarks></remarks>
        public void PrintEnArchivo(string FileReport, string Username, string Password, string Servername, string Filter = "", string _rutadestinoAGuardar = "", CrystalDecisions.Shared.ExportFormatType Export = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        {
            frmVerInformes frmCRNet = new frmVerInformes();
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();
            Sections crSections;
            ReportObjects crReportObjects;
            SubreportObject crSubreportObject;
            ReportDocument crSubreportDocument;
            Database crDatabase;
            Tables crTables;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectioninfo;
            string BaseDatos = "TRANSPORTES";

            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    crConnectioninfo = new ConnectionInfo();

                    {
                        var withBlock = crConnectioninfo;
                        withBlock.ServerName = Servername;
                        withBlock.DatabaseName = BaseDatos;
                        withBlock.UserID = Username;
                        withBlock.Password = Password;
                        withBlock.IntegratedSecurity = false;
                    }

                    {
                        var withBlock = frmCRNet;
                        crNicasoftStandarReport.Load(FileReport);

                        crDatabase = crNicasoftStandarReport.Database;

                        crTables = crDatabase.Tables;

                        foreach (Table crTable in crTables)
                        {
                            crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                            crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = false;
                            crTableLogOnInfo.ConnectionInfo.ServerName = Servername;
                            crTableLogOnInfo.ConnectionInfo.UserID = Username;
                            crTableLogOnInfo.ConnectionInfo.Password = Password;
                            crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos;
                            crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL;
                            crTableLogOnInfo.ReportName = FileReport;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }

                        crSections = crNicasoftStandarReport.ReportDefinition.Sections;

                        foreach (Section crSection in crSections)
                        {
                            crReportObjects = crSection.ReportObjects;

                            foreach (ReportObject crReportObject in crReportObjects)
                            {
                                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                                {
                                    crSubreportObject = (SubreportObject)crReportObject;

                                    crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

                                    crDatabase = crSubreportDocument.Database;
                                    crTables = crDatabase.Tables;

                                    foreach (Table crTable in crTables)
                                    {
                                        {
                                            var withBlock1 = crConnectioninfo;
                                            withBlock1.ServerName = Servername;
                                            withBlock1.DatabaseName = BaseDatos;
                                            withBlock1.UserID = Username;
                                            withBlock1.Password = Password;
                                        }
                                        crTableLogOnInfo = crTable.LogOnInfo;
                                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                                        crTable.ApplyLogOnInfo(crTableLogOnInfo);
                                    }
                                }
                            }
                        }

                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;
                        withBlock.visorRPT.LogOnInfo[0].ConnectionInfo.Type = ConnectionInfoType.SQL;

                        if (Filter != "")
                        {
                            withBlock.visorRPT.SelectionFormula = Filter;
                            crNicasoftStandarReport.RecordSelectionFormula = Filter;
                        }

                        if (_rutadestinoAGuardar != string.Empty)
                        {
                            // ** Si existe el Archivo, lo tenemos que borrar antes de guardar porque da errores
                            // ** Borrar Archivo   
                            File.Delete(_rutadestinoAGuardar);
                            // ** Exporta el archivo directamente. No pasa por el Visor
                            // ** Export está por defecto a pdf. Se puede cambiar en las variables de la función
                            crNicasoftStandarReport.ExportToDisk(Export, _rutadestinoAGuardar);
                        }
                        withBlock.visorRPT.Refresh();
                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;
                }
            }
        }

        /// <summary>
        ///     ''' Imprime el Report directamente en archivo con la ruta pasada y el tipo de archivo
        ///     ''' </summary>
        ///     ''' <param name="FileReport">Ruta del Report</param>
        ///     ''' <param name="Username">usuario Base datos</param>
        ///     ''' <param name="Password">password del usuario Base de datos</param>
        ///     ''' <param name="Servername">Servidor de la Base de Datos</param>
        ///     ''' <param name="listadeParametros">parametros para el crystal</param>
        ///     ''' <param name="_rutadestinoAGuardar">Ruta donde se guarda el archivo</param>
        ///     ''' <param name="Export">Tipo de Archivo a guardar</param>
        ///     ''' <remarks></remarks>
        public void PrintEnArchivoSP(string FileReport, string Username, string Password, string Servername, DataTable dtParametros, string _rutadestinoAGuardar = "", CrystalDecisions.Shared.ExportFormatType Export = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        {
            clsFunciones clsFunciones = new clsFunciones();
            frmVerInformes frmCRNet = new frmVerInformes();
            bool IsConnecting = true;
            ReportDocument crNicasoftStandarReport = new ReportDocument();
            Sections crSections;
            ReportObjects crReportObjects;
            SubreportObject crSubreportObject;
            ReportDocument crSubreportDocument;
            Database crDatabase;
            Tables crTables;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectioninfo;
            string BaseDatos = "TRANSPORTES";

            while (IsConnecting)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    crConnectioninfo = new ConnectionInfo();

                    {
                        var withBlock = crConnectioninfo;
                        withBlock.ServerName = Servername;
                        withBlock.DatabaseName = BaseDatos;
                        withBlock.UserID = Username;
                        withBlock.Password = Password;
                        withBlock.IntegratedSecurity = false;
                    }

                    {
                        var withBlock = frmCRNet;
                        crNicasoftStandarReport.Load(FileReport);

                        crDatabase = crNicasoftStandarReport.Database;

                        crTables = crDatabase.Tables;

                        foreach (Table crTable in crTables)
                        {
                            crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                            crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = false;
                            crTableLogOnInfo.ConnectionInfo.ServerName = Servername;
                            crTableLogOnInfo.ConnectionInfo.UserID = Username;
                            crTableLogOnInfo.ConnectionInfo.Password = Password;
                            crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos;
                            crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL;

                            crTableLogOnInfo.ReportName = FileReport;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }

                        crSections = crNicasoftStandarReport.ReportDefinition.Sections;

                        foreach (Section crSection in crSections)
                        {
                            crReportObjects = crSection.ReportObjects;

                            foreach (ReportObject crReportObject in crReportObjects)
                            {
                                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                                {
                                    crSubreportObject = (SubreportObject)crReportObject;

                                    crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

                                    crDatabase = crSubreportDocument.Database;
                                    crTables = crDatabase.Tables;

                                    foreach (Table crTable in crTables)
                                    {
                                        {
                                            var withBlock1 = crConnectioninfo;
                                            withBlock1.ServerName = Servername;
                                            withBlock1.DatabaseName = BaseDatos;
                                            withBlock1.UserID = Username;
                                            withBlock1.Password = Password;
                                        }
                                        crTableLogOnInfo = crTable.LogOnInfo;
                                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo;
                                        crTable.ApplyLogOnInfo(crTableLogOnInfo);
                                    }
                                }
                            }
                        }

                        withBlock.visorRPT.ReportSource = crNicasoftStandarReport;
                        withBlock.visorRPT.LogOnInfo[0].ConnectionInfo.Type = ConnectionInfoType.SQL;


                        foreach (DataRow dr in dtParametros.Rows)
                            crNicasoftStandarReport.SetParameterValue(dr["nombre_parametro"].ToString(), dr["valor_parametro"].ToString());

                        crNicasoftStandarReport.ExportToDisk(ExportFormatType.PortableDocFormat, _rutadestinoAGuardar);

                        IsConnecting = false;
                        DidPreviouslyConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                    frmCRNet.Close();
                    break;
                }
            }
        }
    }
}