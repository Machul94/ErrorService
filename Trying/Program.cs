using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

using System.Threading.Tasks;

namespace Trying
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine(message.Sid);
        }
    }
}
