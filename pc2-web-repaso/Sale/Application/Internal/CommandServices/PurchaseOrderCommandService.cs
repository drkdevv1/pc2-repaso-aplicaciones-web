using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pc2_web_repaso.Sale.Domain.Model.Commands;
using pc2_web_repaso.Sale.Domain.Repositories;
using pc2_web_repaso.Sale.Domain.Services;
using pc2_web_repaso.Shared.Domain.Repositories;
using pc2_web_repaso.Sale.Domain.Model.ValueObjects;

namespace pc2_web_repaso.Sale.Application.Internal.CommandServices
{
    public class PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork) : IPurchaseOrderCommandService
    {
        public async Task<PurchaseOrder> Handle(CreatePurchaseOrderCommand command)
        {
            var existingPurchaseOrder = await purchaseOrderRepository.FindByCustomerAndFabricIdAsync(command.Customer, command.FabricId);

            if (existingPurchaseOrder != null)
            {
                throw new Exception("A purchase order with the same customer and fabricId already exists.");
            }

            if (!Enum.IsDefined(typeof(EFabric), command.FabricId))
            {
                throw new Exception("Invalid fabricId. It must correspond to one of the 8 possibilities offered by Cotton Knit.");
            }

            var purchaseOrder = new PurchaseOrder(command);
            try
            {
                await purchaseOrderRepository.AddAsync(purchaseOrder);
                await unitOfWork.CompleteAsync();
                return purchaseOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the purchase order: {e.Message}");
                return null!;
            }
        }
    }
}