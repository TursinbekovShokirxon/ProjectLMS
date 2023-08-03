using LMSSchool.Models;
using LMSSchool.Services.Intefaces;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace LMSSchool.Services.Classes;
internal class SubjectCRUDService : ISubjectCRUDService
{
    private static List<Subject> subj = new();
    private  string path = @"../../../DB/DBSubject.Json";
    WriteToFileService writeToFileService = new WriteToFileService();
    public SubjectCRUDService()
    {
        if (File.Exists(path))
        {
            string jsonDesirialize = File.ReadAllText(path);
            subj = JsonConvert.DeserializeObject<List<Subject>>(jsonDesirialize);
        }
    }
    public void Create(Subject obj)
    {
        Console.Write("Enter Name Subject :"); obj.Name = Console.ReadLine() ?? "";
        Console.Clear();
        subj.Add(obj);
        string JsonSerialize = JsonConvert.SerializeObject(subj, Formatting.Indented);
        writeToFileService.WriteToFile(path, JsonSerialize);
    }
    public void Delete(Guid id)
    {
        Console.Clear();
        var removedSubj = subj.FirstOrDefault(p => p.Id.Equals(id));
        if (removedSubj != null) subj.Remove(removedSubj);
        else throw new Exception($"Id= {id} Fan topilmadi!");
        string JsonSerialize = JsonConvert.SerializeObject(subj, Formatting.Indented);
        writeToFileService.WriteToFile(path, JsonSerialize);
    }
    public List<Subject> GetAll()
    {
        Console.Clear();
        return subj;
    }
    public Subject GetById(Guid id)
    {
        Console.Clear();
        var SubjLikeId = subj.FirstOrDefault(p => p.Id.Equals(id));
        if (SubjLikeId == null) throw new Exception("Not found in the list");
        return SubjLikeId;
    }
    public void Update(Subject obj)
    {
        Console.Clear();
        Console.Write("Enter :"); obj.Name = Console.ReadLine()??"";
        int index = subj.FindIndex(x => x.Id.Equals(obj.Id));
        subj[index] = obj;
        string JsonSerialize = JsonConvert.SerializeObject(subj, Formatting.Indented);
        writeToFileService.WriteToFile(path, JsonSerialize);
    }
}
