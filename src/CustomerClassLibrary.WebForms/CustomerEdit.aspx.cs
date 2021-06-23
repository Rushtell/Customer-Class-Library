using CustomerClassLibrary.DataAssembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        DataCustomerAssembler dataCustomerAssembler { get; set; }

        public string customerIdReq { get; set; }

        public CustomerEdit()
        {
            dataCustomerAssembler = new DataCustomerAssembler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                customerIdReq = Request.QueryString["customerId"];

                LoadCustomer(customerIdReq);
            }
        }

        public void LoadCustomer(string customerIdReq)
        {
            if (customerIdReq != null)
            {
                var customer = dataCustomerAssembler.BuildCustomer(Convert.ToInt32(customerIdReq));

                firstName.Text = customer.FirstName;
                lastName.Text = customer.LastName;
                phoneNumber.Text = customer.PhoneNumber;
                email.Text = customer.Email;
                money.Text = customer.Money.ToString();
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                customerIdReq = Request.QueryString["customerId"];
            }

            

            if (customerIdReq != null)
            {
                var customer = new Customer()
                {
                    FirstName = firstName?.Text,
                    LastName = lastName?.Text,
                    PhoneNumber = phoneNumber?.Text,
                    Email = email?.Text,
                    Money = Convert.ToDecimal(money?.Text)
                };

                customer.CustomerId = Convert.ToInt32(customerIdReq);
                dataCustomerAssembler.UpdateCustomer(customer);
            }
            else 
            {
                var customer = new Customer()
                {
                    FirstName = firstName?.Text,
                    LastName = lastName?.Text,
                    PhoneNumber = phoneNumber?.Text,
                    Email = email?.Text,
                    Money = Convert.ToDecimal(money?.Text),
                    Address = new List<Address>() {
                    new Address() {
                        CustomerId = Convert.ToInt32(customerIdReq),
                        AddressLine = addressLine?.Text,
                        SecondAddressLine = secondAddressLine?.Text,
                        PostalCode = postalCode?.Text,
                        City = city?.Text,
                        State = state?.Text,
                        Country = country?.Text
                    }
                },
                    Note = new List<Note>() {
                    new Note() {
                        CustomerId = Convert.ToInt32(customerIdReq),
                        Text = noteText?.Text
                    }
                }
                };

                dataCustomerAssembler.CreateCustomer(customer);
            }

            Response?.Redirect("CustomerList");
        }
    }
}