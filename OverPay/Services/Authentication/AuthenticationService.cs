using Newtonsoft.Json;
using OverPay.Global;
using OverPay.Model.Authentication;
using OverPay.Model.Response;
using OverPay.Services.Merchant;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Services.Authentication
{
    public class AuthenticationService
    {

        public async Task<ServiceResponse> Login(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceResponse serviceResponse = new ServiceResponse();

                var stringPayload = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RouteAddresses.BaseAddress+"/api/Authenticate/login", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    AuthenticationToken authenticationToken = JsonConvert.DeserializeObject<AuthenticationToken>(await response.Content.ReadAsStringAsync());
                    if (authenticationToken.AccessToken == "") {
                        serviceResponse.message = "Unauthorized Failed!";
                        return serviceResponse; 
                    }
                    AuthenticationTokenInfo.authenticationToken = authenticationToken;
                    MerchantService merchantService = new MerchantService();
                    CurrentMerchantInformation.merchant = await merchantService.ReadCurrent();
                    serviceResponse.isSuccessed = true;
                    return serviceResponse;
                }

                else
                {
                    serviceResponse.message = "Failed";
                    return serviceResponse;
                }

                
            }
        }

        public bool LogOut()
        {
            AuthenticationTokenInfo.authenticationToken.AccessToken = "";
            if (String.IsNullOrEmpty(AuthenticationTokenInfo.authenticationToken.AccessToken))
            {
                return true;
            }
            return false;
        }
    }
}
