using Newtonsoft.Json;
using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Payment
{
    public class PaymentService
    {
        private OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public PaymentService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }
        public async Task<OverPay.Model.Payment.Payment> CreateSalePayment(OverPay.Model.Payment.Payment payment)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(payment);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Payment/Payment/CreateSalePayment", stringContent);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Payment.Payment jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Payment.Payment>(responseMessageStringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return jwtResponse;
            }
            return jwtResponse;
        }
    }
}
