using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Domain.Model.Queries;
using pc2_web_repaso.Sale.Domain.Repositories;
using pc2_web_repaso.Sale.Domain.Services;


namespace pc2_web_repaso.Sale.Application.Internal.QueryServices; 

public class PurchaseOrderQueryService(IPurchaseOrderRepository purchaseOrderRepository) : IPurchaseOrderQueryService 
{ 
    public async Task<PurchaseOrder?> Handle(GetByCustomerAndFabricIdQuery query) 
    {
        return await purchaseOrderRepository.FindByCustomerAndFabricIdAsync(query.Customer, query.FabricId); 
    } 
}