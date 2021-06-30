using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerClassLibrary.MVC.Controllers
{
    public class AddressController : Controller
    {
        AddressesRepository addressesRepository { get; set; }

        public AddressController()
        {
            addressesRepository = new AddressesRepository();
        }
        // GET: Address
        public ActionResult Index(int id)
        {
            var addresses = addressesRepository.ReadCustomerAddresses(id);
            ViewBag.CustomerID = id;
            return View(addresses);
        }

        // GET: Address/Create
        public ActionResult Create(int id)
        {
            Address address = new Address() { CustomerId = id };
            return View(address);
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            try
            {
                AddressValidator validator = new AddressValidator();
                var result = validator.Validate(address);
                if (result.IsValid)
                {
                    addressesRepository.Create(address);
                }
                else
                {
                    List<string> listErrors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        listErrors.Add(item.ErrorMessage);
                    }
                    ViewBag.Errors = listErrors;
                    return View(address);
                }

                return Redirect($"~/Address/Index/{address.CustomerId}");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var address = addressesRepository.Read(id);
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                AddressValidator validator = new AddressValidator();
                var result = validator.Validate(address);
                if (result.IsValid)
                {
                    addressesRepository.Update(address);
                }
                else
                {
                    List<string> listErrors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        listErrors.Add(item.ErrorMessage);
                    }
                    ViewBag.Errors = listErrors;
                    return View(address);
                }

                return Redirect($"~/Address/Index/{address.CustomerId}");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            var address = addressesRepository.Read(id);
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                var deletedAddress = addressesRepository.Read(id);
                addressesRepository.Delete(id);

                return Redirect($"~/Address/Index/{deletedAddress.CustomerId}");
            }
            catch
            {
                return View();
            }
        }
    }
}
