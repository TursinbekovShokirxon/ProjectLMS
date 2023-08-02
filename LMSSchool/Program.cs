

using LMSSchool.Managers;

namespace LMSSchool;

internal class Program
{
   public static void Main()
    {
        try
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select\n1.Pupil\n2.Subject\n3.Exit");
                byte select = byte.Parse(Console.ReadLine());
                if (select == 1)
                {
                    new PupilManager().Run();
                }
                else if (select == 2)
                {
                    new SubjectManager().Run();
                }
                else if(select==3)
                {
                    break;    
                }
                else
                {
                    Console.WriteLine("You enter wrong button");
                    Thread.Sleep(1000);
                }

                Console.Clear();
            }
        }
        catch (Exception e)
        {
            new ExceptionHandler.ExceptionHandler(e).Handle();
        }
    }
}