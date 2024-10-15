namespace AD.Hashing;

public interface IMap<K, V>
{
    public void Set(K k, V v);
    public V Get(K k);
    public bool Contains(K key);

    public V this[K key]
    {
        get => Get(key);
        set => Set(key, value);
    }

    public int Count();
    public int Capacity();
}
