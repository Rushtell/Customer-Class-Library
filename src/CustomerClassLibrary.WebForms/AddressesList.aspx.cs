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
    public partial class AddressesList : System.Web.UI.Page
    {
        AddressesRepository addressesRepository { get; set; }

        public List<Address> listAddresses { get; set; }

        public int pageNum { get; set; }

        public int customerId { get; set; }

        public int addressesCount { get; set; }

        public AddressesList()
        {
            addressesRepository = new AddressesRepository();
            listAddresses = new List<Address>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Request.QueryString["customerId"];
            var addressIdReq = Request.QueryString["addressId"];
            var pageNum = Request.QueryString["page"];
            customerId = Convert.ToInt32(customerIdReq);
            if (pageNum == null)
            {
                Response?.Redirect($"AddressesList?page=1&customerId={customerIdReq}");
            }
            this.pageNum = Convert.ToInt32(pageNum);
            if (addressIdReq != null)
            {
                addressesRepository.Delete(Convert.ToInt32(addressIdReq));
            }
            var allListAddresses = addressesRepository.ReadCustomerAddresses(Convert.ToInt32(customerIdReq));
            addressesCount = allListAddresses.Count;
            for (int i = 0; i < 15; i++)
            {
                int num = i + ((Convert.ToInt32(pageNum) - 1) * 15);
                if (num < addressesCount)
                {
                    listAddresses.Add(allListAddresses[num]);
                }
            }
        }
    }
}