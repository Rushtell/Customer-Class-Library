using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class DataAddressesRepositoryTests
    {
        [Fact]
        public void TestCreate()
        {
            var addressesRepository = new AddressesRepository();
            addressesRepository.Create(new Address()
            {
                CustomerId = 2,
                AddressLine = "st Pushkina",
                SecondAddressLine = "house Kolotushkina",
                AddressType = AddressType.Billing,
                City = "Chelybinsk",
                Country = "United States",
                PostalCode = "123456",
                State = "Texas"
            });
        }

        [Fact]
        public void TestRead()
        {
            var addressesRepository = new AddressesRepository();
            addressesRepository.Read(1);
        }

        [Fact]
        public void ReadCustomerAddresses()
        {
            var addressesRepository = new AddressesRepository();
            addressesRepository.ReadCustomerAddresses(2);
        }

        [Fact]
        public void TestUpdate()
        {
            var addressesRepository = new AddressesRepository();
            addressesRepository.Update(new Address()
            {
                AddressId = 1,
                CustomerId = 2,
                AddressLine = "st Pushkina",
                SecondAddressLine = "house Kolotushkina",
                AddressType = AddressType.Billing,
                City = "Chelybinsk",
                Country = "United States",
                PostalCode = "123456",
                State = "Texas"
            });
        }

        [Fact]
        public void TestDelete()
        {
            var addressesRepository = new AddressesRepository();
            addressesRepository.Delete(1);
        }
    }
}
