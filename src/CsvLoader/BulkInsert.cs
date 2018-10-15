namespace CsvLoader
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using CsvLoader.Models;
    using FastMember;

    public class BulkInsert
    {
        public static async Task InsertRecordsSqlBulkCopy(string connectionstring, IList<BigStorage> bigStorageList)
        {
            var copyParameters = new[]
                                     {
                                         nameof(BigStorage.RecordId),
                                         nameof(BigStorage.ShopCode),
                                         nameof(BigStorage.ItemId),
                                         nameof(BigStorage.ItemName),
                                         nameof(BigStorage.PricePerItem),
                                         nameof(BigStorage.CountOfIems),
                                         nameof(BigStorage.TotalPrice),
                                         nameof(BigStorage.TransactionDate)
                                     };

            using (var sqlcopy = new SqlBulkCopy(connectionstring))
            {
                sqlcopy.BatchSize = 500;
                sqlcopy.DestinationTableName = "[theBigStorage]";
                using (ObjectReader reader = ObjectReader.Create(bigStorageList, copyParameters))
                {
                    await sqlcopy.WriteToServerAsync(reader);
                }
            }
        }
    }
}