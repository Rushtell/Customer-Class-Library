using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public enum AddressType
    {
        Shipping,
        Billing
    }

    public class Address
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public string AddressLine { get; set; }

        [Column("AddressLine2")]
        public string SecondAddressLine { get; set; }

        public AddressType AddressType { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
