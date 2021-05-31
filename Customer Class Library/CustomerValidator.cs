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
        public List<string> ErrorsList { get; set; }

        public CustomerValidator(Customer customer)
        {
            ErrorsList = new List<string>();
            CheckFirstName(customer);
            CheckLastName(customer);
            CheckAddress(customer);
            CheckPhone(customer);
            CheckEmail(customer);
            CheckNote(customer);
        }

        void CheckFirstName(Customer customer)
        {
            if (customer.FirstName == null)
            {
                ErrorsList.Add("FirstName incorrect");
                return;
            }
            if (customer.FirstName.Length < 3 || customer.FirstName.Length > 50) ErrorsList.Add("FirstName incorrect");
        }

        void CheckLastName(Customer customer)
        {
            if (customer.LastName == null)
            {
                ErrorsList.Add("LastName incorrect");
                return;
            }
            if (customer.LastName.Length < 3 || customer.LastName.Length > 50) ErrorsList.Add("LastName incorrect");
        }

        void CheckAddress(Customer customer)
        {
            if (customer.Address == null)
            {
                ErrorsList.Add("Address incorrect");
                return;
            }
            AddressValidator addressValidator = new AddressValidator(customer.Address);
            foreach (var item in addressValidator.ErrorsList)
            {
                ErrorsList.Add(item);
            }
        }

        void CheckPhone(Customer customer)
        {
            if (customer.PhoneNumber == null)
            {
                ErrorsList.Add("Phone number incorrect");
                return;
            }
            if (!customer.PhoneNumber.StartsWith("+") || !customer.PhoneNumber.Substring(1).All(c => Char.IsDigit(c))) ErrorsList.Add("Phone number incorrect");
        }

        void CheckEmail(Customer customer)
        {
            if (customer.Email == null)
            {
                ErrorsList.Add("Email incorrect");
                return;
            }
            string pattern = @"[0-9a-z]*\@[0-9a-z]*\.[a-z]*";
            if (!Regex.IsMatch(customer.Email, pattern, RegexOptions.IgnoreCase)) ErrorsList.Add("Email incorrect");
        }

        void CheckNote(Customer customer)
        {
            if (customer.Note == null) ErrorsList.Add("Note incorrect");
        }
    }
}
