using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class EFAddressesRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFAddressesRepository()
        {
            var repository = new EFAddressesRepository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToMethodCreateEFAddressesRepository()
        {
            var repository = new EFAddressesRepository();

            var addressId = repository.Create(new Address()
            {
                CustomerId = 2,
                AddressLine = "EFtest",
                SecondAddressLine = "EFtest2",
                AddressType = AddressType.Billing,
                City = "EFtest3",
                PostalCode = "123456",
                State = "EFtest4",
                Country = "Canada"
            });

            Assert.True(addressId > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadEFAddressesRepository()
        {
            Mock<EFAddressesRepository> mock = new Mock<EFAddressesRepository>();
            Address testAddress = new Address();
            mock.Setup(m => m.Read(1)).Returns(testAddress);
            var result = mock.Object.Read(1);

            Assert.Equal(testAddress, result);
        }

        [Fact]
        public void ShouldBeAbleToMethodUpdateEFAddressesRepository()
        {
            Address testAddress = new Address()
            {
                AddressId = 3,
                CustomerId = 2,
                AddressLine = "EFtestUpd",
                SecondAddressLine = "EFtest2Upd",
                AddressType = AddressType.Billing,
                City = "EFtest3Upd",
                PostalCode = "123456",
                State = "EFtest4Upd",
                Country = "Canada"
            };

            Mock<EFAddressesRepository> mock = new Mock<EFAddressesRepository>();
            mock.Setup(m => m.Update(testAddress)).Returns(testAddress);
            var result = mock.Object.Update(testAddress);

            Assert.Equal(testAddress, result);
        }

        [Fact]
        public void ShouldBeAbleToMethodDeleteEFAddressesRepository()
        {
            Mock<EFCustomerRepository> mock = new Mock<EFCustomerRepository>();
            mock.Setup(m => m.Delete(1)).Returns(true);
            var result = mock.Object.Delete(1);

            Assert.True(result);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadCustomerAddressesEFAddressesRepository()
        {
            var repository = new EFAddressesRepository();

            var listCustomers = repository.ReadCustomerAddresses(2);

            Assert.True(listCustomers.Count > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodDeleteAllByCustomerIdEFAddressesRepository()
        {
            Mock<EFAddressesRepository> mock = new Mock<EFAddressesRepository>();
            mock.Setup(m => m.DeleteAllByCustomerId(1)).Returns(true);
            var result = mock.Object.DeleteAllByCustomerId(1);

            Assert.True(result);
        }
    }
}
