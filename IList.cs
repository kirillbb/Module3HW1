using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1
{
    public interface IList<T>
    {
        public void Add(T item);
        public void AddRange(params T[] items);
        public bool Remove(T item);
        public void RemoveAt(int index);
        public void Sort();
    }
}
