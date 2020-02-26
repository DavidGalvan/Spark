using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark
{
    public static class Utilities
    {
        public static string[] GetBlockedCustomers()
        {
            string[] Customers = new string[3];
            Customers[0] = "6";
            Customers[1] = "9";
            Customers[2] = "11";
            return Customers;
        }
    }
}