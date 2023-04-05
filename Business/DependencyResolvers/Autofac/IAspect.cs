using Castle.DynamicProxy;

namespace Business.DependencyResolvers.Autofac
{
    public partial class AutofacBusinessModule
    {
        public interface IAspect : IInterceptor
        {
        }

    }
}

