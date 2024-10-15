using System.Collections.Generic;

namespace AD.Hashing;

public class Map<K, V> : IMap<K, V>
{
    protected K[] keys;
    protected V[] values;
    protected bool[] occupied;

    private const int INITIAL_SIZE = 5;

    protected int size;

    public Map(int initialSize = INITIAL_SIZE)
    {
        keys = new K[initialSize];
        values = new V[initialSize];
        occupied = new bool[initialSize];
        size = 0;
    }

    protected bool IsFull()
    {
        return size >= keys.Length;
    }

    public void Set(K key, V value)
    {
        int hashCode = key.GetHashCode();
        int index = hashCode % keys.Length;

        while (occupied[index])
        {
            if (keys[index].Equals(key))
            {
                values[index] = value;
                return;
            }

            index++;
            index %= keys.Length;
        }

        keys[index] = key;
        values[index] = value;
        occupied[index] = true;
        size++;

        if (IsFull())
        {
            Resize();
        }
    }

    public V Get(K key)
    {
        int hashCode = key.GetHashCode();
        int index = hashCode % keys.Length;

        while (occupied[index])
        {
            if (keys[index].Equals(key))
            {
                return values[index];
            }

            index++;
            index %= keys.Length;
        }

        throw new KeyNotFoundException();
    }

    public bool Contains(K key)
    {
        int hashCode = key.GetHashCode();
        int index = hashCode % keys.Length;

        while (occupied[index])
        {
            if (keys[index].Equals(key))
            {
                return true;
            }

            index++;
            index %= keys.Length;
        }

        return false;
    }

    protected void Resize()
    {
        int newSize = NextPrime(keys.Length * 2);

        Map<K, V> map = new(newSize);
        for (int i = 0; i < keys.Length; i++)
        {
            K key = keys[i];
            V value = values[i];

            map.Set(key, value);
        }

        keys = map.keys;
        values = map.values;
        occupied = map.occupied;
    }

    public static int NextPrime(int n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                n++;
                i = 2;
            }
        }

        return n;
    }
}
