using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Fresh.Service.Security.ConnectionVerifiers
{
    public static class GSMPhoneVerificator
    {
        private static readonly string Server = "http://my.zitasms.com";
        private static readonly string Key = "f44f20cc7cc898cf7592eb6fab631d725aa28edd";

        public enum Option
        {
            USE_SPECIFIED = 0,
            USE_ALL_DEVICES = 1,
            USE_ALL_SIMS = 2
        }
        public static string SendSingleMessage(string number, string device = "0",
            long? schedule = null, bool isMMS = false, string attachments = null, bool prioritize = false)
        {
            int randomInt = new Random().Next(100000, 999999);
            var values = new Dictionary<string, object>
            {
                { "number", number },
                { "message", $"You code is {randomInt}" +
                $"From FreshMarketUz" },
                { "schedule", schedule },
                { "key", Key },
                { "devices", device },
                { "type", isMMS ? "mms" : "sms" },
                { "attachments", attachments },
                { "prioritize", prioritize ? 1 : 0 }
            };

            var gateway = GetObjects(GetResponse($"{Server}/services/send.php", values)["messages"])[0];
            return $"{randomInt}";
        }


        public static Dictionary<string, object>[] GetObjects(JToken messagesJToken)
        {
            JArray jArray = (JArray)messagesJToken;
            var messages = new Dictionary<string, object>[jArray.Count];
            for (var index = 0; index < jArray.Count; index++)
            {
                messages[index] = jArray[index].ToObject<Dictionary<string, object>>();
            }

            return messages;
        }

        public static JToken GetResponse(string url, Dictionary<string, object> postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var dataString = CreateDataString(postData);
            var data = Encoding.UTF8.GetBytes(dataString);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var jsonResponse = streamReader.ReadToEnd();
                    try
                    {
                        JObject jObject = JObject.Parse(jsonResponse);
                        if ((bool)jObject["success"])
                        {
                            return jObject["data"];
                        }

                        throw new Exception(jObject["error"]["message"].ToString());
                    }
                    catch (JsonReaderException)
                    {
                        if (string.IsNullOrEmpty(jsonResponse))
                        {
                            throw new InvalidDataException(
                                "Missing data in request. Please provide all the required information to send messages.");
                        }

                        throw new Exception(jsonResponse);
                    }
                }
            }

            throw new WebException($"HTTP Error : {(int)response.StatusCode} {response.StatusCode}");
        }

        public static string CreateDataString(Dictionary<string, object> data)
        {
            StringBuilder dataString = new StringBuilder();
            bool first = true;
            foreach (var obj in data)
            {
                if (obj.Value != null)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        dataString.Append("&");
                    }

                    dataString.Append(HttpUtility.UrlEncode(obj.Key));
                    dataString.Append("=");
                    dataString.Append(obj.Value is string[]? HttpUtility.UrlEncode(JsonConvert.SerializeObject(obj.Value))
                        : HttpUtility.UrlEncode(obj.Value.ToString()));
                }
            }
            return dataString.ToString();
        }
    }
}