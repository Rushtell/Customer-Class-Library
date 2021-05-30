using FluentValidation.Results;
using System;
using Xunit;

namespace Customer_Class_Library.Test
{
    public class UnitTest1
    {
        
        [Fact]
        public void AdressClassTest()
        {
            Address testAdress = new Address();
            testAdress.AddressLine = "st.Pupkina";
            testAdress.SecondAddressLine = "house Vaniutkina";
            testAdress.AddressType = AddressType.Billing;
            testAdress.City = "Воронеж";
            testAdress.PostalCode = "1458";
            testAdress.State = "Texas";
            testAdress.Country = "Россия";

            Assert.Equal(testAdress.AddressLine, "st.Pupkina");
            Assert.Equal(testAdress.SecondAddressLine, "house Vaniutkina");
            Assert.Equal(testAdress.AddressType, AddressType.Billing);
            Assert.Equal(testAdress.City, "Воронеж");
            Assert.Equal(testAdress.PostalCode, "1458");
            Assert.Equal(testAdress.State, "Texas");
            Assert.Equal(testAdress.Country, "Россия");
        }

        [Fact]
        public void ValidatorsTestShouldBeEmptyString()
        {
            Address address = new Address()
            {
                AddressLine = "st. Pushkina",
                SecondAddressLine = "house Kolotushkina",
                AddressType = AddressType.Shipping,
                City = "Vakanda",
                PostalCode = "244433",
                State = "Texas",
                Country = "United States"
            };

            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer()
            {
                FirstName = "Vladislav",
                LastName = "Maslov",
                Address = address,
                PhoneNumber = "+322223",
                Email = "123@ewok.com",
                Note = "Hello, World!",
                Money = 322
            };

            ValidationResult result = validator.Validate(customer);
            Console.WriteLine(result.ToString("\n"));

            Assert.Equal("", result.ToString());
        }

        [Fact]
        public void ValidatorsTestShouldBeErrorCountry()
        {
            Address address = new Address()
            {
                AddressLine = "st. Pushkina",
                SecondAddressLine = "house Kolotushkina",
                AddressType = AddressType.Shipping,
                City = "Vakanda",
                PostalCode = "244433",
                State = "Texas",
                Country = "Russia"
            };

            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer()
            {
                FirstName = "Vladislav",
                LastName = "Maslov",
                Address = address,
                PhoneNumber = "+322223",
                Email = "123@ewok.com",
                Note = "Hello, World!",
                Money = 322
            };

            ValidationResult result = validator.Validate(customer);
            Console.WriteLine(result.ToString("\n"));

            Assert.Equal("Указанное условие не было выполнено для 'Country'.", result.ToString());
        }
    }
}
