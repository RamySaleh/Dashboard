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
    }
}
