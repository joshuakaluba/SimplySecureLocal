using SimplySecureLocal.Data.DataContext;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SimplySecureLocal.Data.DataAccessLayer
{
    public abstract class BaseRepository
    {
        internal SimplySecureDataContext DataContext;

        internal HttpClient ApplicationHttpClient(Uri baseAddress)
        {
            var httpClient = new HttpClient { BaseAddress = baseAddress };

            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}