using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceStation.BLL.Configurations;
using ServiceStation.BLL.Factories.Interfaces;
using ServiceStation.BLL.Factories;
using ServiceStation.BLL.Mapping;
using ServiceStation.BLL.Services;
using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Data;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories;
using ServiceStation.DAL.Repositories.Contracts;
using FluentValidation;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo());
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  //  o.IncludeXmlComments(xmlPath);
    // Security
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


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

builder.Services.AddTransient<JwtTokenConfiguration>();
builder.Services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IMechanicRepository,MechanicRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IManagerService,ManagerService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IMechanicService,MechanicService>();
builder.Services.AddScoped<IUnitOfBisnes, UnitOfBisnes>();

builder.Services.AddTransient<EmailSender>();

builder.Services.AddScoped<IValidator<ClientSignInRequest>, ClientSignInRequestValidator>();
builder.Services.AddScoped<IValidator<ClientSignUpRequest>, ClientSingUpRequestValidator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new()
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"])),
                            ClockSkew = TimeSpan.Zero,
                        };
                    });

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
