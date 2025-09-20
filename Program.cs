using Microsoft.OpenApi.Models;
using PruebaInmobiApi.Application.Interfaces;
using PruebaInmobiApi.Application.Services;
using PruebaInmobiApi.Domain.Interfaces;
using PruebaInmobiApi.Infrastructure.Data;
using PruebaInmobiApi.Infrastructure.Mappings;
using PruebaInmobiApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba Inmobi API", Version = "v1" });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDB") ?? "mongodb://localhost:27017";
var databaseName = "test";

builder.Services.AddSingleton(new MongoDbContext(mongoConnectionString, databaseName));
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
builder.Services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<PropertyMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend"); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();