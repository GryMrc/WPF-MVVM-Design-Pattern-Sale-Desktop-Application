using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Authentication
{
    public class User
    {  
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Language { get; set; } = "";
        public int ProgramId { get; set; } = 24;
        public int ChannelId { get; set; } = 14;
        public string HomeModuleName { get; set; } = "OverPaySalesHome";
        public bool UseOTPVerification { get; set; }
        public ClientInfo clientInfo { get; set; }
        public string CaptchaToken { get; set; }
    }
}
