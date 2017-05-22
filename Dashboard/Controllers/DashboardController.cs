using Dashboard.Models;
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
        public ActionResult Index(string customerNameFilter, string vehicleStatusFilter)
        {
            var customers = new List<Customer>();
            if (string.IsNullOrEmpty(customerNameFilter) && string.IsNullOrEmpty(vehicleStatusFilter))
            {
                customers = new CustomerRepository().GetAll().ToList();
            }
            else
            {
                bool? vehicleStatus = null;
                if (vehicleStatusFilter != "All")
                {
                    bool parsedStatus;
                    if (bool.TryParse(vehicleStatusFilter, out parsedStatus))
                    {
                        vehicleStatus = parsedStatus;
                    }
                }

                customers = new CustomerRepository().FilterCustomers(customerNameFilter, vehicleStatus).ToList();                
            }           
            
            return View(customers);
        }
    }
}