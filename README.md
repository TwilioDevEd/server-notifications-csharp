<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# Server Notifications on ASP.NET MVC

![](https://github.com/TwilioDevEd/server-notifications-csharp/workflows/NetFx/badge.svg)

Use Twilio to send SMS alerts so that you never miss a critical issue.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/server-notifications/csharp/mvc)!

### Local development

1. First clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/server-notifications-csharp.git

   cd server-notifications-csharp
   ```

1. Create a copy of `ServerNotifications.Web/Local.config.sample` and rename it to
   `ServerNotifications.Web/Local.config`.

1. Open `ServerNotifications.Web/Local.config` and update the following keys:
   ```
   <appSettings>
     <add key="TwilioAccountSid" value="TWILIO_ACCOUNT_SID"/>
     <add key="TwilioAuthToken" value="TWILIO_AUTH_TOKEN"/>
     <add key="TwilioPhoneNumber" value="TWILIO_PHONE_NUMBER"/>
   </appSettings>
   ```

   You can find your Twilio credentials _Account SID_ and _Auth Token_ at
   https://www.twilio.com/user/account/settings

   Also, you can find a _Twilio Phone Number_ at
   https://www.twilio.com/user/account/phone-numbers/incoming

1. Open `ServerNotifications.Web/App_Data/administrators.csv` and update the the
   list of administrators accordingly to your requirements.

1. Build the solution and run the web project. You'll receive a text shortly with details on the exception.

   That's it!


## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](LICENSE)
* Lovingly crafted by Twilio Developer Education.