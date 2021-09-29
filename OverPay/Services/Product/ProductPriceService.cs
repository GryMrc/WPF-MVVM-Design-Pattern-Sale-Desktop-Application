using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Product
{
    public class ProductPriceService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public ProductPriceService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }
        public async Task<ProductPrice> GetProductPrice(int productId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/ProductPrice/GetProductPrice?id=" + productId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            ProductPrice jwtResponse = JsonConvert.DeserializeObject<ProductPrice>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
