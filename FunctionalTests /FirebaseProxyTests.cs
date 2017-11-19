using System;
using System.Net;
using InTouch.FirebaseCloudMessaging;
using Xunit;

namespace FunctionalTests
{
    // Test only for debugging!!!! Delete it
    public class FirebaseProxyTests
    {
        
        [Fact]
        public void IsSuccessfulRequest()
        {
            // todo use DI
            // Arrange
            var firebaseProxy = new FirebaseProxy(new TokenProvider());

            // Act
            var response = firebaseProxy.SendTestNotification();
            
            // Assert
            response.Wait();
            Assert.True(response.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
