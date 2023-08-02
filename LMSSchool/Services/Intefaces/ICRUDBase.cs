namespace LMSSchool.Services.Intefaces;

internal interface ICRUDBase<T>
{
    public void Create(T obj);
    public T GetById(Guid id);
    public List<T> GetAll();
    public void Update(T obj);
    public void Delete(Guid id);
}
