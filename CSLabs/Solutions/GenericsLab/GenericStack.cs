using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsLab
{
    public class GenericStack<T>
    {
        int _CurrentStackPos = 0;
        int _StackSize = 0;
        T[] _StackItems = null;

        public GenericStack()
        {
            _StackSize = 50;
            _StackItems = new T[_StackSize];
        }

        public void Push(T item)
        {
            if (_CurrentStackPos >= _StackSize)
                throw new StackOverflowException();
            _StackItems[_CurrentStackPos] = item;
            _CurrentStackPos++;
        }

        public T Pop()
        {
            _CurrentStackPos--;
            if (_CurrentStackPos >= 0)
            {
                return _StackItems[_CurrentStackPos];
            }
            else
            {
                _CurrentStackPos = 0;
                return default(T);
            }
        }
    }
}
