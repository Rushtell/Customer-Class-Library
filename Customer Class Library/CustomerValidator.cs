using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer_Class_Library
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).Length(3,50).NotNull();

            RuleFor(customer => customer.LastName).Length(3,50).NotNull();

            RuleFor(customer => customer.Address).SetValidator(new AddressValidator()).NotNull();

            RuleFor(customer => customer.PhoneNumber).MaximumLength(15).NotNull().Must(IsPhoneValid);

            RuleFor(customer => customer.Email).EmailAddress().NotNull();

            RuleFor(customer => customer.Note).NotEmpty().NotNull();

            RuleFor(customer => customer.Money).NotNull();

            bool IsPhoneValid(string phone)
            {
                if (phone == null) return false;
                return !(!phone.StartsWith("+") || !phone.Substring(1).All(c => Char.IsDigit(c)));
            }

        }
    }
}
