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
            RuleFor(customer => customer.FirstName).Length(3,50);

            RuleFor(customer => customer.LastName).Length(3,50);

            RuleFor(customer => customer.Address).SetValidator(new AddressValidator());

            RuleFor(customer => customer.PhoneNumber).MaximumLength(15).NotEmpty().Must(IsPhoneValid);

            //string pattern = @"[0-9a-z]*\@[0-9a-z]*\.[a-z]*";
            //Regex.IsMatch(customer.Address, pattern, RegexOptions.IgnoreCase);

            RuleFor(customer => customer.Email).EmailAddress().NotEmpty();

            RuleFor(customer => customer.Note).NotEmpty();

            RuleFor(customer => customer.Money).NotEmpty();

            bool IsPhoneValid(string phone)
            {
                if (phone == null) return false;
                return !(!phone.StartsWith("+") || !phone.Substring(1).All(c => Char.IsDigit(c)));
            }

        }
    }
}
