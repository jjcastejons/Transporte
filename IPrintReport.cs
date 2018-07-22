using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Transportes
{
    public interface IPrintReport
    {

        void PrintPreview(String FileReport, DataSet Datasource, String Filter);
        void Print(String FileReport, DataSet Datasource, String Filter);
        void PrintLogon(String FileReport, String Username, String Password, String Servername, String Filter);
        //void PrintEnArchivo(String FileReport, String Username, String Password, String Servername, DataSet Datasource, String Filter);
        //Sub PrintEnArchivo(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
        //  ByVal Servername As String, Optional ByVal Filter As String = "", Optional ByVal _rutadestinoAGuardar As String = "", Optional ByVal Export As CrystalDecisions.Shared.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    }
}
