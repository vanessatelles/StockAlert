using System;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace StockAlert
{
    public class EmailMessage
    {
        string _server, _sender, _receiver, _username, _password, _message;

        public String Server { get; set; }

        public String Sender { get; set; }

        public String Receiver { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public String Message { get; set; }
    }
}
