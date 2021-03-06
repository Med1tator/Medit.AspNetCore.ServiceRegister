﻿using Medit.AspNetCore.ServiceRegister.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Medit.AspNetCore.ServiceRegister
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceRegister(this IServiceCollection services, ServiceRegistrations registrations)
        {
            if (registrations == null)
                throw new ArgumentNullException(nameof(registrations));

            ServiceRegistrationsFilter(registrations);

            registrations.ForEach(serviceRegistration =>
            {
                services.Add(serviceRegistration.GetServiceDescriptor());
            });

            return services;
        }

        public static IServiceCollection AddServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var registrations = configuration.GetServiceRegistrations<ServiceRegistrations>();

            ServiceRegistrationsFilter(registrations);

            services.AddServiceRegister(registrations);

            return services;
        }

        private static void ServiceRegistrationsFilter(ServiceRegistrations registrations)
        {
            registrations.RemoveAll(o => string.IsNullOrWhiteSpace(o.ServiceType) || string.IsNullOrWhiteSpace(o.ImplementationType) || string.IsNullOrWhiteSpace(o.ImplementationPath));
        }
    }
}
