using LMSSchool.Services.Classes;

namespace LMSSchool.Events;

public class OnObjectUpdatedModel
{
    public static SendSmsTelegramService send=new();
    public static Action<object> OnObjectUpdated = (obj) =>
    {
        Console.WriteLine(obj.GetType().GetProperty("Name") + " object updated ");
        send.SendSmsTelegram(obj.GetType().GetProperty("Name") + " object updated");
    };
}

