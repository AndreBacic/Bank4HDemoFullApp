using System;
using System.Collections.Generic;
using System.Text;
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
            
            // TODO - finish this method

            return output;
        }
    }
}
