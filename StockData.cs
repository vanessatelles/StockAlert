using System;
using System.Collections.Generic;
using System.Runtime;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       WebClient wc = new WebClient();
       
        public void GetData()
        {
            var response = wc.DownloadString("https://api.twelvedata.com/time_series?symbol=PETR4&interval=15min&outputsize=1&apikey=apiKey");
            var timeSeries = JsonSerializer.Deserialize<TimeSeries>(response);
            if (timeSeries.status == "ok")
            {
                Console.WriteLine("Received symbol: " + timeSeries.meta["symbol"] + ", close: " + timeSeries.values[0]["close"]);
            }
        }
    }
}
