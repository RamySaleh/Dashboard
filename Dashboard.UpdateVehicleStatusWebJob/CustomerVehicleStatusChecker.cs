using Dashboard.Models;
using Dashboard.Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.UpdateVehicleStatusWebJob
{
    public class CustomerVehicleStatusChecker
    {
        ICustomerRepository customerRepository;

        public CustomerVehicleStatusChecker(ICustomerRepository customerRepository)
        {
            if (customerRepository == null)
            {
                this.customerRepository = new CustomerRepository();
            }
            else
            {
                this.customerRepository = customerRepository;
            }
        }
        public void UpdateVehiclesStatus()
        {
            var customers = customerRepository.GetAll();
            var connectionChecker = new ConnectionChecker();

            foreach (var customer in customers)
            {
                foreach (var vehicle in customer.OwnedVehicles)
                {
                    vehicle.Status = connectionChecker.CheckVehicleStatus(vehicle);
                }

                var result = customerRepository.Update(customer);

                Console.WriteLine($"Document {result} updated");
            }            
        }
    }
}
