using MongoDB.Driver;
using MongoDB.Bson;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Data;

namespace PruebaInmobiApi.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly IMongoCollection<Property> _properties;

    public PropertyRepository(MongoDbContext context)
    {
        _properties = context.Properties;
    }

    public async Task<List<Property>> GetPropertiesAsync(Dictionary<string, string> filters)
    {
          try
    {
        var pingResult = await _properties.Database.RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1));
        Console.WriteLine("✅ Conexión a MongoDB exitosa");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error de conexión a MongoDB: {ex.Message}");
    }
        var filter = Builders<Property>.Filter.Empty;

        if (filters.ContainsKey("name") && !string.IsNullOrEmpty(filters["name"]))
        {
            var nameFilter = filters["name"];
            filter &= Builders<Property>.Filter.Regex(x => x.Name, new BsonRegularExpression($"^{nameFilter}", "i"));        }

        if (filters.ContainsKey("address") && !string.IsNullOrEmpty(filters["address"]))
        {
            var addressFilter = filters["address"];
            filter &= Builders<Property>.Filter.Regex(x => x.Address, new BsonRegularExpression(addressFilter, "i"));
        }

        if (filters.ContainsKey("minPrice") && decimal.TryParse(filters["minPrice"], out var minPrice))
            filter &= Builders<Property>.Filter.Gte(x => x.Price, minPrice);

        if (filters.ContainsKey("maxPrice") && decimal.TryParse(filters["maxPrice"], out var maxPrice))
            filter &= Builders<Property>.Filter.Lte(x => x.Price, maxPrice);

         var allProperties = await _properties.Find(_ => true).ToListAsync();
    
    Console.WriteLine($"Total propiedades en DB: {allProperties.Count}");
    foreach (var prop in allProperties)
    {
        Console.WriteLine($"Propiedad: {prop.Name} - Precio: {prop.Price}");
    }

        return await _properties.Find(filter).ToListAsync();
    }

    public async Task<Property?> GetByIdAsync(string id)
    {
        return await _properties.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}