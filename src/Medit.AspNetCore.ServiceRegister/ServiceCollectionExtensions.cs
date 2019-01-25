using Medit.AspNetCore.ServiceRegister.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Medit.AspNetCore.ServiceRegister
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceRegister(this IServiceCollection services, ServiceRegistrations registrations)
        {
            if (registrations == null)
                throw new ArgumentNullException(nameof(registrations));

            registrations.ForEach(serviceRegistration =>
            {
                services.Add(serviceRegistration.GetServiceDescriptor());
            });
            
            return services;
        }
    }
}
