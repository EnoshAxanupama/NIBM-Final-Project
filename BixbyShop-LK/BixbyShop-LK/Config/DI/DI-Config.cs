using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BixbyShop_LK.Config.DI
{
    public static class ComponentRegistrationGenerator
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var targetAssembly = Assembly.GetExecutingAssembly();
            var classes = GetAnnotatedClasses(targetAssembly);

            foreach (var classType in classes)
            {
                var implementedInterfaces = classType.GetInterfaces();

                foreach (var interfaceType in implementedInterfaces)
                {
                    services.AddTransient(interfaceType, classType);
                }
            }
        }

        private static IEnumerable<Type> GetAnnotatedClasses(Assembly assembly)
        {
            var classes = assembly.GetTypes().Where(type => type.GetCustomAttributes<ComponentAttribute>().Any());
            return classes;
        }
    }
}
