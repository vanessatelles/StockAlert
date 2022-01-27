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
        MailMessage mail = new MailMessage();

        public String Server 
        {
            get { return _server; }
            set { _server = value; }
        }

        public String Sender 
        {
            get { return _sender; }
            set { _sender = value; }
        }

        public String Receiver 
        {
            get { return _receiver; }
            set { _receiver = value; }
        }

        public String Username 
        {
            get { return _username; }
            set { _username = value; }
        }

        public String Password 
        {
            get { return _password; }
            set { _password = value; }
        }

        public String Message 
        {
            get { return _message; }
            set { _message = value; }
        }

        public SmtpClient ServerConnection()
        {
            SmtpClient SmtpServer = new SmtpClient(_server);
            mail.From = new MailAddress(_sender);
            mail.To.Add(_receiver);
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_username, _password);
            SmtpServer.EnableSsl = true;
            return SmtpServer;
        }

        public void SendMessage()
        {
            SmtpClient SmtpServer = ServerConnection();
            mail.Subject = "Stock Alert";
            mail.Body = _message;
            SmtpServer.Send(mail);
        }
    }
}
