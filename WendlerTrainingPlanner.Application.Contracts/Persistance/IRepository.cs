namespace WendlerTrainingPlanner.Application.Contracts.Persistance
{
    using System.Linq.Expressions;

    public interface IRepository
    {
        /// <summary>
        /// Creates 
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Creates new entity object in the storage.</param>
        void Create<TEntity>(TEntity entity);

        /// <summary>
        /// Commits all changes in one transaction.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="filter">Filter expression for specific entity type.</param>
        /// <returns>Returns a query against a specific data source wherein the type of the data is known.</returns>
        IQueryable<TEntity> FilterBy<TEntity>(Expression<Func<TEntity, bool>> filter);
    }
}
