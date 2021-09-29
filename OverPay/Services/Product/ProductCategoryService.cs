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
    public class ProductCategoryService
    {
        private readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;
        public ProductCategoryService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<JwtResponse<OverPay.Model.Product.ProductCategory>> ListAll(int pageSize, int page, string sortDirection)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/List?sort=" + sortDirection + "&pageSize=" + pageSize + "&page=" + page + "&group=&filter=");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            JwtResponse<OverPay.Model.Product.ProductCategory> jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Response.JwtResponse<OverPay.Model.Product.ProductCategory>>(responseMessageStringContent);

            return jwtResponse;
        }


        public async Task<Model.Response.ServiceResponse> Create(OverPay.Model.Product.ProductCategory productCategory)
        {

            ServiceResponse serviceResponse = new ServiceResponse();

            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(productCategory);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponseMessage = await httpClient.PostAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/Create", stringContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                serviceResponse.isSuccessed = true;
                return serviceResponse;
            }

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response);
            return serviceResponse;
        }

        public async Task<ServiceResponse> Update(OverPay.Model.Product.ProductCategory productCategory)
        {

            ServiceResponse serviceResponse = new ServiceResponse();

            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var data = JsonConvert.SerializeObject(productCategory);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponseMessage = await httpClient.PutAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/Update", stringContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                serviceResponse.isSuccessed = true;
                return serviceResponse;
            }

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response);
            return serviceResponse;
        }

        public async Task<bool> Delete(int productCategoryId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.DeleteAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/Delete?id=" + productCategoryId);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<OverPay.Model.Product.ProductCategory> GetByMasterId(int masterId)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/Read?id=" + masterId);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            OverPay.Model.Product.ProductCategory jwtResponse = JsonConvert.DeserializeObject<OverPay.Model.Product.ProductCategory>(responseMessageStringContent);

            return jwtResponse;
        }

        public async Task<IEnumerable<OverPay.Model.Product.ProductCategory>> SearchMerchantProduct(string searchFilter)
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/Product/ProductCategory/Search?merchantId=5&name="+searchFilter);
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<OverPay.Model.Product.ProductCategory> jwtResponse = JsonConvert.DeserializeObject<IEnumerable<OverPay.Model.Product.ProductCategory>>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
