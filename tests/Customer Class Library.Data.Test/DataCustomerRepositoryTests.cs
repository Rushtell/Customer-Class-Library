using System;
using System.Collections.Generic;
using Xunit;

namespace Customer_Class_Library.Data.Test
{
    public class DataCustomerRepositoryTests
    {
        [Fact]
        public void TestCreate()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Create(new Customer()
            {
                FirstName = "Valera",
                LastName = "Petrunov",
                Address = new List<Address>() { new Address() { AddressLine = "st Pushkina", SecondAddressLine = "house Kolotushkina", AddressType = AddressType.Billing, City = "Chelybinsk", Country = "United States", PostalCode = "123456", State = "Texas" } },
                Email = "qwer@gmail.com",
                PhoneNumber = "+7123456789",
                Note = new List<string>() { "Hello", "World" },
                Money = (decimal)100.51
            });
        }

        [Fact]
        public void TestRead()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Read(1);
        }

        [Fact]
        public void TestUpdate()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Update(new Customer()
            {
                CustomerId = 1,
                FirstName = "Valera2",
                LastName = "Petrunov2",
                Address = new List<Address>() { new Address() { AddressLine = "st Pushkina", SecondAddressLine = "house Kolotushkina", AddressType = AddressType.Billing, City = "Chelybinsk", Country = "United States", PostalCode = "123456", State = "Texas" } },
                Email = "qwer2@gmail.com",
                PhoneNumber = "+71234567892",
                Note = new List<string>() { "Hello2", "World2" },
                Money = (decimal)100.67
            });
        }

        [Fact]
        public void TestDelete()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Delete(1);
        }
    }
}
