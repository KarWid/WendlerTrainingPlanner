namespace WendlerTrainingPlanner.Api.Client
{
    using RestSharp;

    public abstract class BaseApiClient
    {
        protected readonly RestClient _restClient;

        protected static readonly string TRAINING_PLAN_TEMPLATE = "trainingplantemplate";

        // TODO: I am not sure about this solution, I mean, does rest client should be created by a user ?
        // Probably no, and the url should be taken from Configuration, but I am not sure
        // It depends on requirements in my opinion. I think that for "tool" purposes it is good enough 
        public BaseApiClient(RestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
