namespace WebApplication.Domain.Enums
{
    [Flags]
    public enum EventStatus
    {
        Rejected,
        Approved,
        UnderModeration,
        Finished
    }
}
