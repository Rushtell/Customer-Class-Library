using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerLib_Maslov;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
