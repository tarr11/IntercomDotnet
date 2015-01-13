using System;

namespace intercom_dotnet.Resources
{
    public class Impressions : Resource
    {
        public Impressions(Client client) : base(client)
        {
        }

        public dynamic Post(object hash)
        {
            throw new NotSupportedException("MessageThreads has been deprecated as part of the v1 API support ending");
        }
    }
}
