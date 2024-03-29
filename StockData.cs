﻿using System.Globalization;

namespace StockAlert
{
    public class StockData : StockAPIData
    {
        // Fields
        private float _salePrice, _purchasePrice;


        // Properties
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public float PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }


        /// <summary>
        /// It makes a comparison between reference values and the real-time data from the API. 
        /// It also defines which, and if, a message should be sent to the users.
        /// </summary>
        public void CompareValues()
        {
            string stockAPIData = DownloadString();            

            if (float.Parse(stockAPIData, CultureInfo.InvariantCulture.NumberFormat) > _salePrice)
            {
                CallMessenger("Sell");
            }
            else if (float.Parse(stockAPIData, CultureInfo.InvariantCulture.NumberFormat) < _purchasePrice)
            {
                CallMessenger("Buy");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now.ToString("h:mm:ss")} - No action needed.");
            }
        }


        /// <summary>
        /// Assemble the message to be sent to the user, it also calls the message sending method. 
        /// </summary>
        /// <param name="message">(string) The "Buy" or "Sell" text.</param>
        private void CallMessenger(string message)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = $"{DateTime.Now.ToString("h:mm:ss")} - Sugestion: {message} {StockSymbol}";
            emailMessage.SendMessage();

            Console.WriteLine(emailMessage.Message);
        }
    }
}