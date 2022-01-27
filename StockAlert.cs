using System;
using System.Globalization;

namespace StockAlert
{
    class Principal 
    {
        static void Main(string[] args)
        {
            string _chosenStock = args[0];
            float _salePrice = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
            float _purchasePrice = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat); ;
            Console.Write($"Stock escolhido:\t{_chosenStock}\n" +
                          $"Valor de Venda:\t{_salePrice}\n" +
                          $"Valor de Compra:\t{_purchasePrice}");
        }
    }

}