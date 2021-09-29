using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Sale
{
   public class SaleApplication
    {
        public int Id { get; set; } = 4;
        public string Name { get; set; }
        public int MainDocumentTypeId { get; set; } = 1;
        public OverPay.Model.FinancialDocument.MainFinancialDocumentType MainDocumentType { get; set; }
        public bool IsActive { get; set; }
        public bool IsInternal { get; set; }
        public string LaunchPath { get; set; }
        public bool AutoSequence { get; set; }
        public bool GenericProductOnly { get; set; }
        public int TerminalTypeId { get; set; } = 2;
    }
}
