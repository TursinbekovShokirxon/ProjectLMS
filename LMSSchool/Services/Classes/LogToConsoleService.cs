using LMSSchool.Services.Intefaces;

namespace LMSSchool.Services.Classes;

internal class LogToConsoleService : ILogToConsoleService
{
    public void LogToConsole(string message)
    {
        Console.WriteLine(message);
    }
}
