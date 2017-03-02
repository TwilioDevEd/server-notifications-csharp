using ServerNotifications.Web.Domain.Twilio;
using ServerNotifications.Web.Models.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebGrease.Css.Extensions;

namespace ServerNotifications.Web.Domain
{
    public class Notifier
    {
        private Uri _imageUrl = new Uri("http://howtodocs.s3.amazonaws.com/new-relic-monitor.png");

        private readonly IAdministratorsRepository _administratorsRepository;
        private readonly ITwilioRestClient _restClient;

        public Notifier(IAdministratorsRepository repository)
        {
            _administratorsRepository = repository;
            _restClient = new TwilioRestClient(Credentials.TwilioAccountSid, Credentials.TwilioAuthToken);
        }

        public Notifier(IAdministratorsRepository repository, ITwilioRestClient client)
        {
            _administratorsRepository = repository;
            _restClient = client;
        }

        public async Task SendMessagesAsync(string message)
        {
            var mediaUrl = new List<Uri> { _imageUrl };
            _administratorsRepository.All().ForEach(async administrator =>
                await MessageResource.CreateAsync(
                    new PhoneNumber(administrator.PhoneNumber),
                    from: new PhoneNumber(Credentials.TwilioPhoneNumber),
                    body: message,
                    mediaUrl: mediaUrl,
                    client: _restClient));
        }
    }
}