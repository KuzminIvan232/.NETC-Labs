using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{

    public class ExtendedDictionaryElement<T, U, V>
    {
        public T Key { get; set; }
        public U Value1 { get; set; }
        public V Value2 { get; set; }

        public ExtendedDictionaryElement(T key, U v1, V v2)
        {
            Key = key;
            Value1 = v1;
            Value2 = v2;
        }
    }

    public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    {
        private List<ExtendedDictionaryElement<T, U, V>> _items = new List<ExtendedDictionaryElement<T, U, V>>();

        public int Count => _items.Count;

        public void Add(T key, U v1, V v2)
        {
            if (ContainsKey(key)) throw new ArgumentException("Ключ вже існує!");
            _items.Add(new ExtendedDictionaryElement<T, U, V>(key, v1, v2));
        }

        public bool Remove(T key)
        {
            var item = _items.Find(x => x.Key.Equals(key));
            return _items.Remove(item);
        }

        public bool ContainsKey(T key) => _items.Exists(x => x.Key.Equals(key));

        public bool ContainsValue(object value)
        {
            return _items.Exists(x => x.Value1.Equals(value) || x.Value2.Equals(value));
        }

        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get
            {
                var item = _items.Find(x => x.Key.Equals(key));
                if (item == null) throw new KeyNotFoundException();
                return item;
            }
        }

        public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}