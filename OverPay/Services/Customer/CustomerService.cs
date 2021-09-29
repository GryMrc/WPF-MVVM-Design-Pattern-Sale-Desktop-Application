using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OverPay.Model.Customer;

namespace OverPay.Services.Customer
{
    public class CustomerService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public CustomerService()
        {
             this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<JwtResponse<OverPay.Model.Customer.Customer>> ListAll(int pageSize, int page, string sortDirection)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Customer/Customer/List?sort=" + sortDirection + "&pageSize=" + pageSize + "&page=" + page + "&group=&filter=");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            JwtResponse<OverPay.Model.Customer.Customer> jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Response.JwtResponse<OverPay.Model.Customer.Customer>>(responseMessageStringContent);
            return jwtResponse;
        }

        public async Task<bool> Create(OverPay.Model.Customer.Customer customer)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Customer/Customer/Create", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<OverPay.Model.Customer.Customer> GetByMasterId(int masterId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Customer/Customer/Read?id=" + masterId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Customer.Customer jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Customer.Customer>(responseMessageStringContent);

            return jwtResponse;
        }
        public async Task<bool> Update(OverPay.Model.Customer.Customer customer)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync(RouteAddresses.BaseAddress +"/api/Customer/Customer/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int customerId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.DeleteAsync(RouteAddresses.BaseAddress + "/api/Customer/Customer/Delete?id=" + customerId);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<OverPay.Model.Customer.Customer>> SearchCustomer(string searchFilter)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Customer/Customer/SearchCustomer?sort=&pageSize=10&page=1&group=&filter=&searchFilter=" + searchFilter);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<OverPay.Model.Customer.Customer> jwtResponse = JsonConvert.DeserializeObject<IEnumerable<OverPay.Model.Customer.Customer>>(responseMessageStringContent);
            return jwtResponse;
        }

        public async Task<OverPay.Model.Customer.CustomerInformation> GetByCustomerIdForSaleSummary(int customerId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Customer/CustomerContact/GetByCustomerIdForSaleSummary?id=" + customerId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Customer.CustomerInformation jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Customer.CustomerInformation>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
