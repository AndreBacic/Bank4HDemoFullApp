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
* TODO - make attached front end
* TODO - make console back-end data accessor
* TODO - make deposit class
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
        public SQLDataAccessor(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Bank4HDemo");
        }
        public void InsertPayment(PaymentModel payment)
        {
            // TODO - finish this method
        }

        public void UpdatePayment(PaymentModel payment)
        {
            // TODO - finish this method
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
