using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;

namespace WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate
{
    public record CreateTrainingPlanTemplateCommandResponse(IdsDto TrainingPlanTemplateIds) : BaseResponse;
}
