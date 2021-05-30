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
            RuleFor(address => address.SecondAddressLine).MaximumLength(100);
            RuleFor(address => address.AddressType).IsInEnum();
            RuleFor(address => address.City).MaximumLength(50);
            RuleFor(address => address.PostalCode).MaximumLength(6);
            RuleFor(address => address.State).MaximumLength(20);
            RuleFor(address => address.Country).Must(IsCountryValid).NotEmpty();

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
