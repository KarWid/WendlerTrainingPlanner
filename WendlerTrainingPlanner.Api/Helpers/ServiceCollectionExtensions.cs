namespace WendlerTrainingPlanner.Api.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;


    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Initializes the database context.
        /// </summary>
        /// <param name="services"></param>
        //public static IServiceCollection AddDbContext(this IServiceCollection services)
        //{
        //    services.AddDbContextPool<GymTrainingPlannerDbContext>(options =>
        //        options.UseNpgsql(Environment.GetEnvironmentVariable(CqrsConstant.EnvironmentVariablesConstant.CONNECTION_STRING)));
        //    services.AddIdentity<ApplicationUserEntity, ApplicationRoleEntity>().AddEntityFrameworkStores<GymTrainingPlannerDbContext>();

        //    return services;
        //}

        /// <summary>
        /// Configures swagger.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1",
                    Title = "Wendler Training Planner API",
                    Description = "Wendler Training Planner API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = string.Empty,
                        Email = string.Empty,
                        Url = new Uri("https://example.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License - TODO",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            return services;
        }

        /// <summary>
        /// Configures mapper.
        /// </summary>
        /// <param name="services"></param>
        /// TODO @KWidla: uncomment
        //public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        //{
        //    var configuration = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddMaps(typeof(AccountProfile).Assembly);
        //        cfg.AddMaps(typeof(UserMapperProfile).Assembly);
        //    });

        //    services.AddSingleton(configuration.CreateMapper());

        //    return services;
        //}
    }
}

