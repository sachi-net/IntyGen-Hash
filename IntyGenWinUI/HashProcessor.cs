using HashGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntyGenWinUI
{
    public static class HashProcessor
    {
        public static ICryptoProcessor Initialize(string hashType)
        {
            ICryptoProcessor processor;

            switch (hashType.Trim().ToLower())
            {
                case "md5": processor = new MD5Processor(); break;
                case "sha1": processor = new SHA1Processor(); break;
                case "sha256": processor = new SHA256Processor(); break;
                default: throw new ArgumentException("Invalid hash initializing.", nameof(hashType));
            }

            return processor;
        }
    }
}
