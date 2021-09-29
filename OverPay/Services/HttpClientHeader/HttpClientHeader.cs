using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OverPay.Services.HttpClientHeader
{
    public class HttpClientHeader
    {
        public void HttpClientHeaderCreated(HttpClient httpClient)
        {
            if (!String.IsNullOrEmpty(AuthenticationTokenInfo.authenticationToken.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthenticationTokenInfo.authenticationToken.AccessToken);
            }
                
        }
    }
}
