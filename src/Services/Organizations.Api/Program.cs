
using Organizations.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var serviceApiGroup = app.MapGroup("/organizations");

serviceApiGroup.MapPost("/", OrganizationController.Create)
   .WithName("Create")
   .WithOpenApi();

app.Run();