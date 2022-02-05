using System;
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
        string _stock;
        float _salePrice, _purchasePrice;

        public string Stock { get { return _stock; } set { if (value != null) _stock = value; } }
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public float PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }

        WebClient webClient = new WebClient();
        private TimeSeries GetData()
        {
            var response = webClient.DownloadString("https://api.twelvedata.com/time_series?symbol=" + _stock + "&interval=15min&outputsize=1&apikey=apiKey");
            var timeSeries = JsonSerializer.Deserialize<TimeSeries>(response);
            if (timeSeries.status == "ok")
            {
                Console.WriteLine("Received symbol: " + timeSeries.meta["symbol"] + ", close: " + timeSeries.values[0]["close"]);
            }

            return timeSeries;
        }
        
        public void CompareValues()
        {
            TimeSeries timeSeries = GetData();

            if (float.Parse(timeSeries.values[0]["close"], CultureInfo.InvariantCulture.NumberFormat) > _salePrice)
            {
                Console.WriteLine("API value > Sale Price");
                Console.WriteLine(timeSeries.values[0]["close"] + "\t" + _salePrice ) ;
            }
            else if (float.Parse(timeSeries.values[0]["close"], CultureInfo.InvariantCulture.NumberFormat) < _purchasePrice)
            {
                Console.WriteLine("API value < Purchase Price");
                Console.WriteLine(timeSeries.values[0]["close"] + "\t" + _purchasePrice);
            }
            else
            {
                Console.WriteLine( "Valor dentro dos limites.");
            }
        }
    }
}
