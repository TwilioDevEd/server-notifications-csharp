using System.Web.Configuration;

namespace ServerNotifications.Web.Domain.Twilio
{
    public class Credentials
    {
        public static string TwilioAccountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
        public static string TwilioAuthToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];
        public static string TwilioPhoneNumber = WebConfigurationManager.AppSettings["TwilioPhoneNumber"];
    }
}