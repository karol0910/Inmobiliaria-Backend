using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Domain.Interfaces;

public interface IPropertyTraceRepository
{
    Task<List<PropertyTrace>> GetByPropertyIdAsync(string idProperty);
}