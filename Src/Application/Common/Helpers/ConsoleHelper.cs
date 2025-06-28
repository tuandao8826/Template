using System.Text;

namespace Application.Common.Helpers;

public static class ConsoleHelper
{
    public static void WriteLine(string actionName, string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\n[{DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss}] ----> {actionName} ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"{message}\n");
        Console.ResetColor();
    }
}
