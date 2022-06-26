namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class TrainingPlanTemplateType : BaseEntity<TrainingPlanTemplateTypeId>
    {
        private string _name;
        private bool _isLeader;

        public bool IsLeader => _isLeader;

        public TrainingPlanTemplateType(string name, bool isLeader)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainArgumentException(DomainResource.ArgumentNotValid, nameof(name));

            _name = name;
            _isLeader = isLeader;
        }
    }
}
