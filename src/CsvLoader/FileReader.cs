namespace CsvLoader
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using CsvLoader.Models;

    public class FileReader
    {
        public static Task<IList<BigStorage>> CsvReader(string filePath, LineParser parser)
        {
            using (var reader = new StreamReader(filePath))
            {
                IList<BigStorage> listBigStorage = new List<BigStorage>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    listBigStorage.Add(parser.ParseToBigStorage(line)); 
                }

                return Task.Run(() => listBigStorage);
            }
        }
    }
}