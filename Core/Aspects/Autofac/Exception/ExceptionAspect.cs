
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using System.Linq;
using FluentValidation.Results;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionAspect : MethodInterception
    {
        private Type _type;
        public ExceptionAspect(Type type)
        {
            _type = type;
        }

        public override void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (WebException we)
            {
                OnException(invocation, we);
            }
            catch (System.Exception ex)
            {
                OnException(invocation, ex);
            }
        }


        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            var exceptionMessage = e.Message;
            string logMessage = string.Format("{0}: Error running {1}. {2}{3}", DateTime.Now, invocation.Method.Name, exceptionMessage, e.StackTrace);

            int instanceArgumentsLength = _type.GenericTypeArguments.Length;


            
            var instance = (IResult)(
                instanceArgumentsLength > 0 ?
                Activator.CreateInstance(_type, null, false, exceptionMessage)
                :
                Activator.CreateInstance(_type, false, exceptionMessage));
           
            instance.StatusCode = 500;
            if (e is WebException)
            {
                WebException? webEx = (WebException?)e;
                HttpWebResponse? response = webEx?.Response as HttpWebResponse;
                var status = response?.StatusCode;
                int statusCode = status != null ? (int)((HttpStatusCode)status) : 500;
                instance.StatusCode = statusCode;
            }
            else if (e is ValidationException)
            {
                ValidationException? validationException = (ValidationException?)e;
                instance.StatusCode = 400;
                foreach (var error in validationException?.Errors)
                {
                    instance.MessageList.Add(error.PropertyName, error.ErrorMessage);
                }
            } 

            invocation.ReturnValue = instance;
        }

    }

}
