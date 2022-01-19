using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IOC;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public CoreModule()
        {
        }

        public void Load(IServiceCollection services)
        {
          
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          
        }
    }
}
