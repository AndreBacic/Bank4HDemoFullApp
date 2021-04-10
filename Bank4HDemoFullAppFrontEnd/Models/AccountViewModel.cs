using Bank4HDemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank4HDemoFullAppFrontEnd.Models
{
    public class AccountViewModel
    {
        public List<PaymentModel> PaidPayments { get; set; } = new List<PaymentModel>();
        public List<PaymentModel> UnpaidPayments { get; set; } = new List<PaymentModel>();
        public User User { get; set; }
    }
}
