using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;

namespace Fresh.Service.Security.ConnectionVerifiers
{
    public class ImapPhoneVerificator
    {
        private static readonly string BASE_URL = "https://dmzzn8.api.infobip.com";
        private static readonly string API_KEY = "eb5d113070952587fe02971302cbb76a-110b25a5-5033-479f-a595-deafa591632f";
        private static readonly string SENDER = "InfoSMS";

        public (int rand,string status) Verify(string number)
        {
            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999);
            var configuration = new Configuration()
            {
                BasePath = BASE_URL,
                ApiKeyPrefix = "App",
                ApiKey = API_KEY
            };

            var sendSmsApi = new SendSmsApi(configuration);

            var smsMessage = new SmsTextualMessage()
            {
                From = SENDER,
                Destinations = new List<SmsDestination>()
                {
                    new SmsDestination(to: number)
                },
                Text =
                    $"Please verify action\n" +
                    $"YOUR CODE IS - {rand_num}\n"
                    + "DON'T LET ANYONE TO KNOW THIS CODE OTHER THAN US\n"
            };
            var smsRequest = new SmsAdvancedTextualRequest()
            {
                Messages = new List<SmsTextualMessage>() { smsMessage }
            };

            try
            {
                var smsResponse = sendSmsApi.SendSmsMessage(smsRequest);

                return (rand: rand_num, status: "Success");
            }
            catch (ApiException apiException)
            {
                return (0, $"There some error while sending message, {apiException.Message}");
            }
        }
    }
}
