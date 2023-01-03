using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ErrorService
{
    public class Sms
    {
        private string _twilloPhoneNnumber;
        private string _reciverPhoneNumber;
        private string _twilloAccountSid;
        private string _twilloAuthenticatorToken;
        private string _senderName;

        public Sms(SmsParams smsParams)
        {
            _twilloPhoneNnumber = smsParams.TwilloPhoneNnumber;
            _reciverPhoneNumber = smsParams.ReciverPhoneNumber;
            _twilloAccountSid = smsParams.TwilloAccountSid;
            _twilloAuthenticatorToken = smsParams.TwilloAuthenticatorToken;
            _senderName = smsParams.SenderName;
        }

        public async Task Send()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("twiliosid");
            string authToken = Environment.GetEnvironmentVariable("twilioauth");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Testing",
                from: new Twilio.Types.PhoneNumber(_twilloPhoneNnumber),
                to: new Twilio.Types.PhoneNumber(_reciverPhoneNumber)
            );


        }
    }
}
