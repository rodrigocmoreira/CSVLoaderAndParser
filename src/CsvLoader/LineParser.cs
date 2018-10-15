namespace CsvLoader
{
    using System;
    using System.Globalization;

    using CsvLoader.Models;

    public class LineParser
    {
        public BigStorage ParseToBigStorage(string line)
        {
            string[] values = line.Split(',');

            string shopCode = values[0];

            switch (shopCode)
            {
                case "AAA":
                    return new BigStorage
                    {
                        ShopCode = shopCode,
                        ItemId = int.Parse(values[1]),
                        ItemName = values[2],
                        PricePerItem = decimal.Parse(values[4], new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        CountOfIems = int.Parse(values[5]),
                        TransactionDate = DateTime.Parse(values[6]),
                        TotalPrice = decimal.Parse(values[7], new NumberFormatInfo() { NumberDecimalSeparator = "." })
                    };
                case "BBB":
                    return new BigStorage
                    {
                        ShopCode = shopCode,
                        ItemId = int.Parse(values[4]),
                        ItemName = values[2],
                        PricePerItem = decimal.Parse(values[5], new NumberFormatInfo() { NumberDecimalSeparator = "." }),
                        CountOfIems = int.Parse(values[6]),
                        TransactionDate = DateTime.Parse($"{values[1]} {values[3]}"),
                        TotalPrice = decimal.Parse(values[7], new NumberFormatInfo() { NumberDecimalSeparator = "." })
                    };
                default: return new BigStorage();
            }
        }
    }
}