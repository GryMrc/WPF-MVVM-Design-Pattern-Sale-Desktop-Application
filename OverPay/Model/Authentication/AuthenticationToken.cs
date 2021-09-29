using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Authentication
{
    public class AuthenticationToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireInSeconds { get; set; }
        public int RefreshInSeconds { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string UserEMail { get; set; }
        public string Gender { get; set; }
        public bool UserIsLocked { get; set; }
        public bool PasswordExpired { get; set; }
        public bool Unauthorized { get; set; }
        public bool Unverified { get; set; }
        public bool OTPCodeTimeOut { get; set; }
        public int IdleTimeout { get; set; }
        public bool InvalidCaptcha { get; set; }
    }
}
