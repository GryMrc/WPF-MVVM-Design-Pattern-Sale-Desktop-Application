using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Merchant
{
    public class MerchantPaymentTypeService
    {
        private OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public MerchantPaymentTypeService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }
        public async Task<JwtResponse<OverPay.Model.Merchant.MerchantPaymentType>> ListMerchantPaymentType()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Merchant/MerchantPaymentType/ListMerchantPaymentType");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            JwtResponse<OverPay.Model.Merchant.MerchantPaymentType> jwtResponse = JsonConvert.DeserializeObject <JwtResponse<OverPay.Model.Merchant.MerchantPaymentType>> (responseMessageStringContent);
            return jwtResponse;
        }
    }
}
