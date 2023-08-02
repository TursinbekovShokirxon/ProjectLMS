using LMSSchool.Events;
using LMSSchool.Services.Classes;
using static LMSSchool.Events.OnCatchExceptionModel;

namespace LMSSchool.ExceptionHandler;

internal class ExceptionHandler
{
    private readonly Exception _exception;
    SendSmsTelegramService sendSmsTelegramService = new SendSmsTelegramService();
    LogToConsoleService logToConsoleService = new LogToConsoleService();
    OnCatchException onCatch;
    public ExceptionHandler(Exception exception)
    {
        _exception = exception;
        onCatch += logToConsoleService.LogToConsole;
        onCatch += sendSmsTelegramService.SendSmsTelegram;
    }
    public void Handle()
    {
        onCatch.Invoke(_exception.Message);
        Console.WriteLine("Enter Any button for continue"); Console.ReadKey();
        Program.Main();
    }
}
