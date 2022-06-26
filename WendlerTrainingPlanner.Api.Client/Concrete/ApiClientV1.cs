namespace WendlerTrainingPlanner.Api.Client.Concrete
{
    using RestSharp;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts.BaseResponses;
    using Contracts.V1.Requests.TrainingPlanTemplate;
    using Contracts.V1.Responses.TrainingPlanTemplate;
    using WendlerTrainingPlanner.Api.Client.Abstract;

    public class ApiClientV1 : BaseApiClient, IApiClientV1
    {
        private readonly string _endpointPrefix = "/api/v1";

        public ApiClientV1(RestClient restClient) : base(restClient) {}

        /// <inheritdoc cref="IApiClientV1"/>
        public async Task<ApiResponse<CreateTrainingPlanTemplateResponse>?> TrainingPlanTemplateCreate(
            CreateTrainingPlanTemplateRequest request, 
            CancellationToken cancellationToken = default)
        {
            var restRequest = new RestRequest($"{_endpointPrefix}/{TRAINING_PLAN_TEMPLATE}", Method.Post);

            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(request);

            var result = await _restClient.ExecuteAsync<ApiResponse<CreateTrainingPlanTemplateResponse>>(restRequest, cancellationToken);

            if (result.ErrorException != null)
            {
                throw result.ErrorException;
            }

            return result?.Data;
        }


        //public ApiClientV1(HttpClient httpClient, string apiUrl) : base(httpClient, apiUrl, 1) { }

        ///// <inheritdoc cref="IApiClientV1"></inheritdoc>
        //public async Task<IApiResponse<CreateTrainingPlanTemplateResponse>> TrainingPlanTemplateCreate(CreateTrainingPlanTemplateRequest request)
        //{
        //    var result = await _httpClient.PostAsJsonAsync(TRAINING_PLAN_TEMPLATE, request);
        //    return await result.Content.ReadAsAsync<ApiResponse<CreateTrainingPlanTemplateResponse>>();
        //}

        ///// <inheritdoc cref="IApiClientV1"></inheritdoc>
        //public async Task<IApiResponse<CreateTrainingPlanTemplateResponse>> TrainingPlanTemplateCreate(CreateTrainingPlanTemplateRequest request, CancellationToken cancellationToken)
        //{
        //    var result = await _httpClient.PostAsJsonAsync(TRAINING_PLAN_TEMPLATE, request, cancellationToken);
        //    return await result.Content.ReadAsAsync<ApiResponse<CreateTrainingPlanTemplateResponse>>();
        //}
    }
}
