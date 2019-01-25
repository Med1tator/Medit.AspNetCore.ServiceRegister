using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Medit.AspNetCore.ServiceRegister.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static ServiceDescriptor GetServiceDescriptor(this ServiceRegistration serviceRegistration)
        {
            if (serviceRegistration == null)
                throw new ArgumentNullException(nameof(serviceRegistration));

            var erviceTypeAndImplementationType = serviceRegistration.GetServiceTypeAndImplementationType();

            return new ServiceDescriptor(
                erviceTypeAndImplementationType.Item1,
                erviceTypeAndImplementationType.Item2,
                serviceRegistration.Lifetime);
        }

        private static Tuple<Type, Type> GetServiceTypeAndImplementationType(this ServiceRegistration serviceRegistration)
        {
            if (serviceRegistration == null)
                throw new ArgumentNullException(nameof(serviceRegistration));

            if (string.IsNullOrWhiteSpace(serviceRegistration.ImplementationType))
                throw new ArgumentNullException(nameof(serviceRegistration.ImplementationType));

            if (string.IsNullOrWhiteSpace(serviceRegistration.ImplementationPath))
                throw new ArgumentNullException(nameof(serviceRegistration.ImplementationPath));

            var assemblyPath = serviceRegistration.ImplementationPath;

            if (!Path.IsPathRooted(assemblyPath))
                assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyPath);

            var assembly = Assembly.LoadFrom(assemblyPath);

            if (assembly == null)
                throw new NullReferenceException($"Assembly was not loaded from path: {assemblyPath}");

            var implementationType = assembly.GetTypes().FirstOrDefault(o => o.Name == serviceRegistration.ImplementationType)
                ?? throw new Exception($"No type named was {serviceRegistration.ImplementationType} found.");

            var serviceType = implementationType.GetInterface(serviceRegistration.ServiceType) ??
                throw new NullReferenceException($"No type named was {serviceRegistration.ServiceType} found.");

            return new Tuple<Type, Type>(serviceType, implementationType);
        }
    }
}
