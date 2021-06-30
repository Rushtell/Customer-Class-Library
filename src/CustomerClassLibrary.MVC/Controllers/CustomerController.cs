using CustomerClassLibrary.DataAssembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerClassLibrary.MVC.Controllers
{
    public class CustomerController : Controller
    {
        DataCustomerAssembler dataCustomerAssembler { get; set; }

        public CustomerController()
        {
            dataCustomerAssembler = new DataCustomerAssembler();
        }

        // GET: Customer
        public ActionResult Index(int page)
        {
            ViewBag.page = page;
            ViewBag.CustomersCount = dataCustomerAssembler.Count();
            var customersList = dataCustomerAssembler.GetSelection(page * 15 - 15, page * 15);

            return View(customersList);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer()
            {
                Address = new List<Address>() { new Address() },
                Note = new List<Note>() { new Note() }
            };
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                CustomerValidator validator = new CustomerValidator();
                var result = validator.Validate(customer);
                if (result.IsValid)
                {
                    dataCustomerAssembler.CreateCustomer(customer);
                }
                else
                {
                    List<string> listErrors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        listErrors.Add(item.ErrorMessage);
                    }
                    ViewBag.Errors = listErrors;
                    return View(customer);
                }

                return Redirect("~/Customer/Index?page=1");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = dataCustomerAssembler.BuildCustomer(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                CustomerValidator validator = new CustomerValidator();
                var lastCustomer = dataCustomerAssembler.BuildCustomer(id);
                customer.Address = lastCustomer.Address;
                customer.Note = lastCustomer.Note;
                var result = validator.Validate(customer);
                if (result.IsValid)
                {
                    dataCustomerAssembler.UpdateCustomer(customer);
                }
                else
                {
                    List<string> listErrors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        listErrors.Add(item.ErrorMessage);
                    }
                    ViewBag.Errors = listErrors;
                    return View(customer);
                }

                return Redirect($"~/Customer/Index?page=1");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = dataCustomerAssembler.BuildCustomer(id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                dataCustomerAssembler.DeleteCustomer(id);

                return Redirect($"~/Customer/Index?page=1");
            }
            catch
            {
                return View();
            }
        }
    }
}
