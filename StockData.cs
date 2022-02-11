
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
            StockAPIData stockAPIData = DownloadString();            

            if (float.Parse(stockAPIData.price, CultureInfo.InvariantCulture.NumberFormat) > _salePrice)
            {
                CallMessenger("Sell");
            }
            else if (float.Parse(stockAPIData.price, CultureInfo.InvariantCulture.NumberFormat) < _purchasePrice)
            {
                CallMessenger("Buy");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now.ToString("h:mm:ss")} - No action needed.");
            }
        }

        
        private void CallMessenger(string message)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = $"{DateTime.Now.ToString("h:mm:ss")} - Sugestion: {message} {_stockSymbol}";
            emailMessage.SendMessage();

            Console.WriteLine(emailMessage.Message);
        }
    }
}
