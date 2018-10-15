namespace CsvLoader
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
            
            Stopwatch stopWatch = Stopwatch.StartNew();

            try
            {
                IList<BigStorage> bigStorageList = await FileReader.CsvReader(filePath, new LineParser()).ConfigureAwait(false);
                await BulkInsert.InsertRecordsSqlBulkCopy(connectionstring, bigStorageList);
                Console.WriteLine("CSV Uploaded to DB!");
                Console.WriteLine("It's fast!");
                Console.WriteLine(":)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Are you sure about the ConnectionString?");
                Console.WriteLine(":(");
            }
            finally
            {
                stopWatch.Stop();
                Console.WriteLine("Elapsed time {0} ms", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("Press enter to end!");
            }
        }
    }
}