using CustomerClassLibrary.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.MVC.Test
{
    public class AddressControllerTests
    {
        [Fact]
        public void TestCreateAddressController()
        {
            AddressController addressController = new AddressController();

            Assert.NotNull(addressController);
        }

        //[Fact]
        //public void TestIndexMethod()
        //{
        //    AddressController addressController = new AddressController();

        //    var test = addressController.Index(2);

        //    Assert.NotNull(test);
        //}

        //[Fact]
        //public void TestCreateMethod()
        //{
        //    AddressController addressController = new AddressController();

        //    var test = addressController.Create(new Address());

        //    Assert.NotNull(test);
        //}
    }
}
