namespace WendlerTrainingPlanner.Api.Middleware
{
    using System.Net;
    using System.Text.Json;
    using WendlerTrainingPlanner.Api.Responses;
    using WendlerTrainingPlanner.Application.CQRS.Exceptions;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Api.Resources;
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerService _loggerService; // TODO

        public ErrorHandlingMiddleware(RequestDelegate next/*, ILoggerService loggerService*/)
        {
            _next = next;
            //_loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            //_loggerService.LogError(httpContext, ex);

            var response = httpContext.Response;
            response.ContentType = "application/json";

            ApiResponse apiResponseResult = new BussinessLogicErrorApiResponse(ApiGeneralResource.Something_Went_Wrong);

            switch (ex)
            {
                case NotFoundException notFoundApiManagerException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    apiResponseResult = new NotFoundApiResponse(notFoundApiManagerException.Message);
                    break;
                case ManagerException apiManagerException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponseResult = new BussinessLogicErrorApiResponse(apiManagerException.Message);
                    break;
                // TODO
                //case NpgsqlException npgsqlException:
                //    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //    apiResponseResult = new BussinessLogicErrorApiResponse(npgsqlException.Message);
                //    break;
                case DomainException domainException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponseResult = new BussinessLogicErrorApiResponse(domainException.Message);
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiResponseResult = new BussinessLogicErrorApiResponse(ApiGeneralResource.Something_Went_Wrong);
                    break;
            }

            var result = JsonSerializer.Serialize(apiResponseResult);
            await response.WriteAsync(result);
        }
    }
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
