using System.Collections.Generic;
using PruebaInmobiApi.Domain.Entities;

namespace PruebaInmobiApi.Tests.TestHelpers;

public static class PropertyTestData
{
    public static Property CreateProperty(string name = "Casa en Centro", decimal price = 1850000)
    {
        return new Property
        {
            Id = "1",
            Name = name,
            Address = "Av. Principal 456",
            Price = price,
            CodeInternal = "INT001",
            Year = 2025,
            IdOwner = "owner1",
            Image = "https://inmobiliariasantamariavera.com/images/fwre/properties/160/502257788_725235216632520_2422236283229673141_n.jpg",
            OwnerName = "Juan Pérez"
        };
    }

    public static List<Property> CreatePropertyList()
    {
        return new List<Property>
        {
            CreateProperty("Casa en Centro", 1850000),
            CreateProperty("Casa en el B. Las Brisas", 450000000),
            CreateProperty("Apartamento 202", 195000000),
            CreateProperty("Apartamento Moderno en Rivera-Huila", 320000000),
            CreateProperty("Local en Rivera-Huila", 320000000),
            CreateProperty("Finca Las Mercedes", 350000000)
        };
    }
}