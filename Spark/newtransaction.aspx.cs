using System;
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

                }
            }
            catch (Exception Ex)
            {
                LabelError.Text = Ex.Message;
            }
        }
    }
}