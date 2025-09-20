using Microsoft.AspNetCore.Mvc;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;

namespace PruebaInmobiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyImageController : ControllerBase
{
    private readonly IPropertyImageRepository _propertyImageRepository;

    public PropertyImageController(IPropertyImageRepository propertyImageRepository)
    {
        _propertyImageRepository = propertyImageRepository;
    }

[HttpGet]
public async Task<ActionResult<List<PropertyImage>>> GetByPropertyId(string idProperty)
{
    Console.WriteLine($"[IMAGE] Recibido idProperty: {idProperty}");
    
    if (string.IsNullOrEmpty(idProperty))
    {
        Console.WriteLine("[IMAGE] idProperty es null o vacío");
        return BadRequest("idProperty es requerido");
    }

    try
    {
        var images = await _propertyImageRepository.GetByPropertyIdAsync(idProperty);

        if (images == null || images.Count == 0)
        {
            return NotFound("No se encontraron imágenes para esta propiedad.");
        }
        return Ok(images);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[IMAGE] Error: {ex.Message}");
        return StatusCode(500, $"Error al obtener imágenes: {ex.Message}");
    }
}
}