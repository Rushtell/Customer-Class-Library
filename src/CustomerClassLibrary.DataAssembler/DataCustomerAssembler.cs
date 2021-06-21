using CustomerClassLibrary.Data;
using System;

namespace CustomerClassLibrary.DataAssembler
{
    public class DataCustomerAssembler
    {
        public Customer BuildCustomer (int id)
        {
            var customerRepository = new CustomerRepository();
            var addressesRepository = new AddressesRepository();
            var notesRepository = new NotesRepository();

            var customer = customerRepository.Read(id);
            var addressList = addressesRepository.ReadCustomerAddresses(customer.CustomerId);
            var notes = notesRepository.ReadCustomerNotes(customer.CustomerId);
            customer.Address = addressList;
            customer.Note = notes;
            return customer;
        }
    }
}
