using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public class EFAddressesRepository : IRepository<Address>
    {
        DataContext database { get; set; }

        public EFAddressesRepository()
        {
            database = new DataContext();
        }

        public virtual int Create(Address entity)
        {
            database.Addresses.Add(entity);
            database.SaveChanges();
            return entity.AddressId;
        }

        public virtual Address Read(int id)
        {
            return database.Addresses.FirstOrDefault(e => e.AddressId == id);
        }

        public virtual Address Update(Address entity)
        {
            var address = database.Addresses.Where(e => e.AddressId == entity.AddressId).FirstOrDefault();

            address.CustomerId = entity.CustomerId;
            address.AddressLine = entity.AddressLine;
            address.SecondAddressLine = entity.SecondAddressLine;
            address.AddressType = entity.AddressType;
            address.City = entity.City;
            address.PostalCode = entity.PostalCode;
            address.State = entity.State;
            address.Country = entity.Country;

            database.SaveChanges();
            return address;
        }

        public virtual bool Delete(int id)
        {
            try
            {
                database.Addresses.Remove(database.Addresses.FirstOrDefault(e => e.AddressId == id));
                database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual List<Address> ReadCustomerAddresses(int id)
        {
            return database.Addresses.Where(e => e.CustomerId == id).ToList();
        }

        public virtual bool DeleteAllByCustomerId(int id)
        {
            try
            {
                var listToDelete = database.Addresses.Where(e => e.CustomerId == id).ToList();
                foreach (var item in listToDelete)
                {
                    database.Addresses.Remove(item);
                }
                database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
