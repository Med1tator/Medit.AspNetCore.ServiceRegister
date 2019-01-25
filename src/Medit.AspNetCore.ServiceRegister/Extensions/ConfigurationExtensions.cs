using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medit.AspNetCore.ServiceRegister.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetServiceRegistrations<T>(this IConfiguration configuration, string key = null)
            where T : class, new()
        {
            var result = new T();

            if (string.IsNullOrWhiteSpace(key))
                key = typeof(T).Name;
            configuration.Bind(key, result);

            return result;
        }
    }
}
