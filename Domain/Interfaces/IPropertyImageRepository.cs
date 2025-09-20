using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Domain.Interfaces;

public interface IPropertyImageRepository
{
    Task<List<PropertyImage>> GetByPropertyIdAsync(string idProperty);
}