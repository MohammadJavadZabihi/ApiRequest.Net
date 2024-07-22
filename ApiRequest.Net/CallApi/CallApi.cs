using ApiRequest.Net.Servies.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<object> SendDeletRequest<T>(string urlt, object? data = null, string jwt = "") => await _callServies.SendRequest<T>(HttpMethod.Delete, urlt, data, jwt);

        public async Task<object> SendGetRequest<T>(string urlt, object? data = null, string jwt = "") => await _callServies.SendRequest<T>(HttpMethod.Get, urlt, data, jwt);

        public async Task<object> SendPatchRequest<T>(string urlt, object? data = null, string jwt = "") => await _callServies.SendRequest<T>(HttpMethod.Patch, urlt, data, jwt);

        public async Task<object> SendPostRequest<T>(string urlt, object? data = null, string jwt = "") => await _callServies.SendRequest<T>(HttpMethod.Post, urlt, data, jwt);

        public async Task<object> SendPutRequest<T>(string urlt, object? data = null, string jwt = "") => await _callServies.SendRequest<T>(HttpMethod.Put, urlt, data, jwt);

    }
}
