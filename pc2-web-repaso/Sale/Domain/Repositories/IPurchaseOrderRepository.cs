using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Shared.Domain.Repositories;

namespace pc2_web_repaso.Sale.Domain.Repositories;

public interface IPurchaseOrderRepository:IBaseRepository<PurchaseOrder>
{
    Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, int fabricId);
}