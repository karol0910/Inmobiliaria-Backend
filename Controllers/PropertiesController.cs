using Microsoft.AspNetCore.Mvc;
using PruebaInmobiApi.Application.DTOs;
using PruebaInmobiApi.Application.Interfaces;

namespace PruebaInmobiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    private readonly ILogger<PropertiesController> _logger;

    public PropertiesController(IPropertyService propertyService,  ILogger<PropertiesController> logger)
    {
        _propertyService = propertyService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PropertyDto>>> Get([FromQuery] Dictionary<string, string> filters)
    {
        try
        {
            var properties = await _propertyService.GetPropertiesAsync(filters);
            return Ok(properties);
        }
        catch 
        {
            return StatusCode(500, "Error al obtener propiedades.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyDto>> GetById(string id)
    {
        try
        {
            var property = await _propertyService.GetByIdAsync(id);
            if (property == null)
                return NotFound();

            return Ok(property);
        }
        catch
        {
            return StatusCode(500, "Error al obtener propiedad.");
        }
    }
}