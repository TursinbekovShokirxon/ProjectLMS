using LMSSchool.Models;

namespace LMSSchool.Services.Intefaces;

internal interface IPupilCRUDService : ICRUDBase<Pupil>
{
    public Pupil TheBestPupil();
    public Dictionary<string, IEnumerable<(string,int)>> CountOfFiveGradesForEachSubject();
    public Dictionary<string, double> AvaregeGrade();
}
