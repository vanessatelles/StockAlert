using System;
using System.Net.Mail;
using System.Configuration;

namespace StockAlert
{
    public class EmailMessage
    {
        string _server, _sender, _receiver, _username, _password, _message;        
             
        public String Message { get { return _message; } set { if (value != null) _message = value; }}
      
        MailMessage mail = new MailMessage();

        private void SetCredentials()
        {
            _server = ConfigurationManager.AppSettings["server"];
            _sender = ConfigurationManager.AppSettings["sender"];
            _receiver = ConfigurationManager.AppSettings["receiver"];
            _username = ConfigurationManager.AppSettings["username"];
            _password = ConfigurationManager.AppSettings["password"];            
        }
        public SmtpClient ServerConnection()
        {
            SetCredentials();
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
