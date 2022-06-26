namespace WendlerTrainingPlanner.Infrastructure.EF
{
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Infrastructure.EF.EntityConfigurations;

    // TODO: implement mediator here
    public class WendlerTrainingPlannerDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "wendler-training-planner";

        private IDbContextTransaction? _currentTransaction; 

        // DBSets
        public DbSet<MainExercise> MainExercises { get; set; }

        // Properties
        public bool HasActiveTransaction => _currentTransaction != null;

        // Constructor
        public WendlerTrainingPlannerDbContext(DbContextOptions<WendlerTrainingPlannerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MainExerciseConfiguration());
        }

        // Public methods
        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}
