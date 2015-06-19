using System;

namespace IntercomDotNet.Resources
{
    public class Tags : Resource
    {
        public Tags(Client client) : base(client)
        {
        }

        public dynamic Get(string name)
        {
            throw new NotImplementedException("Tags have not been converted to V2 API format yet");
        }

        public dynamic Post(object hash)
        {
            throw new NotImplementedException("Tags have not been converted to V2 API format yet");
        }

        public dynamic Delete(int id)
        {
            throw new NotImplementedException("Tags have not been converted to V2 API format yet");
        }
    }
}
