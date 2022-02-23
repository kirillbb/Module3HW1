using System.Collections;
using System.Collections.Generic;

namespace Module3HW1
{
    public class MyList<T> :IList<T>, IEnumerable<T> where T : IComparable<T>
    {
        public T[] list;

        public const int lenght = 10;
        private int currentLenght;
        private int lastIndex;
        public int CurrentLenght
        {
            get { return currentLenght; }
        }
        public int LastIndex
        {
            get
            { return lastIndex; }
        }

        public MyList()
        {
            currentLenght = lenght;
            list = new T[currentLenght];
            lastIndex = 0;
        }
        public MyList(T[] items)
        {
            currentLenght = items.Length;
            lastIndex = items.Length;
            list = items;
        }

        public void Add(T item)
        {
            if (ListIsFull())
            {
                currentLenght = currentLenght * 2;

                T[] newList = new T[currentLenght];

                for (int index = 0; index < list.Length; index++)
                {
                    newList[index] = list[index];
                }

                list = newList;
            }
            list[lastIndex++] = item;
        }
        public void AddRange(params T[] items)
        {
            foreach (var item in items)
            {
                if (ListIsFull())
                    Resize();
                Add(item);
            }
            
        }
        private void Resize()
        {
            int newLenght = list.Length + list.Length;
            T[] newList = new T[newLenght];

            for (int i = 0; i < list.Length; i++)
            {
                newList[i] = list[i];
            }
            currentLenght = newList.Length;
            list = newList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }

        public bool Remove(T item)
        {
            bool removed = false;
            T[] newList = new T[currentLenght];
            for (int i = 0, j = 0; i < currentLenght; i++)
            {
                if (list[i].Equals(item))
                {
                    removed = true;
                    lastIndex--;
                    continue;
                }
                newList[j] = list[i];
                j++;
            }
            list = newList;

            return removed;
        }
        public void RemoveAt(int index)
        {
            T[] newList = new T[currentLenght];
            index--; /////////////////////////////////
            for (int i = 0, j = 0; i < currentLenght; i++)
            {
                if (i.Equals(index))
                {
                    lastIndex--;
                    continue;
                }
                newList[j] = list[i];
                j++;
            }
            list = newList;
        }
        public void Sort()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length - 1; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        T item = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool ListIsFull()
        {
            if (lastIndex == list.Length)
                return true;
            return false;
        }
    
    }
}
