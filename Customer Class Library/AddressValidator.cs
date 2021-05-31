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
        public List<string> ErrorsList { get; set; }

        public AddressValidator(Address address)
        {
            ErrorsList = new List<string>();
            CheckAddressLine(address);
            CheckSecondAddressLine(address);
            CheckAddressType(address);
            CheckCity(address);
            CheckPostalCode(address);
            CheckState(address);
            CheckCountry(address);
        }

        void CheckAddressLine(Address address)
        {
            if (address.AddressLine == null)
            {
                ErrorsList.Add("AddressLine incorrect");
                return;
            }
            if (address.AddressLine.Length > 100) ErrorsList.Add("AddressLine incorrect");
        }

        void CheckSecondAddressLine(Address address)
        {
            if (address.SecondAddressLine == null)
            {
                ErrorsList.Add("SecondAddressLine incorrect");
                return;
            }
            if (address.AddressLine.Length > 100) ErrorsList.Add("SecondAddressLine incorrect");
        }

        void CheckAddressType(Address address)
        {
            if (!Enum.IsDefined(typeof(AddressType), address.AddressType)) ErrorsList.Add("AddressType incorrect");
        }

        void CheckCity(Address address)
        {
            if (address.City == null)
            {
                ErrorsList.Add("City incorrect");
                return;
            }
            if (address.City.Length > 50) ErrorsList.Add("City incorrect");
        }

        void CheckPostalCode(Address address)
        {
            if (address.PostalCode == null)
            {
                ErrorsList.Add("PostalCode incorrect");
                return;
            }
            if (address.PostalCode.Length > 6) ErrorsList.Add("PostalCode incorrect");
        }

        void CheckState(Address address)
        {
            if (address.State == null) 
            {
                ErrorsList.Add("State incorrect");
                return;
            }
            if (address.State.Length > 20) ErrorsList.Add("State incorrect");
        }

        void CheckCountry(Address address)
        {
            string[] arrCountrys = new string[] { "United States", "Canada" };
            foreach (var item in arrCountrys)
            {
                if (item == address.Country) return;
            }
            ErrorsList.Add("Country incorrect");
        }
    }
}
