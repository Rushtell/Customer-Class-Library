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
        public DataContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerLibEF_Maslov;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Address>().Property(e => e.AddressType).HasColumnType("nvarchar");
        //}

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
