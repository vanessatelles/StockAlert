using System;
using System.Configuration;
using System.Globalization;

using System.Timers;

namespace StockAlert
{
    class Principal 
    {
        static void Main(string[] args)
        {
            //Reference values
            StockData stockData = new StockData();
            stockData.Stock = args[0];
            stockData.SalePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            stockData.PurchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);            
                        
            EmailMessage message = new EmailMessage();
            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            timer.AutoReset = true;            
            timer.Elapsed += new System.Timers.ElapsedEventHandler(MyMethod);
            timer.Start();
            Console.WriteLine($"Stock alert using {stockData.Stock} with sale price of {stockData.SalePrice} and purchase price of {stockData.PurchasePrice}.");


            //stockData.Test();
            System.Console.ReadKey();
            /*
            for (; ; )
              {                       
                // Keep the console window open in debug mode.
               // Console.WriteLine("Press any key to exit.");
               // System.Console.ReadKey();
            }*/

        }
        public static void MyMethod(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
            //stockData.Test()
        }

    }

}