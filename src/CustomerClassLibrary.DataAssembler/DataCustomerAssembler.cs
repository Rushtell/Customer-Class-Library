using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;

namespace CustomerClassLibrary.DataAssembler
{
    public class DataCustomerAssembler
    {
        public virtual Customer BuildCustomer (int id)
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

        public virtual Customer CreateCustomer(Customer customer)
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

        public virtual bool DeleteCustomer(int id)
        {
            try
            {
                var customerRepository = new CustomerRepository();
                var addressesRepository = new AddressesRepository();
                var notesRepository = new NotesRepository();

                addressesRepository.DeleteAllByCustomerId(id);
                notesRepository.DeleteAllByCustomerId(id);
                customerRepository.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerRepository = new CustomerRepository();
                customerRepository.Update(customer);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual List<Customer> GetAll()
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

        public virtual List<Customer> GetSelection(int numFrom, int numTo)
        {
            List<Customer> listCustomer = new List<Customer>();
            var customerRepository = new CustomerRepository();
            var addressesRepository = new AddressesRepository();
            var notesRepository = new NotesRepository();

            listCustomer = customerRepository.ReadSelect(numFrom, numTo);
            foreach (var customer in listCustomer)
            {
                var addressList = addressesRepository.ReadCustomerAddresses(customer.CustomerId);
                var notes = notesRepository.ReadCustomerNotes(customer.CustomerId);
                customer.Address = addressList;
                customer.Note = notes;
            }
            return listCustomer;
        }

        public virtual int Count()
        {
            var customerRepository = new CustomerRepository();

            return customerRepository.Count();
        }
    }
}
