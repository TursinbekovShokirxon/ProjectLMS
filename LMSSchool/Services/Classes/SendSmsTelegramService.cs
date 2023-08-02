using LMSSchool.Services.Intefaces;

namespace LMSSchool.Services.Classes;

public class SendSmsTelegramService : ISendSmsTelegramService
{
    public void SendSmsTelegram(string message)
    {
        Console.WriteLine(message +"  Shu Xabar telegramga jonatildi");
    }
}
