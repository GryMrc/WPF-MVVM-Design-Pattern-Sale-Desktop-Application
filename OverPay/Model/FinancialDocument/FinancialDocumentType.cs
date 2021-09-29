using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.FinancialDocument
{
    public class FinancialDocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MainDocumentTypeId { get; set; }
        public MainFinancialDocumentType MainDocumentType { get; set; }
        public long? DocumentTemplateId { get; set; }
        public string InvoiceNo { get; set; }
        public FinancialDocumentType Type { get; set; }
    }
}
