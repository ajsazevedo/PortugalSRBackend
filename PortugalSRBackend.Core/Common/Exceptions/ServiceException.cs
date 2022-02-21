using System.Runtime.Serialization;

namespace PortugalSRBackend.Core.Common.Exceptions
{
    [Serializable]
    public class ServiceException : GlobalException
    {
        public string FriendlyMessage { get; set; }
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
            FriendlyMessage = message;
        }

        public ServiceException(string message, string friendlyMessage) : base(message)
        {
            FriendlyMessage = friendlyMessage;
        }

        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)

        {
        }

        public ServiceException(string message, Exception innerException)
             : base(message, innerException)
        {
            FriendlyMessage = message;
        }
    }
}
