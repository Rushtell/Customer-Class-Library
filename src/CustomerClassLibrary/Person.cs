using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerClassLibrary
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
