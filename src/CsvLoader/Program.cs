namespace CsvLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using CsvLoader.Models;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static IConfiguration Configuration;

        public static void Main(string[] args)
        {
            Task.Run(() => Start(args));
            Console.Read();
        }

        public static async Task Start(string[] args)
        {
            string filePath = args.Length > 0 ? args[0] : string.Empty;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Invalid Path");
                return;
            }

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
            string connectionstring = Configuration["ConnectionString"];
            
            try
            {
                IList<BigStorage> bigStorageList = await FileReader.CsvReader(filePath, new LineParser()).ConfigureAwait(false);
                await BulkInsert.InsertRecordsSqlBulkCopy(connectionstring, bigStorageList);
                Console.WriteLine("CSV Uploaded to DB!");
                Console.WriteLine("Press enter to end! :)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}