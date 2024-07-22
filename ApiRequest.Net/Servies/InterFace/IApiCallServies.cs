using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest.Net.Servies.InterFace
{
    public interface IApiCallServies
    {
        Task<object> SendRequest<T>(HttpMethod method, string url, object? data, string jwt);
    }
}
