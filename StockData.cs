using System.Net;
using System.Text.Json;
using System.Globalization;

namespace StockAlert
{
    public class TimeSeries
    {
        public Dictionary<string, string> meta { get; set; }
        public IList<Dictionary<string, string>> values { get; set; }
        public string status { get; set; }
    }

    public class StockData
    {
        // Fields
        private string _stock;
        private float _salePrice, _purchasePrice;

        // Properties
        public string Stock { get { return _stock; } set { if (value != null) _stock = value; } }
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public float PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }

        // Object
        WebClient webClient = new WebClient();
        private TimeSeries GetData()
        {
            string response = webClient.DownloadString("https://api.twelvedata.com/time_series?symbol=" + _stock + "&interval=15min&outputsize=1&apikey=apiKey");
            TimeSeries timeSeries = JsonSerializer.Deserialize<TimeSeries>(response);
            

            if (timeSeries.status == "ok")
            {
                Console.WriteLine($"Received symbol:{timeSeries.meta["symbol"]}, close: {timeSeries.values[0]["close"]}");
            }
            else { Console.WriteLine($"StockAPI connection status: {timeSeries.status}");  }

            return timeSeries;
        }
        

        public void CompareValues()
        {
            TimeSeries timeSeries = GetData();

            if (float.Parse(timeSeries.values[0]["close"], CultureInfo.InvariantCulture.NumberFormat) > _salePrice)
            {
                CallMessenger("Sell", timeSeries);
            }
            else if (float.Parse(timeSeries.values[0]["close"], CultureInfo.InvariantCulture.NumberFormat) < _purchasePrice)
            {
                CallMessenger("Buy", timeSeries);
            }
            else
            {
                Console.WriteLine("No action needed.");
            }
        }


        private void CallMessenger(string message, TimeSeries timeSeries)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.Message = $"Sugestion: {message} {timeSeries.meta["symbol"]}";
            emailMessage.SendMessage();
            Console.WriteLine(emailMessage.Message);
        }
    }
}
