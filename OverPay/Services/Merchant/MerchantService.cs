using Newtonsoft.Json;
using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Merchant
{
   public class MerchantService
    {
        private OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public MerchantService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }
        public async Task<OverPay.Model.Merchant.Merchant> ReadCurrent()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Merchant/Merchant/ReadCurrent");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Merchant.Merchant jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Merchant.Merchant>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
