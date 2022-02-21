using System.Runtime.Serialization;

namespace PortugalSRBackend.Core.Common.Exceptions
{
    [Serializable]
    public class GlobalException : Exception
    {
        public GlobalException()
        {
        }
        public GlobalException(string message) : base(message)
        {

        }

        protected GlobalException(SerializationInfo info, StreamingContext context)
            : base(info, context)

        {
        }

        public GlobalException(string message, Exception innerException)
             : base(message, innerException)
        {
        }
    }
}
