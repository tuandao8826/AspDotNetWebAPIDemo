using DotNetCoreWebAPIWithAngular_BE.Application;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Extensions;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kết nối database 
builder.Services.AddDbContext<WebAPIWithAngularDemoContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Repositories
builder.Services.AddRepositories();

// MediaR
builder.Services.AddApplicationMediaR();

// Build App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Đăng ký Middleware
//app.UseMiddleware<SimpleMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
