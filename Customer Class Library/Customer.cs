using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Customer_Class_Library
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<string> Note { get; set; }

        public decimal Money { get; set; }
    }
}
