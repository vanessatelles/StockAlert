using System;
using System.Configuration;
using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        static void Main(string[] args)
        {
            //Reference values
            string _chosenStock = args[0];
            float _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            float _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);            
                        
            EmailMessage msg = new EmailMessage();
            msg.Message = ConfigurationManager.AppSettings["sale"] + _chosenStock;

            StockData stockData = new StockData();
            stockData.Stock = _chosenStock;
            stockData.SalePrice = _salePrice;
            stockData.PurchasePrice = _purchasePrice;
            //stockData.CompareValues();

            //msg.SendMessage();
           // Console.WriteLine(stockData.Stock);

        }
    }

}