using LMSSchool.Models;
using LMSSchool.Services.Intefaces;
namespace LMSSchool.Services.Classes;
internal class SubjectCRUDService : ISubjectCRUDService
{
    private static List<Subject> subj = new();
    public void Create(Subject obj)
    {
        Console.Clear();
        subj.Add(obj);
    }
    public void Delete(Guid id)
    {
        Console.Clear();
        var removedSubj = subj.FirstOrDefault(p => p.Id.Equals(id));
        if (removedSubj != null) subj.Remove(removedSubj);
        else throw new Exception($"Id= {id} Fan topilmadi!");
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
        int index = subj.FindIndex(x => x.Id.Equals(obj.Id));
        subj[index] = obj;
    }
}
