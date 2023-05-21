using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Security.JsonWebToken;
using Data.Abstract;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        /// <summary>
        /// Dependency lifetimes
        /// <br/>
        /// <b>Transient:</b> InstancePerDependency();<br/>
        /// <b>Scoped:</b> InstancePerLifetimeScope();<br/>
        /// <b>Singleton:</b> SingleInstance();<br/>
        /// </summary> 
        protected override void Load(ContainerBuilder builder)
        { 
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();          

            builder.RegisterType<GuideManager>().As<IGuideService>().InstancePerDependency();
            builder.RegisterType<EfGuideDal>().As<IGuideDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().InstancePerDependency();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<PlaceManager>().As<IPlaceService>().InstancePerDependency();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>().SingleInstance();

            builder.RegisterType<TourManager>().As<ITourService>().InstancePerDependency();
            builder.RegisterType<EfTourDal>().As<ITourDal>().SingleInstance();

            builder.RegisterType<InvoiceManager>().As<IInvoiceService>().InstancePerDependency();
            builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>().SingleInstance();

            builder.RegisterType<TouristManager>().As<ITouristService>().InstancePerDependency();
            builder.RegisterType<EfTouristDal>().As<ITouristDal>().SingleInstance();

            builder.RegisterType<NationalityManager>().As<INationalityService>().InstancePerDependency();
            builder.RegisterType<EfNationalityDal>().As<INationalityDal>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().InstancePerDependency();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();


            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
