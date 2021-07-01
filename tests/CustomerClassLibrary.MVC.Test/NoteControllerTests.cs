using CustomerClassLibrary.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.MVC.Test
{
    public class NoteControllerTests
    {
        [Fact]
        public void TestCreateNoteController()
        {
            NoteController noteController = new NoteController();

            Assert.NotNull(noteController);
        }
    }
}
