using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameShopApiClient;

namespace GameShopApp.ApiController
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<swaggerClient> ConnectToApi()
        {
            return new swaggerClient("https://localhost:7183/", httpClient);
        }
        public async Task<swaggerClient> CheckForApiStatus()
        {
            var swaggerClient = new swaggerClient("https://localhost:7183/", httpClient);

            try
            {
                var categories = await swaggerClient.GetCategoriesAsync();
                return swaggerClient;
            }
            catch
            {
                return null;
            }
        }
    }
}