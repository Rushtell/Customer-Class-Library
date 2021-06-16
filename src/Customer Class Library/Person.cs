using System;
using System.ComponentModel.DataAnnotations;

namespace Customer_Class_Library
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
