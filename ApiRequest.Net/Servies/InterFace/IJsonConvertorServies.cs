using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest.Net.Servies.InterFace
{
    public interface IJsonConvertorServies
    {
        string JsonSerializer(object data);
        T JsonDeserialize<T>(string json);
    }
}
