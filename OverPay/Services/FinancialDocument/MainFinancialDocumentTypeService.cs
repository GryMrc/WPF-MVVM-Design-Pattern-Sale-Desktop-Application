using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.FinancialDocument
{
    public class MainFinancialDocumentTypeService
    {
        private  readonly OverPay.Services.HttpClientHeader.HttpClientHeader httpClientHeader;

        public MainFinancialDocumentTypeService()
        {
            this.httpClientHeader = new OverPay.Services.HttpClientHeader.HttpClientHeader();
        }

        public async Task<List<OverPay.Model.FinancialDocument.MainFinancialDocumentType>> ListAll()
        {
            var httpClient = new HttpClient();
            this.httpClientHeader.HttpClientHeaderCreated(httpClient);
            var responseMessage = await httpClient.GetAsync(RouteAddresses.BaseAddress + "/api/FinancialDocument/MainFinancialDocumentType/GetByMerchant");
            string responseMessageStringContent = await responseMessage.Content.ReadAsStringAsync();
            List<OverPay.Model.FinancialDocument.MainFinancialDocumentType> jwtResponse = JsonConvert.DeserializeObject<List<OverPay.Model.FinancialDocument.MainFinancialDocumentType>>(responseMessageStringContent);
            return jwtResponse;
        }
    }
}
