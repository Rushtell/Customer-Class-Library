using CustomerClassLibrary.DataAssembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        DataCustomerAssembler dataAssembler { get; set; }

        public List<Customer> listCustomers { get; set; }

        public int pageNum { get; set; }

        public int customersCount { get; set; }

        public CustomerList()
        {
            dataAssembler = new DataCustomerAssembler();
            listCustomers = new List<Customer>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Request.QueryString["customerId"];
            var pageNum = Request.QueryString["page"];
            this.pageNum = Convert.ToInt32(pageNum);
            if (pageNum == null)
            {
                Response?.Redirect("CustomerList?page=1");
            }
            if (customerIdReq != null)
            {
                dataAssembler.DeleteCustomer(Convert.ToInt32(customerIdReq));
            }
            customersCount = dataAssembler.Count(); 
            int numCustomers = Convert.ToInt32(pageNum) * 15;
            listCustomers = dataAssembler.GetSelection(numCustomers - 15, numCustomers);
            //var allListCustomers = dataAssembler.GetAll();
            //customersCount = allListCustomers.Count;
            //for (int i = 0; i < 15; i++)
            //{
            //    int num = i + ((Convert.ToInt32(pageNum) - 1) * 15);
            //    if (num < customersCount)
            //    {
            //        listCustomers.Add(allListCustomers[num]);
            //    }
            //}
        }
    }
}