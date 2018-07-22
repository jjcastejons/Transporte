Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Windows.Forms
Imports System.Windows.Forms
Imports System.IO

Public Class clsReport

    Implements IPrintReport
    Dim DidPreviouslyConnect As Boolean = False

    ''' <summary>
    ''' Imprime el informe en pantalla antes de pasarlo a la impresora
    ''' </summary>
    ''' <param name="FileReport">Ruta del informe</param>
    ''' <param name="DataSource">DataSet pasado para ver en el informe</param>
    ''' <param name="Filter">filtro opcional que queramos pasarle</param>
    ''' <remarks></remarks>
    Public Sub PrintPreview(ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
        Optional ByVal Filter As String = "") Implements IPrintReport.PrintPreview
        

        Dim frmCRNet As New frmVerInformes
        'Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crNicasoftStandarReport As New ReportDocument

        'If Not DidPreviouslyConnect Then
        ' frmStatusMessage.Show("Estableciendo conexión...")
        'End If

        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor

                With frmCRNet

                    With crNicasoftStandarReport
                        .Load(FileReport)
                        .SetDataSource(DataSource)
                    End With

                    .rptVisor.ReportSource = crNicasoftStandarReport

                    If Not Filter = String.Empty Then
                        .rptVisor.SelectionFormula = Filter
                    End If

                    .rptVisor.Refresh()
                    .Show()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    'frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)

                Cursor.Current = Cursors.Default
                'frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub


            End Try

        End While

    End Sub
    ''' <summary>
    ''' Imprime directamente el informe a la impresora determinada
    ''' </summary>
    ''' <param name="FileReport">Ruta del informe</param>
    ''' <param name="DataSource">DataSet pasado para mostrar</param>
    ''' <param name="Filter">Filtro que queramos pasarle</param>
    ''' <remarks></remarks>
    Public Sub Print(ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
        Optional ByVal Filter As String = "") Implements IPrintReport.Print

        Dim frmCRNet As New frmVerInformes
        'Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crNicasoftStandarReport As New ReportDocument


        'If Not DidPreviouslyConnect Then
        '    frmStatusMessage.Show("Estableciendo conexión...")
        'End If


        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor

                With frmCRNet

                    With crNicasoftStandarReport
                        .Load(FileReport)
                        .SetDataSource(DataSource)

                    End With

                    .rptVisor.ReportSource = crNicasoftStandarReport

                    If Not Filter = "" Then
                        .rptVisor.SelectionFormula = Filter
                    End If


                    .rptVisor.Refresh()
                    .rptVisor.PrintReport()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    'frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)

                Cursor.Current = Cursors.Default
                'frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub

            End Try

        End While

    End Sub

    ''' <summary>
    ''' Mostrar informe pasando los valores directamente de la Base de Datos
    ''' </summary>
    ''' <param name="FileReport">Ruta del informe</param>
    ''' <param name="Username">Usuario de la BBDD</param>
    ''' <param name="Password">Password de la BBDD</param>
    ''' <param name="Servername">Servidor SQL</param>
    ''' <param name="Filter">Filtro opcional a pasarle</param>
    ''' <remarks></remarks>
    Public Sub PrintLogon(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
        ByVal Servername As String, Optional ByVal Filter As String = "") Implements IPrintReport.PrintLogon

        Dim clsFunciones As New clsFunciones

        clsFunciones.grabarLogUsuario("Informes", "Visualizacion informe : " & FileReport & " Filtro: " & Filter)

        Dim frmCRNet As New frmVerInformes
        'Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crNicasoftStandarReport As New ReportDocument

        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject
        Dim crSubreportDocument As ReportDocument

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectioninfo As ConnectionInfo
        Dim BaseDatos As String = "vulcaban"

        'If Not DidPreviouslyConnect Then
        '    frmStatusMessage.Show("Estableciendo conexión...")
        'End If

        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor
                crConnectioninfo = New ConnectionInfo

                With crConnectioninfo
                    .ServerName = Servername
                    .DatabaseName = BaseDatos
                    .UserID = Username
                    .Password = Password
                    .IntegratedSecurity = False
                End With

                With frmCRNet

                    crNicasoftStandarReport.Load(FileReport)

                    crDatabase = crNicasoftStandarReport.Database

                    crTables = crDatabase.Tables

                    For Each crTable In crTables
                        crTableLogOnInfo = crTable.LogOnInfo
                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                        'crTableLogOnInfo.ConnectionInfo.DatabaseName = crConnectioninfo.DatabaseName
                        crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = False
                        crTableLogOnInfo.ConnectionInfo.ServerName = Servername
                        crTableLogOnInfo.ConnectionInfo.UserID = Username
                        crTableLogOnInfo.ConnectionInfo.Password = Password
                        crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos
                        crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL

                        crTableLogOnInfo.ReportName = FileReport
                        crTable.ApplyLogOnInfo(crTableLogOnInfo)
                    Next

                    crSections = crNicasoftStandarReport.ReportDefinition.Sections

                    For Each crSection In crSections
                        crReportObjects = crSection.ReportObjects

                        For Each crReportObject In crReportObjects
                            If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                                crSubreportObject = CType(crReportObject, SubreportObject)

                                crSubreportDocument = _
                                crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                                crDatabase = crSubreportDocument.Database
                                crTables = crDatabase.Tables

                                For Each crTable In crTables
                                    With crConnectioninfo
                                        .ServerName = Servername
                                        .DatabaseName = BaseDatos
                                        .UserID = Username
                                        .Password = Password
                                    End With
                                    crTableLogOnInfo = crTable.LogOnInfo
                                    crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                                Next

                            End If
                        Next
                    Next

                    .rptVisor.ReportSource = crNicasoftStandarReport
                    .rptVisor.LogOnInfo(0).ConnectionInfo.Type = ConnectionInfoType.SQL

                    If Not Filter = "" Then
                        .rptVisor.SelectionFormula = Filter
                    End If

                    .rptVisor.Refresh()
                    .Show()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    'frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Cursor.Current = Cursors.Default
                'frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub

            End Try

        End While

    End Sub

    ''' <summary>
    ''' Mostrar informe pasando los valores de un Procedimiento Almacenado de la Base de Datos
    ''' </summary>
    ''' <param name="FileReport">Ruta del informe</param>
    ''' <param name="Username">Usuario de la BBDD</param>
    ''' <param name="Password">Password de la BBDD</param>
    ''' <param name="Servername">Servidor SQL</param>
    ''' <param name="Filter">Filtro opcional a pasarle</param>
    ''' <remarks></remarks>
    Public Sub PrintLogonSP(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
        ByVal Servername As String, ByVal listadeParametros As ParameterFields, Optional ByVal Filter As String = "")

        Dim clsFunciones As New clsFunciones

        clsFunciones.grabarLogUsuario("Informes", "Visualizacion informe : " & FileReport & " Filtro: " & Filter)

        Dim frmCRNet As New frmVerInformes
        'Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crNicasoftStandarReport As New ReportDocument

        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject
        Dim crSubreportDocument As ReportDocument

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectioninfo As ConnectionInfo
        Dim BaseDatos As String = "vulcaban"

        'If Not DidPreviouslyConnect Then
        '    frmStatusMessage.Show("Estableciendo conexión...")
        'End If

        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor
                crConnectioninfo = New ConnectionInfo

                With crConnectioninfo
                    .ServerName = Servername
                    .DatabaseName = BaseDatos
                    .UserID = Username
                    .Password = Password
                    .IntegratedSecurity = False
                End With

                With frmCRNet

                    crNicasoftStandarReport.Load(FileReport)

                    crDatabase = crNicasoftStandarReport.Database

                    crTables = crDatabase.Tables

                    For Each crTable In crTables
                        crTableLogOnInfo = crTable.LogOnInfo
                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                        'crTableLogOnInfo.ConnectionInfo.DatabaseName = crConnectioninfo.DatabaseName
                        crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = False
                        crTableLogOnInfo.ConnectionInfo.ServerName = Servername
                        crTableLogOnInfo.ConnectionInfo.UserID = Username
                        crTableLogOnInfo.ConnectionInfo.Password = Password
                        crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos
                        crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL

                        crTableLogOnInfo.ReportName = FileReport
                        crTable.ApplyLogOnInfo(crTableLogOnInfo)
                    Next

                    crSections = crNicasoftStandarReport.ReportDefinition.Sections

                    For Each crSection In crSections
                        crReportObjects = crSection.ReportObjects

                        For Each crReportObject In crReportObjects
                            If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                                crSubreportObject = CType(crReportObject, SubreportObject)

                                crSubreportDocument = _
                                crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                                crDatabase = crSubreportDocument.Database
                                crTables = crDatabase.Tables

                                For Each crTable In crTables
                                    With crConnectioninfo
                                        .ServerName = Servername
                                        .DatabaseName = BaseDatos
                                        .UserID = Username
                                        .Password = Password
                                    End With
                                    crTableLogOnInfo = crTable.LogOnInfo
                                    crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                                Next

                            End If
                        Next
                    Next

                    .rptVisor.ReportSource = crNicasoftStandarReport
                    .rptVisor.LogOnInfo(0).ConnectionInfo.Type = ConnectionInfoType.SQL

                    If Not Filter = "" Then
                        .rptVisor.SelectionFormula = Filter
                    End If

                    'Dim juan As New ParameterFields



                    .rptVisor.ParameterFieldInfo = listadeParametros
                    .rptVisor.Refresh()
                    .Show()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    'frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Cursor.Current = Cursors.Default
                'frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub

            End Try

        End While

    End Sub
    ''' <summary>
    ''' Imprime el Report directamente en archivo con la ruta pasada y el tipo de archivo
    ''' </summary>
    ''' <param name="FileReport">Ruta del Report</param>
    ''' <param name="Username">usuario Base datos</param>
    ''' <param name="Password">password del usuario Base de datos</param>
    ''' <param name="Servername">Servidor de la Base de Datos</param>
    ''' <param name="Filter">Filtro del crystal</param>
    ''' <param name="_rutadestinoAGuardar">Ruta donde se guarda el archivo</param>
    ''' <param name="Export">Tipo de Archivo a guardar</param>
    ''' <remarks></remarks>
    Public Sub PrintEnArchivo(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
        ByVal Servername As String, Optional ByVal Filter As String = "", Optional ByVal _rutadestinoAGuardar As String = "", _
        Optional ByVal Export As CrystalDecisions.Shared.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat) Implements IPrintReport.PrintEnArchivo

        Dim clsFunciones As New clsFunciones

        clsFunciones.grabarLogUsuario("Informes", "Grabar informe en archivo : " & FileReport & " Filtro: " & Filter & ";Usuario: " & Usuario)

        Dim frmCRNet As New frmVerInformes
        'Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crNicasoftStandarReport As New ReportDocument

        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject
        Dim crSubreportDocument As ReportDocument

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectioninfo As ConnectionInfo
        Dim BaseDatos As String = "vulcaban"

        'If Not DidPreviouslyConnect Then
        '    frmStatusMessage.Show("Estableciendo conexión...")
        'End If

        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor
                crConnectioninfo = New ConnectionInfo

                With crConnectioninfo
                    .ServerName = Servername
                    .DatabaseName = BaseDatos
                    .UserID = Username
                    .Password = Password
                    .IntegratedSecurity = False
                End With

                With frmCRNet

                    crNicasoftStandarReport.Load(FileReport)

                    crDatabase = crNicasoftStandarReport.Database

                    crTables = crDatabase.Tables

                    For Each crTable In crTables
                        crTableLogOnInfo = crTable.LogOnInfo
                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                        'crTableLogOnInfo.ConnectionInfo.DatabaseName = crConnectioninfo.DatabaseName
                        crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = False
                        crTableLogOnInfo.ConnectionInfo.ServerName = Servername
                        crTableLogOnInfo.ConnectionInfo.UserID = Username
                        crTableLogOnInfo.ConnectionInfo.Password = Password
                        crTableLogOnInfo.ConnectionInfo.DatabaseName = BaseDatos
                        crTableLogOnInfo.ConnectionInfo.Type = ConnectionInfoType.SQL

                        crTableLogOnInfo.ReportName = FileReport
                        crTable.ApplyLogOnInfo(crTableLogOnInfo)
                    Next

                    crSections = crNicasoftStandarReport.ReportDefinition.Sections

                    For Each crSection In crSections
                        crReportObjects = crSection.ReportObjects

                        For Each crReportObject In crReportObjects
                            If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                                crSubreportObject = CType(crReportObject, SubreportObject)

                                crSubreportDocument = _
                                crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                                crDatabase = crSubreportDocument.Database
                                crTables = crDatabase.Tables

                                For Each crTable In crTables
                                    With crConnectioninfo
                                        .ServerName = Servername
                                        .DatabaseName = BaseDatos
                                        .UserID = Username
                                        .Password = Password
                                    End With
                                    crTableLogOnInfo = crTable.LogOnInfo
                                    crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                                Next

                            End If
                        Next
                    Next

                    .rptVisor.ReportSource = crNicasoftStandarReport
                    .rptVisor.LogOnInfo(0).ConnectionInfo.Type = ConnectionInfoType.SQL

                    If Not Filter = "" Then
                        .rptVisor.SelectionFormula = Filter
                        crNicasoftStandarReport.RecordSelectionFormula = Filter
                    End If

                    If _rutadestinoAGuardar <> String.Empty Then
                        '** Si existe el Archivo, lo tenemos que borrar antes de guardar porque da errores
                        '** Borrar Archivo   
                        File.Delete(_rutadestinoAGuardar)

                        '** Exporta el archivo directamente. No pasa por el Visor
                        '** Export está por defecto a pdf. Se puede cambiar en las variables de la función
                        crNicasoftStandarReport.ExportToDisk(Export, _rutadestinoAGuardar)
                    End If

                    .rptVisor.Refresh()
                    ''.Show()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    'frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Cursor.Current = Cursors.Default
                'frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub

            End Try

        End While

    End Sub
End Class
