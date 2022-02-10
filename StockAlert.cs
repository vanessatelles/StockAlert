using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        private static System.Timers.Timer _timer;
        private static string? _chosenStock;
        private static float _salePrice;
        private static float _purchasePrice;
        

        static void Main(string[] args)
        {
            ArrayInfo(args);

            //Reference values
            SetReferenceValues(args[0], args[1], args[2]);            
                                    
            SetTimer();

            Console.WriteLine("Stock alert fires the event every two minutes. Press the Enter key to exit the application.\n");
            Console.WriteLine($"Stock Alert is current using {_chosenStock} with reference values as: \nSale price: \t{_salePrice}\nPurchase price:\t{_purchasePrice}");
            Console.ReadLine();

            _timer.Stop();
            _timer.Dispose();

            Console.WriteLine("Terminating the application.");
            
        }

        /// <summary>
        /// 
        /// </summary>
        
        private static void ArrayInfo(string[] array)
        {
            if (array.Length != 3)
            {
                Console.WriteLine("Missing argument.");
                Environment.Exit(0);
            }
        }


        private static void SetReferenceValues( string chosenStock, string salePrice, string purchasePrice) 
        {
            _chosenStock = chosenStock;
            _salePrice = float.Parse(salePrice, CultureInfo.InvariantCulture.NumberFormat);
            _purchasePrice = float.Parse(purchasePrice, CultureInfo.InvariantCulture.NumberFormat);
        }


        private static void StockValues()
        {
            StockData stockData = new StockData();
            stockData.StockSymbol = _chosenStock;
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