using MongoDB.Driver;
using MongoDB.Bson;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Data;

namespace PruebaInmobiApi.Infrastructure.Repositories;

public class PropertyTraceRepository : IPropertyTraceRepository
{
    private readonly IMongoCollection<PropertyTrace> _propertyTraces = null!;

    public PropertyTraceRepository(MongoDbContext context)
    {
        _propertyTraces = context.PropertyTraces;
    }

  public async Task<List<PropertyTrace>> GetByPropertyIdAsync(string idProperty)
{

    if (string.IsNullOrEmpty(idProperty))
    {
        return new List<PropertyTrace>();
    }

    try
    {
        var pingResult = await _propertyTraces.Database.RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1));

        var totalDocs = await _propertyTraces.CountDocumentsAsync(_ => true);

        var allDocs = await _propertyTraces.Find(_ => true).Limit(5).ToListAsync();

        foreach (var doc in allDocs)
        {
            Console.WriteLine($"   - IdProperty: '{doc.IdProperty}' (Tipo: {doc.IdProperty?.GetType().Name ?? "null"}, Longitud: {doc.IdProperty?.Length ?? 0})");
        }

        var filter = Builders<PropertyTrace>.Filter.Eq(x => x.IdProperty, idProperty);
        var result = await _propertyTraces.Find(filter).ToListAsync();

        foreach (var item in result)
        {
            Console.WriteLine($"Encontrado: IdProperty = '{item.IdProperty}'");
        }

        return result;
    }
    catch
    {
        throw; 
    }
}
    
}