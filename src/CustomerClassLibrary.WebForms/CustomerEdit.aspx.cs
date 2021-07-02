using CustomerClassLibrary.DataAssembler;
using FluentValidation.Results;
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

        public string errorReq { get; set; }

        public CustomerEdit()
        {
            dataCustomerAssembler = new DataCustomerAssembler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                customerIdReq = Request.QueryString["customerId"];
                errorReq = Request.QueryString["error"];

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
                try
                {
                    var customer = BuildCustomerWithoutAddressAndNote();

                    CustomerValidator validator = new CustomerValidator();
                    ValidationResult result = validator.Validate(customer);
                    
                    if (RegularExpressionValidatorFirstName.IsValid == true &&
                        RegularExpressionValidatorLastName.IsValid == true &&
                        RegularExpressionValidatorPhone.IsValid == true &&
                        RegularExpressionValidatorEmail.IsValid == true &&
                        RegularExpressionValidatorMoney.IsValid == true)
                    {
                        if (result.ToString() != "")
                        {
                            Response?.Redirect($"CustomerEdit?error=1&customerId={customerIdReq}");
                        }

                        customer.CustomerId = Convert.ToInt32(customerIdReq);
                        dataCustomerAssembler.UpdateCustomer(customer);

                        Response?.Redirect("CustomerList");
                    }

                }
                catch (FormatException)
                {
                    Response?.Redirect($"CustomerEdit?error=1&customerId={customerIdReq}");
                }
            }
            else 
            {
                try
                {
                    var customer = BuildCustomerWithAddressAndNote();

                    CustomerValidator validator = new CustomerValidator();
                    ValidationResult result = validator.Validate(customer);

                    if (Page.IsValid)
                    {
                        if (result.ToString() != "")
                        {
                            Response?.Redirect("CustomerEdit?error=1");
                        }

                        dataCustomerAssembler.CreateCustomer(customer);

                        Response?.Redirect("CustomerList");
                    }
                }
                catch (FormatException)
                {
                    Response?.Redirect("CustomerEdit?error=1");
                }
            }
        }

        public Customer BuildCustomerWithAddressAndNote()
        {
            AddressType concretAddressType;
            if (addressType.SelectedIndex == 0) concretAddressType = AddressType.Billing;
            else if (addressType.SelectedIndex == 1) concretAddressType = AddressType.Shipping;
            else concretAddressType = default;
            return new Customer()
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
                            AddressTypeEnum = concretAddressType,
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
        }

        public Customer BuildCustomerWithoutAddressAndNote()
        {
            var customer = new Customer()
            {
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                Money = Convert.ToDecimal(money?.Text)
            };

            var buildedCustomer = dataCustomerAssembler.BuildCustomer(Convert.ToInt32(customerIdReq));
            customer.Address = buildedCustomer.Address;
            customer.Note = buildedCustomer.Note;
            return customer;
        }
    }
}