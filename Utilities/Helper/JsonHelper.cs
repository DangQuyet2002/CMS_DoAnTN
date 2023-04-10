using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class JsonHelper
    {
        public static T JsonDeserialize<T>(string jsonString)
        {
            try
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = "dd/MM/yyyy"
                };
                T obj = JsonConvert.DeserializeObject<T>(jsonString, jsonSettings);
                return obj;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"JsonHelper error: {ex.Message}");
                return default(T);
            }
        }
    }
}
