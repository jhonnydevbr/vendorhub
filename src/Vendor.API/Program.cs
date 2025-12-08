using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using vendorhub.Configuration;
using vendorhub.Model;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfig()
    .AddSwaggerConfig();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
