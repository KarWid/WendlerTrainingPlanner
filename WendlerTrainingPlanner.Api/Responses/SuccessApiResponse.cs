namespace WendlerTrainingPlanner.Api.Responses
{
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;
    using WendlerTrainingPlanner.Api.Contracts.Enums;

    public record SuccessApiResponse<T>(T Result) : ApiResponse<T>(Result, ResponseStatus.Success, new List<string>()) where T : class;
}
