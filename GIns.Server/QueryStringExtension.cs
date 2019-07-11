using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GIns.Server
{
    public static class QueryStringExtension
    {
        public static string GetQueryString(this object obj, string prefix = "")
        {
            var query = "";
            try
            {
                var vQueryString = (JsonConvert.SerializeObject(obj));
                String v1 = vQueryString.Replace("[", "");
                String v2 = v1.Replace("]", "");
                var json = JsonConvert.DeserializeObject(v2);

                var jObj = (JObject)JsonConvert.DeserializeObject(v2);

                query = String.Join("&",
                       jObj.Children().Cast<JProperty>()
                       .Select(jp =>
                       {
                           if (jp.Value.Type == JTokenType.Array)
                           {
                               var count = 0;
                               var arrValue = String.Join("&", jp.Value.ToList().Select<JToken, string>(p =>
                               {
                                   var tmp = JsonConvert.DeserializeObject(p.ToString()).GetQueryString(jp.Name + HttpUtility.UrlEncode("[") + count++ + HttpUtility.UrlEncode("]"));
                                   return tmp;
                               }));
                               return arrValue;
                           }
                           else
                               return (prefix.Length > 0 ? prefix + HttpUtility.UrlEncode("[") + jp.Name + HttpUtility.UrlEncode("]") : jp.Name) + "=" + HttpUtility.UrlEncode(jp.Value.ToString());
                       }
                       )) ?? "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            return query;
        }
    }
}

