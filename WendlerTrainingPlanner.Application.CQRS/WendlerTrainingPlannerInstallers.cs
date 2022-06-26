namespace WendlerTrainingPlanner.Application.CQRS
{
    using System.Reflection;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate;

    public static partial class WendlerTrainingPlannerInstallers
    {
        public static IServiceCollection AddWendlerTrainingPlannerCQRS
            (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddCqrsServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateTrainingPlanTemplateCommand>, CreateTrainingPlanTemplateCommandValidator>();

            return services;
        }
    }
}
