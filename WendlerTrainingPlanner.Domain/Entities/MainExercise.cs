namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    /// <summary>
    /// It is not a value object because it has an identity.
    /// </summary>
    public class MainExercise : BaseEntity<MainExerciseId>
    {
        private string _name;

        public MainExercise(string name) 
        {
            if (string.IsNullOrEmpty(name)) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Name");

            _name = name;
        }
    }
}
