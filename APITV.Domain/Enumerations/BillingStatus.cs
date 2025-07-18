using System.ComponentModel;

namespace APITV.Domain.Enumerations;

public enum BillingStatus
{
    [Description("Pendiente")]
    Pending = 1,

    [Description("Pagado")]
    Paid = 2,

    [Description("Adeudo")]
    Debt = 3,

    [Description("Atrasado")]
    Overdue = 4,

    [Description("Cancelado")]
    Canceled = 5,
}