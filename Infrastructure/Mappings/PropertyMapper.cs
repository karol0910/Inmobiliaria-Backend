using PruebaInmobiApi.Application.DTOs;
using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Infrastructure.Mappings;

public class PropertyMapper
{
    public List<PropertyDto> MapToDto(List<Property> properties)
    {
        return properties.Select(p => new PropertyDto
        {
            Id = p.Id,
            Name = p.Name,
            Address = p.Address,
            Price = p.Price,
            Image = p.Image,
            OwnerName = p.OwnerName
        }).ToList();
    }

    public PropertyDto MapToDto(Property property)
    {
        return new PropertyDto
        {
            Id = property.Id,
            Name = property.Name,
            Address = property.Address,
            Price = property.Price,
            Image = property.Image,
            OwnerName = property.OwnerName
        };
    }
}