using System;
using System.Runtime.Serialization;

namespace Prolog.Exceptions
{
    [System.Serializable]
    public class PrologException : Exception
    {
        public PrologException() {}

        public PrologException(string message) : base(message) {}

        public PrologException(string message, Exception inner) : base(message, inner) {}

        protected PrologException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {}
    }
}