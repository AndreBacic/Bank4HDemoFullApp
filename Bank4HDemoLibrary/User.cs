using System;
using System.Collections.Generic;
using System.Text;

namespace Bank4HDemoLibrary
{
    public class User
    {
        public string Name { get; set; } = "Andre";
        public decimal BankBalance { get; set; } = 4170.31m;

        /// <summary>
        /// Storing this this way is probably not secure for a real application
        /// </summary>
        public string CreditCardNumber { get; set; } = "8644-9971-6929-5064";
    }
}
