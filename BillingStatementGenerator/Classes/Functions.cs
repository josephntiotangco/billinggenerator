using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStatementGenerator
{
    public class Functions
    {

        public string GetDataLocation()
        {
            if (!Directory.Exists(Globals.gvDataLocation)) Directory.CreateDirectory(Globals.gvDataLocation);
            return Globals.gvDataLocation;
        }

        public string GetDataBillingsLocation()
        {
            string path = Path.Combine(Globals.gvDataLocation, "Billed");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

    }
}
