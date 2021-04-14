using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Configuration;
/*
* NOTES:
* 
* TODO - make seperate front end
*/
/// <summary>
/// Web development demo application for my 2021 4H presentation.
/// 
/// This library is for both the full stack and back end demos.
/// 
/// There is a seperate front end that will most likely not be run from VS.
/// 
/// Notes on the whole demo are recorded in Bank4HDemoLibrary.DataAccessor
/// </summary>
namespace Bank4HDemoLibrary
{
    public class SQLDataAccessor
    {
        private string ConnectionString;

        /// <summary>
        /// Sets up the data accessor
        /// </summary>
        /// <param name="configuration">Parameter to be supplied by dependency injection</param>
        public SQLDataAccessor(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Bank4HDemo");

            DemoDBReset();
        }

        /// <summary>
        /// Sets up the data accessor
        /// </summary>
        /// <param name="connectionString">DB connection string must be supplied manually in this overload</param>
        public SQLDataAccessor(string connectionString)
        {
            ConnectionString = connectionString;

            DemoDBReset();
        }

        /// <summary>
        /// Runs a stored procedure that resets the demo db. This method is called by the constructor.
        /// </summary>
        public void DemoDBReset()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                connection.Execute("dbo.spPayments_DemoReset", commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePayment(PaymentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var p = new DynamicParameters();

                p.Add("@Id", model.Id);
                p.Add("@datePaid", model.DatePaid);

                connection.Execute("dbo.spPayments_Update", p, commandType: CommandType.StoredProcedure);        
            }
        }

        public List<PaymentModel> GetPayments()
        {
            List<PaymentModel> output = new List<PaymentModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                output = connection.Query<PaymentModel>("dbo.spPayments_GetAll").ToList();
            }

            return output;
        }
    }
}
