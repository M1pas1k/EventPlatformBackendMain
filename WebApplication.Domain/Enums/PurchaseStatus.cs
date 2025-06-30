namespace WebApplication.Domain.Enums
{
    [Flags]
    public enum PurchaseStatus
    {
        Pending,
        Success,
        Cancelled,
    }
}
