using pc2_web_repaso.Sale.Domain.Model.Commands;
using pc2_web_repaso.Sale.Domain.Model.ValueObjects;

namespace pc2_web_repaso.Sale.Domain.Model.Aggregates;

public partial class PurchaseOrder: PurchaseOrderAudit
{
    public PurchaseOrder() {}
    
    public PurchaseOrder(string customer, string city, string resumeUrl, int quantity)
    {
        Customer = customer;
        City = city;
        ResumeUrl = resumeUrl;
        Quantity = quantity;
    }
    public PurchaseOrder(CreatePurchaseOrderCommand createPurchaseOrderCommand)
    {
        Customer = createPurchaseOrderCommand.Customer;
        City = createPurchaseOrderCommand.City;
        FabricId = (EFabric)createPurchaseOrderCommand.FabricId;
        ResumeUrl = createPurchaseOrderCommand.ResumeUrl;
        Quantity = createPurchaseOrderCommand.Quantity;
    }
    
    public new int Id { get; set; }
    public string? Customer { get; set; }
    
    public EFabric FabricId { get; set; }
    public string? City { get; set; }
    public string? ResumeUrl { get; set; }
    public int Quantity { get; set; }
}