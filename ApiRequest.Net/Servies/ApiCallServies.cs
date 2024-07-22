using ApiRequest.Net.Servies.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ApiRequest.Net.Servies
{
    public class ApiCallServies : IApiCallServies
    {
        private readonly HttpClient _client;
        private readonly JsonConvertor _jsonConvertor;
        public ApiCallServies(HttpClient client, JsonConvertor jsonConvertor)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
            _jsonConvertor = jsonConvertor ?? throw new ArgumentNullException(nameof(jsonConvertor));
        }

        public async Task<object> SendRequest<T>(HttpMethod method, string url, object? data, string jwt)
        {
            var request = new HttpRequestMessage(method, url);

            if(data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            if (!string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            try
            {
                var responeMessage = await _client.SendAsync(request);
                if(responeMessage.IsSuccessStatusCode)
                {
                    var respone = await responeMessage.Content.ReadAsStringAsync();
                    var objects = _jsonConvertor.JsonDeserialize<T>(respone);

                    if (objects != null) 
                        return objects;

                    return "Having Trouble With Returning Object";
                }

                return "Response Message : " + responeMessage;
            }
            catch (Exception ex)
            {
                return "Error Message : " + ex.Message;
            }
        }
    }
}
