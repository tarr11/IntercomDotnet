using System;

namespace intercom_dotnet.Resources
{
    [Obsolete]
    public class MessageThreads : Resource
    {
        public MessageThreads(Client client) : base(client)
        {
        }

        public dynamic Get(int? userId = null, string email = null, int? threadId = null, string currentUrl = null)
        {
            throw new NotSupportedException("MessageThreads has been deprecated as part of the v1 API support ending");
        }

        public dynamic Post(object hash)
        {
            throw new NotSupportedException("MessageThreads has been deprecated as part of the v1 API support ending");
        }

        public dynamic Put(object hash)
        {
            throw new NotSupportedException("MessageThreads has been deprecated as part of the v1 API support ending");
        }
    }
}
