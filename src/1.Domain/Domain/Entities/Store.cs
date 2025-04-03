using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities;
public class Store : Entity
{
    public int MapNumber { get; set; }

    public int RegistrationNumber { get; set; }

    public decimal MapMeterage { get; set; }

    public decimal RegisteredMeterage { get; set; }

    public int PostalCode { get; set; }

    public int Code { get; set; }

    public string Owner { get; set; } = string.Empty;

    public string OwnerPhoneNumber { get; set; } = string.Empty;

    public PossessionState PossessionState { get; set; }

    public FloorNumber FloorNumber { get; set; }

    public DateTime PossessionDate { get; set; }

    public string SaleContractNumber { get; set; } = string.Empty;
}
