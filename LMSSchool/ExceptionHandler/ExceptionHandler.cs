using LMSSchool.Events;
using LMSSchool.Services.Classes;
using static LMSSchool.Events.OnCatchExceptionModel;

namespace LMSSchool.ExceptionHandler;

internal class ExceptionHandler
{
    private readonly Exception _exception;
    SendSmsTelegramService sendSmsTelegramService = new SendSmsTelegramService();
    LogToConsoleService logToConsoleService = new LogToConsoleService();
    public ExceptionHandler(Exception exception)
    {
        _exception = exception;
    }
    public void Handle()
    {
        OnCatchException onCatch = sendSmsTelegramService.SendSmsTelegram;
        onCatch += logToConsoleService.LogToConsole;
        onCatch.Invoke(_exception.Message);
    }
}
