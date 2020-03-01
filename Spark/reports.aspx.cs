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
                var Invoices = Data.Invoices
                              .Where(Invoice => Invoice.InvoiceAmount > 40)
                              .OrderByDescending(Invoice => Invoice.InvoiceNumber).Take(1);
                string Output = "";
                foreach (Invoice InvoiceToOutput in Invoices)
                {
                    Output += InvoiceToOutput.Customer.CustomerName;
                    Output += " - ";
                    Output += InvoiceToOutput.InvoiceNumber;
                    Output += "<br / >";
                }
                LabelReport.Text = Output;
            }
        }
    }
}