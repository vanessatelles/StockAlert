﻿using System.Configuration;
using System.Net;
using System.Text.Json;

namespace StockAlert
{
    public class StockAPIData
    {
        // Fields
        public string? _endPoint, _apiKey, _stockSymbol;

        // Properties
        public string? price { get; set; }
        public string StockSymbol { get { return _stockSymbol; } set { if (value != null) _stockSymbol = value; } }

        // TODO comment
        public StockAPIData()
        {
            _endPoint = "https://api.twelvedata.com/price?symbol=";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];
        }

        
        WebClient webClient = new WebClient();

        // TODO return....
        /// <summary>
        /// The method downloads and parses the json data from Twelve Data API.
        /// </summary>
        /// <returns>(stockAPIData) Returns </returns>
        public string DownloadString()
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