namespace WendlerTrainingPlanner.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task UpdateByUniqueIdAsync(T entity);

        Task UpdateByIdAsync(T entity);
    }
}
