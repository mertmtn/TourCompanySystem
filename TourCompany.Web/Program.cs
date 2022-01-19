using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<TourCompanyDbContext>();

builder.Services.AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true);

builder.Services.AddTransient<IGuideService, GuideManager>();
builder.Services.AddSingleton<IGuideDal, EfGuideDal>();

builder.Services.AddTransient<ILanguageService, LanguageManager>();
builder.Services.AddSingleton<ILanguageDal, EfLanguageDal>();

builder.Services.AddTransient<IPlaceService, PlaceManager>();
builder.Services.AddSingleton<IPlaceDal, EfPlaceDal>();
builder.Services.AddTransient<IPlaceService, PlaceManager>();
builder.Services.AddSingleton<IPlaceDal, EfPlaceDal>();

builder.Services.AddTransient<ITourService, TourManager>();
builder.Services.AddSingleton<ITourDal, EfTourDal>();

builder.Services.AddTransient<IInvoiceService, InvoiceManager>();
builder.Services.AddSingleton<IInvoiceDal, EfInvoiceDal>();

builder.Services.AddTransient<ITouristService, TouristManager>();
builder.Services.AddSingleton<ITouristDal, EfTouristDal>();

builder.Services.AddTransient<INationalityService, NationalityManager>();
builder.Services.AddSingleton<INationalityDal, EfNationalityDal>();

builder.Services.AddTransient<ICountryService, CountryManager>();
builder.Services.AddSingleton<ICountryDal, EfCountryDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


 