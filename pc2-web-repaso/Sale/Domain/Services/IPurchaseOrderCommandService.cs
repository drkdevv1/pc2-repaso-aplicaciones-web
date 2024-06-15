using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Domain.Model.Commands;

namespace pc2_web_repaso.Sale.Domain.Services;

public interface IPurchaseOrderCommandService
{
    public Task<PurchaseOrder>Handle(CreatePurchaseOrderCommand command);
}