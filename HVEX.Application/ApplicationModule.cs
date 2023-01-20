using HVEX.Application.Services.Implementations;
using HVEX.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddApplicationServices();           

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ITransformerService, TransformerService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
