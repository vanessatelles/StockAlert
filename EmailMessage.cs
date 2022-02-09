using System.Net.Mail;
using System.Configuration;

namespace StockAlert
{
    public class EmailMessage
    {
        // Field
        private string? _server, _port, _sender, _receiver, _username, _password, _message;        
        
        // Properties
        public string Message { get { return _message; } set { if (value != null) _message = value; } }
      
        MailMessage mail = new MailMessage();

        public EmailMessage()
        {
            _server = ConfigurationManager.AppSettings["server"];
            _port = ConfigurationManager.AppSettings["port"];
            _sender = ConfigurationManager.AppSettings["sender"];
            _receiver = ConfigurationManager.AppSettings["receiver"];
            _username = ConfigurationManager.AppSettings["username"];
            _password = ConfigurationManager.AppSettings["password"];            
        }


        private SmtpClient ServerConnection()
        {
            SmtpClient smtpServer = new SmtpClient(_server);

            mail.From = new MailAddress(_sender);
            mail.To.Add(_receiver);
            smtpServer.Port = Int32.Parse(_port);
            smtpServer.Credentials = new System.Net.NetworkCredential(_username, _password);
            smtpServer.EnableSsl = true;

            return smtpServer;
        }


        public void SendMessage()
        {
            SmtpClient smtpServer = ServerConnection();

            mail.Subject = "Stock Alert";
            mail.Body = _message;
            smtpServer.Send(mail);
        }
    }
}
