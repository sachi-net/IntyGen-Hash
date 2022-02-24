using IntyGenConsoleUI.UIMessaging;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace IntyGenConsoleUI.UIProcessing
{
    public class HelpProcessor : IConsoleUIProcessor
    {
        private NameValueCollection config = ConfigurationManager.AppSettings;
        private const string _t = "\t";
        private const string _3 = "   ";

        public async Task Start()
        {
            Console.WriteLine("\n");
            Message.Show(AlertType.Information, "Help and Tips");
            Message.Show(AlertType.Information, "-------------");

            #region 1. Single Hash
            Console.Write("\n");
            Message.Show(AlertType.Information, "1. Calculate hash for a single file");
            Message.Show(AlertType.None, $"{_t}Allows to generate hash signature for the specified file.");
            Message.Show(AlertType.None, $"{_t}Pressing [1] key will start this feature.");
            Message.Show(AlertType.Information, $"{_3}Parameters");
            Message.Show(AlertType.Success, $"{_3}{_3}File Path");
            Message.Show(AlertType.None, $"{_t}  - Fully qualified path to the file.");
            Message.Show(AlertType.None, $"{_t}    The path string should only contain ASCII characters.");
            Message.Show(AlertType.Success, $"{_3}{_3}Hash Type");
            Message.Show(AlertType.None, $"{_t}  - Which Hash algorithm to be used while calculating hash signature.");
            Message.Show(AlertType.None, $"{_t}    Hash type shoulde be one of [ MD5 | SHA1 | SHA256 ] types.");
            Message.Show(AlertType.None, $"{_3}{_3}Program supports up to maximum file size of {RefineMaxFileSize()}.");
            #endregion

            #region 2. Multiple Hashes
            Console.WriteLine("\n");
            Message.Show(AlertType.Information, "2. Calculate hash for multiple files in an directory");
            Message.Show(AlertType.None, $"{_t}Allows to generate hash signatures for multiple files in a specified directory.");
            Message.Show(AlertType.None, $"{_t}Pressing [2] key will start this feature.");
            Message.Show(AlertType.Information, $"{_3}Parameters");
            Message.Show(AlertType.Success, $"{_3}{_3}Folder Path");
            Message.Show(AlertType.None, $"{_t}  - Folder path which contains the files to be calculated the hash signatures.");
            Message.Show(AlertType.None, $"{_t}    The path string should only contain ASCII characters.");
            Message.Show(AlertType.Success, $"{_3}{_3}Hash Type");
            Message.Show(AlertType.None, $"{_t}  - Which Hash algorithm to be used while calculating hash signature.");
            Message.Show(AlertType.None, $"{_t}    Hash type shoulde be one of [ MD5 | SHA1 | SHA256 ] types.");
            Message.Show(AlertType.Success, $"{_3}{_3}Skip Large Files");
            Message.Show(AlertType.None, $"{_t}  - Whether to ignore large files in the directory while calculating hash.");
            Message.Show(AlertType.None, $"{_t}    If Yes [Y], program will skip large files and continue.");
            Message.Show(AlertType.None, $"{_t}    If No [N], program will stop only if it finds large file, otherwise continues.");
            Message.Show(AlertType.None, $"{_t}    Program supports up to maximum file size of {RefineMaxFileSize()}.");
            #endregion

            #region 3. Verify Integrity
            Console.WriteLine("\n");
            Message.Show(AlertType.Information, "3. Verify file integrity");
            Message.Show(AlertType.None, $"{_t}Allows to compare and verify the integrity of a file with specified hash signature.");
            Message.Show(AlertType.None, $"{_t}Pressing [3] key will start this feature.");
            Message.Show(AlertType.Information, $"{_3}Parameters");
            Message.Show(AlertType.Success, $"{_3}{_3}File Path");
            Message.Show(AlertType.None, $"{_t}  - Fully qualified path to the file.");
            Message.Show(AlertType.None, $"{_t}    The path string should only contain ASCII characters.");
            Message.Show(AlertType.Success, $"{_3}{_3}Hash Type");
            Message.Show(AlertType.None, $"{_t}  - Which Hash algorithm to be used while calculating hash signature.");
            Message.Show(AlertType.None, $"{_t}    Hash type shoulde be one of [ MD5 | SHA1 | SHA256 ] types.");
            Message.Show(AlertType.Success, $"{_3}{_3}Hash Signature");
            Message.Show(AlertType.None, $"{_t}  - This hash will be compared with the specified file.");
            Message.Show(AlertType.None, $"{_t}    The hash signature should not contain illegal characters except dashes.");
            Message.Show(AlertType.None, $"{_3}{_3}Program supports up to maximum file size of {RefineMaxFileSize()}.");
            #endregion

            #region 4. View Help
            Console.WriteLine("\n");
            Message.Show(AlertType.Information, "3. View Help");
            Message.Show(AlertType.None, $"{_t}Allows to access help tips about the program functionalities.");
            Message.Show(AlertType.None, $"{_t}Pressing [H] or [F1] key will open the help tips page.");
            #endregion

            #region 5. Exit Program
            Console.WriteLine("\n");
            Message.Show(AlertType.Information, "4. Exit Program");
            Message.Show(AlertType.None, $"{_t}Close all modules and quit the program.");
            Message.Show(AlertType.None, $"{_t}Pressing [X] or [Q] key will close the program.");
            #endregion

            await Task.CompletedTask;
        }

        private string RefineMaxFileSize()
        {
            long size = Convert.ToInt64(config["maxFileSize"]);
            string refinedSizeStr;

            if (size / Math.Pow(1024, 1) < 1024)
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 1)).ToString()} KB";
            }
            else if (size / Math.Pow(1024, 2) < 1024)
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 2)).ToString()} MB";
            }
            else
            {
                refinedSizeStr = $"{(size / Math.Pow(1024, 3)).ToString()} GB";
            }

            return refinedSizeStr;
        }
    }
}
