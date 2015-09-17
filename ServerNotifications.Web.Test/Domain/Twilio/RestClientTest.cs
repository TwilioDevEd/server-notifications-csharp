using Moq;
using NUnit.Framework;
using RestSharp;
using ServerNotifications.Web.Domain.Twilio;
using Twilio;

namespace ServerNotifications.Web.Test.Domain.Twilio
{
    public class RestClientTest
    {
        [Test]
        public void SendMessage()
        {
            var mockClient = new Mock<TwilioRestClient>(Credentials.TwilioAccountSid, Credentials.TwilioAuthToken) { CallBase = true };
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>(request => savedRequest = request)
                .Returns(new Message());

            var client = new Web.Domain.Twilio.RestClient(mockClient.Object);
            
            const string body = "Alert message";
            client.SendMessage("from", "to", body, "image");

            mockClient.Verify(trc => trc.Execute<Message>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.That(savedRequest, Is.Not.Null);
        }
    }
}
