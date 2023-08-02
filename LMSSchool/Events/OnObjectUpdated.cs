namespace LMSSchool.Events;

public class OnObjectUpdatedModel
{
    public static Action<object> OnObjectUpdated = (obj) =>
        Console.WriteLine(obj.GetType().GetProperty("Name") + " object updated ");
}

