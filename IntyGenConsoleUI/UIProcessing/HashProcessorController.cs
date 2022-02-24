using HashGeneratorLibrary;
using IntyGenConsoleUI.UIMessaging;
using System;

namespace IntyGenConsoleUI.UIProcessing
{
    static class HashProcessorController
    {
        public static ICryptoProcessor Initialize(string processorType)
        {
            ICryptoProcessor processor;

            switch (processorType.Trim().ToLower())
            {
                case "md5": processor = new MD5Processor(); break;
                case "sha1": processor = new SHA1Processor(); break;
                case "sha256": processor = new SHA256Processor(); break;
                default: throw new ArgumentException(Message.INVALID_HASH_TYPE, nameof(processorType));
            }

            return processor;
        }
    }
}
