namespace HashGeneratorLibrary.MessageCollection
{
    internal static class ApplicationMessage
    {
        internal const string BUFFER_NOT_SET = "Buffer is null or not set.";
        internal const string STREAM_NOT_SET = "Data stream is null or empty.";
        internal const string HASH_NOT_SET = "Hash is null or empty.";
        internal const string DATAKEY_NOT_SET = "Data key is null or empty.";
        internal const string CONTENT_NOT_SET = "Stream or buffer content is null or not set";
        internal const string DATA_NOT_SET = "Crypto data is null or not set.";
        internal const string DATA_COLLECTION_NOT_SET = "Crypto data collection is null or empty.";
        internal const string DATA_CONTENT_NOT_SET = "One or more data contents have not set in the collection.";
        internal const string INVALID_TYPE = "Invalid data or parameter type.";
        internal const string FILE_TOO_LARGE = "File too large to process.";
    }
}
