namespace WendlerTrainingPlanner.Api.Responses
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;
    using WendlerTrainingPlanner.Api.Contracts.Enums;

    public record BussinessLogicErrorApiResponse(IList<string> Errors) : ApiResponse(ResponseStatus.BusinessLogicError, Errors)
    {
        public BussinessLogicErrorApiResponse(string error) : this(new List<string> { error }) { }
    }
}
