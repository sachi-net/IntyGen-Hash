using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntyGenWinUI.UIControllers.Validations
{
    public static class MessageTemplates
    {
        private static readonly NameValueCollection _config = ConfigurationManager.AppSettings;

        public static string NO_FILE_SELECTED = "No file selected.";
        public static string NO_FILES_ADDED = "No files added.";
        public static string FILE_TOO_LARGE = $"File too large. Max allowed file size is {RefineMaxFileSize()}";
        public static string DIRECTORY_CONTAINS_LARGE_FILES = $"Directory contains one or more large file(s). Max allowed file size is {RefineMaxFileSize()}.";
        public static string DIRECTORY_IS_EMPTY = "Selected directory is empty.";
        public static string HASH_COPIED = "Hash result copied to clipboard!";
        public static string DASHED_HASH_PREVIEW = "Looks like XX-XX-XX-XX-XX";
        public static string NON_DASHED_HASH_PREVIEW = "Looks like XXXXXXXXXX";
        public static string HASH_IS_EMPTY = "Hash signature cannot be empty.";
        public static string FILE_VERIFIED = "File integrity matches.";
        public static string FILE_NOT_VERIFIED = "File integrity does not match.";
        public static string RESULT_SAVED(string path) { return $"Result successfully saved to \"{path}\"."; }

        private static string RefineMaxFileSize()
        {
            long size = Convert.ToInt64(_config["maxFileSize"]);
            string refinedSizeStr;

            if (size / Math.Pow(1024, 1) < 1024)
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 1))} KB";
            }
            else if (size / Math.Pow(1024, 2) < 1024)
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 2))} MB";
            }
            else
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 3))} GB";
            }

            return refinedSizeStr;
        }
    }
}
