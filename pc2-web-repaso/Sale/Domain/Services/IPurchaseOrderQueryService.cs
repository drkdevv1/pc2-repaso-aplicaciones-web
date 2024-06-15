using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Domain.Model.Queries;

namespace pc2_web_repaso.Sale.Domain.Services;

public interface IPurchaseOrderQueryService
{
    Task<PurchaseOrder?> Handle(GetByCustomerAndFabricIdQuery query);
}