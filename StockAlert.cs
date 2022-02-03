using System;
using System.Configuration;
using System.Globalization;

using System.Timers;

namespace StockAlert
{
    class Principal 
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            //Reference values
            StockData stockData = new StockData();
            stockData.Stock = args[0];
            stockData.SalePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            stockData.PurchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);

            SetTimer();

            Console.WriteLine("Stock alert fires the event every two minutes. Press the Enter key to exit the application.\n");
            Console.WriteLine($"Stock Alert is current using {stockData.Stock} with reference values as: \nSale price: \t{stockData.SalePrice}\nPurchase price:\t{stockData.PurchasePrice}");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
        }
    }

}