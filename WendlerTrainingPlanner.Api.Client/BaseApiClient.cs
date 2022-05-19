namespace WendlerTrainingPlanner.Api.Client
{
    using RestSharp;

    public abstract class BaseApiClient
    {
        protected readonly RestClient _restClient;

        protected static readonly string TRAINING_PLAN_TEMPLATE = "trainingplantemplate";

        public BaseApiClient(RestClient restClient)
        {
            _restClient = restClient;
        }

        //protected readonly HttpClient _httpClient;
        //public BaseApiClient(HttpClient httpClient, string apiUrl, int version)
        //{
        //    // TODO
        //    _httpClient = httpClient;
        //    _httpClient.BaseAddress = new Uri(apiUrl + $"/api/v{version}/");
        //    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}
    }
}
