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

        public async Task<object> SendDeletRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var request = new HttpRequestMessage();

            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }
            request.Method = HttpMethod.Delete;
            request.RequestUri = new Uri(urlt);

            if (string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            var responseMessageWithData = await _client.SendAsync(request);

            if (responseMessageWithData.IsSuccessStatusCode)
            {
                var response = await responseMessageWithData.Content.ReadAsStringAsync();
                var objects = _jsonConvertor.JsonDeserialize<T>(response);

                if (objects != null)
                    return objects;

                return "having trouble returning object";
            }

            return responseMessageWithData;
        }

        public async Task<object> SendGetRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var request = new HttpRequestMessage();

            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(urlt);

            if (string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            var responseMessageWithData = await _client.SendAsync(request);

            if (responseMessageWithData.IsSuccessStatusCode)
            {
                var response = await responseMessageWithData.Content.ReadAsStringAsync();
                var objects = _jsonConvertor.JsonDeserialize<T>(response);

                if (objects != null)
                    return objects;

                return "having trouble returning object";
            }

            return responseMessageWithData;
        }

        public async Task<object> SendPatchRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var request = new HttpRequestMessage();

            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }
            request.Method = HttpMethod.Patch;
            request.RequestUri = new Uri(urlt);

            if (string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            var responseMessageWithData = await _client.SendAsync(request);

            if (responseMessageWithData.IsSuccessStatusCode)
            {
                var response = await responseMessageWithData.Content.ReadAsStringAsync();
                var objects = _jsonConvertor.JsonDeserialize<T>(response);

                if (objects != null)
                    return objects;

                return "having trouble returning object";
            }

            return responseMessageWithData;
        }

        public async Task<object> SendPostRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var request = new HttpRequestMessage();

            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(urlt);

            if (string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            var responseMessageWithData = await _client.SendAsync(request);

            if (responseMessageWithData.IsSuccessStatusCode)
            {
                var response = await responseMessageWithData.Content.ReadAsStringAsync();
                var objects = _jsonConvertor.JsonDeserialize<T>(response);

                if (objects != null)
                    return objects;

                return "having trouble returning object";
            }

            return responseMessageWithData;
        }

        public async Task<object> SendPutRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var request = new HttpRequestMessage();

            if (data != null)
            {
                var json = _jsonConvertor.JsonSerializer(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }
            request.Method = HttpMethod.Put;
            request.RequestUri = new Uri(urlt);

            if (string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

            var responseMessageWithData = await _client.SendAsync(request);

            if (responseMessageWithData.IsSuccessStatusCode)
            {
                var response = await responseMessageWithData.Content.ReadAsStringAsync();
                var objects = _jsonConvertor.JsonDeserialize<T>(response);

                if (objects != null)
                    return objects;

                return "having trouble returning object";
            }

            return responseMessageWithData;
        }
    }
}
