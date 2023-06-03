using ServiceStation.DAL.Repositories.Contracts;
using ServiceStation.DAL.Repositories;
using System.Data;
using System.Data.SqlClient;
using ServiceStation.BAL.Services.Interfaces;
using ServiceStation.BAL.Services;
/*using Microsoft.EntityFrameworkCore;
*/using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));

builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IMechanicsTasksRepository, MechanicsTasksRepository>();
builder.Services.AddScoped<IPartNeededRepository, PartNeededRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IJobService, JobService>(); 
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IMechanicsTasksService, MechanicsTasksService>();
builder.Services.AddScoped<IPartNeededService, PartNeededService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IUnitOfBisnes, UnitOfBisnes>();






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
