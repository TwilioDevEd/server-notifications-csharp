using ServerNotifications.WebMvc3.Domain.Twilio;
using ServerNotifications.WebMvc3.Models.Repository;

namespace ServerNotifications.WebMvc3.Domain
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
            foreach (var administrator in _administratorsRepository.All())
            {
                _restClient.SendMessage(Credentials.TwilioPhoneNumber, administrator.PhoneNumber, message, ImageUrl);
            }
        }
    }
}