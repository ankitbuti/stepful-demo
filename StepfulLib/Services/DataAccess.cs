using System.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace StepfulLib;

public class DatabaseSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string CollectionName { get; set; }
}

public class DataAccess
{
    public MongoClient MongoClient { get; set; }
    public IMongoDatabase Mongo { get; set; }
    public IMongoCollection<BsonDocument> ActiveCollection { get; set; }

    public DataAccess(string ConnectionString, string DatabaseName, string CollectionName = "System-Default")
    {
        this.MongoClient = new MongoClient(ConnectionString);
        Mongo = MongoClient.GetDatabase(DatabaseName);
        SetActiveCollection(CollectionName);
    }

    public DataAccess(IOptions<DatabaseSettings> DatabaseSettings)
    {
        this.MongoClient = new MongoClient(DatabaseSettings.Value.ConnectionString);
        Mongo = MongoClient.GetDatabase(DatabaseSettings.Value.DatabaseName);
        SetActiveCollection(DatabaseSettings.Value.CollectionName);
    }

    public DataAccess(IConfiguration configuration)
    {
        int y = 0;
    }

    public void SetActiveCollection(string CollectionName)
    {
        ActiveCollection = Mongo.GetCollection<BsonDocument>(CollectionName);
    }

    public async Task<bool> AddAsync(BsonDocument obj)
    {
        try
        {
            await ActiveCollection.InsertOneAsync(obj);
            return true;
        }
        catch (Exception ex)
        {
            SLog.Write(this.GetType().Name + ".AddAsync() Error: " + ex.Message);
            return false;
        }
    }

    public async Task<BsonDocument> GetAsync(string Id)
    {
        try
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(Id));

            var A = await ActiveCollection.Find(filter).FirstOrDefaultAsync();

              //var T = await ActiveCollection.Find<BsonDocument>(s => s.IsDeleted == false && c.Id == Id).FirstOrDefaultAsync();
             //long c = ActiveCollection.EstimatedDocumentCount();
            //return null;
            return A;

        }
        catch (Exception ex)
        {
            SLog.Write(this.GetType().Name + ".GetAsync() Error: " + ex.Message);
            return null;
        }
    }

    public bool DeleteAsync(string Id)
    {
        return true;
    }
}


