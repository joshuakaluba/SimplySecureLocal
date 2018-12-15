using SimplySecureLocal.Data.Models.Static;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.Services
{
    public static class BackendAvailabilityService
    {
        public static async Task<bool> DetermineAvailability()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response 
                        = await client.GetAsync(ApplicationConfig.BackendHost);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {
                // if this method fails, the backend server is down. Return false as there is nothing else that we need to do
                return false;
            }
        }
    }
}