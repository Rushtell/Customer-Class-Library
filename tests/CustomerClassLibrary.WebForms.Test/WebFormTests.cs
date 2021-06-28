using System;
using Xunit;

namespace CustomerClassLibrary.WebForms.Test
{
    public class WebFormTests
    {
        [Fact]
        public void ShouldCreateCustomerList()
        {
            CustomerList target = new CustomerList();

            Assert.NotNull(target);
        }

        [Fact]
        public void ShouldCreateCustomerEdit()
        {
            CustomerEdit target = new CustomerEdit();

            Assert.NotNull(target);
        }

        [Fact]
        public void ShouldCreateAddressList()
        {
            AddressesList target = new AddressesList();

            Assert.NotNull(target);
        }

        [Fact]
        public void ShouldCreateAddressEdit()
        {
            AddressesEdit target = new AddressesEdit();

            Assert.NotNull(target);
        }

        [Fact]
        public void ShouldCreateNotesList()
        {
            NotesList target = new NotesList();

            Assert.NotNull(target);
        }

        [Fact]
        public void ShouldCreateNotesEdit()
        {
            NotesEdit target = new NotesEdit();

            Assert.NotNull(target);
        }
    }
}
