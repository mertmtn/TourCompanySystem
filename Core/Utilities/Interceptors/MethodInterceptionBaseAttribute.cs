using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{

    /*
     * Base class’a attribute özelliği vererek 
     * aop modüllerimizin method ve class’ların üzerine yazılarak bir attribute gibi kullanılmasını sağlıyoruz.
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
