using System;
using System.Configuration;
using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        static void Main(string[] args)
        {
            string _chosenStock = args[0];
            string _actionMessage;
            float _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            float _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);            

            EmailMessage msg = new EmailMessage();
            msg.Server = "smtp.gmail.com";
            msg.Username = args[3];
            msg.Sender = msg.Username + "@gmail.com";
            msg.Receiver = args[4] + "@gmail.com";            
            msg.Password = args[5];
            msg.Message = ConfigurationManager.AppSettings["purchase"] + _chosenStock;

            msg.SendMessage();
            Console.WriteLine($"{msg.Server}\n{msg.Sender}\n{msg.Receiver}\n{msg.Username}\n{msg.Password}\n{msg.Message}");

        }

    }

}