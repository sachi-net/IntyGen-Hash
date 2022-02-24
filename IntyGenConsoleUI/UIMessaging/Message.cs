using System;

namespace IntyGenConsoleUI.UIMessaging
{
    public static class Message
    {
        internal const string DIRECTORY_NOT_FOUND = "Directory not found in specified path.";
        internal const string FILE_NOT_FOUND = "File not found in specified path.";
        internal const string INVALID_HASH_TYPE = "Invalid hash type.";
        internal const string FILE_TOO_LARGE = "File is too large to process";
        internal const string MORE_LARGE_FILES = "Specified directory contains large files which cannot process.";
        internal const string INVALID_OPTION = "Invalid option.";
        internal const string INTEGRITY_VERIFIED = "File integrity matches with specified hash signature.";
        internal const string INTEGRITY_FAILED = "File integrity does not match with specified hash signature.";

        public static void Show(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Show(AlertType type, string message)
        {
            switch (type)
            {
                case AlertType.Information:
                    Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case AlertType.Success:
                    Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case AlertType.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case AlertType.Error:
                    Console.ForegroundColor = ConsoleColor.Red; break;
                case AlertType.Critical:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ResetColor(); break;
            }

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
