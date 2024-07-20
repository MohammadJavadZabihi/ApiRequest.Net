using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiRequest.Net.Servies.InterFace;

namespace ApiRequest.Net.Servies
{
    public class JsonConvertor : IJsonConvertorServies
    {
        private string JsonIEnumSerialize(IEnumerable ienum)
        {
            var json = new StringBuilder();

            json.Append("[");

            var enumerator = ienum.GetEnumerator();
            var hasNex = enumerator.MoveNext();

            while (hasNex)
            {
                json.Append(JsonSerializer(enumerator.Current));
                hasNex = enumerator.MoveNext();
                if (hasNex)
                    json.Append(",");
            }

            json.Append("]");

            return json.ToString();
        }

        public string JsonSerializer(object data)
        {
            if (data == null)
                return "null";

            var objectType = data.GetType();

            if (objectType == typeof(string))
                return $"\"{data}\"";

            if (objectType == typeof(int))
                return data.ToString();

            if (objectType == typeof(bool))
                return data.ToString().ToLower();

            if (typeof(IEnumerable).IsAssignableFrom(objectType))
                return JsonIEnumSerialize((IEnumerable)data);

            var json = new StringBuilder();
            json.Append('{');

            var properties = objectType.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var value = property.GetValue(data);

                json.Append($"\"{property.Name}\" : {JsonSerializer(value)}");

                if (i < properties.Length - 1)
                    json.Append(",");
            }

            json.Append("}");

            return json.ToString();
        }

        public T JsonDeserialize<T>(string json)
        {
            return (T)Deserialize(json, typeof(T));
        }

        private object Deserialize(string json, Type type)
        {
            if (type == typeof(string))
                return json.Trim('"');
            if (type == typeof(bool))
                return bool.Parse(json);
            if (type.IsPrimitive)
                return Convert.ChangeType(json, type);
            if (typeof(IEnumerable).IsAssignableFrom(type))
                return DeserializeEnumerable(json, type);

            var obj = Activator.CreateInstance(type);
            var properties = type.GetProperties();
            var matches = Regex.Matches(json, "\"(\\w+)\":(.*?)(,|})");

            foreach (Match match in matches)
            {
                var propertyName = match.Groups[1].Value;
                var value = match.Groups[2].Value.Trim();

                var property = Array.Find(properties, p => p.Name == propertyName);
                if (property != null)
                {
                    var propertyValue = Deserialize(value, property.PropertyType);
                    property.SetValue(obj, propertyValue);
                }
            }

            return obj;
        }

        private object DeserializeEnumerable(string json, Type type)
        {
            var elementType = type.IsArray ? type.GetElementType() : type.GenericTypeArguments[0];
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));

            var matches = Regex.Matches(json, "(\".*?\"|\\d+|true|false|null)(,|])");

            foreach (Match match in matches)
            {
                if (match.Value == "]")
                    break;

                var value = match.Groups[1].Value;
                var element = Deserialize(value, elementType);
                list.Add(element);
            }

            if (type.IsArray)
            {
                var array = Array.CreateInstance(elementType, list.Count);
                list.CopyTo(array, 0);
                return array;
            }

            return list;
        }
    }
}
