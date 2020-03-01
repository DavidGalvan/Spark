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
            using (SparkDataContext Data = new SparkDataContext())
            {
                Customer CheckCustomer = Data.Customers
                                         .SingleOrDefault(Customer => Customer
                                         .CustomerID == 99);
                if (CheckCustomer == null)
                {
                    LabelReport.Text = "Customer does not exist";
                }
                else
                {
                    LabelReport.Text = CheckCustomer.CustomerName;
                }
                    
              
                
            }
        }
    }
}