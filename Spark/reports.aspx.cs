using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spark
{
    public partial class reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> BlockedCustomers = Utilities.GetBlockedCustomers();
            var SubList = BlockedCustomers.Where(CustomerID =>
                                                 CustomerID == "6"
                                                 || CustomerID == "9"
                                                 || CustomerID == "98");
            foreach (string CustomerID in SubList)
            {
                LabelReport.Text += CustomerID;
                LabelReport.Text += "<br />";
            }
        }

       
    }
}