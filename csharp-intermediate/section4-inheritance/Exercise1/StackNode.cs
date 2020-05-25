using System;

namespace Exercise1{
    class StackNode
    {
        public object Value { get; set; }
        public StackNode PreviousNode { get; set; }

        public StackNode(StackNode previousNode, object value)
        {
            this.PreviousNode = previousNode;
            this.Value = value;
        }
    }
}