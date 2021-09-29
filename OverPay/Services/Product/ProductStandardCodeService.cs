using Newtonsoft.Json;
using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Product
{
    class ProductStandardCodeService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public ProductStandardCodeService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<OverPay.Model.Product.ProductStandardCode>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/ProductStandardCode/ListAll");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<OverPay.Model.Product.ProductStandardCode>>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
