using Microsoft.AspNetCore.Mvc;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;

namespace PruebaInmobiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyTraceController : ControllerBase
{
    private readonly IPropertyTraceRepository _propertyTraceRepository;

    public PropertyTraceController(IPropertyTraceRepository propertyTraceRepository)
    {
        _propertyTraceRepository = propertyTraceRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<PropertyTrace>>> GetByPropertyId(string idProperty)
    {
        try
        {
            var traces = await _propertyTraceRepository.GetByPropertyIdAsync(idProperty);
            return Ok(traces);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error al obtener trazas de propiedad.");
        }
    }
}