using CustomerClassLibrary.MVC.Controllers;
using System;
using Xunit;

namespace CustomerClassLibrary.MVC.Test
{
    public class CustomerControllerTests
    {
        [Fact]
        public void TestCreateCustomerController()
        {
            CustomerController customerController = new CustomerController();

            Assert.NotNull(customerController);
        }
    }
}
