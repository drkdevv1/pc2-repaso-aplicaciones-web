namespace pc2_web_repaso.Sale.Interfaces.REST.Resources;

public record PurchaseOrderResource(int Id,string? Customer, int FabricId, string? City, string? ResumeUrl, int Quantity);