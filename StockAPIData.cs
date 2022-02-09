using System;
using System.Configuration;
using System.Net;
using System.Text.Json;

namespace StockAlert
{
    public class StockAPIData
    {
        public string? _endPoint, _apiKey, _stockSymbol;

        // Properties
        public string? price { get; set; }        
        public string StockSymbol { get { return _stockSymbol; } set { if (value != null) _stockSymbol = value; } }

        WebClient webClient = new WebClient();

        public StockAPIData()
        {
            _endPoint = "https://api.twelvedata.com/price?symbol=";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];
        }
                

        public StockAPIData DownloadString()
        {
            string response = webClient.DownloadString(_endPoint + _stockSymbol + "&apikey=" + _apiKey);
            StockAPIData stockAPIData = JsonSerializer.Deserialize<StockAPIData>(response);
            //Console.WriteLine($"Price: {stockAPIData.price}");

            return stockAPIData;

        }
    }
}
