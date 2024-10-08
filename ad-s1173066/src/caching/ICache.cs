using System;

namespace AD
{
    public interface ICache<K, V> where K : notnull where V : struct
    {
        public V? Get(K key);
        public void Set(K key, V value);
    }

    public static class Caching
    {
        public static Func<K, V> MakeCached<K, V>(Func<K, V> function, ICache<K, V> cache) where K : notnull where V : struct
        {
            return (K key) =>
            {
                V? result = cache.Get(key);
                if (result.HasValue)
                {
                    return result.Value;
                }

                result = function(key);
                cache.Set(key, result.Value);
                return result.Value;
            };
        }
    }
}
