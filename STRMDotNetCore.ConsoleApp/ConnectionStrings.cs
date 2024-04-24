using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.ConsoleApp
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-J9BO0AP\\MSSQL2019",
            InitialCatalog = "STMDB",
            UserID = "sa",
            Password = "123@ace.com",
            TrustServerCertificate=true
        };
    }
}
