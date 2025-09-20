// Application/DTOs/PropertyDto.cs
namespace PruebaInmobiApi.Application.DTOs;

public class PropertyDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
}