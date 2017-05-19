using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Customer
    {
        public string id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Vehicle> OwnedVehicles { get; set; }

        public Customer()
        {
            OwnedVehicles = new List<Vehicle>();
        }
    }
}
