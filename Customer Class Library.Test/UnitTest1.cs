using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
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
            testAdress.City = "Âîðîíåæ";
            testAdress.PostalCode = "1458";
            testAdress.State = "Texas";
            testAdress.Country = "Ðîññèÿ";

            Assert.Equal("st.Pupkina", testAdress.AddressLine);
            Assert.Equal("house Vaniutkina", testAdress.SecondAddressLine);
            Assert.Equal(AddressType.Billing, testAdress.AddressType);
            Assert.Equal("Âîðîíåæ", testAdress.City);
            Assert.Equal("1458", testAdress.PostalCode);
            Assert.Equal("Texas", testAdress.State);
            Assert.Equal("Ðîññèÿ", testAdress.Country);
        }

        [Fact]
        public void ValidatorsTestShouldBeEmptyString()
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;

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

            Customer customer = new Customer()
            {
                FirstName = "Vladislav",
                LastName = "Maslov",
                Address = address,
                PhoneNumber = "+322223",
                Email = "123@ewok.com",
                Note = new List<string>() { "Hello", "World!" },
                Money = 322
            };

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            Assert.Equal("", result.ToString());
        }

        [Fact]
        public void ValidatorsTestShouldBeAllErrorsWithoutAddress()
        {
            Address address = new Address()
            {
                AddressLine = "st. Pushkinaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                SecondAddressLine = "house Kolotushkinaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                AddressType = AddressType.Shipping,
                City = "Vakandaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostalCode = "244433234343",
                State = "Texassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss",
                Country = "United"
            };

            Customer customer = new Customer()
            {
                FirstName = "V",
                LastName = "M",
                Address = address,
                PhoneNumber = "3",
                Email = "123ewok.com",
                Money = 322
            };

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            Assert.Equal(12, result.Errors.Count);
        }

        [Fact]
        public void ValidatorsTestShouldBeAllNullErrors()
        {
            Address address = new Address();

            Customer customer = new Customer();

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            Assert.Equal(8, result.Errors.Count);
        }
    }
}
