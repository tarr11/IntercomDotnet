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

        public dynamic Delete(object hash)
        {
            return Client.Execute("users", Method.DELETE, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Get(string email = null, int? user_id = null)
        {
            return Client.Execute("users", Method.GET, (request) =>
                {
                    if (email != null)
                        request.AddParameter("email", email);

                    if (user_id != null)
                        request.AddParameter("user_id", user_id.Value);
                });
        }

        public dynamic Get(int page = 1, int per_page = 500, string tag_id = null, string tag_name = null, string sort = null, string order = null)
        {
            return Client.Execute("users", Method.GET, (request) =>
                {
                    request.AddParameter("page", page);
                    request.AddParameter("per_page", per_page);

                    if (tag_id != null)
                        request.AddParameter("tag_id", tag_id);

                    if (tag_name != null)
                        request.AddParameter("tag_name", tag_name);

                    if (sort != null)
                        request.AddParameter("sort", sort);

                    if (order != null)
                        request.AddParameter("order", order);
                });
        }
    }
}
