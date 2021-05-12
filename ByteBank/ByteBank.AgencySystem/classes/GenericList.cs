using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem.Lists
{
    public class GenericList<T>
    {
        private T[] _items;

        public GenericList()
        {
            _items = new T[0];
        }

        public void Add(params T[] items)
        {
            foreach (T item in items)
                Add(item);
        }

        public void Add(T obj)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = obj;
        }

        public bool Remove(T obj)
        {
            int index = GetIndex(obj);
            if (index != -1)
            {
                _items[index] = default(T);
                for (int i = index; index < (_items.Length - index); i++)
                {
                    if (i == _items.Length - 1)
                        break;
                    _items[i] = _items[i + 1];
                }
                Array.Resize(ref _items, _items.Length - 1);
                return true;
            }
            return false;
        }

        protected int GetIndex(T obj)
        {
            int index = -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                    continue;
                else
                if (_items[i].Equals(obj))
                    return i;
            }
            return index;
        }

        public int Count()
        {
            return _items.Length;
        }

        public void ListAll()
        {
            for (int i = 0; i < _items.Length; i++)
                Console.WriteLine($" Index: {i}, Object: {_items[i].ToString()}");
        }

        public T GetByIndex(int index)
        {
            if (index < 0 || index > _items.Length)
                throw new ArgumentException("Index is out of range", this.GetType() + ".GetByIndex.index");
            return _items[index];
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    return GetByIndex(index);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Index is out of range", this.GetType()  + ".Indexer.index");
                }

            }
        }
    }
}
