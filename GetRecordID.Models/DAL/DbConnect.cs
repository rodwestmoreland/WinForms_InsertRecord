using Dapper;
using GetRecordID.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRecordID.Models.DAL
{
    public class DbConnect
    {
        private const string db = "ConnectionString_SampleDataDB";

        public void CreateRecord(Record model)
        {
            using (var connection = new SqlConnection(Config.DbConnectionString(db))) 
            {
                var sql = @"INSERT INTO [dbo].[SampleData]  (
                                        [BogusName],
                                        [CourtDate],
                                        [AmountOwed]                    )
                            VALUES (@BogusName, @CourtDate, @AmountOwed)";

                var newRecord = new Record()
                {
                    BogusName = model.BogusName,
                    CourtDate = model.CourtDate,
                    AmountOwed = model.AmountOwed
                };

                connection.Execute(sql, newRecord);
            }
            
        }
    }
}
