namespace WebApplication.Application.Interfaces
{
    public interface ICache
    {
        Task<byte[]?> BytesGetAsync(string key, CancellationToken ct);
        Task BytesSetAsync(string key, byte[] value, CancellationToken ct, TimeSpan? expiry = null);
        Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetch, TimeSpan? expiry = null, CancellationToken ct = default);
        Task<T> GetOrSetAsync<T>(string key, Func<T> fetch, TimeSpan? expiry = null, CancellationToken ct = default);
        Task RemoveKeysMask(string mask);
        Task<T?> ObjectGetAsync<T>(string key, CancellationToken ct);
        Task ObjectSetAsync<T>(string key, T value, CancellationToken ct, TimeSpan? expiry = null);
        Task RemoveAsync(string key, CancellationToken ct);
        Task SetAddAsync(string setKey, string value, CancellationToken ct, TimeSpan? expiry = null);
        Task<string[]> SetGetAsync(string setKey, CancellationToken ct);
        Task SetRemoveAsync(string setKey, string value, CancellationToken ct);
        Task<string?> StringGetAsync(string key, CancellationToken ct);
        Task StringSetAsync(string key, string value, CancellationToken ct, TimeSpan? expiry = null);
        Task<long> SetLength(string key);
    }
}
