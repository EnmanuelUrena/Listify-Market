using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ExtensionMethod
{
    public static IServiceCollection ConfigureServices(this IServiceCollection service)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());

        return service;
    }
}
