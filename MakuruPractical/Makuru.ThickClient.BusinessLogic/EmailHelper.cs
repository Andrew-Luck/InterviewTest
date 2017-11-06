using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.ThickClient.BusinessLogic
{
    public static class EmailHelper
    {
        private static Models.Helpers.EmaiSettings emailSettings = null;

        public static bool SendEmail(string message, string subject)
        {
            bool result = true;
            try
            {
                SmtpClient client = new SmtpClient(emailSettings.Server, emailSettings.Port);
                client.EnableSsl = emailSettings.SslEnabled;
                client.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                client.Send(emailSettings.Sender, emailSettings.DefaultRecipients, subject, message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Makuru Exchange Application", ex.Message);
                result = false;
            }
            return result;
        }

        public static void SetEmailSettings(Models.Helpers.EmaiSettings emailSettings)
        {
            EmailHelper.emailSettings = emailSettings;
        }
    }
}
