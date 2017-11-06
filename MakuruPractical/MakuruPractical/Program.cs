using Makuru.Models.Helpers;
using Makuru.ThickClient.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakuruPractical
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            setEmailSettings();
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CurrencyPurchase());
            }
            catch (EntryPointNotFoundException epnfEx)
            {
                MessageBox.Show("Please check the API end point, the application cannot connect.\nThe application will close.", "API Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("An error occured while starting the application, the error is: {0}.\nThe application will close.", e.ExceptionObject), "API Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void setEmailSettings()
        {
            EmaiSettings settings = new EmaiSettings();
            settings.DefaultRecipients = Properties.Settings.Default.EmailDefaultRecipients;
            settings.Password = Properties.Settings.Default.EmailPassword;
            settings.Port = Properties.Settings.Default.EmailPort;
            settings.Sender = Properties.Settings.Default.EmailSender;
            settings.Server = Properties.Settings.Default.EmailServer;
            settings.SslEnabled = Properties.Settings.Default.EmailSslEnabled;
            settings.Username = Properties.Settings.Default.EmailUsername;

            EmailHelper.SetEmailSettings(settings);
        }
    }
}
