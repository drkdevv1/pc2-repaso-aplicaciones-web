using pc2_web_repaso.Sale.Domain.Model.Commands;
using pc2_web_repaso.Sale.Interfaces.REST.Resources;

namespace pc2_web_repaso.Sale.Interfaces.REST.Transform;

public static class CreatePurchaseOrderCommandFromResourceAssembler
{
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource)
    {
        return new CreatePurchaseOrderCommand(
            resource.Customer,
            resource.FabricId,
            resource.City,
            resource.ResumeUrl,
            resource.Quantity
        );
    }
}