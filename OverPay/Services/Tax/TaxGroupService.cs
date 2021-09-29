using Newtonsoft.Json;
using OverPay.Global;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Tax
{
    public class TaxGroupService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public TaxGroupService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<OverPay.Model.Tax.TaxGroup>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Tax/TaxGroup/ListAll");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<OverPay.Model.Tax.TaxGroup>>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
