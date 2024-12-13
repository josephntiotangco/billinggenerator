using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStatementGenerator
{
    public class Constructors
    {
        public class BillingItem
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public decimal Subtotal { get; set; }
            public decimal Quantity { get; set; }
            public decimal Price { get; set; }
            public string UOM { get; set; }
            public string Reference { get; set; }
            public DateTime TransDate { get; set; }
        }

        public class BillingHeader
        {
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerContact { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
            public string CompanyContact { get; set; }
            public string BillingReference { get; set; }
            public decimal BillingAmountDue { get; set; }
            public DateTime BillingDate { get; set; }
            public DateTime BillingDueDate { get; set; }

            public string BillingTerms { get; set; }
            public string BillingRemarks { get; set; }
        }

        public class BillingData
        {
            public BillingHeader header { get; set; }
            public List<BillingItem> items { get; set; }
        }

        public class BillerDetail
        {
            public string Biller { get; set; }
            public string BillerAddress { get; set; }
            public string BillerContact { get; set; }
        }

        public class BillToDetail
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Contact { get; set; }
        }
    }
}
