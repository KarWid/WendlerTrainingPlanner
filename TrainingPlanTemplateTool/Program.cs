using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;
using WendlerTrainingPlanner.Api.Client.Concrete;
using WendlerTrainingPlanner.Api.Contracts.Dtos;
using WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise;
using WendlerTrainingPlanner.Api.Contracts.V1.Requests.TrainingPlanTemplate;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = BuildConfiguration();

        // TODO maybe use some factory
        var restClient = new RestClient(configuration["WendlerTrainingPlannerApiUrl"]);

        var wendlerTrainingPlannerApiClient = new ApiClientV1(restClient);

        var exercises = new List<BaseAccessoryExerciseDto>()
        {
            new AccessoryExerciseDto(1, "Wykroki", 5, 10, 10)
        };

        var accessoryExercises = new AccessoryExercisesDto(exercises);

        var trainingDays = new List<DayOfTrainingPlanTemplateDto>()
        {
            new DayOfTrainingPlanTemplateDto(DayOfWeek.Monday, 1, 100, accessoryExercises)
        };

        var createTrainingPlanTemplateRequest = new CreateTrainingPlanTemplateRequest("Nowa nazwa planu", DateTime.Now.AddDays(1), 3, 0.85f, 1, trainingDays);

        var serialized = JsonSerializer.Serialize<object>(createTrainingPlanTemplateRequest);
        Console.WriteLine(serialized);

        try
        {
            var result = await wendlerTrainingPlannerApiClient.TrainingPlanTemplateCreate(createTrainingPlanTemplateRequest);
            Console.WriteLine($"Result:\n{result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        Console.Read();

    }

    // TODO: It might be extended by environments
    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: true);

        return builder.Build();
    }
}

