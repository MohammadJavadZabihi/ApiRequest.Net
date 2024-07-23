using ApiRequest.Net.Servies.InterFace;
using ApiRequest.Net.Servies.Models;
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
        public async Task<ApiResponse<T>> SendRequest<T>(HttpMethod method, string url, object? data, string jwt)
        {
            HttpClient _client = new HttpClient();
            JsonConvertor _jsonConvertor = new JsonConvertor();
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
                    {
                        return new ApiResponse<T>
                        {
                            Data = objects,
                            IsSuccess = true,
                            Message = "Request Is Successfully"
                        };
                    }
                    return new ApiResponse<T>
                    {
                        Data = default(T),
                        IsSuccess = false,
                        Message = "Error Message : " + respone
                    };
                }

                return new ApiResponse<T>
                {
                    Data = default(T),
                    IsSuccess = false,
                    Message = "Error Message : " + await responeMessage.Content.ReadAsStringAsync()
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Data = default(T),
                    IsSuccess = false,
                    Message = "Error Message : " + ex.Message
                };
            }
        }
    }
}
