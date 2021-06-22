using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }

        public List<Address> Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<string> Note { get; set; }

        public decimal Money { get; set; }
    }
}
