using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using ErrorService.Repositories;
using Twilio.TwiML.Voice;

namespace ErrorService
{
    public partial class ErrorService : ServiceBase
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static int _intervalInMinutes;
        private string _smsReciver;
        private Sms _sms;
        private readonly Timer _timer = new Timer(_intervalInMinutes * 60000);
        private readonly ErrorRepository _errorRepository = new ErrorRepository();
        public ErrorService()
        {
            InitializeComponent();
            try
            {
                _intervalInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalInMinutes"]);
                _smsReciver = ConfigurationManager.AppSettings["ReciverPhoneNumber"];

                  _sms = new Sms(new SmsParams
                {
                    ReciverPhoneNumber = ConfigurationManager.AppSettings["ReciverPhoneNumber"],
                    TwilloAuthenticatorToken = ConfigurationManager.AppSettings["TwilloAuthenticatorToken"],
                    TwilloAccountSid = ConfigurationManager.AppSettings["TwilloAccountSid"],
                    SenderName = ConfigurationManager.AppSettings["SenderName"],
                    TwilloPhoneNnumber = ConfigurationManager.AppSettings["TwilloPhoneNnumber"],
                }); 

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
       

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
            Logger.Info("Service started...");
        }

      
        private async void DoWork(object sender, ElapsedEventArgs e)
        {


            await SendError();

        }
        private async Task SendError()
        {
            var errors = _errorRepository.GetLastErrors(_intervalInMinutes);

            if (errors == null || !errors.Any())
                return;
            ToSmsContent

            Logger.Info("Error sent.");

        }
        protected override void OnStop()
        {
            Logger.Info("Service stopped...");
        }
    }
}
