using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorService
{
    public class SmsParams
    {
        public string TwilloPhoneNnumber { get; set; }
        public string ReciverPhoneNumber { get; set; }
        public string TwilloAccountSid { get; set; }
        public string TwilloAuthenticatorToken { get; set; }
        public string SenderName { get; set; }
    }
}
