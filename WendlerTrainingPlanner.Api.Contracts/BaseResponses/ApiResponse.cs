namespace WendlerTrainingPlanner.Api.Contracts.BaseResponses
{
    using WendlerTrainingPlanner.Api.Contracts.Enums;

    public record ApiResponse(ResponseStatus Status, IEnumerable<string> Errors)
    {
        public bool Success => Status == ResponseStatus.Success;
    }

    public record ApiResponse<T>(T Result, ResponseStatus Status, IEnumerable<string> Errors) 
        : ApiResponse(Status, Errors) 
        where T : class
    {
        
    }
}
