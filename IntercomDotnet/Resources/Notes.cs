using RestSharp;

namespace IntercomDotNet.Resources
{
    public class Notes : Resource
    {
        public Notes(Client client) : base(client, "notes")
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Get(string email = null, int? userId = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
                {
                    if (email != null)
                        request.AddParameter("email", email);

                    if (userId != null)
                        request.AddParameter("user_id", userId.Value);
                });
        }

        public dynamic Get(int noteId)
        {
            return Client.Execute(BaseUrlWithId, Method.GET, request =>
                {
                    request.AddUrlSegment("id", noteId.ToString());
                });
        }
    }
}