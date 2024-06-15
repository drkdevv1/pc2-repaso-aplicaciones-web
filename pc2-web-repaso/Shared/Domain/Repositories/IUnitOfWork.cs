namespace pc2_web_repaso.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}