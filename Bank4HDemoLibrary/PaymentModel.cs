using System;
using System.Collections.Generic;
using System.Text;

namespace Bank4HDemoLibrary
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DatePaid { get; set; }
    }
}
