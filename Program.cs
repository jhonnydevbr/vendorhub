using Microsoft.OpenApi;
using vendorhub.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfig()
    .AddSwaggerConfig();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
