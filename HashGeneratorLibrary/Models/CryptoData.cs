using HashGeneratorLibrary.MessageCollection;
using System;
using System.IO;

namespace HashGeneratorLibrary.Models
{
    /// <summary>
    /// Crypto Data object with identifer and stream or buffer content.
    /// </summary>
    public class CryptoData<T>
    {
        /// <summary>
        /// Unique key value for data stream or buffer identifier.
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// Hash value calculated for the Crypto Data content.
        /// </summary>
        public string Hash { get; internal set; }

        /// <summary>
        /// Data content to calculate hash signature. T is byte[] or Stream.
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// Initialize Crypto Data object with content type T.
        /// </summary>
        /// <param name="dataKey">Data key identifier.</param>
        /// <param name="content">Data content. T is byte[] or Stream.</param>
        /// <exception cref="ArgumentNullException">Throws when dataKey and content is not set.</exception>
        /// <exception cref="TypeAccessException">Throws when type T is not byte[] or Stream.</exception>
        public CryptoData(string dataKey, T content)
        {
            if (string.IsNullOrEmpty(dataKey))
            {
                throw new ArgumentNullException(nameof(dataKey), ApplicationMessage.DATAKEY_NOT_SET);
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content), ApplicationMessage.CONTENT_NOT_SET);
            }

            if (typeof(T) == typeof(byte[]) || typeof(T) == typeof(Stream))
            {
                DataKey = dataKey;
                Content = content;
            }
            else
            {
                throw new TypeAccessException(ApplicationMessage.INVALID_TYPE);
            }
        }
    }
}
