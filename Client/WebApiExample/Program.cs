using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Web.Framework.Api.FluentValidation;
using WebApiExample.Core.DTO.Search;
using WebApiExample.Core.DTO;
using WebApiExample.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddFluentValidationAutoValidation(fv =>
{
    //fv.ImplicitlyValidateChildProperties = true;
}).AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API",
        Version = "v1",
        Contact = new OpenApiContact { Email = "oshastitko@3mdsolutions.com", Name = "Oleg Shastitko" }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// uncomment for implementation
//builder.Services.AddTransient<IRegisteredDeviceService, RegisteredDeviceService>();
//builder.Services.AddTransient<IRevokedDeviceService, RevokedDeviceService>();
//builder.Services.AddTransient<IAdminVendorService, AdminVendorService>();
//builder.Services.AddTransient<IVendorService, VendorService>();


builder.Services.AddTransient<IValidator<VendorCreateDto>, VendorCreateValidation>();
builder.Services.AddTransient<IValidator<VendorUpdateDto>, VendorUpdateValidation>();
builder.Services.AddTransient<IValidator<SearchRegisteredDeviceDto>, SearchRegisteredDeviceValidation>();
builder.Services.AddTransient<IValidator<SearchRevokedDeviceDto>, SearchRevokedDeviceValidation>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
