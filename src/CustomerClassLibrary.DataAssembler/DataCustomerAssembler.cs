using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;

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

        public Customer CreateCustomer(Customer customer)
        {
            var customerRepository = new CustomerRepository();
            var customerId = customerRepository.Create(customer);
            customer.CustomerId = customerId;
            var addressesRepository = new AddressesRepository();

            foreach (var a in customer.Address)
            {
                a.CustomerId = customer.CustomerId;
                a.AddressId = addressesRepository.Create(a);
            }

            var notesRepository = new NotesRepository();

            foreach (var n in customer.Note)
            {
                n.CustomerId = customer.CustomerId;
                n.NoteId = notesRepository.Create(n);
            }

            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customerRepository = new CustomerRepository();
            var addressesRepository = new AddressesRepository();
            var notesRepository = new NotesRepository();

            addressesRepository.DeleteAllByCustomerId(id);
            notesRepository.DeleteAllByCustomerId(id);
            customerRepository.Delete(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Update(customer);
        }

        public List<Customer> GetAll()
        {
            List<Customer> listCustomer = new List<Customer>();
            var customerRepository = new CustomerRepository();
            var addressesRepository = new AddressesRepository();
            var notesRepository = new NotesRepository();

            listCustomer = customerRepository.ReadAll();
            foreach (var customer in listCustomer)
            {
                var addressList = addressesRepository.ReadCustomerAddresses(customer.CustomerId);
                var notes = notesRepository.ReadCustomerNotes(customer.CustomerId);
                customer.Address = addressList;
                customer.Note = notes;
            }
            return listCustomer;
        }
    }
}
