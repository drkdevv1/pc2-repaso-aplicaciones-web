using Microsoft.EntityFrameworkCore;
using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Domain.Model.ValueObjects;
using pc2_web_repaso.Sale.Domain.Repositories;
using pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc2_web_repaso.Sale.Infrastructure.Persistence.EFC.Repositories;

public class PurchaseOrderRepository(AppDbContext context) : BaseRepository<PurchaseOrder>(context), IPurchaseOrderRepository
{
    public Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, int fabricId)
    {
        var fabric = (EFabric)fabricId;
        return Context.Set<PurchaseOrder>().Where(p => p.Customer == customer && p.FabricId == fabric).FirstOrDefaultAsync();
    }
}