using StockAlert;
using System.Globalization;

namespace StockAlert
{
    class StockAlert 
    {
        private System.Timers.Timer _timerCounter;
        private string? _chosenStock;
        private float _salePrice;
        private float _purchasePrice;


        static void Main(string[] args)
        {
            StockAlert stockAlert = new StockAlert(); 

            stockAlert.ArgumentCheck(args);
            stockAlert.SetReferenceValues(args[0], args[1], args[2]);       
            stockAlert.SetTimer();

            Console.WriteLine("Stock alert fires the event every two minutes. Press the Enter key to exit the application.\n");
            Console.WriteLine($"Stock Alert is current using {stockAlert._chosenStock} with reference values as: \nSale price: \t{stockAlert._salePrice}\nPurchase price:\t{stockAlert._purchasePrice}");
            Console.ReadLine();

            stockAlert._timerCounter.Stop();
            stockAlert._timerCounter.Dispose();

            Console.WriteLine("Terminating the application.");
        }


        /// <summary>
        /// If the array's length is less than 3 it means one or more arguments are missing.
        /// If the array's length is greater than 3 it means it has too many arguments.
        /// </summary>
        /// <param name="array">(string[]) Array with the reference arguments.</param>
        private void ArgumentCheck(string[] array)
        {
            if (array.Length < 3)
            {
                Console.WriteLine("Fail: Missing argument.");
                Environment.Exit(0);
            }
            if (array.Length > 3)
            {
                Console.WriteLine("Fail: Too many argument.");
                Environment.Exit(0);
            }
        }

        
        /// <summary>
        /// Set the arguments passed by the user as reference values.
        /// </summary>
        /// <param name="chosenStock">(string) Stock's label.</param>
        /// <param name="salePrice">(float) Stock's sale price.</param>
        /// <param name="purchasePrice">(float) Stock's purchase price.</param>
        private void SetReferenceValues(string chosenStock, string salePrice, string purchasePrice)
        {
            _chosenStock = chosenStock;
            _salePrice = float.Parse(salePrice, CultureInfo.InvariantCulture.NumberFormat);
            _purchasePrice = float.Parse(purchasePrice, CultureInfo.InvariantCulture.NumberFormat);
        }


        /// <summary>
        /// It fires OnTimedEvent event every two minutes (120000 milliseconds).
        /// </summary>
        private void SetTimer()
        {
            _timerCounter = new System.Timers.Timer(120000);
            _timerCounter.Elapsed += OnTimedEvent;
            _timerCounter.AutoReset = true;
            _timerCounter.Enabled = true;
        }


        /// <summary>
        /// The method creates an instance of StockData, assigns it the reference values, 
        /// and calls the CompareValues method.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            StockData stockData = new StockData();
            stockData.StockSymbol = _chosenStock;
            stockData.PurchasePrice = _purchasePrice;
            stockData.SalePrice = _salePrice;
            stockData.CompareValues();
        }
    }

}
