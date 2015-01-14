using System;

namespace intercom_dotnet.Resources
{
    public class Notes : Resource
    {
        public Notes(Client client) : base(client)
        {
        }

        public dynamic Post(object hash)
        {
            throw new NotImplementedException("Tags has not been converted to V2 API format yet");
        }
    }
}