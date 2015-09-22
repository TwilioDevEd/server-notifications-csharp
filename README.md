# Server Notifications on ASP.NET MVC

[![Build
status](https://ci.appveyor.com/api/projects/status/s4edbvaqo9yv64o8/branch/master?svg=true)](https://ci.appveyor.com/project/acamino/server-notifications-csharp/branch/master)

<a href="http://howtodocs.s3.amazonaws.com/server-notifications-notification.png"
   target="_blank">
  <img src="http://howtodocs.s3.amazonaws.com/server-notifications-notification.png"
       alt="Notification on phone" width="60%" />
</a>

Use Twilio to create sms server alerts so that you never miss a critical server
issue.

### Local development

1. First clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/server-notifications-csharp.git

   cd server-notifications-csharp
   ```

2. Create a copy of `ServerNotifications.Web/Web.config.sample` and rename it to
   `ServerNotifications.Web/Web.config`.

3. Open `ServerNotifications.Web/Web.config` and update the following keys:
   ```
   <appSettings>
     <!-- omitted for clarity -->
     <add key="TwilioAccountSid" value="TWILIO_ACCOUNT_SID"/>
     <add key="TwilioAuthToken" value="TWILIO_AUTH_TOKEN"/>
     <add key="TwilioPhoneNumber" value="TWILIO_PHONE_NUMBER"/>
   </appSettings>
   ```

   You can find your Twilio credentials _Account SID_ and _Auth Token_ at
   https://www.twilio.com/user/account/settings

   Also, you can find a _Twilio Phone Number_ at
   https://www.twilio.com/user/account/phone-numbers/incoming

4. Open `ServerNotifications.Web/App_Data/administrators.csv` and update the the
   list of administrators accordingly to your requirements.

5. Build the solution.

   That's it!
