using LMSSchool.Events;
using LMSSchool.Models;
using LMSSchool.Services.Classes;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Managers;

internal class SubjectManager
{
    public readonly ISubjectCRUDService _SubjectCRUDService;
    public SubjectManager() { _SubjectCRUDService = new SubjectCRUDService();}
    public async void Run()
    {
        bool davom = true;
        while (davom)
        {
            Console.Clear();
            Console.WriteLine("SubjectManager ga xush kelibsiz?");
            Console.WriteLine("1. Fan qo'shish");
            Console.WriteLine("2. Fanlarni ko'rish");
            Console.WriteLine("3. Fanni yangilash");
            Console.WriteLine("4. Fanni o'chirish");
            Console.Write("Select :");byte a=byte.Parse(Console.ReadLine()??"");
            switch (a)
            {
                case 1: {
                        Console.Clear();
                        Subject subjectCreated = new(); _SubjectCRUDService.Create(subjectCreated); OnObjectCreatedModel.OnObjectCreated.Invoke(subjectCreated);
                    } break;
                case 2: 
                    {
                        Console.Clear();
                        foreach (var item in _SubjectCRUDService.GetAll())
                        {
                            Console.WriteLine("Name :"+item.Name+" Id :"+item.Id);
                        }
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        foreach (var item in _SubjectCRUDService.GetAll())
                        {
                            Console.WriteLine("Name :"+item.Id+" Id :"+item.Name);
                        }
                        Console.Write("Enter Subjects Id :");Guid id=Guid.Parse(Console.ReadLine()??"");
                         _SubjectCRUDService.Update(_SubjectCRUDService.GetById(id));
                    }
                    break;
                case 4: {
                        foreach (var item in _SubjectCRUDService.GetAll())
                        {
                            Console.WriteLine("Id :"+item.Id+"Name :"+item.Name);
                        }
                        Console.Write("Enter Id :");Guid guid = Guid.Parse(Console.ReadLine() ?? "");
                        _SubjectCRUDService.Delete(guid); } break;
                case 5: { }break;
                default: { Console.WriteLine("You enter wrong button");  Thread.Sleep(1000); } break;
                    
            }

        }
    }

}

