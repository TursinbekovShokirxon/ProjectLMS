namespace LMSSchool.Models;

internal class Pupil
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public List<Subject>? Subjects { get; set; } = new();
}
