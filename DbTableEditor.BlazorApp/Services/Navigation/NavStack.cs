using System.Collections.Generic;

namespace DbTableEditor.BlazorApp.Services.Navigation
{
    public class NavStack
    {
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

        public string Pop()
        {
            return _stack.Pop();
        }
    }
}
