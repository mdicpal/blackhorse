namespace Orchestrator.Database.Extensions;

using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repositories;
using System;

public static class DatabaseDependencyExtensions
{
    public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
    {
        string sqlConnection = Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.Process) ?? string.Empty;
        return services
            .AddAutoMapper()
            .AddEntityFramework(sqlConnection)
            .AddTransient<IInstanceToPollRepository, InstanceToPollRepository>();
    }
        
    private static IServiceCollection AddEntityFramework(this IServiceCollection services, string sqlConnection)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(sqlConnection,
                x => x.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(50),
                    errorNumbersToAdd: null
                )
            )
        );

        services.AddTransient<IInstanceToPollRepository, InstanceToPollRepository>();
        return services;
    }
        
    private static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        MapperConfiguration mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<InstanceToPollDto, InstanceToPoll>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
        });

        IMapper mapper = mapperConfig.CreateMapper();
        // Register the mapper instance for dependency injection if necessary
        services.AddSingleton<IMapper>(mapper);
        return services;
    }
}