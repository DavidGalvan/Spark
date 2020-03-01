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
                Invoice MyInvoice = Data.Invoices.Single
                    (Invoice => Invoice.InvoiceID == 2);
                LabelReport.Text = MyInvoice.InvoiceNumber;
                LabelReport.Text = "<br />";
                LabelReport.Text += MyInvoice.InvoiceAmount.ToString();

            }
        }

        protected void ButtonUpdateInvoice_Click(object sender, EventArgs e)
        {
            using (SparkDataContext Data = new SparkDataContext())
            {
                Invoice MyInvoice = Data.Invoices.Single
                    (Invoice => Invoice.InvoiceID == 2);
                MyInvoice.InvoiceAmount = 123;
                Data.SubmitChanges();

            }
        }
    }
}