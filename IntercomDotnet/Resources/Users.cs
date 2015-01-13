using RestSharp;

namespace intercom_dotnet.Resources
{
    public class Users : Resource
    {
        public Users(Client client) : base(client)
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute("users", Method.POST, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Put(object hash)
        {
            return Client.Execute("users", Method.PUT, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Delete(object hash)
        {
            return Client.Execute("users", Method.DELETE, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Get(string email = null, int? user_id = null, int? page = 1, int per_page = 500,
                           string tag_id = null, string tag_name = null)
        {
            return Client.Execute("users", Method.GET, (request) =>
                {
                    if (email != null)
                        request.AddParameter("email", email);

                    if (user_id != null)
                        request.AddParameter("user_id", user_id.Value);

                    if (page != null)
                        request.AddParameter("page", page);

                    if (per_page != null)
                        request.AddParameter("per_page", per_page);

                    if (tag_id != null)
                        request.AddParameter("tag_id", tag_id);

                    if (tag_name != null)
                        request.AddParameter("tag_name", tag_name);
                });
        }
    }
}
