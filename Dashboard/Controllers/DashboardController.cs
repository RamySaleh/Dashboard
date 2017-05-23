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

        public ActionResult Edit(string id)
        {
            var customer = new CustomerRepository().GetById(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(string id,FormCollection collection)
        {
            var customerRepository = new CustomerRepository();
            var customer = customerRepository.GetById(id);
            if (TryUpdateModel(customer))
            {
                customerRepository.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}