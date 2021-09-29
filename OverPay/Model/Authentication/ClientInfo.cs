using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Authentication
{
    public class ClientInfo
    {   
        public string IPAddress { get; set; }
        public string HostUrl { get; set; }
        public string Location { get; set; }
        public string Platform { get; set; }
        public string Browser { get; set; }
        public string BrowserLanguage { get; set; }
        public string DeviceInformation { get; set; }
    }
}
