using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public class EFCustomerRepository : IRepository<Customer>
    {
        DataContext database { get; set; }

        public EFCustomerRepository()
        {
            database = new DataContext();
        }

        public virtual int Create(Customer entity)
        {
            database.Customers.Add(entity);
            database.SaveChanges();
            return entity.CustomerId;
        }

        public virtual Customer Read(int id)
        {
            return database.Customers.FirstOrDefault(e => e.CustomerId == id);
        }

        public virtual Customer Update(Customer entity)
        {
            var customer = database.Customers.Where(e => e.CustomerId == entity.CustomerId).FirstOrDefault();
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.PhoneNumber = entity.PhoneNumber;
            customer.Email = entity.Email;
            customer.Money = entity.Money;

            database.SaveChanges();
            return customer;
        }

        public virtual bool Delete(int id)
        {
            try
            {
                database.Customers.Remove(database.Customers.FirstOrDefault(e => e.CustomerId == id));
                database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual List<Customer> ReadAll()
        {
            return database.Customers.ToList();
        }

        public virtual List<Customer> ReadSelect(int numFrom, int numTo)
        {
            return database.Customers.OrderBy(e => e.CustomerId).Skip(numFrom).Take(numTo - numFrom).ToList();
        }

        public virtual int Count()
        {
            return database.Customers.Count();
        }
    }
}
