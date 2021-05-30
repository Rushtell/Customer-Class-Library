using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Class_Library
{
    public enum AddressType
    {
        Shipping,
        Billing
    }

    public class Address
    {
        public string AddressLine { get; set; }

        public string SecondAddressLine { get; set; }

        public AddressType AddressType { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
