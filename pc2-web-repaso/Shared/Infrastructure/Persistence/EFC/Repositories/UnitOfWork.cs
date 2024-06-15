using pc2_web_repaso.Shared.Domain.Repositories;
using pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}