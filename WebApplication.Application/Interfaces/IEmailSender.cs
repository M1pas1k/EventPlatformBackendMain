namespace WebApplication.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(IEnumerable<string> emails, string subject, string content, CancellationToken ct);
        Task SendAsync(string email, string subject, string content, CancellationToken ct);
    }
}
