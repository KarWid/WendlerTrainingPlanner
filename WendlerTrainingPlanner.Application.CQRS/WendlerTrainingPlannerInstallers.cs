namespace WendlerTrainingPlanner.Application.CQRS
{
    using System.Reflection;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class WendlerTrainingPlannerInstallers
    {
        public static IServiceCollection AddWendlerTrainingPlannerCQRS
            (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
