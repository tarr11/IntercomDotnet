using System;

namespace intercom_dotnet.Resources
{
    public class MessageThreads : Resource
    {
        public MessageThreads(Client client) : base(client)
        {
        }

        public dynamic Get(int? user_id = null, string email = null, int? thread_id = null, string current_url = null)
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
