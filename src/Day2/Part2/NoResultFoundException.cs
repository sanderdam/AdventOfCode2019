using System;
using System.Runtime.Serialization;

namespace Day2.Part2
{
    public class NoResultFoundException : ApplicationException
    {
        public NoResultFoundException()
        {
        }

        public NoResultFoundException(string message) : base(message)
        {
        }

        public NoResultFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoResultFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
