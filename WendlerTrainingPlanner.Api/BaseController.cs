namespace WendlerTrainingPlanner.Api
{
    using Microsoft.AspNetCore.Mvc;
    using WendlerTrainingPlanner.Api.Responses;

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected OkObjectResult Ok<T>(T value) where T : class
        {
            return base.Ok(new SuccessApiResponse<T>(value));
        }
    }
}
