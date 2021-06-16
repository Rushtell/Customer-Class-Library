using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Customer_Class_Library
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.AddressLine).MaximumLength(100).NotNull();
            RuleFor(address => address.SecondAddressLine).MaximumLength(100).NotNull();
            RuleFor(address => address.AddressType).IsInEnum();
            RuleFor(address => address.City).MaximumLength(50).NotNull();
            RuleFor(address => address.PostalCode).MaximumLength(6).NotNull();
            RuleFor(address => address.State).MaximumLength(20).NotNull();
            RuleFor(address => address.Country).Must(IsCountryValid).NotNull();

            bool IsCountryValid (string country)
            {
                string[] arrCountrys = new string[] { "United States", "Canada" };
                foreach (var item in arrCountrys)
                {
                    if (item == country) return true;
                }
                return false;
            }
        }
    }
}
