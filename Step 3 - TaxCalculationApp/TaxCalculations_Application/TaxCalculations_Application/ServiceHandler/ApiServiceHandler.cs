using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace TaxCalculationsApplication.ServiceHandler
{
    public class ApiServiceHandler
    {
        public async Task<T> PostAsync<T>(string baseUri, string url, object dtoObject)
        {
            dynamic p;
            HttpClient _httpPostClient = new HttpClient();

            _httpPostClient.BaseAddress = new Uri(baseUri);

            var Content = JsonConvert.SerializeObject(dtoObject);
            var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpPostClient.PostAsync(url, byteContent);
            var payload = await response.Content.ReadAsStreamAsync();

            using (StreamReader sr = new StreamReader(payload))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                p = serializer.Deserialize<T>(reader);
            }

            return p;
        }

        public async Task<T> PutAsync<T>(string baseUri, string url, object dtoObject)
        {
            dynamic p;
            HttpClient _httpPutClient = new HttpClient();

            _httpPutClient.BaseAddress = new Uri(baseUri);

            var Content = JsonConvert.SerializeObject(dtoObject);
            var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpPutClient.PutAsync(url, byteContent);
            var payload = await response.Content.ReadAsStreamAsync();

            using (StreamReader sr = new StreamReader(payload))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                p = serializer.Deserialize<T>(reader);
            }

            return p;
        }
    }
}
