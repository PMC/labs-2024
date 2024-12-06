using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    //Class to handle console output
    public static class CS
    {
        internal static void Print(ConsoleColor color, string text)
        {
            ConsoleColor myDefault = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = myDefault;
        }
        internal static void Print(string text)
        {
            Console.Write(text);
        }
        internal static void PrintLn(ConsoleColor color, string text)
        {
            Print(color, text);
            Console.WriteLine();
        }
        internal static void PrintLn(string text)
        {
            Console.WriteLine(text);
        }
    }
}
