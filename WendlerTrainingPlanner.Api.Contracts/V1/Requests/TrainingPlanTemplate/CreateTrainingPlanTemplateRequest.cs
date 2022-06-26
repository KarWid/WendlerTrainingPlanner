namespace WendlerTrainingPlanner.Api.Contracts.V1.Requests.TrainingPlanTemplate
{
    using WendlerTrainingPlanner.Api.Contracts.Dtos;

    public record CreateTrainingPlanTemplateRequest(
        string Name, 
        DateTime From, 
        int Cycles, 
        float TrainingMaxPercentage, 
        int TrainingPlanTemplateTypeId, 
        IList<DayOfTrainingPlanTemplateDto> Days);
}
