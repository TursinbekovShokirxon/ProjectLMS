using LMSSchool.Models;
using LMSSchool.Services.Intefaces;
using Newtonsoft.Json;
using System.IO;

namespace LMSSchool.Services.Classes;

internal class WriteToFileService : IWriteToFileService
{
    public async void WriteToFile(string filePath,string message)
    {
        await Task.Delay(1000);
        using (StreamWriter Writter = new(filePath))
        {
            Writter.WriteLine(message);
        }
    }
}
