using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            return jsonString;
        }

        public static T DeSerialize<T>(string jsonString)
        {
            T jsonObject = JsonConvert.DeserializeObject<T>(jsonString);
            return jsonObject;
        }
    }
}
