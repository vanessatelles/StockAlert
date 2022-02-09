
using System.Globalization;

namespace StockAlert
{
    public class StockData : StockAPIData
    {
        // Fields
        private float _salePrice, _purchasePrice;

        // Properties
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public float PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }


        public void CompareValues()
        {
            StockAPIData timeSeries = DownloadString();

            if (float.Parse(timeSeries.price, CultureInfo.InvariantCulture.NumberFormat) > _salePrice)
            {
                CallMessenger("Sell", timeSeries);
                //Console.WriteLine("Sell.");
            }
            else if (float.Parse(timeSeries.price, CultureInfo.InvariantCulture.NumberFormat) < _purchasePrice)
            {
                CallMessenger("Buy", timeSeries);
                //Console.WriteLine("Buy.");
            }
            else
            {
                Console.WriteLine("No action needed.");
            }
        }

        
        private void CallMessenger(string message, StockAPIData timeSeries)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = $"Sugestion: {message} {_stockSymbol}";
            emailMessage.SendMessage();
            Console.WriteLine(emailMessage.Message);
        }
    }
}
