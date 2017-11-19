using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InTouch.FirebaseCloudMessaging
{
    public class FirebaseProxy
    {
        private TokenProvider _tokenProvider;

        public FirebaseProxy (TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task<HttpResponseMessage> SendTestNotification()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("appslication/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                await _tokenProvider.GetToken());

            // more info: https://firebase.google.com/docs/cloud-messaging/send-message
            var uri = "https://fcm.googleapis.com/v1/projects/intouch-40c70/messages:send";
            string content = GetTestMessage();

            var response = client.PostAsync(uri, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));
            return await response;
        }

        private string GetTestMessage()
        {
            using (StreamReader reader = new StreamReader("testMessage.json"))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
