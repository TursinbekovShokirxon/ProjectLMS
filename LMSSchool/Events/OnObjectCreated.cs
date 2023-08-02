using LMSSchool.Services.Classes;

namespace LMSSchool.Events;

public class OnObjectCreatedModel
{
    static SendSmsTelegramService SendSmsTelegram = new();
    internal static Action<object> OnObjectCreated = (obj) =>
    { 
        Console.WriteLine(obj.GetType().GetProperty("Name") + " object created ");
        SendSmsTelegram.SendSmsTelegram( "object created");
    };

}