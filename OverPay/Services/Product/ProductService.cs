using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Product
{
    public class ProductService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public ProductService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<JwtResponse<OverPay.Model.Product.Product>> ListAll(int pageSize,int page, string sortDirection)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/Product/List?sort=" + sortDirection + "&pageSize="+pageSize+"&page="+page+"&group=&filter=");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            JwtResponse<OverPay.Model.Product.Product> jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Response.JwtResponse<OverPay.Model.Product.Product>>(responseMessageStringContent);

            return jwtResponse;
        }

        public async Task<ServiceResponse> Create(OverPay.Model.Product.Product product)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            product.CategoryId = 424;
            MakeitNull(product);
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(product);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Product/Product/Create",stringContent);


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                serviceResponse.isSuccessed = true;
                return serviceResponse;
            }

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response);
            return serviceResponse;
        }

        public async Task<ServiceResponse> Update(OverPay.Model.Product.Product product)
        {

            ServiceResponse serviceResponse = new ServiceResponse();

            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(product);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponseMessage = await httpClient.PutAsync(RouteAddresses.BaseAddress + "/api/Product/Product/Update", stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                serviceResponse.isSuccessed = true;
                return serviceResponse;
            }

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response);
            return serviceResponse;
        }

        public async Task<bool> Delete(int productId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.DeleteAsync(RouteAddresses.BaseAddress + "/api/Product/Product/Delete?id="+productId);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<OverPay.Model.Product.Product> GetByMasterId(int productId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/Product/Read?id=" + productId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Product.Product jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Product.Product>(responseMessageStringContent);

            return jwtResponse;
        }

        private void MakeitNull(OverPay.Model.Product.Product product)
        {
            product.StandardCode = null;
            product.Unit = null;
            
        }
        public async Task<IEnumerable<OverPay.Model.Product.Product>> SearchMerchantProduct(string searchFilter, int applicationId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/Product/SearchMerchantProduct?sort=&pageSize=10&page=1&group=&filter=&searchFilter=" + searchFilter + "&applicationId=45");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<OverPay.Model.Product.Product> jwtResponse = JsonConvert.DeserializeObject<IEnumerable<OverPay.Model.Product.Product>>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
