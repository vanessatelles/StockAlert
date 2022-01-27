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
            var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            _config.AppSettings.Settings["username"].Value = args[3];
            _config.AppSettings.Settings["password"].Value = args[5];
            _config.Save(ConfigurationSaveMode.Modified);

            EmailMessage msg = new EmailMessage();
            msg.Server = ConfigurationManager.AppSettings["server"];
            msg.Username = ConfigurationManager.AppSettings["username"];
            msg.Sender = msg.Username + "@gmail.com";
            msg.Receiver = args[4] + "@gmail.com";

            /* 
             msg.Password = args[5];*/
            msg.Message = ConfigurationManager.AppSettings["purchase"] + _chosenStock;

            //msg.SendMessage();
            Console.WriteLine($"{msg.Server}\n{msg.Message}\n{msg.Username}\n{msg.Sender}\n{msg.Receiver}");

        }

    }

}