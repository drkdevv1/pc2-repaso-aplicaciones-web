using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pc2_web_repaso.Sale.Domain.Model.Commands;
using pc2_web_repaso.Sale.Domain.Services;
using pc2_web_repaso.Sale.Interfaces.REST.Resources;
using pc2_web_repaso.Sale.Interfaces.REST.Transform;

namespace pc2_web_repaso.Sale.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PurchaseOrderController(
        IPurchaseOrderCommandService purchaseOrderCommandService,
        IPurchaseOrderQueryService purchaseOrderQueryService)
        : ControllerBase
    {
        private readonly IPurchaseOrderQueryService _purchaseOrderQueryService = purchaseOrderQueryService;

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(CreatePurchaseOrderResource resource)
        {
            var createPurchaseOrderCommand = CreatePurchaseOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var purchaseOrder = await purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
            if (purchaseOrder is null) return BadRequest();
            var purchaseOrderResource = PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity(purchaseOrder);
            return Created("", purchaseOrderResource);
        }
    }
}