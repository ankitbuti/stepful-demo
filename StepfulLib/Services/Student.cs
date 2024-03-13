using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace StepfulLib;

[EntityName("Student")]
public class Student : IUser
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsValid { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePicUrl { get; set; }
    public List<TimeSlot> Calendar { get; set; }

    public Student(string Name)
    {
        this.Id = ObjectId.GenerateNewId().ToString();
        this.FullName = Name;
    }
    public Student()
    {

    }
}

public class StudentContext
{
    private readonly IMongoCollection<Student> Collection;

    public StudentContext(DatabaseSettings dbSettings)
    {
        var mongoClient = new MongoClient(
            dbSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            dbSettings.DatabaseName);

        Collection = mongoDatabase.GetCollection<Student>("Student");
    }

    public StudentContext(string ConnectionString, string DatabaseName, string CollectionName = "Student")
    {
        var MongoClient = new MongoClient(ConnectionString);
        var mongoDatabase = MongoClient.GetDatabase(DatabaseName);
        Collection = mongoDatabase.GetCollection<Student>(CollectionName);
    }

    public async Task<List<Student>> GetAsync()
    {
        try {
            return await Collection.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return null;
        }
    }
       

    public async Task<Student?> GetAsync(string id)
    {
        try {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return null;
        }
    }
       

    public async Task<bool> CreateAsync(Student newStudent)
    {
        try {
            await Collection.InsertOneAsync(newStudent);
            return true;
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return false;
        }
    }
       

    public async Task<bool> UpdateAsync(string id, Student updatedStudent)
    {
        try {
            await Collection.ReplaceOneAsync(x => x.Id == id, updatedStudent);
            return true;
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return false;
        }
    }
       

    public async Task<bool> RemoveAsync(string id)
    {
        try {
            await Collection.DeleteOneAsync(x => x.Id == id);
            return true;
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return false;
        }
    }
       

    public async Task<bool> DeleteAllAsync()
    {
        try {
            await Collection.DeleteManyAsync(x => x.Id != null);
            return true;
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return false;
        }

    }
}

public class StudentService : IStudentService
{
    private StudentContext db { get; set; }

    public StudentService(DatabaseSettings dbSettings)
    {
        db = new StudentContext(dbSettings);
    }

    public StudentService(StudentContext db){
        this.db = db;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await db.GetAsync();
    }

    public Student? Create(string email)
    {
        Student s = new Student(email);
        if (db != null)
        {
            if (db.CreateAsync(s).Result)
            {
                return s;
            }
            else{
                SLog.Write("Student DB Create Failed...");
                return null;
            }
        }
        else
        {
            SLog.Write("Student DB Context Not Ready...");
            return null;
        }
    }

    public Task<bool> Save(Student s)
    {
        s.Id = ObjectId.GenerateNewId().ToString();
        return db.CreateAsync(s);
    }

    public Task<bool> DeleteAll()
    {
        return db.DeleteAllAsync();
    }

    public Task<bool> Delete(string Id)
    {
        return db.RemoveAsync(Id);
    }

    public Task<Student?> Get(string Id)
    {
        return db.GetAsync(Id);
    }

    public Task<bool> Update(string Id, Student s)
    {
        return db.UpdateAsync(Id, s);
    }
}

public interface IStudentService : IBusinessService
{
    public new Task<IEnumerable<Student>> GetAllAsync();
    public Student Create(string email);
    public Task<bool> Save(Student s);
    public Task<bool> DeleteAll();
    public Task<bool> Delete(string Id);
    public Task<Student?> Get(string Id);
    public Task<bool> Update(string Id, Student s);
}