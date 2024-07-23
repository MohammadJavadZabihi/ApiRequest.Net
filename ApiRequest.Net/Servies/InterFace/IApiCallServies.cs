using ApiRequest.Net.Servies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest.Net.Servies.InterFace
{
    public interface IApiCallServies
    {
        Task<ApiResponse<T>> SendRequest<T>(HttpMethod method, string url, object? data, string jwt);
    }
}
