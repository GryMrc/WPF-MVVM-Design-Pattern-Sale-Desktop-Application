using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Contact;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OverPay.Services.Contact
{
    public class CityService
    {

        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public CityService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<City>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Contact/City/ListAll");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<City>>(responseMessageStringContent);
            return jwtResponse;
        }

        public async Task<List<City>> Search(int id)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Contact/City/Search/"+id);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            var jwtResponse = JsonConvert.DeserializeObject<List<City>>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
