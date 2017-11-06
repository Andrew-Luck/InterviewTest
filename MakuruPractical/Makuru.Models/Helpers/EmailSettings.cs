using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.Models.Helpers
{
    public class EmaiSettings
    {
        public string Server { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Sender { get; set; }

        public int Port { get; set; }

        public bool SslEnabled { get; set; }

        public string DefaultRecipients { get; set; }
    }
}
