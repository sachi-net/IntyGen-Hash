using HashGeneratorLibrary;
using IntyGenConsoleUI.UIMessaging;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace IntyGenConsoleUI.UIProcessing
{
    public class HashValidator : IConsoleUIProcessor
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
                Console.Write("Enter hash signature: ");
                var hash = Console.ReadLine();

                FileInfo file = new FileInfo(path);

                if (file.Length >= maxFileSize)
                {
                    throw new FileLoadException(Message.FILE_TOO_LARGE);
                }

                Stream fileStream = File.OpenRead(path);
                bool isMatch = await IsValidFile(hash.Trim().Replace("-", string.Empty), type, fileStream);

                if (isMatch)
                {
                    Message.Show(AlertType.Success, Message.INTEGRITY_VERIFIED);
                }
                else
                {
                    Message.Show(AlertType.Error, Message.INTEGRITY_FAILED);
                }
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

        private async Task<bool> IsValidFile(string hash, string processorType, Stream fileStream)
        {
            try
            {
                processor = HashProcessorController.Initialize(processorType);
                return await processor.Compare(hash, fileStream);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
