using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Models.Models;

namespace ByteBank.AgencySystem.List
{
    public class CurrentAccountArrayList
    {
        private CurrentAcoount[] _items;

        public CurrentAccountArrayList()
        {
            _items = new CurrentAcoount[0];
        }

        public void Add(params CurrentAcoount[] items)
        {
            foreach (CurrentAcoount item in items)
                Add(item);    
        }

        public void Add(CurrentAcoount currentAcoount)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = currentAcoount;
        }

        public bool Remove(CurrentAcoount currentAcoount)
        {
            int index = GetIndex(currentAcoount);
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

        protected int GetIndex(CurrentAcoount currentAcoount)
        {
            int index = -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                    continue;
                else
                if (_items[i].Equals(currentAcoount))
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

        public CurrentAcoount GetByIndex(int index)
        {            
            if (index < 0 || index > _items.Length)
                throw new ArgumentException("Index is out of range", "CurrentAcoountArrayList.GetByIndex.index");
            return _items[index];
        }

        public CurrentAcoount this[int index]
        {
            get
            {
                try
                {
                    return GetByIndex(index);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Index is out of range", "CurrentAcoountArrayList.this.Indexer.index");
                }
               
            }
        }
    }
}
