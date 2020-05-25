using System;

namespace Exercise1
{
    class Stack
    {
        private StackNode _bottom;
        private StackNode _last;

        public Stack()
        {
            _bottom = new StackNode(null,null);
            _last = _bottom;
        }

        public void Push(object obj)
        {
            if (obj == null)
            {
                throw new InvalidOperationException("Tried to push a 'null' object.");
            }
            var newNode = new StackNode(_last,obj);
            _last = newNode;
        }

        public object Pop()
        {
            if (_last.PreviousNode == null)
            {
                //_last == _bottom
                throw new InvalidOperationException("Tried to pop an empty stack.");
            }

            object poppedValue = _last.Value;
            _last = _last.PreviousNode;
            return poppedValue;
        }

//Print will be very useful for debugging
        public void Print()
        {
            System.Console.WriteLine("=====");
            var currentNode = _last;
            while (currentNode.PreviousNode != null)
            {
                System.Console.WriteLine(currentNode.Value);
                currentNode = currentNode.PreviousNode;
            }
            System.Console.WriteLine("<BOTTOM>");
            System.Console.WriteLine("=====");
        }
    }
}