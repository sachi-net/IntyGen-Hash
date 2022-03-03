using HashGeneratorLibrary.MessageCollection;
using HashGeneratorLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashGeneratorLibrary
{
    /// <summary>
    /// MD5 cryptographic service for generating hashes or comparing intergrities.
    /// </summary>
    public class MD5Processor : ICryptoProcessor
    {
        /// <summary>
        /// Calculates the MD5 hash from given buffer array.
        /// </summary>
        /// <param name="buffer">Data buffer array.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated MD5 hash string.</returns>
        /// <exception cref="ArgumentNullException">Throws when buffer is not set.</exception>
        public string CalculateHash(byte[] buffer, bool useByteSeperator = false)
        {
            if (buffer is null)
            {
                throw new ArgumentNullException(nameof(buffer), ApplicationMessage.BUFFER_NOT_SET);
            }

            string output;

            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(buffer);
                output = BitConverter.ToString(hash);
            }

            return useByteSeperator ? output : output.Replace("-", string.Empty);
        }

        /// <summary>
        /// Calculates the MD5 hash from given data stream.
        /// </summary>
        /// <param name="dataStream">Data stream.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated MD5 hash string.</returns>
        /// <exception cref="ArgumentNullException">Throws when dataStream is not set.</exception>
        public async Task<string> CalculateHash(Stream dataStream, bool useByteSeperator = false)
        {
            if (dataStream is null)
            {
                throw new ArgumentNullException(nameof(dataStream), ApplicationMessage.STREAM_NOT_SET);
            }

            string output;

            using (var md5 = MD5.Create())
            {
                using (dataStream)
                {
                    var hash = await md5.ComputeHashAsync(dataStream);
                    output = BitConverter.ToString(hash);
                }
            }

            return useByteSeperator ? output : output.Replace("-", string.Empty);
        }

        /// <summary>
        /// Calculates the MD5 hash from given CryptoData object.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="data">Crypto data object.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated MD5 hash stored in CryptoData object.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of CryptoData is not set.</exception>
        public async Task<CryptoData<T>> CalculateHash<T>(CryptoData<T> data, bool useByteSeperator = false)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), ApplicationMessage.DATA_NOT_SET);
            }

            if (data.Content is null)
            {
                throw new NullReferenceException(ApplicationMessage.DATA_CONTENT_NOT_SET);
            }

            string outputHash = string.Empty;

            if (typeof(T) == typeof(byte[]))
            {
                outputHash = CalculateHash(data.Content as byte[], useByteSeperator);
            }

            if (typeof(T) == typeof(Stream))
            {
                outputHash = await CalculateHash(data.Content as Stream, useByteSeperator);
            }

            data.Hash = outputHash;
            return data;
        }

        /// <summary>
        /// Calculates the MD5 hashes for each item in given collection of CryptoData objects.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="dataCollection">Collection of CryptoData objects. T is byte[] or Stream.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Update and return the collection of CryptoData with calculated MD5 hashes.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData collection is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of any CryptoData item in the collection is not set.</exception>
        public async Task<IEnumerable<CryptoData<T>>> CalculateHash<T>(IEnumerable<CryptoData<T>> dataCollection, bool useByteSeperator = false)
        {
            if (dataCollection is null)
            {
                throw new ArgumentNullException(nameof(dataCollection), ApplicationMessage.DATA_COLLECTION_NOT_SET);
            }

            List<Task<CryptoData<T>>> dataHashingTasks = new();

            foreach(var data in dataCollection)
            {
                if (data.Content is null)
                {
                    throw new NullReferenceException(ApplicationMessage.DATA_CONTENT_NOT_SET);
                }

                dataHashingTasks.Add(CalculateHash(data, useByteSeperator));
            }

            return await Task.WhenAll(dataHashingTasks);
        }

        /// <summary>
        /// Calculates the MD5 hashes for each item in given collection of CryptoData objects and reports the progress.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="dataCollection">Collection of CryptoData objects. T is byte[] or Stream.</param>
        /// <param name="progress">Progress report to listen on status of completion.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Update and return the collection of CryptoData with calculated MD5 hashes.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData collection is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of any CryptoData item in the collection is not set.</exception>
        public async Task<IEnumerable<CryptoData<T>>> CalculateHash<T>(IEnumerable<CryptoData<T>> dataCollection, IProgress<int> progress, bool useByteSeperator = false)
        {
            if (dataCollection is null)
            {
                throw new ArgumentNullException(nameof(dataCollection), ApplicationMessage.DATA_COLLECTION_NOT_SET);
            }

            List<CryptoData<T>> output = new();

            foreach(var data in dataCollection)
            {
                output.Add(await CalculateHash(data, useByteSeperator));
                
                int percent = output.Count * 100 / dataCollection.Count();
                progress.Report(percent);
            }
            return output;
        }

        /// <summary>
        /// Compare the stream data integrity against the given MD5 checksum.
        /// </summary>
        /// <param name="hash">MD5 checksum string without group seperators.</param>
        /// <param name="dataStream">Data stream.</param>
        /// <returns>Return true if the stream data matches with given MD5 checksum.</returns>
        /// <exception cref="ArgumentNullException">Throws when MD5 hash or datatStream is not set.</exception>
        public async Task<bool> Compare(string hash, Stream dataStream)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException(nameof(hash), ApplicationMessage.HASH_NOT_SET);
            }

            if (dataStream is null)
            {
                throw new ArgumentNullException(nameof(dataStream), ApplicationMessage.STREAM_NOT_SET);
            }

            var outputHash = await CalculateHash(dataStream);
            return outputHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compare the buffer integrity against the given MD5 checksum.
        /// </summary>
        /// <param name="hash">MD5 checksum string without group seperators.</param>
        /// <param name="buffer">Data buffer array.</param>
        /// <returns>Return true if the stream data matches with given MD5 checksum.</returns>
        /// <exception cref="ArgumentNullException">Throws when MD5 hash or buffer is not set.</exception>
        public bool Compare(string hash, byte[] buffer)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException(nameof(hash), ApplicationMessage.HASH_NOT_SET);
            }

            if (buffer is null)
            {
                throw new ArgumentNullException(nameof(buffer), ApplicationMessage.BUFFER_NOT_SET);
            }

            var outputHash = CalculateHash(buffer);
            return outputHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
