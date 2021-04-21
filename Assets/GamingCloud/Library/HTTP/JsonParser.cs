using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud
{

    public class JsonParser
    {
        public static T ConvertDictionaryToSchema<T>(Dictionary<string, dynamic> json)
        {
            string stringJson = JsonConvert.SerializeObject(json);
            return JsonConvert.DeserializeObject<T>(stringJson);
        }
        public static T ConvertDictionaryToSchema<T>(Dictionary<string, string> json)
        {
            string stringJson = JsonConvert.SerializeObject(json);
            return JsonConvert.DeserializeObject<T>(stringJson);
        }
    }
}
