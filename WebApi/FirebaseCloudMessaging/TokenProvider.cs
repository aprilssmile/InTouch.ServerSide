using System.IO;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;

namespace InTouch.FirebaseCloudMessaging
{
    public class TokenProvider
    {
        public async Task<string> GetToken()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("fcmServerKey.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(
                    new string[] { 
                        "https://www.googleapis.com/auth/firebase.database", 
                        "https://www.googleapis.com/auth/userinfo.email",
                        "https://www.googleapis.com/auth/firebase.messaging", 
                        "https://www.googleapis.com/auth/cloud-platform" }
                    );
            }

            var tokenAccess = credential as ITokenAccess;
            return await tokenAccess.GetAccessTokenForRequestAsync();
        }
    }
}
