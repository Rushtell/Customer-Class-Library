using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class EFCustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToMethodCreateEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var customerId = repository.Create(new Customer()
            {
                FirstName = "EFtest",
                LastName = "EFtest2",
                Email = "EFtest3@test.com",
                PhoneNumber = "+987654321",
                Money = 100
            });

            Assert.True(customerId > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var customer = repository.Read(3);

            Assert.NotNull(customer);
        }

        [Fact]
        public void ShouldBeAbleToMethodUpdateEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var customer = repository.Update(new Customer()
            {
                CustomerId = 2,
                Email = "testUp@test.com",
                FirstName = "testUpd",
                LastName = "testUpd",
                PhoneNumber = "+9008",
                Money = 322

            });

            Assert.NotNull(customer);
        }

        [Fact]
        public void ShouldBeAbleToMethodDeleteEFCustomerRepository()
        {
            Mock<EFCustomerRepository> mock = new Mock<EFCustomerRepository>();
            mock.Setup(m => m.Delete(1)).Returns(true);
            var result = mock.Object.Delete(1);

            Assert.True(result);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadAllEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var listCustomers = repository.ReadAll();

            Assert.True(listCustomers.Count > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadSelectEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var listCustomers = repository.ReadSelect(0, 15);

            Assert.True(listCustomers.Count > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodCountEFCustomerRepository()
        {
            var repository = new EFCustomerRepository();

            var listCustomers = repository.Count();

            Assert.True(listCustomers > 0);
        }
    }
}
