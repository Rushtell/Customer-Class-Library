using CustomerClassLibrary.Data;
using CustomerClassLibrary.DataAssembler;
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

        string customerIdReq { get; set; }

        string addressIdReq { get; set; }

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
                    addressType.Text = "Billing";
                }
                else addressType.Text = "Shipping";

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

            if (addressType.Text == "Billing") address.AddressType = AddressType.Billing;
            else if (addressType.Text == "Shipping") address.AddressType = AddressType.Shipping;

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