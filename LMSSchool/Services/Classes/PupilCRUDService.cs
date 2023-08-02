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
      public  static string path = @"../../../DB/DB.Json";
        List<Pupil>? _pupils = new();
        WriteToFileService writeToFileService = new WriteToFileService();
        private readonly SubjectCRUDService subjectCRUDService =  new();
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
            var p = subjectCRUDService.GetAll();
            if (p != null)
            {
                foreach (var item in p)
                {
                    Console.WriteLine("Id :"+item.Id+" Name:"+item.Name);
                }
                Console.Write("Enter Id what you want add :"); Guid AddId = Guid.Parse(Console.ReadLine() ?? "");
                var p1 = subjectCRUDService.GetById(AddId);

                for (int i = 0; i < length; i++)
                {

                }
                p1.Grades
                pupil.Subjects.Add(p1);
            }
            else
            {
                new SubjectManager().Run();
            }
            _pupils.Add(pupil);
            string JsonSerialize = JsonConvert.SerializeObject(_pupils, Formatting.Indented);
            writeToFileService.WriteToFile(path,JsonSerialize);
        }
        public void Update(Pupil obj)
        {

            int index = _pupils.FindIndex(x => x.Id.Equals(obj.Id));
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
