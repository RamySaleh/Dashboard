using Dashboard.Models;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        DocumentClient _dbClient;
        Uri _customersLink;

        public CustomerRepository()
        {
            // The database url and a read-only key
            _dbClient = new DocumentClient(new Uri("https://dashboardaccount.documents.azure.com:443/"), "OQKy6bd1354FkVYfaPSngzaJcXfd1w4L8M49zSJ2EMZZqg5egxakA9OQV9JJXveBHT9ka9cSmUhGwoTCZ8N4sg==");
            _customersLink = UriFactory.CreateDocumentCollectionUri("DashboardDB", "Customers");
        }      

        public IQueryable<Customer> GetAll()
        {
            var customers = _dbClient.CreateDocumentQuery<Customer>(_customersLink).OrderBy(c => c.Name);
            return customers;
        }

        public IQueryable<Customer> FilterCustomers(string customerName, bool? vehicleStatus)
        {
            var customers = _dbClient.CreateDocumentQuery<Customer>(_customersLink).Where(c => c.Name.StartsWith(customerName));

            if (vehicleStatus.HasValue)
            {
                customers = customers.ToList().Where(c => c.OwnedVehicles.Any(v => v.Status == vehicleStatus.Value)).AsQueryable();
                foreach (var customer in customers)
                {
                    customer.OwnedVehicles = customer.OwnedVehicles.Where(v => v.Status = vehicleStatus.Value).ToList();
                }
            }
                
            return customers.OrderBy(c => c.Name).AsQueryable();
        }

        public string Update(Customer updatedEntity)
        {
            var documentUri = UriFactory.CreateDocumentUri("DashboardDB", "Customers", updatedEntity.id);

            var updated = _dbClient.ReplaceDocumentAsync(documentUri, updatedEntity).Result;

            return updated.Resource.Id;
        }
    }
}
