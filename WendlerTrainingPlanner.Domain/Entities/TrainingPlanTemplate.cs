namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class TrainingPlanTemplate : Entity<TrainingPlanTemplateId, TrainingPlanTemplateUniqueId>
    {
        // TODO: add a maxlength
        public string Name { get; private set; }
        public TrainingPlanTemplateTimeFrom From { get; }
        public int Cycles { get; }
        public TrainingMaxPercentage TrainingMaxPercentage { get; }
        public TrainingPlanTemplateType Type { get; }
        public IEnumerable<DayOfTrainingPlanTemplate> Days { get; }

        // public AppUser User {get; set;}
        // public AppUser? Trainer {get; set;}

        public TrainingPlanTemplate(
            string name,
            TrainingPlanTemplateTimeFrom from,
            TrainingMaxPercentage trainingMaxPercentage,
            TrainingPlanTemplateType type,
            int cycles,
            IEnumerable<DayOfTrainingPlanTemplate> dayOfTrainingPlanTemplates)
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
            Name = name;
            From = from;
            Cycles = cycles;
            TrainingMaxPercentage = trainingMaxPercentage;
            Type = type;
            Days = dayOfTrainingPlanTemplates;
        }

        protected TrainingPlanTemplate()
        {
            // TODO: check if Id also is needed here
            UniqueId = TrainingPlanTemplateUniqueId.NewUniqueId();
            Days = new List<DayOfTrainingPlanTemplate>(); // TODO ?? is it correct ?
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
