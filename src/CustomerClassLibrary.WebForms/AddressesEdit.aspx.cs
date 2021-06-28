using CustomerClassLibrary.Data;
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
    public partial class AddressesEdit : System.Web.UI.Page
    {
        AddressesRepository addressesRepository { get; set; }

        public string customerIdReq { get; set; }

        public string addressIdReq { get; set; }

        public string errorReq { get; set; }

        public AddressesEdit()
        {
            addressesRepository = new AddressesRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            customerIdReq = Request.QueryString["customerId"];

            if (!IsPostBack)
            {
                addressIdReq = Request.QueryString["addressId"];
                errorReq = Request.QueryString["error"];

                LoadAddress(addressIdReq);
            }
        }

        public void LoadAddress(string addressIdReq)
        {
            if (addressIdReq != null)
            {
                var address = addressesRepository.Read(Convert.ToInt32(addressIdReq));

                
                if (address.AddressType == AddressType.Billing)
                {
                    addressType.SelectedIndex = 0;
                }
                else addressType.SelectedIndex = 1;

                addressLine.Text = address.AddressLine;
                secondAddressLine.Text = address.SecondAddressLine;
                postalCode.Text = address.PostalCode;
                city.Text = address.City;
                state.Text = address.State;
                country.Text = address.Country;
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                addressIdReq = Request.QueryString["addressId"];
            }

            var address = new Address()
            {
                CustomerId = Convert.ToInt32(customerIdReq),
                AddressLine = addressLine?.Text,
                SecondAddressLine = secondAddressLine?.Text,
                PostalCode = postalCode?.Text,
                City = city?.Text,
                State = state?.Text,
                Country = country?.Text
            };

            if (addressType.SelectedIndex == 0) address.AddressType = AddressType.Billing;
            else if (addressType.SelectedIndex == 1) address.AddressType = AddressType.Shipping;
            else address.AddressType = default;

            AddressValidator validator = new AddressValidator();
            ValidationResult result = validator.Validate(address);

            if (Page.IsValid)
            {
                if (result.ToString() != "")
                {
                    if (addressIdReq != null)
                    {
                        Response?.Redirect($"AddressesEdit?error=1&addressId={addressIdReq}&customerId={customerIdReq}");
                    }
                    else Response?.Redirect($"AddressesEdit?error=1&customerId={customerIdReq}");

                }

                if (addressIdReq != null)
                {
                    address.AddressId = Convert.ToInt32(addressIdReq);
                    addressesRepository.Update(address);
                }
                else addressesRepository.Create(address);

                Response?.Redirect($"AddressesList?customerId={customerIdReq}");
            }
        }
    }
}