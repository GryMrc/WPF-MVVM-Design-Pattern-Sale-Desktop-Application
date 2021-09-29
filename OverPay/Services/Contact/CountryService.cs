using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Contact;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Contact
{
    public class CountryService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public CountryService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<Country>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Contact/Country/ListAll");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<Country>>(responseMessageStringContent);

            return jwtResponse;
        }
    }
}
