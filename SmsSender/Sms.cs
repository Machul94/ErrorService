using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SmsSender
{
    class Sms
    {
        private int _reciverPhoneNumber;
        private string _twilloAuthenticatorToken;
        private string _twilloAccountSid;
        private string _twilloPhoneNnumber;
        private string _senderName;
        public Sms(SmsParams smsParams)
        {
            _reciverPhoneNumber = smsParams.ReciverPhoneNumber;
            _twilloAuthenticatorToken = smsParams.TwilloAuthenticatorToken;
            _twilloAccountSid = smsParams.TwilloAccountSid;
            _twilloPhoneNnumber = smsParams.TwilloPhoneNnumber;
            _senderName = smsParams.SenderName;
        } 
        static void SmsSend()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("twiliosid");
            string authToken = Environment.GetEnvironmentVariable("twilioauth");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Testing",
                from: new Twilio.Types.PhoneNumber("+17207825902"),
                to: new Twilio.Types.PhoneNumber("+48734440416")
            );

        }
    }
}
