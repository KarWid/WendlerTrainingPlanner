using System.Reflection;

namespace WendlerTrainingPlanner.Api.Helpers
{
    public static partial class WendlerTrainingPlannerInstallers
    {
        public static IServiceCollection AddWendlerTrainingPlannerApi
            (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
