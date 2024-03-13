using System.Net.Http;
using StepfulLib;

namespace Stepful;

public class Client_Student(HttpClient http) : IStudentService
{
    public Student Create(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public Task<Student?> Get(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Student>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Save(Student s)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(string Id, Student s)
    {
        throw new NotImplementedException();
    }
}