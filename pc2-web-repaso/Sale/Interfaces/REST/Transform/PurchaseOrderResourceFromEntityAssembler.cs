using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Interfaces.REST.Resources;

namespace pc2_web_repaso.Sale.Interfaces.REST.Transform;

public static class PurchaseOrderResourceFromEntityAssembler
{
    public static PurchaseOrderResource ToResourceFromEntity(PurchaseOrder entity)
    {
        return new PurchaseOrderResource(
            entity.Id,
            entity.Customer,
            (int)entity.FabricId,
            entity.City,
            entity.ResumeUrl,
            entity.Quantity
        );
    }
}