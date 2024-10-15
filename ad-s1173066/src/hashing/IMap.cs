namespace AD.Hashing;

public interface IMap<K, V>
{
    public void Set(K k, V v);
    public V Get(K k);
    public bool Contains(K key);
}
