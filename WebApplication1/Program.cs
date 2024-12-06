using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Models;




var builder = WebApplication.CreateBuilder(args);

var connetingString = builder.Configuration.GetConnectionString("ConnectDB");
builder.Services.AddDbContext<Shtirbu223ToysShopDbContext>(options  => options.UseNpgsql(connetingString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
