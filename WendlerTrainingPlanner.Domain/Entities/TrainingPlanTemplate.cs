namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Enums;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class TrainingPlanTemplate : Entity<TrainingPlanTemplateId, TrainingPlanTemplateUniqueId>
    {
        private string _name;
        private TrainingPlanTemplateTimeFrom _from;
        private int _cycles;
        private TrainingMaxPercentage _trainingMaxPercentage;
        private TrainingPlanTemplateType _type;

        private readonly List<DayOfTrainingPlanTemplate> _days;
        public IReadOnlyCollection<DayOfTrainingPlanTemplate> Days => _days;

        public string Name => _name;
        public TrainingPlanTemplateTimeFrom From => _from;
        public int Cycles => _cycles;
        public TrainingMaxPercentage TrainingMaxPercentage => _trainingMaxPercentage;
        public TrainingPlanTemplateType Type => _type;

        public TrainingPlanTemplate(
            string name,
            TrainingPlanTemplateTimeFrom from,
            TrainingMaxPercentage trainingMaxPercentage,
            TrainingPlanTemplateType type,
            int cycles,
            List<DayOfTrainingPlanTemplate> dayOfTrainingPlanTemplates)
        {
            int maxDays = 7;

            if (dayOfTrainingPlanTemplates == null || !dayOfTrainingPlanTemplates.Any())
            {
                throw new DomainArgumentException(DomainResource.TrainingPlanTemplateDaysNotDefined);
            }

            if (dayOfTrainingPlanTemplates.Count() > maxDays)
            {
                throw new DomainArgumentException(DomainResource.TrainingPlanTemplateDaysNumberNotValid, UniqueId, maxDays);
            }

            if (string.IsNullOrEmpty(name)) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Name");
            if (from is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "From");

            ValidatedCyclesNumber(type, cycles);

            UniqueId = TrainingPlanTemplateUniqueId.NewUniqueId();
            Version = 0;
            _name = name;
            _from = from;
            _cycles = cycles;
            _trainingMaxPercentage = trainingMaxPercentage;
            _type = type;
            _days = dayOfTrainingPlanTemplates;
        }

        //protected TrainingPlanTemplate()
        //{
        //    // TODO: check if Id also is needed here
        //    UniqueId = TrainingPlanTemplateUniqueId.NewUniqueId();
        //    Version = 0;
        //    Days = new List<DayOfTrainingPlanTemplate>(); // TODO ?? is it correct ?
        //}

        public TrainingPlanTemplateIds Ids()
        {
            if (this.Id is null)
            {
                return new TrainingPlanTemplateIds
                {
                    UniqueId = this.UniqueId,
                    CreatedId = this.Id,
                    Status = IdsStatus.CantReturnCreatedIdWhenYouAreEventSourcing
                };
            }

            return new TrainingPlanTemplateIds()
            {
                UniqueId = this.UniqueId,
                CreatedId = this.Id
            };
        }

        private void ValidatedCyclesNumber(TrainingPlanTemplateType type, int cycles)
        {
            if (type.IsLeader)
            {
                if (cycles != 2 && cycles != 3)
                {
                    throw new DomainArgumentException(DomainResource.TrainingPlanTemplateLeaderCyclesInvalid);
                }

                return;
            }

            if (cycles < 1 || cycles > 2)
            {
                throw new DomainArgumentException(DomainResource.TrainingPlanTemplateAnchorCyclesInvalid);
            }
        }
    }
}
