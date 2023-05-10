using Microsoft.Data.SqlClient;
using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.BLL.Services;
using ServiceStation.DAL.Data.Contracts;
using ServiceStation.DAL.Interfaces.Contracts;
using ServiceStation.DAL.Repositories.Contracts;
using ServiceStation.DAL.Repositories;
using System.Data;
using Microsoft.AspNetCore.Identity;
using ServiceStation.DAL.Entities;
using Microsoft.Extensions.Configuration;
using ServiceStation.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ServiceStationDatabase.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ServiceStationIdentityDBContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);

});


builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IModelService, ModelService>();

builder.Services.AddScoped<IUnitOfBisnes, UnitOfBisnes>();

builder.Services.AddIdentityCore<Client>()
                   .AddRoles<IdentityRole>()
                   .AddSignInManager<SignInManager<Client>>()
                   .AddDefaultTokenProviders()
                   .AddEntityFrameworkStores<ServiceStationIdentityDBContext>();



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
