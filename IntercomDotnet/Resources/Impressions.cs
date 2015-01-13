using RestSharp;

namespace intercom_dotnet.Resources
{
    public class Impressions : Resource
    {
        public Impressions(Client client)
            : base(client)
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute("impressions", Method.POST, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }
    }
}
