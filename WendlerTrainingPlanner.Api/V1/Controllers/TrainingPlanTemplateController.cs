namespace WendlerTrainingPlanner.Api.V1.Controllers.TrainingPlanTemplate
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using WendlerTrainingPlanner.Api.Contracts.BaseResponses;
    using WendlerTrainingPlanner.Api.Contracts.V1.Requests.TrainingPlanTemplate;
    using WendlerTrainingPlanner.Api.Contracts.V1.Responses.TrainingPlanTemplate;
    using WendlerTrainingPlanner.Api.Resources;
    using WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate;

    [ApiController, ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrainingPlanTemplateController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TrainingPlanTemplateController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [ProducesResponseType(typeof(ApiResponse<CreateTrainingPlanTemplateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingPlanTemplateRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateTrainingPlanTemplateCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);
            if (result is null)
            {
                return BadRequest(ApiGeneralResource.TrainingPlanTemplate_Create_Failed);
            }

            // TODO
            return Ok(new CreateTrainingPlanTemplateResponse());
        }
    }
}
