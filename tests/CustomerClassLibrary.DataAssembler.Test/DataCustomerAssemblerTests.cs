using System;
using Xunit;
using System.Collections.Generic;

namespace CustomerClassLibrary.DataAssembler.Test
{
    public class DataCustomerAssemblerTests
    {
        [Fact]
        public void BuildTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            var customer = customerAssembler.BuildCustomer(2);

            Assert.Equal("st Pushkina", customer.Address[0].AddressLine);
        }

        [Fact]
        public void ShouldCreateCustomerTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            var customer = customerAssembler.CreateCustomer(new Customer() 
            { 
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                PhoneNumber = "Test",
                Money = 100,
                Address = new List<Address>() { new Address() { 
                    AddressLine = "Test",
                    SecondAddressLine = "Test",
                    City = "Test",
                    AddressType = AddressType.Billing,
                    Country = "Canada",
                    PostalCode = "123456",
                    State = "Test"
                } },
                Note = new List<Note>() { new Note() { CustomerId = 2, Text = "Hello" }, new Note() { CustomerId = 2, Text = "World" } }
            });


             Assert.True(customer.CustomerId > 0);
             Assert.True(customer.Address[0].AddressId > 0);

        }
    }
}
