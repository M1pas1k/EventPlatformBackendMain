using StackExchange.Redis;
using System.Text.Json;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructure.Cache
{
    public class RedisCacheProvider(IConnectionMultiplexer connectionMultiplexer) : ICache
    {
        private readonly IDatabase _redis = connectionMultiplexer.GetDatabase();

        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetch, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            var fromCache = await ObjectGetAsync<T>(key, ct);
            if (fromCache is not null)
            {
                Console.WriteLine("Cache HIT");
                return fromCache;
            }
            Console.WriteLine("Cache MISS");

            var fromFetch = await fetch();
            await ObjectSetAsync(key, fromFetch, ct, expiry);
            return fromFetch;
        }

        public async Task<T> GetOrSetAsync<T>(string key, Func<T> fetch, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            return await GetOrSetAsync(key, () => Task.FromResult(fetch()), expiry, ct);
        }

        public async Task<string?> StringGetAsync(string key, CancellationToken ct)
        {
            ValidateKey(key);
            return await _redis.StringGetAsync(key).WaitAsync(ct);
        }

        public async Task StringSetAsync(string key, string value, CancellationToken ct, TimeSpan? expiry = null)
        {
            ValidateKey(key);
            await _redis.StringSetAsync(key, value, expiry).WaitAsync(ct);
        }

        public async Task BytesSetAsync(string key, byte[] value, CancellationToken ct, TimeSpan? expiry = null)
        {
            ValidateKey(key);
            await _redis.StringSetAsync(key, value, expiry).WaitAsync(ct);
        }

        public async Task<byte[]?> BytesGetAsync(string key, CancellationToken ct)
        {
            ValidateKey(key);
            return await _redis.StringGetAsync(key).WaitAsync(ct);
        }

        public async Task RemoveAsync(string key, CancellationToken ct)
        {
            ValidateKey(key);
            await _redis.KeyDeleteAsync(key).WaitAsync(ct);
        }

        public async Task<string[]> SetGetAsync(string setKey, CancellationToken ct)
        {
            ValidateKey(setKey);
            var values = await _redis.SetMembersAsync(setKey).WaitAsync(ct);
            return values.Select(v => v.ToString()).ToArray();
        }

        public async Task SetAddAsync(string setKey, string value, CancellationToken ct, TimeSpan? expiry = null)
        {
            ValidateKey(setKey);
            await _redis.SetAddAsync(setKey, value).WaitAsync(ct);

            if (expiry.HasValue)
            {
                await _redis.KeyExpireAsync(setKey, expiry).WaitAsync(ct);
            }
        }

        public async Task SetRemoveAsync(string setKey, string value, CancellationToken ct)
        {
            ValidateKey(setKey);
            await _redis.SetRemoveAsync(setKey, value).WaitAsync(ct);
        }

        public async Task ObjectSetAsync<T>(string key, T value, CancellationToken ct, TimeSpan? expiry = null)
        {
            ValidateKey(key);
            var json = JsonSerializer.Serialize(value);
            await StringSetAsync(key, json, ct, expiry);
        }

        public async Task<T?> ObjectGetAsync<T>(string key, CancellationToken ct)
        {
            ValidateKey(key);
            var json = await StringGetAsync(key, ct);
            return json != null ? JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) : default;
        }

        public async Task RemoveKeysMask(string mask)
        {
            var server = connectionMultiplexer.GetServer(connectionMultiplexer.GetEndPoints().First());
            var keys = server.Keys(pattern: mask).ToArray();

            if (keys.Length > 0)
            {
                await _redis.KeyDeleteAsync(keys);
            }
        }

        public async Task<long> SetLength(string key)
        {
            return await _redis.SetLengthAsync(key);
        }

        private static void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or whitespace", nameof(key));
            }
        }
    }

}
