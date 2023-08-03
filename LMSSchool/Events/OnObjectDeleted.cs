using LMSSchool.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LMSSchool.Events
{
    internal class OnObjectDeletedModel
    {
        public static SendSmsTelegramService send = new();
        public static Action<object> OnObjectDeleted = (obj) =>
        {
            string a = obj.GetType().GetProperty("Name") + " object deleted ";
            Console.WriteLine(a);
            send.SendSmsTelegram(a);
        };
       
    }
}
