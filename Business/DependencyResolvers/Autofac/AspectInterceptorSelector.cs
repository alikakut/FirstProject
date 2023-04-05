using Autofac;
using Castle.DynamicProxy;

namespace Business.DependencyResolvers.Autofac
{
    public partial class AutofacBusinessModule
    {
        public class AspectInterceptorSelector : IInterceptorSelector
        {
            public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
            {
                return type.GetInterfaces()
                    .Where(t => typeof(IAspect).IsAssignableFrom(t))
                    .Select(t => (IInterceptor)Activator.CreateInstance(t))
                    .ToArray();
            }
        }

    }
}

