using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMicro.Entities
{
    public class FieldCollection : IDictionary<string, object>
    {
        private Dictionary<string, object> Fields;
        public FieldCollection()
        {
            Fields = new Dictionary<string, object>();
        }
        public object this[string key]
        {
            get => Fields[key];
            set
            {
                if (!Fields.ContainsKey(key))
                    Fields.Add(key, value);
                else
                    Fields[key] = value;
            }
        }

        public ICollection<string> Keys => Fields.Keys;

        public ICollection<object> Values => Fields.Values;

        public int Count => Fields.Count;

        public bool IsReadOnly => true;

        public void Add(string key, object value)
        {
            if (Fields.ContainsKey(key))
                Fields[key] = value;
            else
                Fields.Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Fields.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return Fields.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return Fields.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return Fields.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return Fields.Remove(key);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return Fields.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
