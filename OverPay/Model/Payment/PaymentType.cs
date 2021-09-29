using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Payment
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnedifactName { get; set; }
        public string UnedifactChannelCode { get; set; }
        public string UnedifactChannelName { get; set; }
        public string UnedifactCode { get; set; }
        public bool IsOffline { get; set; }
        public int? RequiredDocumentTypeId { get; set; }
    }
}
