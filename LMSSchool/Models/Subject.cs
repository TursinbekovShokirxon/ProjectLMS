using System.Runtime.ConstrainedExecution;
using System.Transactions;

namespace LMSSchool.Models;

internal class Subject
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<int>? Grades { get; set; } = new();
    public Subject()
    {
        Console.Write("Enter Name Subject :"); Name = Console.ReadLine() ?? "";
    }

}
