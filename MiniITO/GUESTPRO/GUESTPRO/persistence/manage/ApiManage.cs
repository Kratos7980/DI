using GUESTPRO.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.manage
{
    internal class ApiManage
    {
        private string apiUrl = "https://calendarific.com/api/v2/holidays?&api_key=0DKVITWfp3xcrNxFifACkBRmUC6t9jZW&country=ES&year=2025";

        public ApiManage() { }
        public async Task<List<DateTime>> obtenerFestivos()
        {
            ApiObject obj = new ApiObject();
            List<DateTime> listFestivos = new List<DateTime>();
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObject>(jsonResponse);
                    obj.response.holidays.ForEach(h => listFestivos.Add(new DateTime(h.date.dateTime.year, h.date.dateTime.month, h.date.dateTime.day))); 
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
            return listFestivos;
        }
    }
}
