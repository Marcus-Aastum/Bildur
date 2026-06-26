using Bildur;
using Bildur.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
const string HELSEIDSCHEME = "helseid";

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ImageService>();

builder.Services.AddMudServices();

builder.Services.AddTransient<OidcEvents>();

builder.Services.AddAuthentication(HELSEIDSCHEME).AddOpenIdConnect(HELSEIDSCHEME, oidcOptions =>
{
    oidcOptions.Authority = builder.Configuration.GetValue<string>("Authority");
    oidcOptions.ClientId = builder.Configuration.GetValue<string>("ClientId");

    oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.Require;
    oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
    oidcOptions.ResponseMode = OpenIdConnectResponseMode.Query;

    oidcOptions.Scope.Add("offline_access");
    oidcOptions.Scope.Add("openid");

    oidcOptions.EventsType = typeof(OidcEvents);

    oidcOptions.SaveTokens = true;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapGroup("/authentication").MapLoginAndLogout();

app.Run();
