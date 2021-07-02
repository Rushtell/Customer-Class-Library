using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.Data.Test
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
                Address = new List<Address>() { new Address() { AddressLine = "st Pushkina", SecondAddressLine = "house Kolotushkina", AddressTypeEnum = AddressType.Billing, City = "Chelybinsk", Country = "United States", PostalCode = "123456", State = "Texas" } },
                Email = "qwer@gmail.com",
                PhoneNumber = "+7123456789",
                Note = new List<Note>() { new Note() { CustomerId = 2, Text = "Hello"}, new Note() { CustomerId = 2, Text = "World" } },
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
                Address = new List<Address>() { new Address() { AddressLine = "st Pushkina", SecondAddressLine = "house Kolotushkina", AddressTypeEnum = AddressType.Billing, City = "Chelybinsk", Country = "United States", PostalCode = "123456", State = "Texas" } },
                Email = "qwer2@gmail.com",
                PhoneNumber = "+71234567892",
                Note = new List<Note>() { new Note() { CustomerId = 2, Text = "Hello" }, new Note() { CustomerId = 2, Text = "World" } },
                Money = (decimal)100.67
            });
        }

        [Fact]
        public void TestDelete()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Delete(1);
        }

        [Fact]
        public void TestGetFirst15Customers()
        {
            var customerRepository = new CustomerRepository();
            var customers = customerRepository.ReadSelect(0, 15);

            Assert.True(customers.Count > 0);
        }

        [Fact]
        public void TestCount()
        {
            var customerRepository = new CustomerRepository();
            var count = customerRepository.Count();
            Assert.True(count > 0);
        }

        [Fact]
        public void TestReadAll()
        {
            var customerRepository = new CustomerRepository();
            var count = customerRepository.ReadAll().Count;
            Assert.True(count > 0);
        }
    }
}
