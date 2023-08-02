using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSchool.Events
{
    internal class OnObjectDeletedModel
    {
        public static Action<object> OnObjectDeleted = (obj) =>
        Console.WriteLine(obj.GetType().GetProperty("Name") + " object deleted ");
    }
}
