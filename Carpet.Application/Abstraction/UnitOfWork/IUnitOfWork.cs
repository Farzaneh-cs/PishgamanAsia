namespace Carpet.Application.Abstraction.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync();

}
