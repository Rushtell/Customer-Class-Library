using FluentValidation;
using FluentValidation.Results;
using System;
using Xunit;

namespace Customer_Class_Library.Test
{
    public class UnitTest1
    {
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

            CustomerValidator validator = new CustomerValidator(customer);

            string result = "";
            foreach (var item in validator.ErrorsList)
            {
                result += item;
            }

            Assert.Equal("", result);
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

            CustomerValidator validator = new CustomerValidator(customer);

            string result = "";
            foreach (var item in validator.ErrorsList)
            {
                result += $"\n{item}";
            }

            Assert.Equal("\nFirstName incorrect\nLastName incorrect\nAddressLine incorrect" +
                "\nSecondAddressLine incorrect\nCity incorrect\nPostalCode incorrect\nState incorrect\nCountry incorrect" +
                "\nPhone number incorrect\nEmail incorrect\nNote incorrect", result);
        }

        [Fact]
        public void ValidatorsTestShouldBeAllErrors()
        {
            Address address = new Address();

            Customer customer = new Customer() { Address = address};

            CustomerValidator validator = new CustomerValidator(customer);

            string result = "";
            foreach (var item in validator.ErrorsList)
            {
                result += $"\n{item}";
            }

            Assert.Equal("\nFirstName incorrect\nLastName incorrect\nAddressLine incorrect" +
                "\nSecondAddressLine incorrect\nCity incorrect\nPostalCode incorrect\nState incorrect\nCountry incorrect" +
                "\nPhone number incorrect\nEmail incorrect\nNote incorrect", result);
        }

        [Fact]
        public void ValidatorsTestShouldBeErrorsWithoutAdress()
        {
            Address address = new Address();

            Customer customer = new Customer();

            CustomerValidator validator = new CustomerValidator(customer);

            string result = "";
            foreach (var item in validator.ErrorsList)
            {
                result += $"\n{item}";
            }

            Assert.Equal("\nFirstName incorrect\nLastName incorrect\nAddress incorrect" +
                "\nPhone number incorrect\nEmail incorrect\nNote incorrect", result);
        }
    }
}
