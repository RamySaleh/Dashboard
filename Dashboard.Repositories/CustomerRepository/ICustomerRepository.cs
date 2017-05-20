using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> FilterCustomers(string customerName, bool? vehicleStatus);
    }
}
