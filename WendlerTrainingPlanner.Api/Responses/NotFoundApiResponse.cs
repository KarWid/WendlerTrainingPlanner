namespace WendlerTrainingPlanner.Api.Responses
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;
    using WendlerTrainingPlanner.Api.Contracts.Enums;

    public record NotFoundApiResponse(IEnumerable<string> Errors) : ApiResponse(ResponseStatus.NotFound, Errors)
    {
        public NotFoundApiResponse(string error) : this(new List<string> { error }) { }
    }
}
