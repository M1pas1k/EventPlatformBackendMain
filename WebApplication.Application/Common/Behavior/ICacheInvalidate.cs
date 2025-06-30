namespace WebApplication.Application.Common.Behavior
{
    public interface ICacheInvalidate
    {
        public string[] CacheKeys { get; }
    }
}
