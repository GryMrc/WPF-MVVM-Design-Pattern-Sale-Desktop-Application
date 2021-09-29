using Newtonsoft.Json;
using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Customer
{
    public class CustomerTypeService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public CustomerTypeService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<OverPay.Model.Customer.CustomerType>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Customer/CustomerType/ListAll");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<OverPay.Model.Customer.CustomerType>>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
