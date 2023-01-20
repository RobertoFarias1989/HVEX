using HVEX.Core.Repositories;
using HVEX.Infrastructure.Persistence;
using HVEX.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddMongo()
            .AddRepositories();

        return services;
    }

    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbOptions>(sp => {
            var configuration = sp.GetService<IConfiguration>();
            var options = new MongoDbOptions();

            configuration.GetSection("Mongo").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp => {
            var configuration = sp.GetService<IConfiguration>();
            var options = sp.GetService<MongoDbOptions>();

            var client = new MongoClient(options.ConnectionString);
            var db = client.GetDatabase(options.Database);

            //var dbSeed = new DbSeed(db);
            //dbSeed.Populate();

            return client;
        });

        services.AddTransient(sp => {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();

            var db = mongoClient.GetDatabase(options.Database);

            return db;
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITestRepository, TestRepository>();
        services.AddScoped<ITransformerRepository, TransformerRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        return services;
    }
}
