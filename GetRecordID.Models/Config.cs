using GetRecordID.Models.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRecordID.Models
{
    public class Config
    {
        public static DbConnect DbConnection { get; private set; }
        
        public static string DbConnectionString(string name) => ConfigurationManager.ConnectionStrings[name].ConnectionString;

        public static void InitializeConnection()
        {
            DbConnect sqlConnection = new DbConnect();
            DbConnection = sqlConnection;
        }

    }
}
