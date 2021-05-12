using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Models.Models;

namespace ByteBank.AgencySystem.List
{
    public class ObjectList
    {
        private Object[] _items;

        public ObjectList()
        {
            _items = new Object[0];
        }

        public void Add(params Object[] items)
        {
            foreach (Object item in items)
                Add(item);
        }

        public void Add(Object obj)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = obj;
        }

        public bool Remove(Object obj)
        {
            int index = GetIndex(obj);
            if (index != -1)
            {
                _items[index] = null;
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

        protected int GetIndex(Object obj)
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
                Console.WriteLine($" Index: {i}, Objeto: {_items[i].ToString()}");
        }

        public Object GetByIndex(int index)
        {
            if (index < 0 || index > _items.Length)
                throw new ArgumentException("Index is out of range", "ObjectList.GetByIndex.index");
            return _items[index];
        }

        public Object this[int index]
        {
            get
            {
                try
                {
                    return GetByIndex(index);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Index is out of range", "ObjectList.this.Indexer.index");
                }

            }
        }
    }
}
