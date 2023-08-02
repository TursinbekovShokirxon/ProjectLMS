using LMSSchool.Events;
using LMSSchool.Models;
using LMSSchool.Services.Classes;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Managers;

internal class PupilManager
{
    public readonly IPupilCRUDService _pupilCRUDService; 
    public PupilManager()
    {
        _pupilCRUDService = new PupilCRUDService();
    }
    public void Run()
    {
        bool davom = true;
        while (davom)
        {
            Console.WriteLine("PupilManager ga xush kelibsiz?");
            Console.WriteLine("1. O`quvchi qo'shish");
            Console.WriteLine("2. O`quvchilarni ko'rish");
            Console.WriteLine("3. O`quvchini yangilash");
            Console.WriteLine("4. O`quvchini o'chirish");
            Console.WriteLine("5. Eng Yaxshi o`quvchi");
            Console.WriteLine("6. O`quvchini har bir fandan olgan 5  baholarini soni");
            Console.WriteLine("7. O`quvchini har bir fandan olgan o`rtacha  bahosi.");
            Console.WriteLine("0. Dasturdan chiqish");
            Console.Write("Tanlang: ");

            int tanlov = Convert.ToInt32(Console.ReadLine());

            switch (tanlov)
            {
                case 0: davom = false; break;
                case 1:
                    Pupil PuipilCreate = new();
                    _pupilCRUDService.Create(PuipilCreate);
                    OnObjectCreatedModel.OnObjectCreated.Invoke(PuipilCreate);

                    break;
                case 2:
                    if (_pupilCRUDService.GetAll() != null)
                    {
                        foreach (var item in _pupilCRUDService.GetAll())
                        {
                            Console.WriteLine("Id : " + item.Id + " " + "Name :" + item.Name+" "+"Fanlari :");
                            foreach (var item1 in item.Subjects)
                            {
                                Console.Write(item1+" " );
                            }
                        }
                    }
                    else continue;
                    ; break;
                case 3:
                    if (_pupilCRUDService.GetAll() != null)
                    {
                        foreach (var item in _pupilCRUDService.GetAll())
                        {
                            Console.WriteLine("Id : " + item.Id + " " + "Name :" + item.Name);
                        }
                        Console.WriteLine("Enter Id where  :"); Guid Pid = Guid.Parse(Console.ReadLine()??"");
                        var p = _pupilCRUDService.GetAll().FirstOrDefault(x => x.Id == Pid);
                        _pupilCRUDService.Update(p);
                        OnObjectUpdatedModel.OnObjectUpdated.Invoke(p);
                    }
                    else { Console.WriteLine("Ozgartirishga hech narsa yoq !"); Thread.Sleep(1000); }
                    break;
                case 4:
                    foreach (var item in _pupilCRUDService.GetAll())
                    {
                        Console.WriteLine("Id :"+item.Id+" Name :"+item.Name);
                    }
                    Console.Write("Enter Id which you want delete :");Guid GuideDelete = Guid.Parse(Console.ReadLine() ?? "");
                    _pupilCRUDService.Delete(GuideDelete);
                    OnObjectDeletedModel.OnObjectDeleted.Invoke(GuideDelete);
                    break;
                case 5:
                    _pupilCRUDService.TheBestPupil();
                    break;
                case 6:
                    foreach (var item in _pupilCRUDService.CountOfFiveGradesForEachSubject())
                    {
                        Console.WriteLine("name :"+item.Key );
                        foreach (var item1 in item.Value)
                        {
                            Console.WriteLine("Name of Subject :"+item1.Item1 + " Count Of Five :"+item1.Item2);
                        }
                    }
                    break;
                case 7:
                    foreach (var item in _pupilCRUDService.AvaregeGrade())
                    {
                        Console.WriteLine("Names :"+item.Key+" Average :"+item.Value);
                    }
                    break;
                default:
                    Console.WriteLine("Noto'g'ri tanlov boshqa tugma kiriting!");
                    Thread.Sleep(1000);
                    break;
            }

            Console.WriteLine();
        }
    }
}