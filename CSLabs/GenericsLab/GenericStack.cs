using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsLab
{
    public class GenericStack
    {
        int _CurrentStackPos = 0;
        int _StackSize = 0;
        object[] _StackItems = null;

        public GenericStack()
        {
            _StackSize = 50;
            _StackItems = new object[_StackSize];
        }

        public void Push(object item)
        {
            if (_CurrentStackPos >= _StackSize)
                throw new StackOverflowException();
            _StackItems[_CurrentStackPos] = item;
            _CurrentStackPos++;
        }

        public object Pop()
        {
            _CurrentStackPos--;
            if (_CurrentStackPos >= 0)
            {
                return _StackItems[_CurrentStackPos];
            }
            else
            {
                _CurrentStackPos = 0;
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}
