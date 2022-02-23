using System.Collections;

namespace Module3HW1
{
    public class MyList<T> : IList<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        public const int Lenght = 10;
        private T[] _list;

        private int _currentLenght;
        private int _lastIndex;
        public MyList()
        {
            _currentLenght = Lenght;
            _list = new T[_currentLenght];
            _lastIndex = 0;
        }

        public MyList(T[] items)
        {
            _currentLenght = items.Length;
            _lastIndex = items.Length;
            _list = items;
        }

        public int CurrentLenght
        {
            get
            {
                return _currentLenght;
            }
        }

        public int LastIndex
        {
            get
            {
                return _lastIndex;
            }
        }

        public void Add(T item)
        {
            if (ListIsFull())
            {
                _currentLenght = _currentLenght * 2;

                T[] newList = new T[_currentLenght];

                for (int index = 0; index < _list.Length; index++)
                {
                    newList[index] = _list[index];
                }

                _list = newList;
            }

            _list[_lastIndex++] = item;
        }

        public void AddRange(params T[] items)
        {
            foreach (var item in items)
            {
                if (ListIsFull())
                {
                    Resize();
                }

                Add(item);
            }
        }

        public void Resize()
        {
            int newLenght = _list.Length + _list.Length;
            T[] newList = new T[newLenght];

            for (int i = 0; i < _list.Length; i++)
            {
                newList[i] = _list[i];
            }

            _currentLenght = newList.Length;
            _list = newList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _list.Length; i++)
            {
                yield return _list[i];
            }
        }

        public bool Remove(T item)
        {
            bool removed = false;
            T[] newList = new T[_currentLenght];

            for (int i = 0, j = 0; i < _currentLenght; i++)
            {
                if (_list[i].Equals(item))
                {
                    removed = true;
                    _lastIndex--;
                    continue;
                }

                newList[j] = _list[i];
                j++;
            }

            _list = newList;

            return removed;
        }

        public void RemoveAt(int index)
        {
            T[] newList = new T[_currentLenght];
            index--; /////////////////////////////////
            for (int i = 0, j = 0; i < _currentLenght; i++)
            {
                if (i.Equals(index))
                {
                    _lastIndex--;
                    continue;
                }

                newList[j] = _list[i];
                j++;
            }

            _list = newList;
        }

        public void Sort()
        {
            for (int i = 0; i < _list.Length; i++)
            {
                for (int j = 0; j < _list.Length - 1; j++)
                {
                    if (_list[j].CompareTo(_list[j + 1]) > 0)
                    {
                        T item = _list[j];
                        _list[j] = _list[j + 1];
                        _list[j + 1] = item;
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
            if (_lastIndex == _list.Length)
            {
                return true;
            }

            return false;
        }
    }
}
