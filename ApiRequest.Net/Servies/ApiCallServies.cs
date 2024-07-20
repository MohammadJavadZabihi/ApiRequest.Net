using ApiRequest.Net.Servies.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<object> SendDeletRequest<T>(string urlt, object data, string jwt = "")
        {
            throw new NotImplementedException();
        }

        public async Task<object> SendGetRequest<T>(string urlt, object data, string jwt = "")
        {
            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Content = content,
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(urlt)
                };

                if (jwt != null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
                }

                var responseMessage = await _client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var response = await responseMessage.Content.ReadAsStringAsync();
                    var objects = _jsonConvertor.JsonDeserialize<T>(response);

                    return objects;
                }

                return responseMessage;
            }
        }

        public Task<object> SendPatchRequest<T>(string urlt, object data, string jwt = "")
        {
            throw new NotImplementedException();
        }

        public Task<object> SendPostRequest<T>(string urlt, object data, string jwt = "")
        {
            throw new NotImplementedException();
        }

        public Task<object> SendPutRequest<T>(string urlt, object data, string jwt = "")
        {
            throw new NotImplementedException();
        }
    }
}
