﻿using Cassandra;
using FluentValidation;
using Lab3.Discussion.Data;
using Lab3.Discussion.Infrastructure.Mapper;
using Lab3.Discussion.Infrastructure.Validators;
using Lab3.Discussion.Models;
using Lab3.Discussion.Repositories.Implementations;
using Lab3.Discussion.Repositories.Interfaces;
using Lab3.Discussion.Services.Impementations;
using Lab3.Discussion.Services.Interfaces;

namespace Lab3.Discussion.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddCassandra(this IServiceCollection services, IConfiguration config)
        {
            var address = config.GetValue<string>("Cassandra:Address");
            var schema = config.GetValue<string>("Cassandra:Schema");
            var session = new CassandraConnector(address!, schema!).GetSession();
            services.AddSingleton(session);
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICassandraRepository<Note>, CassandraNoteRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssemblyContaining<NoteRequestDtoValidator>();

            return services;
        }
    }
}
