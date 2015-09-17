using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ServerNotifications.Web.Domain;
using ServerNotifications.Web.Domain.Twilio;
using ServerNotifications.Web.Models;
using ServerNotifications.Web.Models.Repository;

namespace ServerNotifications.Web.Test.Domain
{
    public class NotifierTest
    {
        [Test]
        public void SendMessages_sends_a_message_to_each_administrator()
        {
            var mockRepository = new Mock<IAdministratorsRepository>();
            mockRepository.Setup(x => x.All())
                .Returns(new List<Administrator>
                {
                    new Administrator {Name = "Bob"},
                    new Administrator {Name = "Alice"}
                });

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(
                x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            new Notifier(mockRepository.Object, mockRestClient.Object).SendMessages();

            mockRestClient.Verify(
                x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Exactly(2));
        }
    }
}
