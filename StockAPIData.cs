using System.Configuration;
using System.Net;
using System.Text.Json;

namespace StockAlert
{
    public class StockAPIData
    {
        // Fields
        protected string? _endPoint, _apiKey, _stockSymbol;

        // Properties
        public string? price { get; set; }
        public string StockSymbol { get { return _stockSymbol; } set { if (value != null) _stockSymbol = value; } }

        /// <summary>
        /// Initializes a new instance of the StockAPI class by using configuration file settings 
        /// and the API endpoint for real-time data.
        /// </summary>
        public StockAPIData()
        {
            _endPoint = "https://api.twelvedata.com/price?symbol=";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];
        }

        
        WebClient webClient = new WebClient();

 
        /// <summary>
        /// The method downloads and parses the json data from Twelve Data API.
        /// </summary>
        /// <returns>(string) Returns the stock real-time price.</returns>
        protected string DownloadString()
        {
            string response = webClient.DownloadString(_endPoint + _stockSymbol + "&apikey=" + _apiKey);
            StockAPIData stockAPIData = JsonSerializer.Deserialize<StockAPIData>(response);

            if (stockAPIData.price == null)
            {
                Console.WriteLine($"Fail: Error with StockAPI.");
                Environment.Exit(0);
            }

            return stockAPIData.price;

        }
    }

}