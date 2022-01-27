using System;
using System.Configuration;
using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        static void Main(string[] args)
        {
            string _chosenStock = args[0];
            string _actionMessage;
            float _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            float _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);

            _actionMessage = ConfigurationManager.AppSettings["sale"];
            Console.Write($"{_actionMessage}{_chosenStock}");
        }          

    }

}