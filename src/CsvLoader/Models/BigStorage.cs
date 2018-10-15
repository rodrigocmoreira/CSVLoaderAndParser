namespace CsvLoader.Models
{
    using System;

    public class BigStorage
    {
        public long RecordId { get; set; }
        public string ShopCode { get; set; }
        public int ItemId  { get; set; }
        public string ItemName  { get; set; }
        public decimal PricePerItem { get; set; }
        public int CountOfIems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}