using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            var list = new List<Customer>();
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    list = context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Customer FindById(string username)
        {
            Customer p = new Customer();
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    p = context.Customers.SingleOrDefault(x => x.username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static Customer Save(Customer p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    var entityEntry = context.Customers.Add(p);
                    context.SaveChanges();
                    return entityEntry.Entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update(Customer p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(Customer p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    var p1 = context.Customers.SingleOrDefault(x => x.username == p.username);
                    context.Customers.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}