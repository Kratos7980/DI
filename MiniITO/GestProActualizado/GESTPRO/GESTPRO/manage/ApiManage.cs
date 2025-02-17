using FormularioExamen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.manage
{
    class ApiManage
    {
        private string apiUrl = "https://calendarific.com/api/v2/holidays?&api_key=0DKVITWfp3xcrNxFifACkBRmUC6t9jZW&country=ES&year=2025&month=05";

        public ApiManage() { }
        public async Task<List<ApiObject>> obtenerFestivos()
        {
            var objects = new List<ApiObject>();
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiObject>>(jsonResponse);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching data: {ex.Message}");
            }
            return objects;
        }
    }
}
