﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spark
{
    public partial class newtransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private decimal CalculateVAT(decimal Amount)
        {
            decimal VATAmount = Amount * 0.2m;
            VATAmount = Math.Round(VATAmount, 2);
            return VATAmount;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilities.GetBlockedCustomers().
                    Contains(DropDownListCustomer.SelectedValue)
                    )
                {
                    LabelError.Text = "That customer is currently out of use";
                }
                else
                {
                    using (SparkDataContext Data = new SparkDataContext())
                    {
                        Invoice NewInvoice = new Invoice();
                        NewInvoice.CustomerID = 1;
                        NewInvoice.InvoiceNumber = TextBoxInvoiceNumber.Text;
                        NewInvoice.InvoiceAmount = Convert.ToDecimal(TextBoxAmount.Text);
                        NewInvoice.InvoiceTaxAmount = Convert.ToDecimal(TextBoxTaxAmount.Text);
                        NewInvoice.InvoiceDate = DateTime.Now;
                        Data.Invoices.InsertOnSubmit(NewInvoice);
                        Data.SubmitChanges();
                        PanelAddInvoice.Visible = false;
                        PanelConfirmAdded.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                LabelError.Text = Ex.Message;
            }
        }
    }
}