namespace pc2_web_repaso.Sale.Domain.Model.Commands;

public record CreatePurchaseOrderCommand(string Customer, int FabricId, string City, string ResumeUrl, int Quantity);