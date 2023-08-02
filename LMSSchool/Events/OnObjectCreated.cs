namespace LMSSchool.Events;

public class OnObjectCreatedModel
{
    public static Action<object> OnObjectCreated = (obj) =>
    Console.WriteLine(obj.GetType().GetProperty("Name") + " object created ");
}