using MongoDB.Driver;
using MongoDB.Bson;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Data;

namespace PruebaInmobiApi.Infrastructure.Repositories;

public class PropertyImageRepository : IPropertyImageRepository
{
    private readonly IMongoCollection<PropertyImage> _propertyImages;

    public PropertyImageRepository(MongoDbContext context)
    {
        _propertyImages = context.PropertyImages;
    }

    public async Task<List<PropertyImage>> GetByPropertyIdAsync(string idProperty)
    {
        var filter =Builders<PropertyImage>.Filter.Eq(x => x.IdProperty, idProperty);
        return await _propertyImages.Find(filter).ToListAsync();
    }
}