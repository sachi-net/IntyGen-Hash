using HashGeneratorLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HashGeneratorLibrary
{
    /// <summary>
    /// Cryptographic service for generating hashes or comparing intergrities.
    /// </summary>
    public interface ICryptoProcessor
    {
        /// <summary>
        /// Calculates the hash from given buffer array.
        /// </summary>
        /// <param name="buffer">Data buffer array.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated hash string.</returns>
        /// <exception cref="ArgumentNullException">Throws when buffer is not set.</exception>
        string CalculateHash(byte[] buffer, bool useByteSeperator = false);

        /// <summary>
        /// Calculates the hash from given data stream.
        /// </summary>
        /// <param name="dataStream">Data stream.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated hash string.</returns>
        /// <exception cref="ArgumentNullException">Throws when dataStream is not set.</exception>
        Task<string> CalculateHash(Stream dataStream, bool useByteSeperator = false);

        /// <summary>
        /// Calculates the hash from given CryptoData object.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="data">Crypto data object.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Calculated hash stored in CryptoData object.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of CryptoData is not set.</exception>
        Task<CryptoData<T>> CalculateHash<T>(CryptoData<T> data, bool useByteSeperator = false);

        /// <summary>
        /// Calculates the hashes for each item in given collection of CryptoData objects.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="dataCollection">Collection of CryptoData objects. T is byte[] or Stream.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Update and return the collection of CryptoData with calculated hashes.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData collection is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of any CryptoData item in the collection is not set.</exception>
        Task<IEnumerable<CryptoData<T>>> CalculateHash<T>(IEnumerable<CryptoData<T>> dataCollection, bool useByteSeperator = false);

        /// <summary>
        /// Calculates the hashes for each item in given collection of CryptoData objects and reports the progress.
        /// </summary>
        /// <typeparam name="T">T is byte[] or Stream.</typeparam>
        /// <param name="dataCollection">Collection of CryptoData objects. T is byte[] or Stream.</param>
        /// <param name="progress">Progress report to listen on status of completion.</param>
        /// <param name="useByteSeperator">Whether to group the hash string by bytes with dashes.</param>
        /// <returns>Update and return the collection of CryptoData with calculated hashes.</returns>
        /// <exception cref="ArgumentNullException">Throws when CryptoData collection is not set.</exception>
        /// <exception cref="NullReferenceException">Throws when Content of any CryptoData item in the collection is not set.</exception>
        Task<IEnumerable<CryptoData<T>>> CalculateHash<T>(IEnumerable<CryptoData<T>> dataCollection, IProgress<int> progress, bool useByteSeperator = false);

        /// <summary>
        /// Compare the stream data integrity against the given checksum.
        /// </summary>
        /// <param name="hash">Checksum string without group seperators.</param>
        /// <param name="dataStream">Data stream.</param>
        /// <returns>Return true if the stream data matches with given checksum.</returns>
        /// <exception cref="ArgumentNullException">Throws when hash or datatStream is not set.</exception>
        Task<bool> Compare(string hash, Stream dataStream);

        /// <summary>
        /// Compare the buffer integrity against the given checksum.
        /// </summary>
        /// <param name="hash">Checksum string without group seperators.</param>
        /// <param name="buffer">Data buffer array.</param>
        /// <returns>Return true if the stream data matches with given checksum.</returns>
        /// <exception cref="ArgumentNullException">Throws when hash or buffer is not set.</exception>
        bool Compare(string hash, byte[] buffer);
    }
}