using MongoDB.Bson;
using MongoDB.Driver;

namespace StepfulLib;

[EntityName("Coach")]
public class Coach : IUser
{
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsValid { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePicUrl { get; set; }
    public List<TimeSlot> Calendar { get; set; }

    public Location Location { get; set; }
    public string Timezone { get; set; }
    public List<Speciality> Specialities { get; set; }

    public Coach(string Name)
    {
        this.Id = ObjectId.GenerateNewId().ToString();
        this.FullName = Name;
    }
    public Coach()
    {

    }
}

public class CoachContext
{
    private readonly IMongoCollection<Coach> Collection;

    public CoachContext(DatabaseSettings dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(dbSettings.DatabaseName);

        Collection = mongoDatabase.GetCollection<Coach>("Coach");
    }

    public CoachContext(string ConnectionString, string DatabaseName, string CollectionName = "Coach")
    {
        var MongoClient = new MongoClient(ConnectionString);
        var mongoDatabase = MongoClient.GetDatabase(DatabaseName);

        Collection = mongoDatabase.GetCollection<Coach>(CollectionName);
    }


    public async Task<IEnumerable<Coach>> GetAsync()
    {
        try
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
        catch(Exception ex)
        {
            SLog.Write(ex.Message);
            return null;
        }
    }
       

    public async Task<Coach?> GetAsync(string id)
    {
        try {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch(Exception ex) {
            SLog.Write(ex.Message);
            return null;
        }
        
    }
        

    public async Task<bool> CreateAsync(Coach newCoach)
    {
        try {
            await Collection.InsertOneAsync(newCoach);
            return true;
        }
        catch (Exception ex) {
            SLog.Write(ex.Message);
            return false;
        }
    }
        
    public async Task<bool> UpdateAsync(string id, Coach updatedCoach)
    {
        try {
            await Collection.ReplaceOneAsync(x => x.Id == id, updatedCoach);
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

public class CoachService : ICoachService
{
    private CoachContext? db { get; set; }

    private Coach coach = null;

    public CoachService() { }

    public CoachService(DatabaseSettings? dbSettings)
    {
        if (dbSettings != null)
        {
            db = new CoachContext(dbSettings);
        }
    }

    public CoachService(Coach coach)
    {
        this.coach = coach;
    }

    public Task<IEnumerable<Coach>> GetAllAsync()
    {
        return db.GetAsync();
    }

    public Coach? Create(string email)
    {
        Coach c = new Coach(email);
        if (db != null)
        {
            if (db.CreateAsync(c).Result)
            {
                return c;
            }
            else
            {
                SLog.Write("Coach DB Create Failed...");
                return null;
            }
        }
        else
        {
            SLog.Write("Coach DB Context Not Ready...");
            return null;
        }
    }

    public Task<bool> Save(Coach c)
    {
        c.Id = ObjectId.GenerateNewId().ToString();
        return db.CreateAsync(c);
    }

    public Task<bool> DeleteAll()
    {
        return db.DeleteAllAsync();
    }

    public Task<bool> Delete(string Id)
    {
        return db.RemoveAsync(Id);
    }

    public Task<Coach?> Get(string Id)
    {
        return db.GetAsync(Id);
    }

    public Task<bool> Update(string Id, Coach c)
    {
        return db.UpdateAsync(Id, c);
    }

    public Task<bool> AddSlot(Coach c, DateTime slot)
    {
        if (c.Calendar == null)
        {
            c.Calendar = new List<TimeSlot>();
        }

        c.Calendar = c.Calendar.OrderBy(c => c.StartTime).ToList();

        TimeSlot s1 = new TimeSlot(slot);
        bool allow = true;

        foreach(TimeSlot s in c.Calendar)
        {
            if(s1.StartTime.Subtract(s.EndTime.ToUniversalTime()).Minutes < 0)
            {
                allow = false;
                break;
            }
        }

        if(allow)
        {
            c.Calendar.Add(s1);
            return Update(c.Id, c);
        }

        SLog.Write("Time Conflict. Can't create a new slot");
        return null;
    }
}

public interface ICoachService : IBusinessService{
    public new Task<IEnumerable<Coach>> GetAllAsync();
    public Coach? Create(string email);
    public Task<bool> Save(Coach c);
    public Task<bool> DeleteAll();
    public Task<bool> Delete(string Id);
    public Task<Coach?> Get(string Id);
    public Task<bool> Update(string Id, Coach c);

    public Task<bool> AddSlot(Coach c, DateTime slot);
}