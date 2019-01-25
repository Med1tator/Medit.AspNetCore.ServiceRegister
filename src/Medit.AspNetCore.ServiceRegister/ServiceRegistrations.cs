using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Medit.AspNetCore.ServiceRegister
{
    public class ServiceRegistrations : List<ServiceRegistration>
    {
    }

    public class ServiceRegistration
    {
        // Service interface type.
        public string ServiceType { get; set; }
        
        // Service implementation type.
        public string ImplementationType { get; set; }

        // Service implementation assembly relative path.
        public string ImplementationPath { get; set; }

        // Service lifetime, the default is Scoped.
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Scoped;
    }
}
