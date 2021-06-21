using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.Test
{
    public class ValidatorsTests
    {
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
                Address = new List<Address>() { address },
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
                Address = new List<Address>() { address },
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

            Assert.Equal(7, result.Errors.Count);
        }
    }
}
