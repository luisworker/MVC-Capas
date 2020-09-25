using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Proyectos
{
    public class CrystalReportsCnn
    {
        public static CrystalDecisions.Shared.ConnectionInfo GetConnectionInfo() 
        {
            var Sconn = new System.Data.SqlClient.SqlConnectionStringBuilder(
                System.Configuration.ConfigurationManager.ConnectionStrings["ProyectosConnection"].ConnectionString);

            CrystalDecisions.Shared.ConnectionInfo connInfo = new CrystalDecisions.Shared.ConnectionInfo();
            connInfo.ServerName = Sconn.DataSource;
            connInfo.DatabaseName = Sconn.InitialCatalog;
            connInfo.UserID = Sconn.UserID;
            connInfo.Password = Sconn.Password;
            return connInfo;
        }
    }
}