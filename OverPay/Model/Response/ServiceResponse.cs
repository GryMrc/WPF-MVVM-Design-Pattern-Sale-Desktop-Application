using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Response
{
    public class ServiceResponse
    {
        public string detail { get; set; }
        public int errorLevel { get; set; }
        public int errorNo { get; set; }
        public string message { get; set; }
        public string title { get; set; }
        public bool isSuccessed { get; set; }
    }
}
