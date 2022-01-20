using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterType<GuideManager>().As<IGuideService>().SingleInstance();
            builder.RegisterType<EfGuideDal>().As<IGuideDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<PlaceManager>().As<IPlaceService>().SingleInstance();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>().SingleInstance();

            builder.RegisterType<TourManager>().As<ITourService>().SingleInstance();
            builder.RegisterType<EfTourDal>().As<ITourDal>().SingleInstance();

            builder.RegisterType<InvoiceManager>().As<IInvoiceService>().SingleInstance();
            builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>().SingleInstance();

            builder.RegisterType<TouristManager>().As<ITouristService>().SingleInstance();
            builder.RegisterType<EfTouristDal>().As<ITouristDal>().SingleInstance();

            builder.RegisterType<NationalityManager>().As<INationalityService>().SingleInstance();
            builder.RegisterType<EfNationalityDal>().As<INationalityDal>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
