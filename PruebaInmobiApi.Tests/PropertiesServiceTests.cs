using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaInmobiApi.Application.Services;
using PruebaInmobiApi.Domain.Entities;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Mappings;
using PruebaInmobiApi.Tests.TestHelpers;

namespace PruebaInmobiApi.Tests;

[TestFixture]
public class PropertiesServiceTests
{
    private Mock<IPropertyRepository> _mockRepository;
    private PropertyMapper _mapper;
    private PropertyService _service;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IPropertyRepository>();
        _mapper = new PropertyMapper();
        _service = new PropertyService(_mockRepository.Object, _mapper);
    }

    [Test]
    public async Task GetPropertiesAsync_ReturnsMappedProperties()
    {
        var properties = PropertyTestData.CreatePropertyList();
        _mockRepository.Setup(r => r.GetPropertiesAsync(It.IsAny<Dictionary<string, string>>()))
                       .ReturnsAsync(properties);

        var result = await _service.GetPropertiesAsync(new Dictionary<string, string>());

        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Count);
        Assert.AreEqual("Casa en Centro", result[0].Name);
        Assert.AreEqual(1850000, result[0].Price);
    }

    [Test]
    public async Task GetByIdAsync_ReturnsMappedProperty()
    {
        var property = PropertyTestData.CreateProperty();
        _mockRepository.Setup(r => r.GetByIdAsync("1"))
                       .ReturnsAsync(property);

        var result = await _service.GetByIdAsync("1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Casa en Centro", result.Name);
        Assert.AreEqual("Juan Pérez", result.OwnerName);
    }
}