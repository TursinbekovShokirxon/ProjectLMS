namespace LMSSchool.Services.Intefaces;

public interface IWriteToFileService
{
    public async void WriteToFile(string filePath,string message);
}
