using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStatementGenerator
{
    public class Globals
    {

        public static string MODULE_NAME = "KFPT Billing Generator";

        public static string gvDataLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\";



        public static Functions fn = new();
    }
}
