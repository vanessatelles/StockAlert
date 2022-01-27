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
            float _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            float _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);
            
            var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            _config.AppSettings.Settings["username"].Value = args[3];
            _config.AppSettings.Settings["receiver"].Value = args[4];
            _config.AppSettings.Settings["password"].Value = args[5];
            _config.Save(ConfigurationSaveMode.Modified);

            EmailMessage msg = new EmailMessage();
            msg.Username = ConfigurationManager.AppSettings["username"];
            msg.Password = ConfigurationManager.AppSettings["password"];
            msg.Sender = msg.Username + "@gmail.com";
            msg.Receiver = ConfigurationManager.AppSettings["receiver"] + "@gmail.com";

            msg.Message = ConfigurationManager.AppSettings["purchase"] + _chosenStock;

            Console.WriteLine(msg.Receiver);

            //msg.SendMessage();

        }

    }

}