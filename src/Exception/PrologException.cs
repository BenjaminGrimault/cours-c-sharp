using System.Runtime.Serialization;

namespace Prolog.Exception
{
    [System.Serializable]
    public class PrologException : System.Exception
    {
        public PrologException() {}

        public PrologException(string message) : base(message) {}

        public PrologException(string message, System.Exception inner) : base(message, inner) {}

        protected PrologException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {}
    }
}