using BusinessObjects;
using System.Collections.Generic;

namespace DataAccess
{
    public interface ICustomerRepository
    {
        Customer Save(Customer customer);
        Customer GetById(string username);
        void Delete(Customer customer);
        void Update(Customer customer);
        List<Customer> GetCustomers();
    }
}
