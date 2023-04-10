using Entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class HelperRestSharp
    {
        private static readonly string host;
        static HelperRestSharp()
        {
            host = ConfigurationManager.AppSettings["ApiUrl"];
        }

        public static async Task<ResponseModel> CallApiAsync(string api, Method method, object dataObject = null, string accessToken = null)
        {
            try
            {
                var client = new RestClient
                {
                    BaseUrl = new Uri(host)
                };
                var request = new RestRequest(api, method) { RequestFormat = DataFormat.Json };
                //request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));

                if (dataObject != null)
                {
                    string jsonWithLocalTimeZone = JsonConvert.SerializeObject(dataObject, Formatting.Indented, new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Local
                    });
                    request.AddJsonBody(jsonWithLocalTimeZone);
                }
                var response = await client.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ResponseModel()
                    {
                        Error = true,
                        Message = response.Content,
                        ResultData = null,
                        MessageStatus = response.StatusDescription,
                        StatusCode = response.StatusCode
                    };
                }
                return new ResponseModel()
                {
                    Error = false,
                    MessageStatus = response.StatusDescription,
                    ResultData = response.Content,
                    StatusCode = response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel(ex);
            }
        }
    }
}
