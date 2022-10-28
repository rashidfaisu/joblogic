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
            return RedirectToAction("Customer");
        }

        public IActionResult Customer()
        {
            var datalist = objCust.GetCustomers();
            return View(datalist);
        }

        public IActionResult Details(Customers data)
        {
            return View(data);
        }

        public IActionResult Edit(Customers data)
        {
            return View("AddCustomer", data);
        }

        public IActionResult AddCustomer(Customers data)
        {
            objCust.AddCustomer(data);
            return RedirectToAction("Customer");
        }

        public IActionResult Delete(Customers data)
        {
            objCust.DeleteCustomer(data);
            return RedirectToAction("Customer");
        }

        public IActionResult Create()
        {
            var data = new Customers();
            return View("AddCustomer", data);
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
