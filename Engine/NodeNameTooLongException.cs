using System;

namespace Engine
{
    public class NodeNameTooLongException : Exception
    {
        public NodeNameTooLongException() : base() { }
        public NodeNameTooLongException(string message) : base(message) { }
        public NodeNameTooLongException(string message, Exception inner) : base(message, inner) { }
 
    }
}