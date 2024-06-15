using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc2_web_repaso.Sale.Domain.Model.Aggregates;

public partial class PurchaseOrderAudit: IEntityWithCreatedUpdatedDate
{
    [Key]
    public int Id { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}