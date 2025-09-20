using PruebaInmobiApi.Application.DTOs;

namespace PruebaInmobiApi.Application.Interfaces;

public interface IPropertyService
{
    Task<List<PropertyDto>> GetPropertiesAsync(Dictionary<string, string> filters);
    Task<PropertyDto?> GetByIdAsync(string id);
}