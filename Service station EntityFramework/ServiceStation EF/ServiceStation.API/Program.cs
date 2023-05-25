using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceStation.BLL.Services;
using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Data;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories;
using ServiceStation.DAL.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceStationDContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);

});

builder.Services.AddAuthentication();
builder.Services.AddIdentityCore<Client>()
                   .AddRoles<IdentityRole<int>>()
                   .AddSignInManager<SignInManager<Client>>()
                   .AddDefaultTokenProviders()
                   .AddEntityFrameworkStores<ServiceStationDContext>();
/*builder.Services.AddDefaultIdentity<Client>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ServiceStationDContext>();*/

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IManagerRepositiry, ManagerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IModelService, ModelService>();

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
