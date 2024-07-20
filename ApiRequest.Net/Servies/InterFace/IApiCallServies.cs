using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest.Net.Servies.InterFace
{
    public interface IApiCallServies
    {
        Task<object> SendGetRequest<T>(string urlt, object? data = null, string jwt = "");
        Task<object> SendPostRequest<T>(string urlt, object? data = null, string jwt = "");
        Task<object> SendDeletRequest<T>(string urlt, object? data = null, string jwt = "");
        Task<object> SendPutRequest<T>(string urlt, object? data = null, string jwt = "");
        Task<object> SendPatchRequest<T>(string urlt, object? data = null, string jwt = "");
    }
}
