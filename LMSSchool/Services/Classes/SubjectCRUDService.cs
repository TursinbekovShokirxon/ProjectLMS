using LMSSchool.Models;
using LMSSchool.Services.Intefaces;
namespace LMSSchool.Services.Classes;
internal class SubjectCRUDService : ISubjectCRUDService
{
    PupilCRUDService pupilCRUDService = new();
    private static List<Subject> subj = new();

    public SubjectCRUDService()
    {
        subj = pupilCRUDService.GetAll()[0].Subjects;
    }
    public void Create(Subject obj)
    {
        subj.Add(obj);
    }
    public void Delete(Guid id)
    {
        var removedSubj = subj.FirstOrDefault(p => p.Id.Equals(id));
        if (removedSubj != null) subj.Remove(removedSubj);
        else throw new Exception($"Id= {id} Fan topilmadi!");
    }
    public List<Subject> GetAll()
    {
        return subj;
    }
    public Subject GetById(Guid id)
    {
        var SubjLikeId = subj.FirstOrDefault(p => p.Id.Equals(id));
        if (SubjLikeId == null) throw new Exception("Not found in the list");
        return SubjLikeId;
    }
    public void Update(Subject obj)
    {
        int index = subj.FindIndex(x => x.Id.Equals(obj.Id));
        subj[index] = obj;
    }
}
