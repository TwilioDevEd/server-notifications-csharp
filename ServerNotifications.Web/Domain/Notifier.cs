using ServerNotifications.Web.Domain.Twilio;
using ServerNotifications.Web.Models.Repository;
using WebGrease.Css.Extensions;

namespace ServerNotifications.Web.Domain
{
    public class Notifier
    {
        private const string ImageUrl = "http://howtodocs.s3.amazonaws.com/new-relic-monitor.png";

        private readonly IAdministratorsRepository _administratorsRepository;
        private readonly IRestClient _restClient;

        public Notifier(IAdministratorsRepository repository, IRestClient restClient)
        {
            _administratorsRepository = repository;
            _restClient = restClient;
        }
        
        public void SendMessages(string message)
        {
            _administratorsRepository.All().ForEach(administrator =>
                _restClient.SendMessage(Credentials.TwilioPhoneNumber, administrator.PhoneNumber, message, ImageUrl));
        }
    }
}