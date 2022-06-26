namespace WendlerTrainingPlanner.Api.Responses
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;
    using WendlerTrainingPlanner.Api.Contracts.Enums;

    public record DatabaseErrorApiResponse(IList<string> Errors) : ApiResponse(ResponseStatus.DatabaseError, Errors)
    {
        public DatabaseErrorApiResponse(string error) : this(new List<string> { error }) { }
    }
}
