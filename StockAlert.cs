using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        private static System.Timers.Timer _timer;
        private static string _choosenStock;
        private static float _salePrice;
        private static float _purchasePrice;
        
        static void Main(string[] args)
        {
            //Reference values            
            _choosenStock = args[0];
            _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);

            
            SetTimer();

            Console.WriteLine("Stock alert fires the event every two minutes. Press the Enter key to exit the application.\n");
            Console.WriteLine($"Stock Alert is current using {_choosenStock} with reference values as: \nSale price: \t{_salePrice}\nPurchase price:\t{_purchasePrice}");
            Console.ReadLine();

            _timer.Stop();
            _timer.Dispose();

            Console.WriteLine("Terminating the application.");
            
        }

        /// <summary>
        /// 
        /// </summary>
        private static void StockValues()
        {
            StockData stockData = new StockData();
            stockData.Stock = _choosenStock;
            stockData.PurchasePrice = _purchasePrice;
            stockData.SalePrice = _salePrice;
            stockData.CompareValues();
        }

        
        private static void SetTimer()
        {
            _timer = new System.Timers.Timer(30000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }


        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            StockValues();
        }
    }

}