using System;
using Xunit;

namespace CustomerClassLibrary.DataAssembler.Test
{
    public class DataCustomerAssemblerTests
    {
        [Fact]
        public void BuildTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            var customer = customerAssembler.BuildCustomer(2);

            Assert.Equal("st Pushkina", customer.Address[0].AddressLine);
        }
    }
}
