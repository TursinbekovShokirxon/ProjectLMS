using LMSSchool.Managers;
using LMSSchool.Models;
using LMSSchool.Services.Intefaces;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static LMSSchool.Events.OnCatchExceptionModel;

namespace LMSSchool.Services.Classes
{

    internal class PupilCRUDService : IPupilCRUDService
    {
      public  static string path = @"../../../DB/DBPupil.Json";
        List<Pupil>? _pupils = new();
        WriteToFileService writeToFileService = new WriteToFileService();
        private readonly SubjectCRUDService subjectCRUDService =  new();
        Random rand = new Random();
        public PupilCRUDService()
        {
            if (File.Exists(path))
            {
                string jsonDesirialize = File.ReadAllText(path);
                _pupils = JsonConvert.DeserializeObject<List<Pupil>>(jsonDesirialize);
            }
        }
        public void Create(Pupil pupil)
        {
            Console.Write("Enter name pupil :");pupil.Name = Console.ReadLine()??"";
            var AllSubjects = subjectCRUDService.GetAll();
            if (AllSubjects.Count()>0)
            {
                foreach (var item in AllSubjects)
                {
                    Console.WriteLine("Id :"+item.Id+" Name:"+item.Name);
                }
                Console.Write("Enter Id what you want add :"); Guid AddId = Guid.Parse(Console.ReadLine() ?? "");
                var p1 = subjectCRUDService.GetById(AddId);
                Console.Write("Enter how Grades you want add :");byte a=byte.Parse(Console.ReadLine()??"");
                for (int i = 0; i < a; i++)
                {
                    p1.Grades.Add(rand.Next(3, 6));
                }
                pupil.Subjects.Add(p1);
            }
            else
            {
                Console.WriteLine("Subjects list is empty but you can add subjects in subject manager P.S. I love you");
                Thread.Sleep(1000); 
            }
            _pupils.Add(pupil);
            string JsonSerialize = JsonConvert.SerializeObject(_pupils, Formatting.Indented);
            writeToFileService.WriteToFile(path,JsonSerialize);
        }
        public void Update(Pupil obj)
        {
            int index = _pupils.FindIndex(x => x.Id.Equals(obj.Id));
            Console.WriteLine("1.Name\n2.Fan Qoshish\n3.Ikkalasiniyam qilish");
            Console.Write("Nmasini yangilashni kiting :");
            byte select = byte.Parse(Console.ReadLine());
            if (select == 1) { Console.Write("Enter him name :"); obj.Name = Console.ReadLine();}
            else if (select == 2)
            {
                foreach (var item in subjectCRUDService.GetAll())
                {
                    Console.WriteLine("Id :" + item.Id + "  Name :" + item.Name);
                }
                Console.WriteLine("Enter which subject you want add :"); Guid guid = Guid.Parse(Console.ReadLine() ?? "");
                Console.Write("Enter how Grades you want add :"); byte a = byte.Parse(Console.ReadLine() ?? "");
                var PersonalSubjectinUpdate = subjectCRUDService.GetById(guid);
                for (int i = 0; i < a; i++)
                {
                    PersonalSubjectinUpdate.Grades.Add(rand.Next(3, 6));
                }
                obj.Subjects.Add(PersonalSubjectinUpdate);
            }
            else if (select == 3)
            {
                obj.Name = Console.ReadLine();
                foreach (var item in subjectCRUDService.GetAll())
                {
                    Console.WriteLine("Id :" + item.Id + "  Name :" + item.Name);
                }
                Console.WriteLine("Enter which subject you want add :"); Guid guid = Guid.Parse(Console.ReadLine() ?? "");
                obj.Subjects.Add(subjectCRUDService.GetById(guid));
            }
            else new Exception("You enter wrong button");
            _pupils[index] = obj;
            string JsonSerialize = JsonConvert.SerializeObject(_pupils, Formatting.Indented);
            writeToFileService.WriteToFile(path, JsonSerialize);
        }
        public void Delete(Guid id)
        {
            var removedPupil = _pupils.FirstOrDefault(p => p.Id.Equals(id));
            if (removedPupil != null)
            {
                _pupils.Remove(removedPupil);
                string JsonSerialize = JsonConvert.SerializeObject(_pupils, Formatting.Indented);
                writeToFileService.WriteToFile(path, JsonSerialize);
            }
            else
            {
                throw new Exception($"Id= {id} o`quvchi topilmadi!");
            }
        }
        public List<Pupil> GetAll()
        {
            return _pupils;
        }
        public Pupil GetById(Guid id)
        {
            var SelectedPupil = _pupils.FirstOrDefault(p => p.Id.Equals(id));
            if (SelectedPupil == null) throw new Exception($"Id= {id} o`quvchi topilmadi!");
            return SelectedPupil;
        }
        public Pupil TheBestPupil()
        {
            return _pupils.OrderBy(x => x.Subjects.Max(s => s.Grades.Count(g => g.Equals(5)))).FirstOrDefault();}

        public Dictionary<string, double> AvaregeGrade()
        {
            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
            if (_pupils == null) new Exception("_pupil list is Empty");
            foreach (var item in _pupils)
            {
                foreach (var item1 in item.Subjects) keyValuePairs.Add(((item.Name) + item1.Name), (item1.Grades.Average()));
            }
            return keyValuePairs;
        }
        public Dictionary<string, IEnumerable<(string, int)>> CountOfFiveGradesForEachSubject()
        {
            Dictionary<string, IEnumerable<(string, int)>> news = new();
            foreach (var item in _pupils)
            {
                IEnumerable<(string, int)> result = new List<(string, int)>();
                foreach (var item1 in item.Subjects) result.Append((item1.Name, item1.Grades.Count(x => x == 5)));
                news.Add(item.Name, result);
            }
            return news;
        }
    }
}
