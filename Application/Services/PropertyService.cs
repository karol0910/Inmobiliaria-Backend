using PruebaInmobiApi.Application.DTOs;
using PruebaInmobiApi.Application.Interfaces;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Mappings;

namespace PruebaInmobiApi.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly PropertyMapper _propertyMapper;

    public PropertyService(IPropertyRepository propertyRepository, PropertyMapper propertyMapper)
    {
        _propertyRepository = propertyRepository;
        _propertyMapper = propertyMapper;
    }

    public async Task<List<PropertyDto>> GetPropertiesAsync(Dictionary<string, string> filters)
    {
        var properties = await _propertyRepository.GetPropertiesAsync(filters);
        return _propertyMapper.MapToDto(properties);
    }

    public async Task<PropertyDto?> GetByIdAsync(string id)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        return property == null ? null : _propertyMapper.MapToDto(property);
    }
}