namespace WendlerTrainingPlanner.Infrastructure.EF
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class WendlerTrainingPlannerInstallers
    {
        public static IServiceCollection AddWendlerTrainingPlannerEFDbServices(this IServiceCollection services)
        {
            services.AddDbContextPool<WendlerTrainingPlannerDbContext>(options =>
            {
                options.UseNpgsql(Environment.GetEnvironmentVariable(Constant.EnvironmentVariable.DATABASE_CONNECTION_STRING));
            });

            return services;
        }
    }
}
