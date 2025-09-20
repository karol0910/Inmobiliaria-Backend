using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Domain.Interfaces;

public interface IPropertyRepository
{
    Task<List<Property>> GetPropertiesAsync(Dictionary<string, string> filters);
    Task<Property?> GetByIdAsync(string id);
}