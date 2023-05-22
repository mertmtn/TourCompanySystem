using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryription;
using Core.Utilities.Security.JsonWebToken;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.Configure<TokenOptions>(
    builder.Configuration.GetSection("TokenOptions"));

builder.Services.AddDbContext<TourCompanyDbContext>();

builder.Services.AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true);

//Configure JWT Token Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(token =>
    {
        token.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.Response.Redirect("/Account/Login");
                context.HandleResponse();

                return Task.FromResult(0);
            }
        };
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


builder.Services.AddDependencyResolvers(new ICoreModule[]
{
                new CoreModule(),
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
//Add JWToken to all incoming HTTP Request Header
app.Use(async (context, next) =>
{
    var JWToken = context.Session.GetString("JWToken");
    if (!string.IsNullOrEmpty(JWToken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
    }
    await next();
});
 
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;


        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is UnauthorizedAccessException)
        {
            context.Response.Redirect("/Error/Error401");
        }
        else if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        {
            context.Response.Redirect("/Error/Error404");
        }
        else
        {
            context.Response.Redirect("/Error/Error500");
        }
    });
});
//Add JWToken Authentication service
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();



