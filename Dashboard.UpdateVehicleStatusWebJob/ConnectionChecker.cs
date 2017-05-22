using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.UpdateVehicleStatusWebJob
{
    public class ConnectionChecker
    {
        public bool CheckVehicleStatus(Vehicle vehicle)
        {
            return new Random().Next() % 2 == 0;
        }
    }
}
