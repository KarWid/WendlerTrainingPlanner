using System.Text.Json;
using RestSharp;
using WendlerTrainingPlanner.Api.Client.Concrete;
using WendlerTrainingPlanner.Api.Contracts.Dtos;
using WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise;
using WendlerTrainingPlanner.Api.Contracts.V1.Requests.TrainingPlanTemplate;

//var restClient = new RestClient("https://wendler-training-planner-api.com");
var restClient = new RestClient("http://wendler-training-planner-api.com");
//var restClient = new RestClient("https://localhost:44300");
var wendlerTrainingPlannerApiClient = new ApiClientV1(restClient);

List<BaseAccessoryExerciseDto> exercises = new List<BaseAccessoryExerciseDto>()
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
    Console.WriteLine($"Result {result != null}");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.Read();
