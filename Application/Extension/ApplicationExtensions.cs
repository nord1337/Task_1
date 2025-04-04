using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extension;

public static class ApplicationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(conf =>
        {
            conf.AddMaps(Assembly.GetExecutingAssembly());
            conf.CreateMap<AddValueDto, ValueEntity>();
            conf.CreateMap<ValueEntity, GetValueDto>();
        });
        services.AddScoped<IValuesRepo, ValuesRepo>();
    }
}
