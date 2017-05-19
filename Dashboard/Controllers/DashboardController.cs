using Dashboard.Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var customers = new CustomerRepository().GetAll().ToList();
            return View(customers);
        }
    }
}