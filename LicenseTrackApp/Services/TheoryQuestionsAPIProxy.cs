using LicenseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LicenseTrackApp.Services
{
    internal class TheoryQuestionsAPIProxy
    {
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = "https://data.gov.il/api/3/action/datastore_search?resource_id=8c0f314f-583d-48b6-9f5f-4483d95f6848&limit=";
        
        public TheoryQuestionsAPIProxy()
        {
            this.client = new HttpClient();
            this.baseUrl = BaseAddress;
        }

        public async Task<Question[]> GetQuestions(int num)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}{num}";
            try
            {
                //Call the server API
                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Rootobject? root = JsonSerializer.Deserialize<Rootobject>(resContent, options);
                    if (root != null)
                    {
                        return root.result.records;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
