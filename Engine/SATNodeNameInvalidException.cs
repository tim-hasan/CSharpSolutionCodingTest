using System;

namespace Engine
{
    public class SATNodeNameInvalidException :Exception
    {
        public SATNodeNameInvalidException() : base() { }
            public SATNodeNameInvalidException(string message) : base(message) { }
            public SATNodeNameInvalidException(string message, Exception inner) : base(message, inner) { }
        }
}