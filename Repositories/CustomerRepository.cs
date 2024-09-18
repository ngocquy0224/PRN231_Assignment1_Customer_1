using BusinessObjects;
using DataAccess;
using DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Delete(Customer customer)
        => CustomerDAO.Delete(customer);

        public Customer GetById(string username)
         => CustomerDAO.FindById(username);

        public List<Customer> GetCustomers()
         => CustomerDAO.GetCustomers();

        public Customer Save(Customer customer)
        => CustomerDAO.Save(customer);

        public void Update(Customer customer)
        => CustomerDAO.Update(customer);
    }
}
