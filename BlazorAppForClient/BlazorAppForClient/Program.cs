using BlazorAppForClient.Areas.Identity;
using BlazorAppForClient.Authentication;
using BlazorAppForClient.Extensions;
using BlazorAppForClient.Interfaces;
using BlazorAppForClient.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;

using MudBlazor.Services;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddBlazoredLocalStorage(); 
builder.Services.AddMudServices();
builder.Services.AddAuthenticationCore();
string APIBaseString = builder.Configuration["APIBaseString"];
/*builder.Services.AddMvc()
                    .AddFluentValidation(configuration =>
                    {
                        configuration.RegisterValidatorsFromAssemblies(
                            AppDomain.CurrentDomain.GetAssemblies());
                    });*/

builder.Services.AddTransient<RequestErrorsHandler>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
                provider => provider.GetRequiredService<ApiAuthenticationStateProvider>());



builder.Services.AddScoped<ApiHttpClient>();

builder.Services.AddHttpClient<IJobService, JobService>(httpClient =>
{
    httpClient.BaseAddress = new($"{APIBaseString}/api/Job/");
});
builder.Services.AddHttpClient<ITeamService, TeamService>(httpClient =>
{
    httpClient.BaseAddress = new($"{APIBaseString}/api/Mechanic/");
});
/*builder.Services.AddHttpClient<IIdentityService, IdentityService>(httpClient =>
{
    httpClient.BaseAddress = new($"{APIBaseString}/api/Manager/");
});
builder.Services.AddHttpClient<IIdentityService, IdentityService>(httpClient =>
{
    httpClient.BaseAddress = new($"{APIBaseString}/api/Model/");
});*/





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
