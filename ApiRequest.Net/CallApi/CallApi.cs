using ApiRequest.Net.Servies.InterFace;
using ApiRequest.Net.Servies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest.Net.CallApi
{
    public class CallApi : ICallApiServies
    {
        private IApiCallServies _callServies;
        public CallApi(IApiCallServies apiCallServies)
        {
            _callServies = apiCallServies ?? throw new ArgumentException(nameof(apiCallServies));
        }

        public async Task<ApiResponse<T>> SendDeletRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var response = await _callServies.SendRequest<T>(HttpMethod.Delete, urlt, data, jwt);

            return new ApiResponse<T>
            {
                Data = response.Data,
                IsSuccess = response.IsSuccess,
                Message = response.Message
            };
        }

        public async Task<ApiResponse<T>> SendGetRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            return await _callServies.SendRequest<T>(HttpMethod.Get, urlt, data, jwt);
        }

        public async Task<ApiResponse<T>> SendPatchRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var response = await _callServies.SendRequest<T>(HttpMethod.Patch, urlt, data, jwt);

            return new ApiResponse<T>
            {
                Data = response.Data,
                IsSuccess = response.IsSuccess,
                Message = response.Message
            };
        }

        public async Task<ApiResponse<T>> SendPostRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var response = await _callServies.SendRequest<T>(HttpMethod.Post, urlt, data, jwt);

            return new ApiResponse<T>
            {
                Data = response.Data,
                IsSuccess = response.IsSuccess,
                Message = response.Message
            };
        }

        public async Task<ApiResponse<T>> SendPutRequest<T>(string urlt, object? data = null, string jwt = "")
        {
            var response = await _callServies.SendRequest<T>(HttpMethod.Put, urlt, data, jwt);

            return new ApiResponse<T>
            {
                Data = response.Data,
                IsSuccess = response.IsSuccess,
                Message = response.Message
            };
        }

    }
}
