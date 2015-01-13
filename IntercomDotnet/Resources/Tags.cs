using RestSharp;

namespace intercom_dotnet.Resources
{
    public class Tags : Resource
    {
        public Tags(Client client)
            : base(client)
        {
        }

        public dynamic Get(string name)
        {
            return Client.Execute("tags", Method.GET, (request) => request.AddParameter("name", name));
        }

        public dynamic Post(object hash)
        {
            return Client.Execute("tags", Method.POST, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Put(object hash)
        {
            return Client.Execute("tags", Method.PUT, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }
    }
}
