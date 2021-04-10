using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank4HDemoFullAppFrontEnd.Models;
using Bank4HDemoLibrary;

namespace Bank4HDemoFullAppFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public User user = null;
        private readonly SQLDataAccessor _dataAccessor;
        public List<PaymentModel> payments = null;

        public HomeController(ILogger<HomeController> logger, User user, SQLDataAccessor dataAccessor)
        {
            _logger = logger;
            _dataAccessor = dataAccessor;
            this.user = user; // hopefully DI will sort this
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The account page shows a list of previous payments and a link to pay the current bill
        /// </summary>
        /// <returns>The completed page</returns>
        public IActionResult Account()
        {
            AccountViewModel accountView = new AccountViewModel();
            accountView.User = this.user;

            payments = _dataAccessor.GetPayments();
            foreach (PaymentModel p in payments)
            {
                if (p.DatePaid != null && p.DatePaid != DateTime.MinValue)
                {
                    accountView.PaidPayments.Add(p);
                }
                else
                {
                    accountView.UnpaidPayments.Add(p);
                }
            }

            return View(accountView);
        }

        /// <summary>
        /// Page that shows confirmation of payment and sends payment Id for payment to be made
        /// </summary>
        /// <param name="id">Id of payment</param>
        /// <returns>View of page</returns>
        public IActionResult CompletePayment(int id)
        {
            PaymentModel payment = _dataAccessor.GetPayments().Where(x => x.Id == id).First();
            return View(payment);
        }

        /// <summary>
        /// Page that displays information about payment before user agrees to pay
        /// </summary>
        /// <param name="id">Id of payment</param>
        /// <returns>View of page, teling the view true is the payment was successfully completed or false if something went wrong.</returns>
        public IActionResult MakePayment(int id)
        {
            payments = _dataAccessor.GetPayments();
            if (payments.Any())
            {

                PaymentModel payment = payments.Where(x => x.Id == id).First();
                if (payment != null)
                {
                    payment.DatePaid = DateTime.Now;
                    _dataAccessor.UpdatePayment(payment);

                    this.user.BankBalance -= payment.Amount;

                    return View(true); // view has redirect to account button
                }
            }
            return View(false); // view has redirect to account button
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
