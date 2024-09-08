using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiToCleanArchitecture.Application.Services;
using WebApiToCleanArchitecture.Domain.Interfaces;
using WebApiToCleanArchitecture.Infrastructure.Data;
using WebApiToCleanArchitecture.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);

var connec = builder.Configuration.GetConnectionString("ConnectSQL");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connec));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
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
