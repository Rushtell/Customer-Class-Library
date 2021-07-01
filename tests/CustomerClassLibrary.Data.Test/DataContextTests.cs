using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class DataContextTests
    {
        [Fact]
        public void ShouldBeAbleToCreateDataContext()
        {
            var database = new DataContext();

            Assert.NotNull(database);
        }
    }
}
