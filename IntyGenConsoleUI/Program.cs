using IntyGenConsoleUI.UIMessaging;
using IntyGenConsoleUI.UIProcessing;
using System;
using System.Threading.Tasks;

namespace IntyGenConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            Console.Title = "IntyGen - Hash";
            IConsoleUIProcessor processor;

            try
            {
                var keyIndex = OptionPicker();

                switch (keyIndex)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        processor = new SingleHashProcessor();
                        await processor.Start();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        processor = new MultipleHashProcessor();
                        await processor.Start();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        processor = new HashValidator();
                        await processor.Start();
                        break;
                    case ConsoleKey.H:
                    case ConsoleKey.F1:
                        processor = new HelpProcessor();
                        await processor.Start();
                        break;
                    case ConsoleKey.X:
                    case ConsoleKey.Q:
                        Environment.Exit(0); break;
                    default:
                        Message.Show(AlertType.Error, $"\n{Message.INVALID_OPTION}"); break;
                }
            }
            catch (Exception exp)
            {
                Message.Show(AlertType.Critical, exp.Message);
            }

            Console.WriteLine("\nPress 0 to restart or any key to exit.");
            var input = Console.ReadKey();
            if(input.Key is ConsoleKey.D0)
            {
                await Main(null);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static ConsoleKey OptionPicker()
        {
            Console.ResetColor();
            Message.Show(AlertType.Information, "Select an option to start...");
            Console.WriteLine("  1. Calculate hash for a single file");
            Console.WriteLine("  2. Calculate hash for multiple files in a directory");
            Console.WriteLine("  3. Verify file integrity");
            Console.WriteLine("  H. View Help");
            Console.WriteLine("  X. Exit program");
            Console.Write("\nEnter the index: ");
            var input = Console.ReadKey();
            return input.Key;
        }
    }
}
