using System;
using System.Collections.Generic;

namespace AD
{
    public class LRUCache<K, V> : ICache<K, V> where K : notnull where V : struct
    {
        protected int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Value should be greater than 0");
                }

                _capacity = value;
            }
        }

        protected Dictionary<K, V> _storage;
        protected LinkedList<K> _lru_info;

        public LRUCache(int capacity)
        {
            Capacity = capacity;

            _storage = new();
            _lru_info = new();
        }

        public V? Get(K key)
        {
            if (_storage.TryGetValue(key, out V value))
            {
                _lru_info.Remove(key);
                _lru_info.AddFirst(key);
                return value;
            }

            return null;
        }

        public void Set(K key, V value)
        {
            if (!_storage.ContainsKey(key) && _storage.Count >= _capacity)
            {
                _storage.Remove(_lru_info.Last!.Value);
                _lru_info.RemoveLast();
            }

            _storage[key] = value;

            _lru_info.Remove(key);
            _lru_info.AddFirst(key);
        }
    }
}
