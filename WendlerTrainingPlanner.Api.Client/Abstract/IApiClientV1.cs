namespace WendlerTrainingPlanner.Api.Client.Abstract
{
    using Contracts.BaseResponses;
    using Contracts.V1.Requests.TrainingPlanTemplate;
    using Contracts.V1.Responses.TrainingPlanTemplate;

    public interface IApiClientV1
    {
        /// <summary>
        /// Creates training plan template with 2 subtemplates.
        /// </summary>
        /// <param name="request">Request object to create new training plan template.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Returns newly created unique identifier.</returns>
        Task<ApiResponse<CreateTrainingPlanTemplateResponse>?> TrainingPlanTemplateCreate(CreateTrainingPlanTemplateRequest request, CancellationToken cancellationToken = default);
    }
}
