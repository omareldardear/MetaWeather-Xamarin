using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trial.Assets
{
    public class WebService
    {
        HttpClient _client;
        public WebService()
        {
            _client = new HttpClient();
        }

        public async Task<String> GET_Task(string uri)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
