using HashGeneratorLibrary;
using IntyGenConsoleUI.UIMessaging;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace IntyGenConsoleUI.UIProcessing
{
    public class SingleHashProcessor : IConsoleUIProcessor
    {
        private ICryptoProcessor processor;
        private NameValueCollection config = ConfigurationManager.AppSettings;

        public async Task Start()
        {
            long maxFileSize = Convert.ToInt64(config["maxFileSize"]);

            try
            {
                Console.WriteLine("\n");
                Console.Write("Enter file path: ");
                var path = Console.ReadLine();
                Console.Write("Enter hash type: ");
                var type = Console.ReadLine();

                FileInfo file = new FileInfo(path);

                if (file.Length >= maxFileSize)
                {
                    throw new FileLoadException(Message.FILE_TOO_LARGE);
                }

                Stream fileStream = File.OpenRead(path);
                var output = await CalculateFileHash(fileStream, type);
                Message.Show(AlertType.Success, output);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(Message.DIRECTORY_NOT_FOUND);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(Message.FILE_NOT_FOUND);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> CalculateFileHash(Stream fileStream, string processorType)
        {
            try
            {
                processor = HashProcessorController.Initialize(processorType);
                return await processor.CalculateHash(fileStream, useByteSeperator: true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
