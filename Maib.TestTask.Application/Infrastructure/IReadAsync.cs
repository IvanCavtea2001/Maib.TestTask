namespace Maib.TestTask.Application.Infrastructure;

public interface IReadAsync<TResult, in TCriteria>
{
    Task<TResult> ReadAsync(TCriteria criteria, CancellationToken cancellationToken);
}