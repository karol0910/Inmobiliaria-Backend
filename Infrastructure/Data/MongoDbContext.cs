using MongoDB.Driver;
using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        Console.WriteLine($"Total propiedades en DB: {databaseName}");
        Console.WriteLine($"Total propiedades en DB: {connectionString}");
    }

public IMongoCollection<Property> Properties => _database.GetCollection<Property>("properties");
public IMongoCollection<PropertyTrace> PropertyTraces => _database.GetCollection<PropertyTrace>("propertytrace");
public IMongoCollection<PropertyImage> PropertyImages => _database.GetCollection<PropertyImage>("propertyimage");


}