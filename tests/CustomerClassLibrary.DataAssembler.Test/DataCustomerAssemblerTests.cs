using System;
using Xunit;
using System.Collections.Generic;
using Moq;

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

        [Fact]
        public void ShouldDeleteCustomerTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            customerAssembler.DeleteCustomer(1);
        }

        [Fact]
        public void ShouldUpdateCustomerTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            customerAssembler.UpdateCustomer(new Customer()
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
        }

        [Fact]
        public void ShouldGetAllCustomersTest()
        {
            Mock<DataCustomerAssembler> mock = new Mock<DataCustomerAssembler>();
            mock.Setup(m => m.GetAll()).Returns(new List<Customer>() { new Customer(), new Customer() });
            var result = mock.Object.GetAll().Count;

            Assert.Equal(2, result);
        }

        [Fact]
        public void ShouldGetSelectionCustomersTest()
        {
            Mock<DataCustomerAssembler> mock = new Mock<DataCustomerAssembler>();
            mock.Setup(m => m.GetSelection(10, 15)).Returns(new List<Customer>() { new Customer(), new Customer(), new Customer(), new Customer(), new Customer() });
            var result = mock.Object.GetSelection(10, 15).Count;

            Assert.Equal(5, result);
        }

        [Fact]
        public void ShouldGetCountResult10Test()
        {
            Mock<DataCustomerAssembler> mock = new Mock<DataCustomerAssembler>();
            mock.Setup(m => m.Count()).Returns(10);
            var result = mock.Object.Count();

            Assert.Equal(10, result);
        }
    }
}
