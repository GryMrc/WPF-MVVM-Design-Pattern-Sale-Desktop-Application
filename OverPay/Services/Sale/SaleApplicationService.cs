using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Sale
{
    public class SaleApplicationService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public SaleApplicationService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<JwtResponse<OverPay.Model.Sale.SaleApplication>> ListAll(int pageSize, int page)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Sales/SalesApplication/List?sort=&pageSize=10&page=2&group=&filter=");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            JwtResponse<OverPay.Model.Sale.SaleApplication> jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Response.JwtResponse<OverPay.Model.Sale.SaleApplication>>(responseMessageStringContent);

            return jwtResponse;
        }
        public async Task<OverPay.Model.Sale.SaleApplication> GetByMasterId(int masterId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Sales/SalesApplication/Read?id=" + masterId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Sale.SaleApplication jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Sale.SaleApplication>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
