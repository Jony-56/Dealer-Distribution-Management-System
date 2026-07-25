using AutoMapper;
using DDMS.Application.Common.Mappings;
using DDMS.Application.Features.Brands.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BrandProfile).Assembly);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IBrandService, BrandService>();

        return services;
    }
}