using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ErrorService
{
    internal static class Program
    {
        static void Main(string[] args)
        {
     

            if (Environment.UserInteractive)
            {
                var parametr = string.Concat(args);
                switch (parametr)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[]
                        {Assembly.GetExecutingAssembly().Location});
                        break;
                    case "--unistall":
                        ManagedInstallerClass.InstallHelper(new[]
                        {"/u", Assembly.GetExecutingAssembly().Location});
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ErrorService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

