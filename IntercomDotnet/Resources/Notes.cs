using System;

namespace IntercomDotNet.Resources
{
    public class Notes : Resource
    {
        public Notes(Client client, string baseUrl) : base(client, baseUrl)
        {
        }

        public dynamic Post(object hash)
        {
            throw new NotImplementedException("Notes have not been converted to V2 API format yet");
        }
    }
}