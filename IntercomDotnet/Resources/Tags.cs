using System;

namespace intercom_dotnet.Resources
{
    public class Tags : Resource
    {
        public Tags(Client client) : base(client)
        {
        }

        public dynamic Get(string name)
        {
            throw new NotImplementedException("Tags has not been converted to V2 API format yet");
        }

        public dynamic Post(object hash)
        {
            throw new NotImplementedException("Tags has not been converted to V2 API format yet");
        }

        public dynamic Delete(int id)
        {
            throw new NotImplementedException("Tags has not been converted to V2 API format yet");
        }
    }
}
