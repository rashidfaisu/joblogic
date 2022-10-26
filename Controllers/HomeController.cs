using JobLogic.Models;
using JobLogic.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JobLogic.Services;

namespace JobLogic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService objCust;

        public HomeController(ILogger<HomeController> logger,ICustomerService objCust)
        {
            _logger = logger;
            this.objCust = objCust;

        }

        #region Customer
        public IActionResult Index()
        {
            List<Customers> DataList = new List<Customers>();
            DataList = objCust.GetCustomers();
            return View(DataList);
        }

        public IActionResult AddCustomer()
        {
            Customers Costomer = new Customers();
            return View(Costomer);
        }

        public IActionResult SaveCustomer(Customers Customer)
        {
            objCust.AddCustomer(Customer);

            return RedirectToAction("Index");
        }

        #endregion Customer

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
