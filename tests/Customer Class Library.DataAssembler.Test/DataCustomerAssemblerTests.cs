using System;
using Xunit;

namespace Customer_Class_Library.DataAssembler.Test
{
    public class DataCustomerAssemblerTests
    {
        [Fact]
        public void BuildTest()
        {
            var customerAssembler = new DataCustomerAssembler();
            var customer = customerAssembler.BuildCustomer(4);
        }
    }
}
