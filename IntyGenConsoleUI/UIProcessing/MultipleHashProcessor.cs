using HashGeneratorLibrary;
using HashGeneratorLibrary.Models;
using IntyGenConsoleUI.UIMessaging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntyGenConsoleUI.UIProcessing
{
    public class MultipleHashProcessor : IConsoleUIProcessor
    {
        private ICryptoProcessor processor;
        private NameValueCollection config = ConfigurationManager.AppSettings;

        public async Task Start()
        {
            try
            {
                Console.WriteLine("\n");
                Console.Write("Enter folder path: ");
                var path = Console.ReadLine();
                Console.Write("Enter hash type: ");
                var type = Console.ReadLine();
                Console.Write("Skip large files (Y/N): ");
                var skip = Console.ReadLine().ToLower();

                bool skipLargeFiles = skip.Trim()[0].Equals('y') ? true :
                    skip.Trim()[0].Equals('n') ? false : throw new ArgumentException(Message.INVALID_OPTION);

                var fileInfoCollection = new DirectoryInfo(path).GetFiles().ToList();
                var output = (await CalculateAllFileHashes(fileInfoCollection, type, skipLargeFiles)).ToList();
                DisplayResult(output);
                Message.Show(AlertType.Information, ($"\n{output.Count}/{fileInfoCollection.Count} file(s) processed."));
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(Message.DIRECTORY_NOT_FOUND);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<CryptoData<Stream>>> CalculateAllFileHashes(List<FileInfo> fileInfoCollection, 
            string processorType, bool skipLargeFiles = true)
        {
            long maxFileSize = Convert.ToInt64(config["maxFileSize"]);
            try
            {
                List<CryptoData<Stream>> fileData = new();

                if (!skipLargeFiles && fileInfoCollection.Any(f => f.Length >= maxFileSize))
                {
                    throw new FileLoadException(Message.MORE_LARGE_FILES);
                }

                var files = fileInfoCollection.Where(f => f.Length < maxFileSize);
                foreach (var file in files)
                {
                    CryptoData<Stream> data = new(file.Name, File.OpenRead(file.FullName));
                    fileData.Add(data);
                }

                processor = HashProcessorController.Initialize(processorType);
                await processor.CalculateHash(fileData, useByteSeperator: false);

                return fileData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DisplayResult<T>(IEnumerable<CryptoData<T>> dataCollection)
        {
            foreach(var data in dataCollection)
            {
                Message.Show(AlertType.Success, $"Hash: {data.Hash} \t Key: {data.DataKey}");
            }
        }
    }
}
