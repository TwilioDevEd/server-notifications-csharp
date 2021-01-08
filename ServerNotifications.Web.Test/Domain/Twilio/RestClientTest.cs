using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Http;
using ServerNotifications.Web.Domain.Twilio;
using System.Threading.Tasks;

namespace ServerNotifications.Web.Test.Domain.Twilio
{
    public class RestClientTest
    {
        [Test]
        public async Task SendMessage()
        {
            var twilioClientMock = new Mock<ITwilioRestClient>();
            twilioClientMock.Setup(c => c.AccountSid).Returns("AccountSID");
            twilioClientMock.Setup(c => c.RequestAsync(It.IsAny<Request>()))
                            .ReturnsAsync(new Response(System.Net.HttpStatusCode.Created, ""));

            const string body = "Alert message";
            List<Uri> mediaUrl = new List<Uri> { new Uri("http://example.com/image") };
            var client = new RestClient(twilioClientMock.Object);
            await client.SendMessage("from", "to", body, mediaUrl);

            twilioClientMock.Verify(
                c => c.RequestAsync(It.IsAny<Request>()), Times.Once);
        }
    }
}
