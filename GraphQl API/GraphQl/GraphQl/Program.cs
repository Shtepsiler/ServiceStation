using GraphQl;
using GraphQl.Data;
using GraphQl.DataLoader;
using GraphQl.Sessions;
using GraphQl.Speakers;
using GraphQl.Types;
using HotChocolate.AspNetCore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);

});

// GraphQl schema
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()

    .AddMutationType<Mutation>()

    .AddType<SpeakerType>()
    .AddType<AttendeeType>()
    .AddType<SessionType>()
    .AddType<TrackType>()    
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>()
    .AddDataLoader<AttendeeByIdDataLoader>()
    .AddDataLoader<TrackByIdDataLoader>()

    ;





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
   GraphQLEndpointConventionBuilder graphQLEndpointConventionBuilder = endpoints.MapGraphQL();
});

app.MapRazorPages();

app.Run();
