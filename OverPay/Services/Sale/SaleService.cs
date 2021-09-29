using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Sale
{
    public class SaleService
    {
        private OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public SaleService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<OverPay.Model.Sale.Sale> Create(OverPay.Model.Sale.Sale sale)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(sale);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Sales/Sale/Create", stringContent);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Sale.Sale jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Sale.Sale>(responseMessageStringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return jwtResponse;
            }
            return jwtResponse;
        }

        public async Task<OverPay.Model.Sale.Sale> CompleteSale(OverPay.Model.Sale.Sale sale)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(sale);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Sales/Sale/CompleteSale", stringContent);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Sale.Sale jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Sale.Sale>(responseMessageStringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return jwtResponse;
            }
            return null;
        }
    }
}
