using Twilio;

namespace ServerNotifications.Web.Domain.Twilio
{
    public interface IRestClient
    {
        Message SendMessage(string to, string body, params string[] mediaUrl);
    }

    public class RestClient : IRestClient
    {   
        private readonly TwilioRestClient _client;

        public RestClient()
        {
            _client = new TwilioRestClient(Credentials.TwilioAccountSid, Credentials.TwilioAuthToken);
        }

        public RestClient(TwilioRestClient client)
        {
            _client = client;
        }

        public Message SendMessage(string to, string body, params string[] mediaUrl)
        {
            return _client.SendMessage(Credentials.TwilioPhoneNumber, to, body, mediaUrl);
        }
    }
}