using System.Collections.Generic;

namespace DbTableEditor.BlazorApp.Services.Navigation
{
    public class NavStack
    {
        public int Size => _stack.Count;

        private readonly Stack<string> _stack = new Stack<string>();

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public void Add(string address)
        {
            _stack.Push(address);
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                _stack.Pop();
            }
        }
        
        public string Top()
        {
            return IsEmpty() ? null : _stack.Peek();
        }
    }
}
