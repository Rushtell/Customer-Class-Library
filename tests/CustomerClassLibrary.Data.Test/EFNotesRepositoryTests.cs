using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class EFNotesRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFNotesRepository()
        {
            var repository = new EFNotesRepository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToMethodCreateEFNotesRepository()
        {
            var repository = new EFNotesRepository();

            var noteId = repository.Create(new Note()
            {
                CustomerId = 2,
                Text = "testEF"
            });

            Assert.True(noteId > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadEFNotesRepository()
        {
            Note note = new Note()
            {
                CustomerId = 2,
                Text = "testEF"
            };
            Mock<EFNotesRepository> mock = new Mock<EFNotesRepository>();
            mock.Setup(m => m.Read(2)).Returns(note);
            var result = mock.Object.Read(2);

            Assert.Equal(note, result);
        }

        [Fact]
        public void ShouldBeAbleToMethodUpdateEFNotesRepository()
        {
            var repository = new EFNotesRepository();

            var customer = repository.Update(new Note()
            {
                NoteId = 2,
                CustomerId = 2,
                Text = "testEF"
            });

            Assert.NotNull(customer);
        }

        [Fact]
        public void ShouldBeAbleToMethodDeleteEFNotesRepository()
        {
            Mock<EFNotesRepository> mock = new Mock<EFNotesRepository>();
            mock.Setup(m => m.Delete(1)).Returns(true);
            var result = mock.Object.Delete(1);

            Assert.True(result);
        }

        [Fact]
        public void ShouldBeAbleToMethodReadCustomerNotesEFNotesRepository()
        {
            var repository = new EFNotesRepository();

            var listCustomers = repository.ReadCustomerNotes(2);

            Assert.True(listCustomers.Count > 0);
        }

        [Fact]
        public void ShouldBeAbleToMethodDeleteAllByCustomerIdEFNotesRepository()
        {
            Mock<EFNotesRepository> mock = new Mock<EFNotesRepository>();
            mock.Setup(m => m.DeleteAllByCustomerId(1)).Returns(true);
            var result = mock.Object.DeleteAllByCustomerId(1);

            Assert.True(result);
        }
    }
}
